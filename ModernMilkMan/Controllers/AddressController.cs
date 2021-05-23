using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ModernMilkMan.Entities;
using ModernMilkMan.Model;
using ModernMilkMan.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModernMilkMan.Controllers
{
    [ApiController]
    [Route("api/customer/{customerId}/addresses")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepo _addressRepo;
        private readonly IMapper _mapper;

        public AddressController(IAddressRepo addressRepo,
            IMapper mapper)
        {
            _addressRepo = addressRepo;
            _mapper = mapper;
        }

        [HttpGet("{addressId}", Name = "GetAddressForUser")]
        public ActionResult<IEnumerable<AddressDTO>> GetAddressForUser(int customerId,int addressId)
        {
            
            var addressForCustomerFromRepo = _addressRepo.GetAddress(customerId, addressId);
            return Ok(_mapper.Map<AddressDTO>(addressForCustomerFromRepo));
        }

        [HttpPost]
        public ActionResult<AddressDTO> CreateAddressForUser(AddressForCreationDTO addressForCreationDTO, int customerId)
        {
            var hasMainAddress = _addressRepo.HasMainAddress(customerId);
            var addressEntity = _mapper.Map<Address>(addressForCreationDTO);
            addressEntity.DateCreated = DateTime.Now;
            if (hasMainAddress && addressEntity.IsMainAddress == true)
            {
               return BadRequest("the user already has a main address.");
            }
            else
            {
                if (addressEntity.Country == "")
                {
                    addressEntity.Country = "UK";
                }
                _addressRepo.AddAddress(customerId, addressEntity);
                _addressRepo.Save();

                var addressToReturn = _mapper.Map<AddressDTO>(addressEntity);
                return CreatedAtRoute("GetAddressForUser", new { customerId = customerId, addressId = addressToReturn.AddressId }, addressToReturn);
            }

        }
        [HttpDelete("{addressId}")]
        public ActionResult DeleteAddressForUser(int customerId, int addressId)
        {

            var moreThanOneAddress = _addressRepo.MoreThanOneAddress(customerId, addressId);
            if (moreThanOneAddress)
            {
                var addressForCustomerFromRepo = _addressRepo.GetAddress(addressId, customerId);
                _addressRepo.DeleteAddress(addressForCustomerFromRepo);
                _addressRepo.Save();

                return NoContent();
            }
            return BadRequest("you cant delete all addresses");
        }

        [HttpPatch("{addressId}")]
        public ActionResult UpDateIsMain(int customerId, int addressId, JsonPatchDocument<AddressForUpdateDTO> patchDocument)
        {
            var hasMainAddress = _addressRepo.HasMainAddress(customerId);
            var addressForCustomerFromRepo = _addressRepo.GetAddress(addressId, customerId);
            var addressToPatch = _mapper.Map<AddressForUpdateDTO>(addressForCustomerFromRepo);
            var incomingvalue = patchDocument.Operations[0].value.ToString();

            if (hasMainAddress && incomingvalue =="true")
            {
                return BadRequest("you cant have two main addresses");
            }



            patchDocument.ApplyTo(addressToPatch);

            _mapper.Map(addressToPatch, addressForCustomerFromRepo);
            _addressRepo.UpdateAddress(addressForCustomerFromRepo);
            _addressRepo.Save();
            return NoContent();

            //Example patch 
            //[
            //    {
            //    "op":"replace",
            //"path": "IsMainAddress",
            //"value": "false"
            //    }
            //]

        }
    }
}

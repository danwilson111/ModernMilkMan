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
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepo _customerRepo;
        private readonly IMapper _mapper;
        public CustomerController(ICustomerRepo customerRepo, IMapper mapper)
        {
            _customerRepo = customerRepo;
            _mapper = mapper;
        }

        [HttpGet]
        [HttpHead]
        public ActionResult<IEnumerable<CustomerDTO>> GetAllCustomers(string isActive)
        {
            var customerEntities = _customerRepo.GetAllCustomers(isActive);

            return Ok(_mapper.Map<IEnumerable<CustomerDTO>>(customerEntities));

        }

        // GET: api/Users/5
        [HttpGet("{customerId}", Name = "GetCustomer")]
        public IActionResult GetCustomer(int customerId)
        {
            var customer = _customerRepo.GetCustomer(customerId);

            if (customer == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CustomerDTO>(customer));
        }


        [HttpPost]
        public ActionResult<CustomerDTO> CreateUser(CustomerForCreationDTO customerForCreationDTO)
        {

            var customerEntity = _mapper.Map<Customer>(customerForCreationDTO);
            var alreadyExist = _customerRepo.AlreadyExist(customerEntity);
            if (alreadyExist)
            {
                return BadRequest("They Already exist");
            }
            else
            {
                _customerRepo.AddCustomer(customerEntity);
                _customerRepo.Save();
                var customerToReturn = _mapper.Map<CustomerDTO>(customerEntity);
                return CreatedAtRoute("GetCustomer", new { customerId = customerToReturn.CustomerId }, customerToReturn);
            }

            //return NoContent();

        }

        [HttpDelete("{customerId}")]
        public ActionResult DeleteUser(int customerId)
        {
            var customer = _customerRepo.GetCustomer(customerId);

            if (customer == null)
            {
                return NotFound();
            }
            _customerRepo.DeleteCustomer(customer);
            _customerRepo.Save();
            return NoContent();
        }

        [HttpPatch("{customerId}")]
        public ActionResult UpDateIsActive(int customerId, JsonPatchDocument<CustomerForUpdateDTO> patchDocument)
        {
            var customerFromRepo = _customerRepo.GetCustomer(customerId);

            var customerToPatch = _mapper.Map<CustomerForUpdateDTO>(customerFromRepo);
            patchDocument.ApplyTo(customerToPatch);

            _mapper.Map(customerToPatch, customerFromRepo);
            _customerRepo.UpdateCustomer(customerFromRepo);
            _customerRepo.Save();
            return NoContent();

        //Example patch 
        // [
        //    {
        // "op":"replace",
        //"path": "isActive",
        //"value": "false"
        //    }
        //]

        }

    }
}

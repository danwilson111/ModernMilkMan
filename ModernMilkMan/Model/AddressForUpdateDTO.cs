using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ModernMilkMan.Model
{
    public class AddressForUpdateDTO
    {
        [DefaultValue(false)]
        public bool IsMainAddress { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ModernMilkMan.Model
{
    public class CustomerForUpdateDTO
    {
        [DefaultValue(true)]
        public bool IsActive { get; set; }
    }
}

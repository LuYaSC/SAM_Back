using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAM.Functions.ControlGifts.Business.Models
{
    public class GetControlGiftDto
    {
        public bool TypeSearch { get; set; }

        public string DocumentNumber { get; set; }

        public string Name { get; set; }

        public string FirstLastName { get; set; }

        public string SecondLastName { get; set; }
    }
}

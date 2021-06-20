using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAM.Functions.ControlGifts.MicroService.Models
{
    public class AssingGiftDto
    {
        public List<int> Beneficiaries { get; set; }

        public bool HaveBackpack { get; set; }

        public bool HaveSchedule { get; set; }

        public int OfficePlace { get; set; }

        public string Observations { get; set; }
    }
}

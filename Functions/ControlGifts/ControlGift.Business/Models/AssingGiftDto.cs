using System.Collections.Generic;

namespace SAM.Functions.ControlGift.Business.Models
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

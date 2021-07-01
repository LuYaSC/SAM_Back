using System.Collections.Generic;

namespace SAM.Functions.ControlGift.Business.Models
{
    public class GetControlGiftResult
    {
        public GetControlGiftResult()
        {
            Details = new List<DatesBeneficiary>();
        }

        public bool IsOk { get; set; }

        public string Message { get; set; }

        public int TotalAports { get; set; }

        public bool HaveBackPack { get; set; }

        public bool HaveSchedule { get; set; }

        public List<DatesBeneficiary> Details { get; set; }
    }

   
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAM.Functions.ControlGifts.MicroService.Models
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

    public class DatesBeneficiary
    {
        public int BeneficiaryId { get; set; }

        public string FullName { get; set; }

        public string BeneficiaryType { get; set; }

        public int Aports { get; set; }
    }
}

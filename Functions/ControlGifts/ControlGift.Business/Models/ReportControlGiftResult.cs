using System.Collections.Generic;

namespace SAM.Functions.ControlGift.Business.Models
{
    public class ReportControlGiftResult
    {
        public int Total { get; set; }

        public int TotalBackPack { get; set; }

        public int TotalSchedule { get; set; }

        public List<OfficePerGifts> DatesPerOffice { get; set; }
    }

   
}

using System.Collections.Generic;

namespace SAM.Functions.ControlGift.Business.Models
{
    public class ReportControlGiftResult
    {
        public ReportControlGiftResult()
        {
            DatesPerOffice = new List<OfficePerGifts>();
        }

        public int Total { get; set; }

        public int TotalBackPack { get; set; }

        public int TotalSchedule { get; set; }

        public List<OfficePerGifts> DatesPerOffice { get; set; }
    }

    public class OfficePerGifts
    {
        public string DescriptionType { get; set; }

        public string Description { get; set; }

        public int TotalPerRegional { get; set; }

        public int TotalBackPack { get; set; }

        public int TotalSchedule { get; set; }
    }
}

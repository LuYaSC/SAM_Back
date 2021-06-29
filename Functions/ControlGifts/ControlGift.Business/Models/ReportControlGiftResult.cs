using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAM.Functions.ControlGifts.Business.Models
{
    public class ReportControlGiftResult
    {
        public int Total { get; set; }

        public int TotalBackPack { get; set; }

        public int TotalSchedule { get; set; }

        public List<OfficePerGifts> DatesPerOffice { get; set; }
    }

    public class OfficePerGifts
    {
        public string DescriptionType { get; set; }

        public string Description { get; set; }

        public int TotalBackPack { get; set; }

        public int TotalSchedule { get; set; }
    }
}

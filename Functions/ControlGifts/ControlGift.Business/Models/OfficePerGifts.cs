using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAM.Functions.ControlGift.Business.Models
{
    public class OfficePerGifts
    {
        public string DescriptionType { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int TotalPerRegional { get; set; } = 0;

        public int TotalBackPack { get; set; } = 0;

        public int TotalSchedule { get; set; } = 0;
    }
}

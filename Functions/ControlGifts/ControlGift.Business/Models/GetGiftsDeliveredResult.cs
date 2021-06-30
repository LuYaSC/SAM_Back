using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAM.Functions.ControlGift.Business.Models
{
    public class GetGiftsDeliveredResult
    {
        public int Total { get; set; }

        public List<ListDelivered> Delivered { get; set; }
    }

    public class ListDelivered
    {
        public string Beneficiary { get; set; }

        public string HaveBackPack { get; set; }

        public string HaveSchedule { get; set; }

        public string Office { get; set; }

        public string Observations { get; set; }

        public DateTime DateCreation { get; set; }
    }
}

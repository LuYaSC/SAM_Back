using System.Collections.Generic;

namespace SAM.Functions.ControlGift.Business.Models
{
    public class GetGiftsDeliveredResult
    {
        public int Total { get; set; }

        public List<ListDelivered> Delivered { get; set; }
    }
}

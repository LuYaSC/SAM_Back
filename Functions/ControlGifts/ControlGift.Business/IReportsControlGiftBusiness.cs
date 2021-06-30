using SAM.Core.Business;
using SAM.Functions.ControlGift.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAM.Functions.ControlGift.Business
{
    public interface IReportsControlGiftBusiness
    {
        Result<ReportControlGiftResult> GetReports();

        Result<GetGiftsDeliveredResult> GetMyGiftsDelivered(GetGiftsDeliveredDto dto);

        Result<GetGiftsDeliveredResult> GetAllGiftsDelivered(GetGiftsDeliveredDto dto);
    }
}

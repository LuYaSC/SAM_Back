using SAM.Core.Business;
using SAM.Functions.ControlGift.Business.Models;

namespace SAM.Functions.ControlGift.Business
{
    public interface IReportsControlGiftBusiness
    {
        Result<ReportControlGiftResult> GetReports();

        Result<GetGiftsDeliveredResult> GetMyGiftsDelivered(GetGiftsDeliveredDto dto);

        Result<GetGiftsDeliveredResult> GetAllGiftsDelivered(GetGiftsDeliveredDto dto);
    }
}

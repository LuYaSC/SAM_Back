using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SAM.Core.Business;
using SAM.Databases.DbSam.Core.Data;
using SAM.Functions.ControlGift.Business;
using SAM.Functions.ControlGift.Business.Models;
using System.Collections.Generic;

namespace SAM.Functions.ControlGifts.MicroService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]

    public class ControlGiftController : ControllerBase
    {
        IControlGiftsBusiness business;
        IReportsControlGiftBusiness reports;

        public ControlGiftController(IControlGiftsBusiness business, IReportsControlGiftBusiness reports)
        {
            this.business = business;
            this.reports = reports;
        }

        [HttpPost]
        public GetControlGiftResult GetDatesBeneficiary([FromBody] GetControlGiftDto dto) => business.GetDatesBeneficiary(dto);

        [HttpPost]
        public AssingGiftResult AssingGift([FromBody] AssingGiftDto dto) => business.AssingGift(dto);

        [HttpPost]
        public List<OfficePlace> GetOffices() => business.GetOffices();

        [HttpPost]
        public Result<ReportControlGiftResult> GetReports() => reports.GetReports();

        [HttpPost]
        public Result<GetGiftsDeliveredResult> GetMyGiftsDelivered([FromBody] GetGiftsDeliveredDto dto) => reports.GetMyGiftsDelivered(dto);

        [HttpPost]
        public Result<GetGiftsDeliveredResult> GetAllGiftsDelivered([FromBody] GetGiftsDeliveredDto dto) => reports.GetAllGiftsDelivered(dto);

        [HttpPost]
        public byte[] TestReport() => reports.TestReport();
    }
}

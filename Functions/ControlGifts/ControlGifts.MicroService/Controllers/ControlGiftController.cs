using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SAM.Databases.DbSam.Core.Data;
using SAM.Functions.ControlGift.Business;
using SAM.Functions.ControlGifts.Business.Models;
using System.Collections.Generic;

namespace SAM.Functions.ControlGifts.MicroService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]

    public class ControlGiftController : ControllerBase
    {
        IControlGiftsBusiness business;

        public ControlGiftController(IControlGiftsBusiness business)
        {
            this.business = business;
        }

        [HttpPost]
        public GetControlGiftResult GetDatesBeneficiary([FromBody] GetControlGiftDto dto) => business.GetDatesBeneficiary(dto);

        [HttpPost]
        public AssingGiftResult AssingGift([FromBody] AssingGiftDto dto) => business.AssingGift(dto);

        [HttpPost]
        public List<OfficePlace> GetOffices() => business.GetOffices();

        [HttpPost]
        public ReportControlGiftResult GetReports() => business.GetReports();
    }
}

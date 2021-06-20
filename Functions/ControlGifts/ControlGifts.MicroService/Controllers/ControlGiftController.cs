using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SAM.Core.Data;
using SAM.Functions.ControlGifts.MicroService.Business;
using SAM.Functions.ControlGifts.MicroService.Models;
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
    }
}

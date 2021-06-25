using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SAM.Core.Business;
using SAM.Functions.ReturnsASR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAM.Functions.ReturnsASR.MicroService.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize]

    public class ReturnsASRController : ControllerBase
    {
        private readonly ILogger<ReturnsASRController> _logger;
        IReturnsASRBusiness business;

        public ReturnsASRController(ILogger<ReturnsASRController> logger, IReturnsASRBusiness business)
        {
            _logger = logger;
            this.business = business;
        }

    }
}

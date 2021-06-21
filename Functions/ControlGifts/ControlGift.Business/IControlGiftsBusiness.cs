using SAM.Databases.DbSam.Core.Data;
using SAM.Functions.ControlGifts.MicroService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAM.Functions.ControlGift.Business
{
    public interface IControlGiftsBusiness
    {
        GetControlGiftResult GetDatesBeneficiary(GetControlGiftDto dto);

        AssingGiftResult AssingGift(AssingGiftDto dto);

        List<OfficePlace> GetOffices();
    }
}

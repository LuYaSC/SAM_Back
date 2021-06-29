using SAM.Databases.DbSam.Core.Data;
using SAM.Functions.ControlGifts.Business.Models;
using System.Collections.Generic;

namespace SAM.Functions.ControlGift.Business
{
    public interface IControlGiftsBusiness
    {
        GetControlGiftResult GetDatesBeneficiary(GetControlGiftDto dto);

        AssingGiftResult AssingGift(AssingGiftDto dto);

        List<OfficePlace> GetOffices();

        ReportControlGiftResult GetReports();
    }
}

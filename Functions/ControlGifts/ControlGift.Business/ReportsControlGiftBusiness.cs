using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SAM.Core.Business;
using SAM.Functions.ControlGift.Business.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace SAM.Functions.ControlGift.Business
{
    public class ReportsControlGiftBusiness : BaseBusiness<Databases.DbSam.Core.Data.ControlGift, ControlGiftsContext>, IReportsControlGiftBusiness
    {
        IMapper mapper;
        int userId;

        public ReportsControlGiftBusiness(ControlGiftsContext context, IPrincipal userInfo, IConfiguration configuration)
            : base(context, userInfo, configuration)
        {
            var claimsIdentity = (ClaimsIdentity)userInfo.Identity;
            userId = int.Parse(claimsIdentity.Claims.Where(x => x.Type == "identifier").FirstOrDefault().Value);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Databases.DbSam.Core.Data.ControlGift, ListDelivered>()
                    .ForMember(d => d.Beneficiary, o => o.MapFrom(s => $"{s.Beneficiary.Name} {s.Beneficiary.FirstLastName} {s.Beneficiary.SecondLastName}"))
                    .ForMember(d => d.Office, o => o.MapFrom(s => $"{s.OfficePlace.DescriptionType} {s.OfficePlace.Description}"))
                    .ForMember(d => d.HaveBackPack, o => o.MapFrom(s => s.HaveBackpack ? "RECIBIO" : "NO RECIBIO"))
                    .ForMember(d => d.HaveSchedule, o => o.MapFrom(s => s.HaveSchedule ? "RECIBIO" : "NO RECIBIO"));
            });
            mapper = new Mapper(config);
        }


        public Result<ReportControlGiftResult> GetReports()
        {
            ReportControlGiftResult result = new ReportControlGiftResult();
            var dates = Context.ControlGifts.Include(x => x.Beneficiary).Include(x => x.UserCreated).Include(x => x.OfficePlace).ToList();
            var offices = Context.OfficePlaces.Where(x => !x.IsDeleted).ToList();
            foreach (var office in offices)
            {
                var list = dates.Where(x => x.OfficePlaceId == office.Id).ToList();
                var listGroup = list.GroupBy(d => d.Beneficiary.DocumentNumber)
                   .Select(
                   g => new Databases.DbSam.Core.Data.ControlGift
                   {
                       Id = g.First().Id,
                       HaveBackpack = g.First().HaveBackpack,
                       HaveSchedule = g.First().HaveSchedule,
                       DateCreation = g.First().DateCreation,
                       DateModification = g.First().DateModification,
                       BeneficiaryId = g.First().BeneficiaryId,
                       OfficePlaceId = g.First().OfficePlaceId,
                       UserCreation = g.First().UserCreation,
                       UserModification = g.First().UserModification,
                       Observations = g.First().Observations,
                       IsDeleted = g.First().IsDeleted
                   });

                if (listGroup.FirstOrDefault() == null) continue;

                var datePerRegional = dates.Where(x => x.Id == listGroup.First().Id).FirstOrDefault();
                result.DatesPerOffice.Add(new OfficePerGifts
                {
                    Description = datePerRegional.OfficePlace.Description,
                    DescriptionType = datePerRegional.OfficePlace.DescriptionType,
                    TotalBackPack = listGroup.Count(x => x.HaveBackpack),
                    TotalSchedule = listGroup.Count(x => x.HaveSchedule),
                    TotalPerRegional = listGroup.Count()
                });
            }

            var listGroupGen = dates.GroupBy(d => d.BeneficiaryId)
                  .Select(
                  g => new Databases.DbSam.Core.Data.ControlGift
                  {
                      Id = g.First().Id,
                      HaveBackpack = g.First().HaveBackpack,
                      HaveSchedule = g.First().HaveSchedule,
                      DateCreation = g.First().DateCreation,
                      DateModification = g.First().DateModification,
                      BeneficiaryId = g.First().BeneficiaryId,
                      OfficePlaceId = g.First().OfficePlaceId,
                      UserCreation = g.First().UserCreation,
                      UserModification = g.First().UserModification,
                      Observations = g.First().Observations,
                      IsDeleted = g.First().IsDeleted,
                  });

            result.Total = listGroupGen.Count();
            result.TotalBackPack = listGroupGen.Count(x => x.HaveBackpack);
            result.TotalSchedule = listGroupGen.Count(x => x.HaveSchedule);
            return Result<ReportControlGiftResult>.SetOk(result);
        }

        public Result<GetGiftsDeliveredResult> GetMyGiftsDelivered(GetGiftsDeliveredDto dto)
        {
            List<Databases.DbSam.Core.Data.ControlGift> listResult = new List<Databases.DbSam.Core.Data.ControlGift>();
            var listOffice = Context.UserRoles.Include(x => x.OfficePlace).Where(x => x.UserId == userId).ToList();
            var beneficiary = Context.Beneficiaries.Where(x => x.DocumentNumber == dto.DocumentNumber).FirstOrDefault();
            foreach (var office in listOffice)
            {
                var tempList = Context.ControlGifts.Include(x => x.OfficePlace).Include(x => x.Beneficiary)
                                      .Where(x => x.UserCreation == userId && x.OfficePlaceId == office.OfficePlaceId).ToList();
                if (beneficiary != null)
                {
                    tempList = tempList.Where(x => x.BeneficiaryId == beneficiary.Id).ToList();
                }
                listResult = listResult.Concat(tempList).ToList();
            }
            return Result<GetGiftsDeliveredResult>.SetOk(new GetGiftsDeliveredResult
            {
                Delivered = mapper.Map<List<ListDelivered>>(listResult.OrderByDescending(x => x.DateCreation)),
                Total = listResult.Count
            });
        }

        public Result<GetGiftsDeliveredResult> GetAllGiftsDelivered(GetGiftsDeliveredDto dto)
        {
            var listGifts = Context.ControlGifts.Include(x => x.OfficePlace).Include(x => x.Beneficiary).Include(x => x.UserCreated).Where(x => !x.IsDeleted).ToList();
            if (!string.IsNullOrEmpty(dto.DocumentNumber))
            {
                var beneficiary = Context.Beneficiaries.Where(x => x.DocumentNumber == dto.DocumentNumber).FirstOrDefault();
                if (beneficiary == null)
                {
                    Result<List<GetGiftsDeliveredResult>>.SetError($"el beneficiario con el documento: {dto.DocumentNumber} no existe");
                }
                listGifts = listGifts.Where(x => x.BeneficiaryId == beneficiary.Id).ToList();
            }
            if (dto.Office != 0)
            {
                listGifts = listGifts.Where(x => x.OfficePlaceId == dto.Office).ToList();
            }
            return listGifts.Any() ? Result<GetGiftsDeliveredResult>.SetOk(new GetGiftsDeliveredResult
            {
                Delivered = mapper.Map<List<ListDelivered>>(listGifts.OrderByDescending(x => x.DateCreation)),
                Total = listGifts.Count
            }) : Result<GetGiftsDeliveredResult>.SetError("No existen Datos que mostrar");
        }
    }
}

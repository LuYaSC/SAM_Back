using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SAM.Databases.DbSam.Core.Data;
using SAM.Functions.ControlGifts.MicroService.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace SAM.Functions.ControlGift.Business
{
    public class ControlGiftsBusiness : IControlGiftsBusiness
    {
        IConfiguration configuration;
        ControlGiftsContext Context;
        IPrincipal userInfo;
        int totalAports = 0;
        int userId = 0;


        public ControlGiftsBusiness(IConfiguration configuration, ControlGiftsContext Context, IPrincipal userInfo)
        {
            this.configuration = configuration;
            this.Context = Context;
            this.userInfo = userInfo;
            var claimsIdentity = (ClaimsIdentity)this.userInfo.Identity;
            userId = int.Parse(claimsIdentity.Claims.Where(x => x.Type == "identifier").FirstOrDefault().Value);
        }

        public GetControlGiftResult GetDatesBeneficiary(GetControlGiftDto dto)
        {
            GetControlGiftResult result = new GetControlGiftResult();
            List<Beneficiary> beneficiaries = new List<Beneficiary>();
            if (dto.TypeSearch)
            {
                beneficiaries = Context.Beneficiaries.Include(y => y.BeneficiaryType).Where(x => x.DocumentNumber == dto.DocumentNumber && !x.IsDeleted).ToList();
            }
            else
            {
                beneficiaries = Context.Beneficiaries.Include(y => y.BeneficiaryType).Where(x => x.Name.Contains(dto.Name) && x.FirstLastName.Contains(dto.FirstLastName)
                                && x.SecondLastName.Contains(dto.SecondLastName) && !x.IsDeleted).ToList();
            }
            if (!beneficiaries.Any()) return new GetControlGiftResult { IsOk = false, Message = "No existen beneficiarios con esos datos" };
            var befsPassive = beneficiaries.Where(x => x.BeneficiaryTypeId == 2).ToList();
            if (befsPassive.Count > 1)
            {
                if (befsPassive.First().EnrollmentTitular == befsPassive.Last().EnrollmentTitular)
                {
                    beneficiaries.Remove(befsPassive.First());
                }
            }
            foreach (var bef in beneficiaries)
            {
                switch (bef.BeneficiaryTypeId)
                {
                    case 1:
                        result.Details.Add(GetActiveAportsBeneficiary(bef));
                        break;
                    case 2:
                        result.Details.Add(GetPassiveAportsBeneficiary(bef));
                        break;
                    case 3:
                        result.Details.Add(GetAfpAportsBeneficiary(bef));
                        break;
                }
            }
            result.IsOk = true;
            result.TotalAports = totalAports;
            result.HaveBackPack = result.TotalAports >= 12 ? true : false;
            result.HaveSchedule = result.TotalAports >= 1 ? true : false;
            return result;
        }

        private DatesBeneficiary GetActiveAportsBeneficiary(Beneficiary dto)
        {
            var listMinistery = Context.MinistryActiveContributions.Where(x => x.CARNET_AA == dto.DocumentNumber).ToList();

            var endListMin = listMinistery.GroupBy(d => d.FECHAAPORTES_AA)
                    .Select(
                    g => new MinistryActiveContribution
                    {
                        Id = g.First().Id,
                        DESCUENTO_AA = g.Sum(s => decimal.Parse(s.DESCUENTO_AA)).ToString(),
                        CARNET_AA = g.First().CARNET_AA,
                        FECHAAPORTES_AA = g.First().FECHAAPORTES_AA,
                        ITEM_AA = g.Count().ToString(),
                        NOMBRE1_AA = g.First().NOMBRE1_AA,
                        NOMBRE2_AA = g.First().NOMBRE2_AA,
                        MATERNO_AA = g.First().MATERNO_AA,
                        PATERNO_AA = g.First().PATERNO_AA,
                        CATEGORIA = g.First().CATEGORIA,
                        PROGRAMA_AA = g.First().PROGRAMA_AA,
                        SERVICIO_AA = g.First().SERVICIO_AA,
                        SUELDO_AA = g.First().SUELDO_AA,
                    });
            totalAports += endListMin.Count();
            return new DatesBeneficiary
            {
                BeneficiaryId = dto.Id,
                Aports = endListMin.Count(),
                BeneficiaryType = dto.BeneficiaryType.Description,
                FullName = $"{dto.Name} {dto.FirstLastName} {dto.SecondLastName} {dto.MarriedLastName}"
            };

        }

        private DatesBeneficiary GetPassiveAportsBeneficiary(Beneficiary dto)
        {
            var listPassiveAports = Context.MinistryPassiveContributions.Where(x => x.T_MATRICULA_AP == dto.EnrollmentTitular).ToList();
            totalAports += listPassiveAports.Count;
            return new DatesBeneficiary
            {
                BeneficiaryId = dto.Id,
                Aports = listPassiveAports.Count,
                BeneficiaryType = dto.BeneficiaryType.Description,
                FullName = $"{dto.Name} {dto.FirstLastName} {dto.SecondLastName} {dto.MarriedLastName}"
            };
        }

        private DatesBeneficiary GetAfpAportsBeneficiary(Beneficiary dto)
        {
            var listAfpAports = Context.AfpPassiveContributions.Where(x => x.DocumentNumber == dto.DocumentNumber).ToList();
            totalAports += listAfpAports.Count;
            return new DatesBeneficiary
            {
                BeneficiaryId = dto.Id,
                Aports = listAfpAports.Count,
                BeneficiaryType = dto.BeneficiaryType.Description,
                FullName = $"{dto.Name} {dto.FirstLastName} {dto.SecondLastName} {dto.MarriedLastName}"
            };
        }

        public AssingGiftResult AssingGift(AssingGiftDto dto)
        {
            foreach (var befv in dto.Beneficiaries)
            {
                var checkGift = Context.ControlGifts.Include(x => x.Beneficiary)
                                                    .Include(x => x.OfficePlace).Where(x => x.BeneficiaryId == befv && !x.IsDeleted).FirstOrDefault();
                if (checkGift != null)
                {
                    return new AssingGiftResult
                    {
                        IsOk = false,
                        Message = $"El obsequio ya fue entregado al Beneficiario {checkGift.Beneficiary.Name} {checkGift.Beneficiary.FirstLastName} {checkGift.Beneficiary.SecondLastName}, " +
                        $"en la regional/distrital de {checkGift.OfficePlace.Description}, si cree que existe un problema comuniquese con el area de sistemas"
                    };
                }
            }

            foreach (var bef in dto.Beneficiaries)
            {
                //Context.ControlGifts.Add(new ControlGift
                //{
                //    BeneficiaryId = bef,
                //    DateCreation = DateTime.Now,
                //    HaveBackpack = dto.HaveBackpack,
                //    HaveSchedule = dto.HaveSchedule,
                //    Observations = dto.Observations,
                //    UserCreation = userId,
                //    UserModification = userId,
                //    OfficePlaceId = dto.OfficePlace
                //});
                Context.SaveChanges();
            }
            return new AssingGiftResult
            {
                IsOk = true,
                Message = $"Operación completada con éxito"
            };
        }

        public List<OfficePlace> GetOffices() => Context.OfficePlaces.ToList();

    }
}

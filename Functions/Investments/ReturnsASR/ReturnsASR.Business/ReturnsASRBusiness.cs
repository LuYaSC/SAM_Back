using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SAM.Core.Business;
using SAM.Databases.DbSam.Core.Data;
using SAM.Functions.Investments.ReturnsASR.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace SAM.Functions.Investments.ReturnsASR.Business
{
    public class ReturnsASRBusiness : BaseBusiness<AsrReturn, ReturnsASRContext>, IReturnsASRBusiness
    {
        IMapper mapper;
        int userId;

        public ReturnsASRBusiness(ReturnsASRContext context, IPrincipal userInfo, IConfiguration configuration) : base(context, userInfo, configuration)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RegistryDto, AsrReturn>();
                cfg.CreateMap<Beneficiary, GetBeneficiaryResult>();
                cfg.CreateMap<AsrReturn, GetReturnsASRResult>();
            });
            //var claimsIdentity = (ClaimsIdentity) userInfo.Identity;
            //userId = int.Parse(claimsIdentity.Claims.Where(x => x.Type == "identifier").FirstOrDefault().Value);
            if (UserInfo.Identity.Name != null)
            {
                //companyId = UserInfo.Identity.GetCompanyId();
            }
            mapper = new Mapper(config);
        }

        public Result<List<GetReturnsASRResult>> GetReturnsASR()
        {
            var listASR = Context.AsrReturns
                                 .Include(x => x.Beneficiary)
                                 .Include(x => x.UserCreated)
                                 .Include(x => x.UserModificated).Where(x => !x.IsDeleted).ToList();

            return listASR.Any() ? Result<List<GetReturnsASRResult>>.SetOk(mapper.Map<List<GetReturnsASRResult>>(listASR)) :
                                   Result<List<GetReturnsASRResult>>.SetError("No existen registros para la busqueda"); 
        }

        public Result<GetBeneficiaryResult> GetBeneficiary(GetBeneficiaryDto dto)
        {
            var beneficiary = Context.Beneficiaries.Where(x => x.DocumentNumber == dto.DocumentNumber && x.BeneficiaryTypeId == dto.BeneficiaryType).FirstOrDefault();
            return beneficiary == null ? Result<GetBeneficiaryResult>.SetError("No existe el Beneficiario buscado")
                : Result<GetBeneficiaryResult>.SetOk(mapper.Map<GetBeneficiaryResult>(beneficiary));
        }

        public Result<string> RegistryReturnASR(RegistryDto dto)
        {
            try
            {
                Context.Save(mapper.Map<AsrReturn>(dto));
                return Result<string>.SetOk("Registro insertado con exito");
            }
            catch (Exception ex)
            {
                return Result<string>.SetError($"Error en la insersion del registro {ex.Message}");
            }
        }

        public Result<string> ModifyRegistryASR(ModifyDto dto)
        {
            var registry = Context.AsrReturns.Where(x => x.Id == dto.RegistryId).FirstOrDefault();
            if (registry == null)
            {
                return Result<string>.SetError("No existe el registro buscado");
            }
            registry.Amount = dto.Amount;
            Context.SaveChanges();
            return Result<string>.SetOk("La operacion se realizo con exito");
        }

        public Result<string> Delete(ModifyDto dto)
        {
            try
            {
                Remove(dto.RegistryId);
                return Result<string>.SetOk("Registro eliminado con exito");
            }
            catch (Exception ex)
            {
                return Result<string>.SetError($"No existe el registro buscado {ex.Message}");
            }
        }
    }
}

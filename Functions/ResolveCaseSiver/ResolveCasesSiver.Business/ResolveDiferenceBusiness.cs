using Microsoft.Extensions.Configuration;
using SAM.Core.Business;
using SAM.Databases.DbSam.Core.Data;
using SAM.Functions.ResolveCasesSiver.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace SAM.Functions.ResolveCasesSiver.Business
{
    public class ResolveDiferenceBusiness : BaseBusiness<Beneficiary, ResolveCasesSiverContext> , IResolveDiferenceBusiness
    {
        public ResolveDiferenceBusiness(ResolveCasesSiverContext context, IPrincipal userInfo, IConfiguration configuration = null) : base(context, userInfo, configuration)
        {
        }

        public Result<ResolveDiferenceResult> GetCaseData(ResolveDiferenceDto dto)
        {
            ResolveDiferenceResult result = new ResolveDiferenceResult();
            var listSiver = Context.MumanalActiveContributions.Where(x => x.cedula_identidad == dto.DocumentNumber).ToList();
            var listMinistery = Context.MinistryActiveContributions.Where(x => x.CARNET_AA == dto.DocumentNumber).ToList();

            var b = listMinistery.GroupBy(d => d.FECHAAPORTES_AA)
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
            int count = 0;
            int countB = b.Count();
            foreach (var data in b)
            {
                var dateSiver = data.FECHAAPORTES_AA.ToString("yyyy-MM-dd");
                var codBase = listSiver.First().cod_base;
                var ctacte = listSiver.Where(x => !string.IsNullOrEmpty(x.ctacte)).FirstOrDefault()?.ctacte;
                if (listSiver.Where(x => x.fecha == dateSiver).FirstOrDefault() == null)
                {
                    count++;
                    var newData = data.FECHAAPORTES_AA.ToString("yyyy-MM-dd");
                    var month = newData.Substring(newData.Length - 5, 2);

                    result.Name = $"{data.NOMBRE1_AA} {data.NOMBRE2_AA} {data.PATERNO_AA} {data.MATERNO_AA}";
                    result.DocumentNumber = data.CARNET_AA;

                    result.ScriptMYSQL += $"Insert into aporte_activo_{newData.Substring(0, 4)}(cod_base, cedula_identidad, numbol, aporte, fecha, mes, ctacte) " +
                        $"values('{codBase}', '{data.CARNET_AA}', {int.Parse(data.ITEM_AA)}, '{data.DESCUENTO_AA}', '{newData}', {month}, '{ctacte}');";

                    result.ScriptSQLSERVER += $"INSERT INTO MumanalDatos(cod_base, cedula_identidad, numbol, aporte, fecha, mes, ctacte) VALUES " +
                        $"({codBase}, {data.CARNET_AA}, {int.Parse(data.ITEM_AA)}, '{data.DESCUENTO_AA}', '{newData}', '{month}', '{ctacte}');";

                    result.Details.Add(new DetailDiference
                    {
                        Id = data.Id,
                        Amount = data.DESCUENTO_AA,
                        Date = data.FECHAAPORTES_AA.ToShortDateString(),
                        QuantityBullet = int.Parse(data.ITEM_AA),
                    });
                }
            }
            result.Details = result.Details.OrderBy(x => x.Id).ToList();
            result.MissingData = count;
            return Result<ResolveDiferenceResult>.SetOk(result);
        }

        public ResolveDiferenceResult GetCaseDataBC(ResolveDiferenceDto dto)
        {
            ResolveDiferenceResult result = new ResolveDiferenceResult();
            var listSiver = Context.SeveranceBonusContributions.Where(x => x.CodigoBase == dto.CodBase).ToList();
            var listMinistery = Context.MinistryActiveContributions.Where(x => x.CARNET_AA == dto.DocumentNumber).ToList();

            var b = listMinistery.GroupBy(d => d.FECHAAPORTES_AA)
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

            var c = listSiver.GroupBy(d => d.Fecha)
                    .Select(
                    g => new SeveranceBonusContribution
                    {
                        Id = g.First().Id,
                        CodigoBase = g.First().CodigoBase,
                        Descuento = g.Sum(s => s.Descuento),
                        Fecha = g.First().Fecha,
                        Mes = g.First().Mes,
                        Sueldo = g.Sum(s => s.Sueldo),
                    }).ToList();
            int count = 0;
            int countB = b.Count();
            int couuntC = c.Count();

            foreach (var data in b)
            {
                var dateSiver = data.FECHAAPORTES_AA.ToString("yyyy-MM-dd");
                var codBase = listSiver.First().CodigoBase;
                //var ctacte = listSiver.Where(x => !string.IsNullOrEmpty(x.ctacte)).First().ctacte;
                if (listSiver.Where(x => x.Fecha.ToString("yyyy-MM-dd") == dateSiver).FirstOrDefault() == null)
                {
                    count++;
                    var newData = data.FECHAAPORTES_AA.ToString("yyyy-MM-dd");
                    var month = newData.Substring(newData.Length - 5, 2);

                    result.Name = $"{data.NOMBRE1_AA} {data.NOMBRE2_AA} {data.PATERNO_AA} {data.MATERNO_AA}";
                    result.DocumentNumber = data.CARNET_AA;

                    result.ScriptMYSQL += $"Insert into aporte_activo_{newData.Substring(0, 4)}(cod_base, cedula_identidad, numbol, aporte, fecha, mes, ctacte) " +
                        $"values('{codBase}', '{data.CARNET_AA}', {int.Parse(data.ITEM_AA)}, '{data.DESCUENTO_AA}', '{newData}', {month}, '');";

                    result.Details.Add(new DetailDiference
                    {
                        Id = data.Id,
                        Amount = data.DESCUENTO_AA,
                        Date = data.FECHAAPORTES_AA.ToShortDateString(),
                        QuantityBullet = int.Parse(data.ITEM_AA),
                    });
                }
            }
            result.Details = result.Details.OrderBy(x => x.Id).ToList();
            result.MissingData = count;
            return result;
        }

        //public byte[] GetReportAports(ResolveDiferenceDto dto)
        //{
        //    var listMinistery = Context.MinisterioDatos.Where(x => x.CARNET_AA == dto.DocumentNumber).ToList();
        //    var b = listMinistery.GroupBy(d => d.FECHAAPORTES_AA)
        //           .Select(
        //           g => new MinisterioDato
        //           {
        //               Id = g.First().Id,
        //               DESCUENTO_AA = g.Sum(s => decimal.Parse(s.DESCUENTO_AA)).ToString(),
        //               CARNET_AA = g.First().CARNET_AA,
        //               FECHAAPORTES_AA = g.First().FECHAAPORTES_AA,
        //               ITEM_AA = g.Count().ToString(),
        //               NOMBRE1_AA = g.First().NOMBRE1_AA,
        //               NOMBRE2_AA = g.First().NOMBRE2_AA,
        //               MATERNO_AA = g.First().MATERNO_AA,
        //               PATERNO_AA = g.First().PATERNO_AA,
        //               CATEGORIA = g.First().CATEGORIA,
        //               PROGRAMA_AA = g.First().PROGRAMA_AA,
        //               SERVICIO_AA = g.First().SERVICIO_AA,
        //               SUELDO_AA = g.First().SUELDO_AA,

        //           });
        //    int count = 0;

        //}

        //public decimal GetSalary

        public List<ResolveDiferenceMassiveResult> GetCaseDataMassive(ResolveDiferenceDto dto)
        {
            List<ResolveDiferenceMassiveResult> result = new List<ResolveDiferenceMassiveResult>();
            foreach (var search in dto.Documents)
            {
                var listSiver = Context.MumanalActiveContributions.Where(x => x.cedula_identidad == search).ToList();
                var listMinistery = Context.MinistryActiveContributions.Where(x => x.CARNET_AA == search).ToList();

                var b = listMinistery.GroupBy(d => d.FECHAAPORTES_AA)
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
                int count = 0;
                string name = string.Empty;
                string docNumber = string.Empty;
                string scriptMYSQL = string.Empty;
                string sQLScript = string.Empty;
                foreach (var data in b)
                {
                    var dateSiver = data.FECHAAPORTES_AA.ToString("yyyy-MM-dd");
                    var codBase = listSiver.First().cod_base;
                    var ctacte = listSiver.Where(x => !string.IsNullOrEmpty(x.ctacte)).First().ctacte;
                    if (listSiver.Where(x => x.fecha == dateSiver).FirstOrDefault() == null)
                    {
                        count++;
                        var newData = data.FECHAAPORTES_AA.ToString("yyyy-MM-dd");
                        var month = newData.Substring(newData.Length - 5, 2);

                        name = $"{data.NOMBRE1_AA} {data.NOMBRE2_AA} {data.PATERNO_AA} {data.MATERNO_AA}";
                        docNumber = data.CARNET_AA;

                        scriptMYSQL += $"Insert into aporte_activo_{newData.Substring(0, 4)}(cod_base, cedula_identidad, numbol, aporte, fecha, mes, ctacte) " +
                            $"values('{codBase}', '{data.CARNET_AA}', {int.Parse(data.ITEM_AA)}, '{data.DESCUENTO_AA}', '{newData}', {month}, '{ctacte}');";

                        sQLScript += $"INSERT INTO MumanalDatos(cod_base, cedula_identidad, numbol, aporte, fecha, mes, ctacte) VALUES " +
                            $"({codBase}, {data.CARNET_AA}, {int.Parse(data.ITEM_AA)}, '{data.DESCUENTO_AA}', '{newData}', '{month}', '{ctacte}');";
                    }
                }
                result.Add(new ResolveDiferenceMassiveResult
                {
                    Name = name,
                    DocumentNumber = docNumber,
                    ScriptMYSQL = scriptMYSQL,
                    ///ScriptSQLSERVER = sQLScript,
                    MissingData = count

                });
            }

            return result;
        }

        public GetPassiveAportsResponse UnificationActiveAports(GetActiveAportsDto dto)
        {
            GetPassiveAportsResponse result = new GetPassiveAportsResponse();
            var firtMat = Context.MumanalFullActiveBeneficiaries.Where(x => x.cedula_identidad == dto.DocumentNumber[0]).FirstOrDefault();
            var lastMat = Context.MumanalFullActiveBeneficiaries.Where(x => x.cedula_identidad == dto.DocumentNumber[1]).FirstOrDefault();
            List<MinistryActiveContribution> firstBefMinisteryData = new List<MinistryActiveContribution>();
            List<MinistryActiveContribution> lastBefMinisteryData = new List<MinistryActiveContribution>();
            result.DisableOldEnrollment = $"update afiliado_activo set cedula_identidad = '{firtMat.cedula_identidad}000', cod_base = {firtMat.cod_base}000 "+
                $"where cedula_identidad = '{firtMat.cedula_identidad}' and cod_base = '{firtMat.cod_base}';";

            for (int i = 2003; i <= DateTime.Now.Year; i++)
            {
                result.ScriptDisableFirstMat += $"update aporte_activo_{i} set codbase = {firtMat.cod_base}000 , cedula_identidad = {firtMat.cedula_identidad}000, obs = 'Deshabilitado por unificacion'" +
                    $"where cedula_identidad = {firtMat.cedula_identidad} and cod_base = {firtMat.cod_base};";

                result.ScriptDisableFirstConcat += $"update aporte_activo_{i} set codbase = {lastMat.cod_base}000 , cedula_identidad = {lastMat.cedula_identidad}000, obs = 'Deshabilitado por unificacion'" +
                    $"where cedula_identidad = {lastMat.cedula_identidad} and cod_base = {lastMat.cod_base};";

            }
            firstBefMinisteryData = Context.MinistryActiveContributions.Where(x => x.CARNET_AA == firtMat.cedula_identidad).ToList();
            var groupFirst = firstBefMinisteryData.GroupBy(d => d.FECHAAPORTES_AA)
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
            lastBefMinisteryData = Context.MinistryActiveContributions.Where(x => x.CARNET_AA == lastMat.cedula_identidad).ToList();
            var groupLast = lastBefMinisteryData.GroupBy(d => d.FECHAAPORTES_AA)
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
            var aux = groupFirst.Concat(groupLast).ToList();
            foreach (var minData in aux)
            {
                result.ScriptNewAports += $"INSERT INTO aporte_activo_{minData.FECHAAPORTES_AA.ToString("yyyy")} (cod_base, cedula_identidad, numbol, aporte, fecha, mes, ctacte) VALUES " +
                    $"({lastMat.cod_base}, {lastMat.cedula_identidad}, '{minData.ITEM_AA}', '{minData.DESCUENTO_AA}', '{minData.FECHAAPORTES_AA.ToString("yyyy-MM-dd")}', " +
                    $"{minData.FECHAAPORTES_AA.ToString("MM")});";
            }
            result.TotalAports = aux.Count;

            return result;

        }

        public GetPassiveAportsResponse UnificationPassiveAports(GetPassiveAportsDto dto)
        {
            GetPassiveAportsResponse result = new GetPassiveAportsResponse();
            var beneficiaries = Context.MumanalPassiveBeneficiaries.Where(x => x.cedula_identidad == dto.DocumentNumber).ToList();
            var lastMat = beneficiaries.Last();
            var firtMat = beneficiaries.First();
            List<MinistryPassiveContribution> MinisteryData = new List<MinistryPassiveContribution>();
            switch (dto.TypeSearch)
            {
                case 1: //Search DocumentNumber
                    MinisteryData = Context.MinistryPassiveContributions.Where(x => x.CARNET_AP == dto.DocumentNumber).ToList();
                    break;
                case 2: //Search Titular Enrollment
                    var list1 = Context.MinistryPassiveContributions.Where(x => x.T_MATRICULA_AP.Contains(firtMat.mat_titular)).ToList();
                    var list2 = Context.MinistryPassiveContributions.Where(x => x.T_MATRICULA_AP.Contains(lastMat.mat_titular)).ToList();
                    MinisteryData = list1.Concat(list2).ToList();
                    break;
                case 3: //Search Beneficiary Enrollment
                    var list3 = Context.MinistryPassiveContributions.Where(x => x.B_MATRICULA_AP.Contains(firtMat.mat_beneficiario)).ToList();
                    var list4 = Context.MinistryPassiveContributions.Where(x => x.B_MATRICULA_AP.Contains(lastMat.mat_beneficiario)).ToList();
                    MinisteryData = list3.Concat(list4).ToList();
                    break;
            }

            var enrollment = $"{(dto.TypeSearch == 2 ? "mat_titular =" + "'" + (firtMat.mat_titular) + "X'" : "mat_beneficiaro = " + "'" + (firtMat.mat_beneficiario) + "X'")}";
            result.DisableOldEnrollment = $"update afiliado_pasivo set cedula_identidad = '{dto.DocumentNumber}(dis)', {enrollment}, concatenado = '{firtMat.concatenado}(dis)'" +
                $"where cedula_identidad = '{dto.DocumentNumber}' and concatenado = '{firtMat.concatenado}';";

            for (int i = 2003; i <= 2021; i++)
            {
                result.ScriptDisableFirstMat += $"update aporte_pasivo_{i} set concatenado = '(dis)'" +
                    $"where cedula_identidad = {dto.DocumentNumber};";

                result.ScriptDisableFirstConcat += $"update aporte_pasivo_{i} set concatenado = '(dis)'" +
                    $"where concatenado = '{firtMat.concatenado}';";

                result.ScriptDisableLastConcat += $"update aporte_pasivo_{i} set concatenado = '(dis)'" +
                         $"where concatenado = '{lastMat.concatenado}';";
            }

            foreach (var minData in MinisteryData)
            {
                result.ScriptNewAports += $"INSERT INTO aporte_pasivo_{minData.FECHA_AP.ToString("yyyy")} (cod_base, cedula_identidad, concatenado, aporte, fecha, mes) VALUES " +
                    $"(0, {dto.DocumentNumber}, '{lastMat.concatenado}', '{minData.DESCUENTO_AP}', '{minData.FECHA_AP.ToString("yyyy-MM-dd")}', {minData.FECHA_AP.ToString("MM")});";
            }
            result.TotalAports = MinisteryData.Count;

            return result;

        }

        public ResolveDiferenceMassiveResult CompletePassiveAports(GetPassiveAportsDto dto)
        {
            ResolveDiferenceMassiveResult result = new ResolveDiferenceMassiveResult();
            var user = Context.MumanalPassiveBeneficiaries.Where(x => x.cedula_identidad == dto.DocumentNumber).FirstOrDefault();
            var mumAports = Context.MumanalPassiveContributions.Where(x => x.cedula_identidad == user.cedula_identidad).ToList();
            var minAports = Context.MinistryPassiveContributions.Where(x => x.T_MATRICULA_AP == user.mat_titular).ToList();
            int count = 0;
            foreach (var data in minAports)
            {
                var dateSiver = data.FECHA_AP.ToString("d/M/yyyy");
                if (mumAports.Where(x => x.fecha == dateSiver).FirstOrDefault() == null)
                {
                    count++;
                    var newData = data.FECHA_AP.ToString("yyyy-MM-dd");
                    var month = newData.Substring(newData.Length - 5, 2);

                    result.Name = $"{data.NOMBRES_AP} {data.PATERNO_AP} {data.MATERNO_AP}";
                    result.DocumentNumber = data.CARNET_AP;

                    result.ScriptMYSQL += $"INSERT INTO aporte_pasivo_ {newData.Substring(0, 4)}(cod_base, cedula_identidad, concatenado, aporte, fecha, mes) " +
                        $" values('{user.cod_base}', '{data.CARNET_AP}', '{user.concatenado}', '{data.DESCUENTO_AP}','{newData}', {month});";
                }
            }
            result.MissingData = count;
            return result;
        }

        public List<ResolveDiferenceMassiveResult> CompleteMassivePassiveAports(GetPassiveAportsDto dto)
        {
            throw new NotImplementedException();
        }

       
    }
}

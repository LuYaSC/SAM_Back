using SAM.Functions.ResolveCasesSiver.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAM.Functions.ResolveCasesSiver.Business
{
    public interface IResolveDiferenceBusiness
    {
        ResolveDiferenceResult GetCaseData(ResolveDiferenceDto dto);

        ResolveDiferenceResult GetCaseDataBC(ResolveDiferenceDto dto);

        List<ResolveDiferenceMassiveResult> GetCaseDataMassive(ResolveDiferenceDto dto);

        GetPassiveAportsResponse UnificationPassiveAports(GetPassiveAportsDto dto);

        ResolveDiferenceMassiveResult CompletePassiveAports(GetPassiveAportsDto dto);

        List<ResolveDiferenceMassiveResult> CompleteMassivePassiveAports(GetPassiveAportsDto dto);
    }
}

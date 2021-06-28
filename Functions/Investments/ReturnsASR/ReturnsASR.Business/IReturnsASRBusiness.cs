using SAM.Core.Business;
using SAM.Functions.Investments.ReturnsASR.Business.Models;
using System;
using System.Collections.Generic;

namespace SAM.Functions.Investments.ReturnsASR.Business
{
    public interface IReturnsASRBusiness
    {
        Result<List<GetReturnsASRResult>> GetReturnsASR();

        Result<GetBeneficiaryResult> GetBeneficiary(GetBeneficiaryDto dto);

        Result<string> RegistryReturnASR(RegistryReturnASRDto dto);

        Result<string> ModifyRegistryASR(ModifyRegistryASRDto dto);

        Result<string> Delete(ModifyRegistryASRDto dto);
    }
}

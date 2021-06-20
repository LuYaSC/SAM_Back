using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAM.Functions.ResolveCasesSiver.Business.Models
{
    public class GetPassiveAportsResponse
    {
        public int TotalAports { get; set; }

        public string DisableOldEnrollment { get; set; }

        public string ScriptDisableFirstMat { get; set; }

        public string ScriptDisableFirstConcat { get; set; }

        public string ScriptDisableLastConcat { get; set; }

        public string ScriptNewAports { get; set; }
    }
}
 
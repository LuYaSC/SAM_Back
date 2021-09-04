using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAM.Functions.ResolveCasesSiver.Business.Models
{
    public class GetPassiveAportsDto
    {
        public string DocumentNumber { get; set; }

        public int TypeSearch { get; set; }

        public string FirstEnrollment { get; set; }

        public string SecondEnrollment { get; set; }
    }
}

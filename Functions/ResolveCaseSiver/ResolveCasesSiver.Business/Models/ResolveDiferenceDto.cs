using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAM.Functions.ResolveCasesSiver.Business.Models
{
    public class ResolveDiferenceDto
    {
        public string DocumentNumber { get; set; }

        public string CodBase { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string FirstLastName { get; set; }

        public string SecondLastName { get; set; }

        public List<string> Documents { get; set; }
    }
}

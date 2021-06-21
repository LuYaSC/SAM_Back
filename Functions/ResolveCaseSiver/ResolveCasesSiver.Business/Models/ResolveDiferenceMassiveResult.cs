using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAM.Functions.ResolveCasesSiver.Business.Models
{
    public class ResolveDiferenceMassiveResult
    {
        public string DocumentNumber { get; set; }

        public string Name { get; set; }

        public int MissingData { get; set; }

        public string ScriptMYSQL { get; set; }

        public string ScriptSQLSERVER { get; set; }
    }
}

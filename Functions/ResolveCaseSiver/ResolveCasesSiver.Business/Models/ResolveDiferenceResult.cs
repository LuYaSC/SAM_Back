using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAM.Functions.ResolveCasesSiver.Business.Models
{
    public class ResolveDiferenceResult
    {
        public ResolveDiferenceResult()
        {
            Details = new List<DetailDiference>();
        }

        public string DocumentNumber { get; set; }

        public string Name { get; set; }

        public int MissingData { get; set; }

        public string ScriptMYSQL { get; set; }

        public string ScriptSQLSERVER { get; set; }

        public List<DetailDiference> Details { get; set; }
    }

    public class DetailDiference
    {
        public int Id { get; set; }

        public string Date { get; set; }

        public string Amount { get; set; }

        public int QuantityBullet { get; set; }
    }
}

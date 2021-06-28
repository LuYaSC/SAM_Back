using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAM.Functions.Investments.ReturnsASR.Business.Models
{
    public class GetReturnsASRResult
    {
        public int Id { get; set; }

        public string Beneficiary { get; set; }

        public int AsrNumber { get; set; }

        public int ReportNumber { get; set; }

        public decimal Amount { get; set; }

        public string DisbursementVoucher { get; set; }

        public string UserCreation { get; set; }

        public string UserModification { get; set; }

        public DateTime DateCreation { get; set; }

        public DateTime DateModification { get; set; }
    }
}

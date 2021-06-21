using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SAM.Databases.DbSam.Core.Data
{
    public class ControlGift : BaseTrace
    {
        public int BeneficiaryId { get; set; }

        [ForeignKey("BeneficiaryId")]
        public virtual Beneficiary Beneficiary { get; set; }

        public bool HaveBackpack { get; set; }

        public bool HaveSchedule { get; set; }

        public int OfficePlaceId { get; set; }

        [ForeignKey("OfficePlaceId")]
        public virtual OfficePlace OfficePlace { get; set; }

        [MaxLength(500)]
        public string Observations { get; set; }
    }
}

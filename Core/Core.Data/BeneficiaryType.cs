using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SAM.Core.Data
{
    public class BeneficiaryType: BaseLogicalDelete
    {
        [MaxLength(50)]
        public string Description { get; set; }
    }
}

using SAM.Core.DataDb;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SAM.Databases.DbSam.Core.Data
{
    public class OfficePlace : BaseLogicalDelete, IDateCreation, IDateModification
    {
        [MaxLength(100)]
        public string Description { get; set; }

        public int Type { get; set; }

        [MaxLength(100)]
        public string DescriptionType { get; set; }

        public DateTime DateCreation { get; set; }

        public DateTime? DateModification { get; set; }
    }
}

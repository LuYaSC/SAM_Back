using Microsoft.AspNetCore.Identity;
using SAM.Core.DataDb;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAM.Databases.DbSam.Core.Data
{
    public class UserRole : IdentityUserRole<int>, ILogicalDelete, IDateCreation, IDateModification
    {
        public int OfficePlaceId { get; set; }

        [ForeignKey("OfficePlaceId")]
        public virtual OfficePlace OfficePlace { get; set; }

        public DateTime DateCreation { get; set; }

        public DateTime? DateModification { get; set; }

        public bool IsDeleted { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAM.Databases.DbSam.Core.Data
{
    public interface IAudit
    {
        DateTime DateCreation { get; set; }

        DateTime? DateModification { get; set; }

        bool IsDeleted { get; set; }
    }
}

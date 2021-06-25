using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAM.Core.DataDb
{
    public interface IAudit
    {
        DateTime DateCreation { get; set; }

        DateTime? DateModification { get; set; }

        bool IsDeleted { get; set; }
    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SAM.Databases.DbSam.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAM.Core.Business
{
    public interface IBaseBusiness<T, TypeKey, CONTEXT>
       where T : IBase<TypeKey>
       where TypeKey : IEquatable<TypeKey>
       where CONTEXT : IdentityDbContext
    {
        void Dispose();

        T Get(TypeKey id);

        IQueryable<T> List();

        void Remove(TypeKey id);

        T Save(T entity);

        Result<string> WarmUp();
    }
}

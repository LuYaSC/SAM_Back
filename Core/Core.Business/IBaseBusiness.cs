using SAM.Core.DataDb;
using SAM.Databases.DbSam.Core.Data.Context;
using System;
using System.Linq;

namespace SAM.Core.Business
{
    public interface IBaseBusiness<T, TypeKey, CONTEXT>
       where T : IBase<TypeKey>
       where TypeKey : IEquatable<TypeKey>
       where CONTEXT : SAMContext
    {
        void Dispose();

        T Get(TypeKey id);

        IQueryable<T> List();

        void Remove(TypeKey id);

        T Save(T entity);

        Result<string> WarmUp();
    }
}

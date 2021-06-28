﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SAM.Core.DataDb;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace SAM.Databases.DbSam.Core.Data.Context
{
    public class UserLogin : IdentityUserLogin<int>
    { }

    public class UserClaim : IdentityUserClaim<int>
    { }

    public class UserToken : IdentityUserToken<int>
    { }

    public class RoleClaim : IdentityRoleClaim<int>
    { }
    public class SAMContext : IdentityDbContext<ApplicationUser, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public SAMContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var cascadeFKs = modelBuilder.Model.GetEntityTypes().SelectMany(t => t.GetForeignKeys()).Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);
            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            //modelBuilder.HasDefaultSchema("ms");
            //modelBuilder.Entity<>().HasQueryFilter(p => !p.IsDeleted);
            //modelBuilder.Filter("IsDeleted", (ILogicalDelete d) => d.IsDeleted, false);
            /**/
            base.OnModelCreating(modelBuilder);
        }
        //public void DisableFilter<CONTEXT>(CONTEXT context, string nameFilter)
        // where CONTEXT : DbContext
        //{
        //    DynamicFilterExtensions.DisableFilter(context, nameFilter);
        //}

        //public void EnableFilter<CONTEXT>(CONTEXT context, string nameFilter)
        //   where CONTEXT : DbContext
        //{
        //    DynamicFilterExtensions.EnableFilter(context, nameFilter);
        //}


        //public DbSet<AuditGroup> AuditGroup { get; set; }

        public IPrincipal userInfo { get; set; }

        public void Detach<T>(T entity) where T : class
        {
            Entry(entity).State = EntityState.Detached;
        }

        //public void ExecuteCommand(string sql, params object[] parameters)
        //{
        //    Database.ExecuteSqlCommand(sql, parameters);
        //}

        //public T ExecuteScalar<T>(string sql, params object[] parameters)
        //{
        //    return Database.SqlQuery<T>(sql, parameters).Single();
        //}

        //public T ExecuteScalar<T>(string sql, int timeOut, params object[] parameters)
        //{
        //    Database.SetCommandTimeout(timeOut);
        //    try
        //    {
        //        return Database.ex <T>(sql, parameters).Single();
        //    }
        //    finally
        //    {
        //        Database.Connection.Close();
        //    }

        //}

        //public List<T> ExecuteScalarList<T>(string sql, int timeOut, params object[] parameters)
        //{
        //    Database.CommandTimeout = timeOut;
        //    try
        //    {
        //        return Database.SqlQuery<T>(sql, parameters).ToList();
        //    }
        //    finally
        //    {
        //        Database.Connection.Close();
        //    }

        //}

        //public List<T> SqlQuery<T>(string sql, params object[] parameters)
        //{
        //    return Database.sq.SqlQuery<T>(sql, parameters).ToList();
        //}

        public void Remove<T>(T entity)
            where T : class, IBase<int>
        {
            Remove<T, int>(entity);
        }

        public void RemoveRange<T>(List<T> entities)
          where T : class, IBase<int>
        {
            foreach (var entity in entities)
            {
                Remove<T, int>(entity);
            }
        }

        public void RemoveData<T>(List<T> entities)
          where T : class , IBase<int>
        {
            foreach (var entity in entities)
            {
                Entry(entity).State = EntityState.Deleted;
            }
        }

        public void Remove<T, TypeKey>(T entity)
            where T : class, IBase<TypeKey>
            where TypeKey : IEquatable<TypeKey>, IConvertible
        {
            if (entity == null)
            {
                return;
            }
            if (entity is ILogicalDelete entityLogicalDelete)
            {
                entityLogicalDelete.IsDeleted = true;
                Save<T, TypeKey>((T)entityLogicalDelete);

                return;
            }
            Entry(entity).State = EntityState.Deleted;
            SaveChanges();
        }

        public T Save<T>(T entity)
            where T : class, IBase<int>
        {
            return Save<T, int>(entity);
        }

        public T Save<T, TypeKey>(T entity)
            where T : class, IBase<TypeKey>
            where TypeKey : IEquatable<TypeKey>, IConvertible
        {
            SetEntity<T, TypeKey>(entity);
            SaveChanges();
            return entity;
        }

        public void SetEntity<TEntity>(TEntity entity)
            where TEntity : class, IBase<TEntity>
        {
            SetEntity(entity);
        }

        public void SetEntity<TEntity, TypeKey>(TEntity entity)
            where TEntity : class, IBase<TypeKey>
            where TypeKey : IEquatable<TypeKey>, IConvertible
        {
            var claimsIdentity = (ClaimsIdentity)this.userInfo.Identity;
            if (entity == null)
            {
                return;
            }
            if (entity.Id.Equals(0))
            {
                Entry(entity).State = EntityState.Added;
                if (entity is IDateCreation)
                {
                    (entity as IDateCreation).DateCreation = DateTime.Now;
                }
                if (entity is IDateModification)
                {
                    (entity as IDateModification).DateModification = DateTime.Now;
                }
                if (entity is IUserCreation<int>)
                {
                    (entity as IUserCreation<int>).UserCreation = int.Parse(claimsIdentity.Claims.Where(x => x.Type == "identifier").FirstOrDefault().Value);
                }
                if (entity is IUserModification<int>)
                {
                    (entity as IUserModification<int>).UserModification = int.Parse(claimsIdentity.Claims.Where(x => x.Type == "identifier").FirstOrDefault().Value);
                }
                //if (entity is IUserCreation<string>)
                //{
                //    (entity as IUserCreation<string>).UserCreation = this.userInfo.Identity.GetUserId<string>();
                //}
                //if (entity is IUserModification<string>)
                //{
                //    (entity as IUserModification<string>).UserModification = this.userInfo.Identity.GetUserId<string>();
                //}
            }
            else
            {
                UpdateEntity<TEntity, TypeKey>(entity);
            }
        }

        private void UpdateEntity<TEntity, TypeKey>(TEntity entity)
           where TEntity : class, IBase<TypeKey>
           where TypeKey : IEquatable<TypeKey>, IConvertible
        {
            var claimsIdentity = (ClaimsIdentity)this.userInfo.Identity;

            if (entity is IDateModification)
            {
                (entity as IDateModification).DateModification = DateTime.Now;
            }
            if (entity is IUserModification<int>)
            {
                (entity as IUserModification<int>).UserModification = int.Parse(claimsIdentity.Claims.Where(x => x.Type == "identifier").FirstOrDefault().Value);
            }
        }
    }
}

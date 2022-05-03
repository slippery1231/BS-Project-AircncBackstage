using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aircnc_BackStage.Models;
using Microsoft.EntityFrameworkCore;

namespace AircncFrontStage.Repositories
{
    public class DBRepository
    {
        public readonly AircncContext _DbContext;
        public DBRepository(AircncContext DbContext) {

            _DbContext = DbContext;
        }
        public virtual void Create<T>(T entity) where T: class
        {
            _DbContext.Entry(entity).State = EntityState.Added;
        }
        public virtual void Update<T>(T entity) where T : class
        {
            _DbContext.Entry(entity).State = EntityState.Modified;
        }
        public virtual void Delete<T>(T entity) where T : class
        {
            _DbContext.Entry(entity).State = EntityState.Deleted;
        }
        public IQueryable<T> GetAll<T>() where T : class
        {
            return _DbContext.Set<T>();
        }
        public void Save()
        {
            _DbContext.SaveChanges();
        }

        //傳入PK  return 那一筆entity 找不到則return null e
        public TEntity GetEntityById<TEntity>(int? id) where TEntity : class
        {
            return _DbContext.Find<TEntity>(id);
        }

    }
}

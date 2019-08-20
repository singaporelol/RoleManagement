using RoleManagement.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace RoleManagement.EFDAL
{
    public class BaseDal<T> where T : class
    {
        
        public DbContext dbcontext
        {
            get { return GetCurrentDbContex(); }
        }
        public static DbContext GetCurrentDbContex()
        {
            DbContext db = CallContext.GetData("DbContext") as DbContext;
            if (db == null)
            {
                db = new DataModelContainer();
                //db.Configuration.LazyLoadingEnabled = false;
                CallContext.SetData("DbContext", db);
            }
            return db;
        }
        
        #region 封装基类增删改查 
        //对user表进行增删改查封装
        public IQueryable<T> GetEntities(Expression<Func<T, bool>> whereLambda)
        {
            return dbcontext.Set<T>().Where(whereLambda).AsQueryable();
        }

        public IQueryable<T> GetPageEntities<s>(Expression<Func<T, bool>> whereLamda,
                                             Expression<Func<T, s>> orderByLamda,
                                             out int total,
                                            int pageSize, int currentPage, bool isAsync)
        {
            if (isAsync)
            {
                total = dbcontext.Set<T>().Where(whereLamda).Count();
                return dbcontext.Set<T>().Where(whereLamda)
                    .OrderBy(orderByLamda)
                    .Skip(pageSize * (currentPage - 1))
                    .Take(pageSize).AsQueryable();
            }
            else
            {
                total = dbcontext.Set<T>().Where(whereLamda).Count();
                return dbcontext.Set<T>().Where(whereLamda)
                    .OrderByDescending(orderByLamda)
                    .Skip(pageSize * (currentPage - 1))
                    .Take(pageSize).AsQueryable();
            }
        }
        public List<T> GetEntitiesList()
        {
            return dbcontext.Set<T>().ToList();
        }
        public T GetEntityById(int id)
        {
            return dbcontext.Set<T>().Find(id);
        }
        public int SaveChanges()
        {
            return dbcontext.SaveChanges();
        }
        public T Add(T user)
        {
            dbcontext.Set<T>().Add(user);
            dbcontext.SaveChanges();
            return user;
        }
        public IEnumerable<T> AddRange(IEnumerable<T> user)
        {
            dbcontext.Set<T>().AddRange(user);
            dbcontext.SaveChanges();
            return user;
        }
        public bool Update(T user)
        {
            dbcontext.Entry<T>(user).State = System.Data.Entity.EntityState.Modified;
            return dbcontext.SaveChanges() > 0;
        }

        public bool Delete(T user)
        {
            dbcontext.Entry<T>(user).State = System.Data.Entity.EntityState.Deleted;
            return dbcontext.SaveChanges() > 0;
        }

        public bool DeleteRange(IQueryable<T> items)
        {
            
            dbcontext.Set<T>().RemoveRange(items);
            
            return dbcontext.SaveChanges() > 0;
        }
        #endregion

    }
}

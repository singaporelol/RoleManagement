using RoleManagement.EFDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RoleManagement.Service
{
    public abstract class BaseService<T> where T:class
    {
        public BaseDal<T> GetCurrentDal{get; set;}
        public BaseService()
        {
            getCurrentDal();
        }
        abstract public void getCurrentDal();
        public T GetEntityById(int id)
        {
            return GetCurrentDal.GetEntityById(id);
        }

        public IQueryable<T> GetEntities(Expression<Func<T, bool>> whereLambda)
        {
            return GetCurrentDal.GetEntities(whereLambda);
        }

        public IQueryable<T> GetPageEntities<s>(Expression<Func<T, bool>> whereLamda,
                                                        Expression<Func<T, s>> orderByLamda,
                                                        out int total,
                                                        int pageSize, int currentPage, bool isAsync)
        {
            return GetCurrentDal.GetPageEntities<s>(whereLamda, orderByLamda, out total, pageSize, currentPage, isAsync);
        }

        public List<T> GetEntitiesList()
        {
            return GetCurrentDal.GetEntitiesList();
        }
        public T Add(T user)
        {
            return GetCurrentDal.Add(user);
        }
        public bool Update(T user)
        {
            return GetCurrentDal.Update(user);
        }
        public bool Delete(T user)
        {
            return GetCurrentDal.Delete(user);
        }

        public bool DeleteRange(Array user)
        {
            return GetCurrentDal.DeleteRange(user);
        }

    }
}

using RoleManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RoleManagement.EFDAL
{
    public class UserInfoDal:BaseDal<UserInfo>
    {
        //DataModelContainer dbcontext = new DataModelContainer();
        //public void test()
        //{
        //    dbcontext.UserInfo.RemoveRange()
        //}
        
        //对user表进行增删改查封装
        #region 未进行基类封装之前的代码
        //public IQueryable<User> GetUsers(Expression<Func<User,bool>> whereLambda)
        //{
        //    return dbcontext.Users.Where(whereLambda).AsQueryable();
        //}

        //public IQueryable<User> GetPageUsers<s>(Expression<Func<User,bool>> whereLamda, 
        //                                     Expression<Func<User,s>> orderByLamda,
        //                                     out int total,
        //                                    int pageSize, int currentPage, bool isAsync)
        //{
        //    if (isAsync)
        //    {
        //        total=dbcontext.Users.Where(whereLamda).Count();
        //        return dbcontext.Users.Where(whereLamda)
        //            .OrderBy(orderByLamda)
        //            .Skip(pageSize * (currentPage-1))
        //            .Take(pageSize).AsQueryable();
        //    }
        //    else
        //    {
        //        total = dbcontext.Users.Where(whereLamda).Count();
        //        return dbcontext.Users.Where(whereLamda)
        //            .OrderByDescending(u => u.Id)
        //            .Skip(pageSize * (currentPage - 1))
        //            .Take(pageSize).AsQueryable();
        //    }
        //}
        //public List<User> GetUserList()
        //{
        //    return dbcontext.Users.ToList();
        //}
        //public User GetUserById(int id)
        //{
        //    return dbcontext.Users.Find(id);
        //}

        //public User Add(User user)
        //{
        //    dbcontext.Users.Add(user);
        //    dbcontext.SaveChanges();
        //    return user;
        //}

        //public bool Update(User user)
        //{
        //     dbcontext.Entry<User>(user).State = System.Data.Entity.EntityState.Modified;
        //    return dbcontext.SaveChanges() > 0;
        //}

        //public bool Delete(User user)
        //{
        //    dbcontext.Entry<User>(user).State = System.Data.Entity.EntityState.Deleted;
        //    return dbcontext.SaveChanges() > 0;
        //} 
        #endregion

    }
}

using RoleManagement.EFDAL;
using RoleManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {


            #region 添加数据库
            //test test = new test
            //{
            //    name = "zhangsan",
            //    age = 19
            //};

            //dbcontext.tests.Add(test);
            //dbcontext.SaveChanges(); 
            #endregion

            #region 修改
            //dbcontext.Entry<test>(new test
            //{
            //    Id = 1,
            //    name = "lisi",
            //    age = 99
            //}).State = System.Data.Entity.EntityState.Modified;

            //dbcontext.SaveChanges(); 
            #endregion

            #region 查询
            //test t= dbcontext.tests.Where(u => u.Id == 1).ToList()[0];

            //var temp = from u in dbcontext.tests
            //           where u.Id == 1
            //           select u;
            //foreach(var k in temp)
            //{
            //    Console.WriteLine(k.Id + " " + k.name);
            //} 
            #endregion

            #region 导航属性添加
            //student s = new student()
            //{
            //    age = 18,
            //    name = "zhangsan2",
            //};

            //dbcontext.students.Add(s);
            //dbcontext.students.Add(new student()
            //{
            //    age = 19,
            //    name = "lisi2"
            //});

            //@class c = new @class()
            //{
            //    classname = "5n2"
            //};

            //dbcontext.classes.Add(c);
            ////关联2个实体： 1个班级对多个学生
            //c.students.Add(s);

            //dbcontext.SaveChanges(); 
            #endregion

            #region 批量删除数据
            //@class s = dbcontext.classes.Where(u => u.Id > 0).ToList()[0];
            //dbcontext.Entry(s).State = System.Data.Entity.EntityState.Deleted;
            //IQueryable<student> ss = dbcontext.students.Where(u => u.classId == s.Id);
            //dbcontext.students.RemoveRange(ss);
            //dbcontext.SaveChanges();
            #endregion

           
            Console.WriteLine("asdf");
            Console.ReadLine();
        }
    }



}

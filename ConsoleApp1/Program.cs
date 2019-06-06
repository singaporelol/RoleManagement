using RoleManagement.EFDAL;
using RoleManagement.Model;
using RoleManagement.Utils;
using System;
using System.Collections;
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

            #region 递归循环加载菜单
            //List<Hashtable> listMenu = new List<Hashtable>();
            //Hashtable ht1 = new Hashtable();
            //ht1.Add("id", 1);
            //ht1.Add("pid", -1);
            //ht1.Add("url", "/");
            //ht1.Add("name", "首页");
            //listMenu.Add(ht1);

            //Hashtable ht2 = new Hashtable();
            //ht2.Add("id", 2);
            //ht2.Add("pid", -1);
            //ht2.Add("url", "/news");
            //ht2.Add("name", "资讯");
            //listMenu.Add(ht2);

            //Hashtable ht3 = new Hashtable();
            //ht3.Add("id", 3);
            //ht3.Add("pid", 2);
            //ht3.Add("url", "/news/hot");
            //ht3.Add("name", "热点");
            //listMenu.Add(ht3);

            //Hashtable ht4 = new Hashtable();
            //ht4.Add("id", 4);
            //ht4.Add("pid", 2);
            //ht4.Add("url", "/news/latest");
            //ht4.Add("name", "滚动新闻");
            //listMenu.Add(ht4);

            //Hashtable ht5 = new Hashtable();
            //ht5.Add("id", 5);
            //ht5.Add("pid", 4);
            //ht5.Add("url", "/news/latest/international");
            //ht5.Add("name", "国际快讯");
            //listMenu.Add(ht5);

            //Hashtable ht6 = new Hashtable();
            //ht6.Add("id", 6);
            //ht6.Add("pid", -1);
            //ht6.Add("url", "/domain");
            //ht6.Add("name", "行业");
            //listMenu.Add(ht6);

            //Hashtable ht7 = new Hashtable();
            //ht7.Add("id", 7);
            //ht7.Add("pid", 5);
            //ht7.Add("url", "/news/latest/international/politics");
            //ht7.Add("name", "政治");
            //listMenu.Add(ht7);

            //Hashtable ht8 = new Hashtable();
            //ht8.Add("id", 8);
            //ht8.Add("pid", 5);
            //ht8.Add("url", "/news/latest/international/military");
            //ht8.Add("name", "军事");
            //listMenu.Add(ht8);

            //List<MenuTreeViewModel> list= GetMenuTree(listMenu, -1); 
            #endregion
            
            #region 多对多关联表测试
            //DataModelContainer dbContainer = new DataModelContainer();
            //dbContainer.classes.Add(new classes
            //{
            //    Name = "4N1"
            //});
            //dbContainer.classes.Add(new classes
            //{
            //    Name = "5N1"
            //});
            //dbContainer.teacher.Add(new teachers
            //{
            //    Name = "zhangsan"
            //});
            //teachers t=dbContainer.teacher.Add(new teachers
            //{
            //    Name = "lisi"
            //});
            //List<teachers> t = new List<teachers>();
            //t = dbContainer.teacher.ToList();
            //dbContainer.classes.Where(u => u.Name == "5N1").FirstOrDefault().teachers.Add(t);
            //dbContainer.teacher.Where(u => u.Name == "zhangsan").FirstOrDefault().classes.Add(dbContainer.classes.Where(u => u.Name == "4N1").FirstOrDefault());
            //dbContainer.SaveChanges(); 
            #endregion


            InitializeDatabase ID = new InitializeDatabase();


            Console.WriteLine("asdf");
            Console.ReadLine();
        }

        public static List<MenuTreeViewModel> GetMenuTree(List<Hashtable> list, int pid)
        {
            List<MenuTreeViewModel> tree = new List<MenuTreeViewModel>();
            var children = list.Where(m => m["pid"].ToString() == pid.ToString()).ToList();
            if (children.Count > 0)
            {
                for (var i = 0; i < children.Count; i++)
                {
                    MenuTreeViewModel itemMenu = new MenuTreeViewModel();
                    itemMenu.item = children[i];
                    itemMenu.children = GetMenuTree(list, Convert.ToInt32(children[i]["id"]));
                    tree.Add(itemMenu);
                }
            }
            return tree;
        }
    }


    public class MenuTreeViewModel
    {
        public Hashtable item { set; get; }

        public List<MenuTreeViewModel> children { set; get; }
    }
}

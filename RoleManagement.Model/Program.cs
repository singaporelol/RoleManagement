using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleManagement.Model
{
    public partial class Action
    {
         public List<Action> ChildMenu { get; set; }
    }
}

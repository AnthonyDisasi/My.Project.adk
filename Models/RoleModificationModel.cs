using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.Project.adk.Models
{
    public class RoleModificationModel
    {
        public string RoleName { get; set; }
        public string RoleId { get; set; }
        public string[] IdsToAdd { get; set; }
        public string[] IdsToDelete { get; set; }
    }
}

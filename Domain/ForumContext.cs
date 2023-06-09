using BusinessLogic.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ForumContext
    {
        public UserModel uData { get; set; }
        public List<RoleModel> uRole { get; set; }
    }
}

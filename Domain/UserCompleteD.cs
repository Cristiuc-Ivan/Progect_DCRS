using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UserCompleteD
    {
        public int UserRole_ID { get; set; }
        public int User_ID { get; set; }
        public string User_Email { get; set; }
        public string User_Login { get; set; }
        public string User_Password { get; set; }
        public int Role_ID { get; set; }
        public string Role_Name { get; set; }
    }
}

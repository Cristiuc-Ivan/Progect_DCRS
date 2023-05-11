using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        //public string UserRoles { get; set; }
        public virtual ICollection<RoleModel> Roles { get; }

    }

/*    public partial class Role
    {
        public int id { get; set; }
        public string name { get; set; }
        public virtual ICollection<User_role> UserRoles { get; set; }
    }

    public partial class User_role
    {
        [Key, ForeignKey("User"), Column(Order = 0)]
        public int user_id { get; set; }
        [Key, ForeignKey("Role"), Column(Order = 1)]
        public int role_id { get; set; }
        public virtual Role Role { get; }
        public virtual UserModel User { get; set; }
    }*/
}

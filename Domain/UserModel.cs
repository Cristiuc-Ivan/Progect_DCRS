using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

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
        public HttpPostedFileBase ProfilePicture { get; set; }
        public virtual ICollection<RoleModel> Roles { get; }

    }

}

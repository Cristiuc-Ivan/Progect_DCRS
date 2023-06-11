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

        [Required(ErrorMessage = "Email is Required")]
        [StringLength(40)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Login is required")]
        [StringLength(20)]
        public string Login { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [StringLength(20)]
        public string Password { get; set; }
        //public string UserRoles { get; set; }
        public HttpPostedFileBase ProfilePicture { get; set; }
        public virtual ICollection<RoleModel> Roles { get; }

    }

}

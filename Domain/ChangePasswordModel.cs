using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ChangePasswordModel
    {
        [StringLength(30)]
        [Required(ErrorMessage = "Password is Required")]
        public string NewPassword { get; set; }
        [StringLength(30)]
        [Required(ErrorMessage = "Password is Required")]
        public string OldPassword { get; set; }
        [StringLength(30)]
        [Required(ErrorMessage = "Password is Required")]
        public string ConfirmationPassword { get; set; }
    }
}

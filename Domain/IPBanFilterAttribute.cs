using BusinessLogic.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Domain
{
    public class IPBanFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Custom logic to be executed before the action method is invoked
            // 10 is max amount of incorrect login enter
            // user enters, enters data if its more than 10 times 
            // then its banned 
            StorageEntities db = new StorageEntities();
            // Get the IP address

            string ipAddress = HttpContext.Current.Request.UserHostAddress;
            if (db.IPs.Where(model => model.Ip_Address == ipAddress).FirstOrDefault() != null)
            {

            }
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            // Custom logic to be executed after the action method is invoked
        }
    }
}

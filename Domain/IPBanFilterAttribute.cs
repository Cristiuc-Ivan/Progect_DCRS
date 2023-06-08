using BusinessLogic.DB;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Domain
{
    public class IPBanFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            StorageEntities db = new StorageEntities();

            string ipAddress = HttpContext.Current.Request.UserHostAddress;
            IP generalIP = db.IPs.Where(model => model.Ip_Address == ipAddress).FirstOrDefault();
            if (generalIP == null)
            {
                IP iP = new IP
                {
                    Ip_Address = ipAddress,
                    IP_Banned = false,
                    IP_CreatedAt = DateTime.Now,
                    IP_wrongAtt = 0
                };
                db.IPs.Add(iP);
            }
            else
            {
                if (generalIP.IP_Banned == true)
                {
                    DateTime lastLoginAttempt = generalIP.IP_CreatedAt.Value;
                    TimeSpan difference = DateTime.Now - lastLoginAttempt;
                    if (difference > TimeSpan.FromMinutes(1))
                    {
                        generalIP.IP_wrongAtt = 0;
                        generalIP.IP_Banned = false;
                    }
                }
                else
                {
                    generalIP.IP_wrongAtt++;
                    generalIP.IP_CreatedAt = DateTime.Now;
                }
                if (generalIP.IP_wrongAtt > 10)
                {
                    generalIP.IP_Banned = true;
                    filterContext.Result = new HttpStatusCodeResult(403, "Access Forbidden");
                    base.OnActionExecuting(filterContext);
                }
            }
            db.SaveChanges();
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            // Custom logic to be executed after the action method is invoked
        }
    }
}

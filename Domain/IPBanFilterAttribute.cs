using BusinessLogic.DB;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Domain
{
    public class IPBanFilterAttribute : ActionFilterAttribute
    {
        StorageEntities db = new StorageEntities();
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string ipAddress = HttpContext.Current.Request.UserHostAddress;

            IP generalIP = db.IPs
                .Where(model => model.Ip_Address == ipAddress)
                .FirstOrDefault();

            if (generalIP != null && generalIP.IP_Banned == true)
            {
                DateTime lastLoginAttempt = generalIP.IP_CreatedAt.Value;
                TimeSpan difference = DateTime.Now - lastLoginAttempt;
                if (difference > TimeSpan.FromMinutes(2))
                {
                    generalIP.IP_wrongAtt = 0;
                    generalIP.IP_Banned = false;
                    db.SaveChanges();
                }
                else
                {
                    filterContext.Result = new HttpStatusCodeResult(403, "Access Forbidden");
                    base.OnActionExecuting(filterContext);
                }
            }
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.HttpContext.Request.HttpMethod == "POST")
            {
                // we check if the model data is valid here
                // if its not valid then we proceed with the BAN logic

                string ipAddress = HttpContext.Current.Request.UserHostAddress;

                IP generalIP = db.IPs
                    .Where(model => model.Ip_Address == ipAddress)
                    .FirstOrDefault();

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
                    // if user submitted form, we check if he exists in first IF
                    // if he does exist we go here and do the following:
                    // we ban-> increment wrongAttempts and on the first method
                    // we check if the ban time has expired
                    // WE MUST CHECK IF THE DATA WAS INCORRECT
                    // Get the value of a specific variable from the action method

                    var formValues = filterContext.HttpContext.Request.Form;
                    var login = formValues["UserLogin"];
                    var password = formValues["Password"];
                    bool IsValidUser = db.Users.Any(user => user.User_Login.ToLower() == login && user.User_Password == password);

                    if (!IsValidUser || !filterContext.Controller.ViewData.ModelState.IsValid)
                    {
                        generalIP.IP_wrongAtt++;
                        generalIP.IP_CreatedAt = DateTime.Now;
                        if (generalIP.IP_wrongAtt > 10)
                        {
                            generalIP.IP_Banned = true;
                        }
                    }
                    else
                    {
                        generalIP.IP_wrongAtt = 0;
                        generalIP.IP_Banned = false;

                    }
                }
                db.SaveChanges();
            }
        }
    }
}

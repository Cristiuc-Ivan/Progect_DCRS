using Web.App_Start;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Security.Principal;
using Domain;
using System.Web.Configuration;

namespace Web
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            //Database.SetInitializer(new CreateDatabaseIfNotExists<StorageEntities>());
            //using (var dbContext = new StorageEntities())
            //{
            //    dbContext.Database.CreateIfNotExists();
            //}
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            // get the cookie
            HttpCookie authCookie = Request.Cookies.Get(FormsAuthentication.FormsCookieName);
            if (authCookie != null)
            {
                // get the ticket
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
                string[] udata = ticket.UserData.Split('|');
                UsersRoleProvider usersRoleProvider = new UsersRoleProvider();
                string[] temp = usersRoleProvider.GetRolesForUser(udata[0]);
                FormsIdentity identity = new FormsIdentity(ticket);
                GenericPrincipal gIdentity = new GenericPrincipal(identity, temp);
                HttpContext.Current.User = gIdentity;
            }
        }
    }
}
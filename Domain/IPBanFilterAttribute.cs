using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Domain
{
    public class IPBanFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            int a = 0; int b = 0; int c = 0; int d = 0; int e = 0; int f = 0;
            a = 3;
            b = 4; c = 5; d = 6;
            e = 7; f = 8;

            // Custom logic to be executed before the action method is invoked
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            int a = 0; int b = 0; int c = 0; int d = 0; int e = 0; int f = 0;
            a = 3;
            b = 4; c = 5; d = 6;
            e = 7; f = 8;

            // Custom logic to be executed after the action method is invoked
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLOGIN2.Helpers
{
    public class SessionControlAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["studentid"] == null)
            {
                HttpContext.Current.Response.Redirect("~/Account/Login");
            }
        }
    }
}
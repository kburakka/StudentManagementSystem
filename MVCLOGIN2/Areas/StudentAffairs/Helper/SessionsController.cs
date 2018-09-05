using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLOGIN2.Areas.StudentAffairs.Helper
{
   
        public class SessionsControl : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                if (HttpContext.Current.Session["Username"] == null)
                {
                    HttpContext.Current.Response.Redirect("~/StudentAffairs/Index/Login");
                }
            }
        }
}
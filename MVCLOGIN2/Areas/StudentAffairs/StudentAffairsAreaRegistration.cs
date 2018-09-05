using System.Web.Mvc;

namespace MVCLOGIN2.Areas.StudentAffairs
{
    public class StudentAffairsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "StudentAffairs";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "StudentAffairs_default",
                "StudentAffairs/{controller}/{action}/{id}",
                new { controller = "StudentAffairs/Index", action = "Login", id = UrlParameter.Optional }
            );
        }
    }
}
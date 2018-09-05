using System.Web.Mvc;

namespace MVCLOGIN2.Areas.Instructor
{
    public class InstructorAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Instructor";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Instructor_default",
                "Instructor/{controller}/{action}/{id}",
                new { controller = "Instructor/InstAccount", action = "Login" , id = UrlParameter.Optional }
                
            );
        }
    }
}
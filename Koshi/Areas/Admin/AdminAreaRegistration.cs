using System.Web.Mvc;

namespace Koshi.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        // admin area registration is default now
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
using System.Web.Mvc;

namespace CNCDataManager.Areas.Selection
{
    public class SelectionAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Selection";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Selection_default",
                "Selection/{controller}/{action}/{id}",
                new { action = "Index", controller= "Selection", id = UrlParameter.Optional }
            );
        }
    }
}
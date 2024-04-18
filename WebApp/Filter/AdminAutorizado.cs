using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApp.Filter
{
    public class AdminAutorizado : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if(context.HttpContext.Session.GetString("Rol") != "Administrador")
            {
                context.Result = new RedirectResult ("/home/index");
            }
        }
    }
}

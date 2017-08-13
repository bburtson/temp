using Microsoft.AspNetCore.Mvc.Filters;

namespace USTVA.Controllers.FilterAttributes
{
    // custom Cross origin attribute.. super handy but i need to lookinto performance I think a policy
    // configuration in startup might possibly be best for performance but for this sites purposes it does the trick.
    public class AllowCrossOriginAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.HttpContext.Request.HttpContext.Response.Headers
                .Add("Access-Control-Allow-Origin", "*");

            base.OnActionExecuting(filterContext);
        }
    }
}

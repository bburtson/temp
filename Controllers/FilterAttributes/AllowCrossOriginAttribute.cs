using Microsoft.AspNetCore.Mvc.Filters;

namespace USTVA.Controllers.FilterAttributes
{
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

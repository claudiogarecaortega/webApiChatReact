using System.Web.Mvc;

namespace Libreria.Attributes
{
    public class OperationAttribute : ActionFilterAttribute
    {
        public OperationAttribute(bool re)
        {
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //var userId = filterContext.HttpContext.User.Identity.GetUserId();
            //var userManager = filterContext.HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            //if (!userManager.IsEmailConfirmed(userId))
            //{
            //    filterContext.Result =
            //        new RedirectToRouteResult(
            //            new RouteValueDictionary(new
            //            {
            //                controller = "ConstrollerNameToRedirect",
            //                action = "ActionMethodToRedirect"
            //            }));
            //}
        }
    }
}

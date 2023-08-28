using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using YellowCart.Models;

namespace YellowCart.Controllers
{
    public class AdminAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var UID = context.HttpContext.Session.GetInt32("Id");
            if (UID != 0) 
            {
                //var loggedUser = JsonConvert.DeserializeObject<Users>();
            }
            base.OnActionExecuting(context);
        }
    }
}

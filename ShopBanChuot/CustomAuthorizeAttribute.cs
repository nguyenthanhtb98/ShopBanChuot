using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopBanChuot
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public string ViewName { get; set; }
        public CustomAuthorizeAttribute()
        {
            ViewName = "Authorize Failed";
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            IsUserAuthorize(filterContext);
        }
        void IsUserAuthorize(AuthorizationContext filterContext)
        {
            //người dùng đã được cấp quyền
            if (filterContext.Result == null) return;
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                ViewDataDictionary dic = new ViewDataDictionary();
                var res = new ViewResult() { ViewName = this.ViewName, ViewData = dic };
                filterContext.Result = res;
            }
        }
    }
}
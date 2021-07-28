using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebTruyen.Helper
{
    public class LoginTacGia: AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (Helper.Auth.user() == null || Helper.Auth.user().TacGias.ToList().Count <=0)
            {
                HttpContext.Current.Response.Redirect("/");
            }
            else
            {
                return true;
            }
            return false;
        }
    }
}
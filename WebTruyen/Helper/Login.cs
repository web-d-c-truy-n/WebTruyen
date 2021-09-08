using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebTruyen.Helper
{
    public class Login: AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {            
            if (Auth.user() == null)
            {               
                HttpContext.Current.Response.Redirect("/");                
            } else if (Auth.user().TinhTrang == ttTaiKhoan.biKhoanVV)
            {
                Auth.logout();
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
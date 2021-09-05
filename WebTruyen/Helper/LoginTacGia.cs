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
            if (Helper.Auth.user() == null || !(new int[] {vtTaiKhoan.tacGiaDaDuyet,vtTaiKhoan.dichGiaDaDuyet}).Contains(Auth.user().VaiTro))
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTruyen.Models;
using WebTruyen.Helper;
namespace WebTruyen.Models
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class LoginAdmin : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            TaiKhoan ad = Auth.user();
            if (ad == null || ad.VaiTro != vtTaiKhoan.admin)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
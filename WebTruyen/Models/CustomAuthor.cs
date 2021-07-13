using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTruyen.Models;
namespace WebTruyen.Models
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomAuthor : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            Admin ad = (Admin)HttpContext.Current.Session["TaikhoanAdmin"];
            if (ad == null)
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
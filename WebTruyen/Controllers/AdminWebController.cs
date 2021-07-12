using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebTruyen.Controllers
{
    public class AdminWebController : Controller
    {
        // GET: AdminWeb
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LoginAdmin()
        {
            return View();
        }
        public ActionResult ThemAdmin()
        {
            return View();
        }
    }
}
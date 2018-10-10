using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructuresAssignment2._0.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Stack()
        {
            return View();
        }

        public ActionResult Queue()
        {
            return View();
        }

        public ActionResult Dictionary()
        {
            return View();
        }

        public ActionResult Exit()
        {
            return Redirect("https://byu.edu");
        }
    }
}
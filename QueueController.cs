using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructuresAssignment2._0.Controllers
{
    public class QueueController : Controller
    {
        static Queue<string> myQueue = new Queue<string>();
        // GET: Queue
        public ActionResult Index()
        {
            ViewBag.Berries = myQueue;
            return View();
        }
        public ActionResult AddOne()
        {
            myQueue.Enqueue("New Entry " + myQueue.Count + 1);
            ViewBag.Berries = myQueue;
            return View("Index");
        }
    }
}
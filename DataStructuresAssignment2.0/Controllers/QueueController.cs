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
        static bool bDisplay = false;
        // GET: Queue
        public ActionResult Index()
        {
            ViewBag.QueueDisplay = bDisplay;
            ViewBag.MyQueue = myQueue;
            return View();
        }

        public ActionResult AddOne()
        {
            myQueue.Enqueue("New Entry " + (myQueue.Count + 1));
            ViewBag.QueueDisplay = bDisplay;
            ViewBag.MyQueue = myQueue;
            return View("Index");
        }

        public ActionResult AddMany()
        {
            myQueue.Clear();
            while (myQueue.Count <= 2000)
            {
                myQueue.Enqueue("New Entry " + (myQueue.Count + 1));
            }
            ViewBag.QueueDisplay = bDisplay;
            ViewBag.MyQueue = myQueue;
            return View("Index");
        }

        public ActionResult Display()
        {
            if (myQueue.Count == 0)
            {
                bDisplay = true;
                ViewBag.Show = "There's nothing to be displayed :<";
            }
            else
            {
                bDisplay = true;
                ViewBag.QueueDisplay = bDisplay;
                ViewBag.MyQueue = myQueue;
            }
            return View("Index");
        }

        public ActionResult Delete()
        {
            ViewBag.QueueDisplay = bDisplay;
            if (myQueue.Count == 0)
            {
                ViewBag.Show = "There's nothing you can delete :<";
            }
            else
            {
                myQueue.Dequeue();
                ViewBag.MyQueue = myQueue;
            }
            return View("Index");
        }

        public ActionResult Clear()
        {
            bDisplay = false;
            myQueue.Clear();
            ViewBag.QueueDisplay = bDisplay;
            ViewBag.Show = "If you'd like to see the Queue, please click on the display button on the side bar :>";
            return View("Index");
        }

        public ActionResult Search()
        {
            ViewBag.QueueDisplay = bDisplay;

            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            bool bSearch = myQueue.Contains("New Entry 3");
            sw.Stop();

            TimeSpan ts = sw.Elapsed;
            if (bSearch == true)
            {
                ViewBag.Show = "Found New Entry 3";
            }
            else
            {
                ViewBag.Show = "Didn't find New Entry 3";
            }
            ViewBag.Show += " in " + ts;
            ViewBag.MyQueue = myQueue;
            return View("Index");
        }

        public ActionResult Exit()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
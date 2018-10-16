using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructuresAssignment2._0.Controllers
{
    public class StackController : Controller
    {
        static Stack<string> myStack = new Stack<string>();
        static bool bDisplay = false;
        // GET: Stack
        public ActionResult Index()
        {
            ViewBag.MyStack = myStack;
            return View();
        }

        //Code for the AddOne function- Adds one item to stack
        public ActionResult AddOne()
        {

            myStack.Push("New Entry " + (myStack.Count + 1));
            ViewBag.MyStack = myStack;

            return View("Index");
        }

        //Adds many items to stack
        public ActionResult AddMany()
        {
            myStack.Clear();
            while (myStack.Count < 2000)
            {
                myStack.Push("New Entry " + (myStack.Count + 1));
            }
            ViewBag.MyStack = myStack;
            return View("Index");
        }

        //Displays the current contents of the stack
        public ActionResult Display()
        {
            if (myStack.Count == 0)
            {
                return View("Error");
            }
            else
            {
                ViewBag.MyStack = myStack;
                return View("Display");
            }
        }

        //Deletes one item from off the stack
        public ActionResult Delete()
        {
            if (myStack.Count == 0)
            {
                return View("Error");
            }
            else
            {
                myStack.Pop();
            }
            return View("Delete");
        }

        //Clears the whole contents from the whole stack
        public ActionResult Clear()
        {
            myStack.Clear();
            return View("Clear");

        }

        //Searches for a specific content on the stack
        public ActionResult Search()
        {
            ViewBag.QueueDisplay = bDisplay;

            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            bool bSearch = myStack.Contains("New Entry 3");
            sw.Stop();

            TimeSpan ts = sw.Elapsed;
            if (bSearch == true)
            {
                ViewBag.Search = "Found New Entry 3";
            }
            else
            {
                ViewBag.Search = "Didn't find New Entry 3";
            }
            ViewBag.Search += " in " + ts;
            ViewBag.MyStack = myStack;
            return View("Search");
        }

        //Returns to the main menu
        public ActionResult Return()
        {
            return View("Index");
        }
    }
}
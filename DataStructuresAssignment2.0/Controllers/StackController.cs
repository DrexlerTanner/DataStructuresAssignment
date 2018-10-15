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
        
        // Method for adding one item to stack
        public ActionResult AddOne()
        {

            myStack.Push("New Entry " + (myStack.Count + 1));
            ViewBag.MyStack = myStack;

            return View("Index");
        }

        //Method for adding 2000 items to stack
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

        //Method for displaying the contents of the stack, or to call an error display if stack is empty
        public ActionResult Display()
        {
            if(myStack.Count == 0)
            {
                return View("Error");
            }
            else { 
            ViewBag.MyStack = myStack;
            return View("Display");
            }
        }

        //Method to delete one item from off the stack
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

        //Method to delete all contents of the stack
        public ActionResult Clear()
        {
            myStack.Clear();
            return View("Clear");

        }

        //Method to search for one particular item on the stack
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

        //Method to return to the home screen
        public ActionResult Return()
        {
            return View("Index");
        }
    }
}
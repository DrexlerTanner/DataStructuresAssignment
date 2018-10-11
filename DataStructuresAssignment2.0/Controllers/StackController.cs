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
        // GET: Stack
        public ActionResult Index()
        {
            ViewBag.MyStack = myStack;
            return View();
        }

        public ActionResult AddOne()
        {

            myStack.Push("New Entry " + (myStack.Count + 1));
            ViewBag.MyStack = myStack;

            return View("Index");
        }

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
        public ActionResult Clear()
        {
            myStack.Clear();
            return View("Clear");

        }
        public ActionResult Return()
        {
            return View("Index");
        }
    }
}
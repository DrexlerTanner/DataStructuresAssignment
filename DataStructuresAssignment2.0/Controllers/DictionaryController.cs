using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructuresAssignment2._0.Controllers
{
    public class DictionaryController : Controller
    {
        static Dictionary<string, int> myDictionary = new Dictionary<string, int>();
        static bool bDictionaryDisplay = false;
        // GET: Dictionary
        public ActionResult Index()
        {
            ViewBag.DictionaryDisplay = bDictionaryDisplay;
            ViewBag.MyDictionary = myDictionary;
            return View();
        }

        public ActionResult AddOne()
        {
            myDictionary.Add("New Entry " + (myDictionary.Count + 1), myDictionary.Count + 1);
            ViewBag.DictionaryDisplay = bDictionaryDisplay;
            ViewBag.MyDictionary = myDictionary;
            return View("Index");
        }

        public ActionResult AddMany()
        {
            myDictionary.Clear();
            while (myDictionary.Count <= 2000)
            {
                myDictionary.Add("New Entry " + (myDictionary.Count + 1), myDictionary.Count + 1);
            }
            ViewBag.DictionaryDisplay = bDictionaryDisplay;
            ViewBag.MyDictionary = myDictionary;
            return View("Index");
        }

        public ActionResult Display()
        {
            if (myDictionary.Count == 0)
            {
                bDictionaryDisplay = true;
                ViewBag.Show = "There's nothing to be displayed :<";
            }
            else
            {
                bDictionaryDisplay = true;
                ViewBag.DictionaryDisplay = bDictionaryDisplay;
                ViewBag.MyDictionary = myDictionary;
            }
            return View("Index");
        }

        public ActionResult Delete()
        {
            ViewBag.DictionaryDisplay = bDictionaryDisplay;
            if (myDictionary.Count == 0)
            {
                ViewBag.Show = "There's nothing you can delete :<";
            }
            else
            {
                myDictionary.Remove("New Entry " + (myDictionary.Count));
                ViewBag.Show = $"New Entry {myDictionary.Count} has been deleted.";
                ViewBag.MyDictionary = myDictionary;
            }
            return View("Index");
        }

        public ActionResult Clear()
        {
            bDictionaryDisplay = false;
            myDictionary.Clear();
            ViewBag.DictionaryDisplay = bDictionaryDisplay;
            ViewBag.Show = "If you'd like to see the Dictionary, please click on the display button on the side bar :>";
            return View("Index");
        }

        public ActionResult Search()
        {
            ViewBag.DictionaryDisplay = bDictionaryDisplay;

            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            bool bSearch = myDictionary.ContainsKey("New Entry 3");
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
            ViewBag.Show += " in " + ts.ToString("ss\\.fffffff");
            ViewBag.MyDictionary = myDictionary;
            return View("Index");
        }

        public ActionResult Exit()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
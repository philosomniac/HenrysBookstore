using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HenrysBookstore.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Inventory()
        {
            List<BOOK> BookList = new List<BOOK>(); // holds all of the books we're going to display

            using (HENRYEntities dbContext = new HENRYEntities())
            {
                var bookQuery = dbContext.BOOKs.Where(x => x != null);

                foreach (BOOK b in bookQuery)
                {
                    BookList.Add(b);
                }

                ViewBag.BookList = BookList;
            }

            return View();
        }
    }
}
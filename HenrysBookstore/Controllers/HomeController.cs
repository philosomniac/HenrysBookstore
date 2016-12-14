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

        public ActionResult BookDetails(string bookcode = "")
        {
            BOOK selectedBook = new BOOK();


            using (HENRYEntities dbContext = new HENRYEntities())
            {
                
                //var bookQuery = dbContext.BOOKs.Include("PUBLISHER").Include("INVENTORies").Where(x => x.BOOK_CODE == bookcode);
                var bookQuery = dbContext.BOOKs.Include("PUBLISHER").Include("INVENTORies").Where(x => x.BOOK_CODE == bookcode);
                selectedBook = bookQuery.FirstOrDefault();

                if (selectedBook == null)
                {
                    var defaultBookQuery = dbContext.BOOKs;
                    selectedBook = defaultBookQuery.First();
                }

                ViewBag.selectedBook = selectedBook;

                ViewBag.PUBLISHER_NAME = selectedBook.PUBLISHER.PUBLISHER_NAME;
                ViewBag.PUBLISHER_CODE = selectedBook.PUBLISHER_CODE;

                // get inventories
                var InventoryQuery = dbContext.INVENTORies.Include("BRANCH").Where(x => x.BOOK_CODE == selectedBook.BOOK_CODE);
                List<INVENTORY> InventoryList = InventoryQuery.ToList();
                ViewBag.INVENTORies = InventoryList;

                // get author using the book detail DB view
                var authorQuery = dbContext.vBookDetails.Where(x => x.BOOK_CODE == selectedBook.BOOK_CODE);
                ViewBag.AUTHOR_LAST = authorQuery.First().AUTHOR_LAST;
                ViewBag.AUTHOR_FIRST = authorQuery.First().AUTHOR_FIRST;
                ViewBag.AUTHOR_NUM = authorQuery.First().AUTHOR_NUM;
                


            }

            ViewBag.selectedBook = selectedBook;
            

            return View(selectedBook);
        }
    }
}
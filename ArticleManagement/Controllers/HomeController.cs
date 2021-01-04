using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArticleManagement.Data;
using PagedList;

namespace ArticleManagement.Controllers
{
    public class HomeController : Controller
    {
        ArticleManagementContext db = new ArticleManagementContext();
        public ActionResult Index(int? id, int? page)
        {
            if (page == null) page = 1;
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            if (id != null)
            {
                var articles = (from a in db.Articles
                                select a)
                                .Where(m => m.CategoryId == id)
                                .OrderByDescending(x => x.ArticleId);
                return View(articles.ToPagedList(pageNumber, pageSize));
            }
            var articles1 = (from a in db.Articles
                            select a).OrderByDescending(x => x.ArticleId);
            return View(articles1.ToPagedList(pageNumber, pageSize));
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
    }
}
using ArticleManagement.Models;
using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Mvc;
using System.Xml.Linq;
using ArticleManagement.Data;

namespace ArticleManagement.Controllers
{
    public class RSSFeedController : Controller
    {
        private ArticleManagementContext db = new ArticleManagementContext();
        // GET: RSSFeed
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string RSSURL)
        {
            // Tạo đối tượng WebClient để downl nội dung của 1 Url
            WebClient wclient = new WebClient();
            wclient.Encoding = Encoding.UTF8;
            string RSSDATA = wclient.DownloadString(RSSURL);
            // Ép kiểu sang xml và đọc các thông tin cơ bản của 1 rss feed
            XDocument xml = XDocument.Parse(RSSDATA);
            var RSSFeedData = (from x in xml.Descendants("item")
                               select new RSSFeed
                               {
                                   Title = ((string)x.Element("title")),
                                   Link = ((string)x.Element("link")),
                                   Description = ((string)x.Element("description")),
                                   PubDate = ((string)x.Element("pubDate"))
                               });
            ViewBag.RSSFeed = RSSFeedData;
            ViewBag.URL = RSSURL;

            try
            {
                foreach (var item in ViewBag.RSSFeed)
                {
                    string title = item.Title;
                    var article = (from a in db.Articles
                                   where a.Title == title
                                   select a).FirstOrDefault<Article>();
                    if (article != null)
                    {
                        // neu da ton tai bao bai thi continue sang buoc lap ke tiep
                        continue;
                    }
                    else
                    {
                        string s = wclient.DownloadString(item.Link);

                        var content = s.Substring(
                                 s.IndexOf("<div class=\"content\">"),
                                 s.IndexOf("<div class=\"author\">") - s.IndexOf("<div class=\"content\">"));
                        var pic = s.Substring(
                                s.IndexOf("<figure class=\"image\""),
                                s.IndexOf("</figure>") - s.IndexOf("<figure class=\"image\"")
                                );
                        var image = pic.Substring(
                                pic.IndexOf("<img"),
                                pic.IndexOf("<figcaption>") - pic.IndexOf("<img")
                                );
                        var url = image.Substring(
                                image.IndexOf("http"),
                                image.IndexOf("\">") - image.IndexOf("http")
                                );

                        // Them vao csdl -> Category -> Author -> Article -> Image
                        var cate = db.Categories.Where(c => c.Description == "RSS")
                                                .FirstOrDefault<Category>();
                        var aut = db.Authors.Where(a => a.Name == "Đ.H Bửu")
                                            .FirstOrDefault<Author>();
                        Article art = new Article();
                        art.AuthorId = aut.AuthorId;
                        art.CategoryId = cate.CategoryId;
                        art.PubDate = DateTime.UtcNow;
                        art.Content = content;
                        art.Title = item.Title;
                        db.Articles.Add(art);
                        db.SaveChanges();

                        Image im = new Image();
                        im.ArticleId = art.ArticleId;
                        im.Url = url;
                        db.Images.Add(im);
                        db.SaveChanges();
                    } 
                }
            }
            catch(Exception)
            {
                return RedirectToAction("Index", "Articles");
            }

            return RedirectToAction("Index", "Articles");
        }
    }
}
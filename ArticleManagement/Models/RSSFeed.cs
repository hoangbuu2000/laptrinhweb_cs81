using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArticleManagement.Models
{
    public class RSSFeed
    {
        public String Title { get; set; }
        public String Link { get; set; }
        public String Description { get; set; }
        public String PubDate { get; set; }
    }
}
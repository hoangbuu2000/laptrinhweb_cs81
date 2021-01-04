using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArticleManagement.Models
{
    public class Author
    {
        public virtual int AuthorId { get; set; }
        [Display(Name ="Tác giả")]
        public virtual string Name { get; set; }
        public virtual List<Article> Articles { get; set; }
    }
}
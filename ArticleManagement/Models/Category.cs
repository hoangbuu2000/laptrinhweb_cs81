using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArticleManagement.Models
{
    public class Category
    {
        public virtual int CategoryId { get; set; }
        [Display(Name ="Danh mục")]
        public virtual string Description { get; set; }
        public virtual List<Article> Articles { get; set; }
    }
}
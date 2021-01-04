using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArticleManagement.Models
{
    public class Article
    {
        public virtual int ArticleId { get; set; }
        [Display(Name ="Tiêu đề")]
        public virtual string Title { get; set; }
        [Display(Name ="Nội dung")]
        public virtual string Content { get; set; }
        [Display(Name ="Ngày xuất bản")]
        public virtual DateTime PubDate { get; set; }
        public virtual List<Image> Images { get; set; }
        public virtual int CategoryId { get; set; }
        public virtual int AuthorId { get; set; }
        public virtual Category Category { get; set; }
        public virtual Author Author { get; set; }
    }
}
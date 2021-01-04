using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArticleManagement.Models
{
    public class Image
    {
        public virtual int ImageId { get; set; }
        [Display(Name ="Đường dẫn")]
        public virtual string Url { get; set; }
        public virtual int ArticleId { get; set; }
        public virtual Article Article { get; set; }
    }
}
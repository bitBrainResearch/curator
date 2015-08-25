using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace curator.Models
{
    public class CodeSnippet
    {
        public int CodeSnippetID { get; set; }

        public string Title { get; set; }

        [AllowHtml]
        public string Description { get; set; }

        [DataType(DataType.MultilineText)]
        public string Code { get; set; }

        public string Language { get; set; }

        public string UserName { get; set; }

        public virtual List<DiscussionPost> Posts { get; set; }

        public virtual List<Rating> Ratings { get; set; }
        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace curator.Models
{
    public class CodeSnippet
    {
        // Annoying
        [Key] public int SnippetID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        [DataType(DataType.MultilineText)]
        public string Code { get; set; }

        public string Language { get; set; }

        public string UserName { get; set; }

        public virtual List<DiscussionPost> Posts { get; set; }

        public virtual List<Rating> Ratings { get; set; }
        
    }
}

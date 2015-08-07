using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace curator.Models
{
    public class DiscussionPost
    {
        public int DiscussionPostID { get; set; }

        public int CodeSnippetID { get; set; }
        public virtual CodeSnippet CodeSnippet { get; set; }
        
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Subject { get; set; }

        [DataType(DataType.MultilineText)]
        [Required]
        public string BodyText { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayName("Created Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}")]
        public DateTime DateCreated { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayName("Last Edited")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}")]
        public DateTime DateEdited { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace curator.Models
{
    public class Rating
    {
        public int RatingID { get; set; }

        public int CodeSnippetID { get; set; }
        public virtual CodeSnippet CodeSnippet { get; set; }

        public string UserName { get; set; }

        public int Clarity { get; set; }

        public int Efficiency { get; set; }

        public int Maintainability { get; set; }

        public int Aesthetics { get; set; }

        public int Overall { get; set; }

    }
}

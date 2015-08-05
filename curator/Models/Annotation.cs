using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace curator.Models
{
    class Annotation
    {
        // Which CodeSnippet is it attached to
        public int SnippetID { get; set; }

        // Which line number of the code snippet?
        public int LineNumber { get; set; }


    }
}

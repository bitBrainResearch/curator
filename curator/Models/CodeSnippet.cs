﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace curator.Models
{
    public class CodeSnippet
    {
        [Key] public int SnippetID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        [DataType(DataType.MultilineText)]
        public string Code { get; set; }
    }
}
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kennisbank.Models
{
    public class DocumentTagViewModel
    {
        public List<Document> Documents { get; set; }
        public SelectList Tags { get; set; }
        public string DocumentTag { get; set; }
        public string SearchString { get; set; }
    }
}

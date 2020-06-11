using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kennisbank.Models
{
    public class DocumentViewModel
    {
        public string Name { get; set; }
        public string Tag { get; set; }
        public long FileSize { get; set; }
        public DateTime AddedOn { get; set; }
        public string AddedBy { get; set; }
        public SelectList Tags { get; set; }
    }
}

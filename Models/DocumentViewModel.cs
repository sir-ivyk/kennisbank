using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Kennisbank.Models
{
    public class DocumentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tag { get; set; }
        public long FileSize { get; set; }
        public DateTime AddedOn { get; set; }
        public DateTime LastEdited { get; set; }
        public string AddedBy { get; set; }
        public SelectList Tags { get; set; }
    }
}

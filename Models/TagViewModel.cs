using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kennisbank.Models
{
    public class TagViewModel
    {
        public List<Tag> Tags { get; set; }
        public string SearchString { get; set; }
    }
}

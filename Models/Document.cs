using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kennisbank.Models
{
    public class Document
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tag { get; set; }
        public long FileSize { get; set; }

        [DataType(DataType.Date)]
        public DateTime AddedOn { get; set; }
        public string AddedBy { get; set; }
    }
}

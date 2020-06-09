using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kennisbank.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Display(Name = "Added On")]
        [DataType(DataType.Date)]
        public DateTime AddedOn { get; set; }

        [Display(Name = "Owner")]
        public string AddedBy { get; set; }

        public Tag()
        {
            AddedOn = DateTime.Now;
        }
    }
}

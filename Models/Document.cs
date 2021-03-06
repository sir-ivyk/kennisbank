﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Kennisbank.Models
{
    public class Document
    {
        public int Id { get; set; }

        [Display(Name = "File Name")]
        public string Name { get; set; }
        public string Tag { get; set; }

        [Display(Name = "File Size")]
        public long FileSize { get; set; }

        [Display(Name = "Added On")]
        [DataType(DataType.Date)]
        public DateTime AddedOn { get; set; }

        [Display(Name = "Last Edited")]
        [DataType(DataType.Date)]
        public DateTime LastEdited { get; set; }

        [Display(Name = "Owner")]
        public string AddedBy { get; set; }

        public string FilePath { get; set; }
    }
}

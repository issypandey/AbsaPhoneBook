﻿using System;
using System.Collections.Generic;

#nullable disable

namespace PhonebookDB.EF.Models
{
    public partial class Entry
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedByDate { get; set; }
        public int? PhoneBookId { get; set; }
    }
}

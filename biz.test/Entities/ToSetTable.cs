﻿using System;
using System.Collections.Generic;

namespace biz.test.Entities
{
    public partial class ToSetTable
    {
        public ToSetTable()
        {
            PhotoToSetTables = new HashSet<PhotoToSetTable>();
        }

        public int Id { get; set; }
        public int? Branch { get; set; }
        public string Comment { get; set; } = null!;
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual User CreatedByNavigation { get; set; } = null!;
        public virtual ICollection<PhotoToSetTable> PhotoToSetTables { get; set; }
    }
}

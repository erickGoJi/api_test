﻿using System;
using System.Collections.Generic;

namespace biz.test.Entities
{
    public partial class Tip
    {
        public Tip()
        {
            PhotoTips = new HashSet<PhotoTip>();
        }

        public int Id { get; set; }
        public int BranchId { get; set; }
        public decimal Amount { get; set; }
        public string? Comment { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual User CreatedByNavigation { get; set; } = null!;
        public virtual ICollection<PhotoTip> PhotoTips { get; set; }
    }
}

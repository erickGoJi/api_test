﻿using System;
using System.Collections.Generic;

namespace biz.test.Entities
{
    public partial class PhotoTabletSageKeeping
    {
        public int Id { get; set; }
        public int TabletSafeKeepingId { get; set; }
        public string Photo { get; set; } = null!;
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual User CreatedByNavigation { get; set; } = null!;
        public virtual TabletSafeKeeping TabletSafeKeeping { get; set; } = null!;
    }
}

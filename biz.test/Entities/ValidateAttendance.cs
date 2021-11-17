﻿using System;
using System.Collections.Generic;

namespace biz.test.Entities
{
    public partial class ValidateAttendance
    {
        public int Id { get; set; }
        public int BranchId { get; set; }
        public int Attendence { get; set; }
        public int ClabTrab { get; set; }
        public DateTime Time { get; set; }
        public string Comment { get; set; } = null!;
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual CatStatusValidateAttendance AttendenceNavigation { get; set; } = null!;
        public virtual User CreatedByNavigation { get; set; } = null!;
    }
}

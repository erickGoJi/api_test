using System;
using System.Collections.Generic;

namespace biz.test.Entities
{
    public partial class WaitlistTable
    {
        public int Id { get; set; }
        public int Branch { get; set; }
        public bool WaitlistTables { get; set; }
        public int? HowManyTables { get; set; }
        public int? NumberPeople { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual User CreatedByNavigation { get; set; } = null!;
    }
}

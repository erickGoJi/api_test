using System;
using System.Collections.Generic;

namespace biz.test.Entities
{
    public partial class User
    {
        public User()
        {
            Alarms = new HashSet<Alarm>();
            CashRegisterShortages = new HashSet<CashRegisterShortage>();
            CatStatusValidateAttendances = new HashSet<CatStatusValidateAttendance>();
            LivingRoomBathroomCleanings = new HashSet<LivingRoomBathroomCleaning>();
            PhotoCashRegisterShortages = new HashSet<PhotoCashRegisterShortage>();
            PhotoLivingRoomBathroomCleanings = new HashSet<PhotoLivingRoomBathroomCleaning>();
            PhotoTabletSageKeepings = new HashSet<PhotoTabletSageKeeping>();
            PhotoTips = new HashSet<PhotoTip>();
            PhotoValidationGas = new HashSet<PhotoValidationGa>();
            RequestTransfers = new HashSet<RequestTransfer>();
            RiskProducts = new HashSet<RiskProduct>();
            StockChickeUseds = new HashSet<StockChickeUsed>();
            StockChickenCreatedByNavigations = new HashSet<StockChicken>();
            StockChickenUpdatedByNavigations = new HashSet<StockChicken>();
            TabletSafeKeepings = new HashSet<TabletSafeKeeping>();
            Tips = new HashSet<Tip>();
            ToSetTables = new HashSet<ToSetTable>();
            ValidateAttendances = new HashSet<ValidateAttendance>();
            ValidationGas = new HashSet<ValidationGa>();
            WaitlistTables = new HashSet<WaitlistTable>();
        }

        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int? ClabTrab { get; set; }
        public string Token { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string MotherName { get; set; } = null!;
        public int RoleId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual CatRole Role { get; set; } = null!;
        public virtual ICollection<Alarm> Alarms { get; set; }
        public virtual ICollection<CashRegisterShortage> CashRegisterShortages { get; set; }
        public virtual ICollection<CatStatusValidateAttendance> CatStatusValidateAttendances { get; set; }
        public virtual ICollection<LivingRoomBathroomCleaning> LivingRoomBathroomCleanings { get; set; }
        public virtual ICollection<PhotoCashRegisterShortage> PhotoCashRegisterShortages { get; set; }
        public virtual ICollection<PhotoLivingRoomBathroomCleaning> PhotoLivingRoomBathroomCleanings { get; set; }
        public virtual ICollection<PhotoTabletSageKeeping> PhotoTabletSageKeepings { get; set; }
        public virtual ICollection<PhotoTip> PhotoTips { get; set; }
        public virtual ICollection<PhotoValidationGa> PhotoValidationGas { get; set; }
        public virtual ICollection<RequestTransfer> RequestTransfers { get; set; }
        public virtual ICollection<RiskProduct> RiskProducts { get; set; }
        public virtual ICollection<StockChickeUsed> StockChickeUseds { get; set; }
        public virtual ICollection<StockChicken> StockChickenCreatedByNavigations { get; set; }
        public virtual ICollection<StockChicken> StockChickenUpdatedByNavigations { get; set; }
        public virtual ICollection<TabletSafeKeeping> TabletSafeKeepings { get; set; }
        public virtual ICollection<Tip> Tips { get; set; }
        public virtual ICollection<ToSetTable> ToSetTables { get; set; }
        public virtual ICollection<ValidateAttendance> ValidateAttendances { get; set; }
        public virtual ICollection<ValidationGa> ValidationGas { get; set; }
        public virtual ICollection<WaitlistTable> WaitlistTables { get; set; }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using dal.test;
using biz.test.Entities;
namespace dal.test.DBContext
{
    public partial class Db_Test : DbContext
    {
        public Db_Test()
        {
        }

        public Db_Test(DbContextOptions<Db_Test> options)
            : base(options)
        {
        }

        public virtual DbSet<Alarm> Alarms { get; set; } = null!;
        public virtual DbSet<CashRegisterShortage> CashRegisterShortages { get; set; } = null!;
        public virtual DbSet<CatAmount> CatAmounts { get; set; } = null!;
        public virtual DbSet<CatMenu> CatMenus { get; set; } = null!;
        public virtual DbSet<CatRole> CatRoles { get; set; } = null!;
        public virtual DbSet<CatSection> CatSections { get; set; } = null!;
        public virtual DbSet<CatStatusRequestTransfer> CatStatusRequestTransfers { get; set; } = null!;
        public virtual DbSet<CatStatusStockChicken> CatStatusStockChickens { get; set; } = null!;
        public virtual DbSet<CatStatusValidateAttendance> CatStatusValidateAttendances { get; set; } = null!;
        public virtual DbSet<CatSubMenu> CatSubMenus { get; set; } = null!;
        public virtual DbSet<LivingRoomBathroomCleaning> LivingRoomBathroomCleanings { get; set; } = null!;
        public virtual DbSet<Permission> Permissions { get; set; } = null!;
        public virtual DbSet<PhotoAlarm> PhotoAlarms { get; set; } = null!;
        public virtual DbSet<PhotoCashRegisterShortage> PhotoCashRegisterShortages { get; set; } = null!;
        public virtual DbSet<PhotoLivingRoomBathroomCleaning> PhotoLivingRoomBathroomCleanings { get; set; } = null!;
        public virtual DbSet<PhotoTabletSageKeeping> PhotoTabletSageKeepings { get; set; } = null!;
        public virtual DbSet<PhotoTip> PhotoTips { get; set; } = null!;
        public virtual DbSet<PhotoToSetTable> PhotoToSetTables { get; set; } = null!;
        public virtual DbSet<PhotoValidationGa> PhotoValidationGas { get; set; } = null!;
        public virtual DbSet<RequestTransfer> RequestTransfers { get; set; } = null!;
        public virtual DbSet<RiskProduct> RiskProducts { get; set; } = null!;
        public virtual DbSet<StockChickeUsed> StockChickeUseds { get; set; } = null!;
        public virtual DbSet<StockChicken> StockChickens { get; set; } = null!;
        public virtual DbSet<TabletSafeKeeping> TabletSafeKeepings { get; set; } = null!;
        public virtual DbSet<Tip> Tips { get; set; } = null!;
        public virtual DbSet<ToSetTable> ToSetTables { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<ValidateAttendance> ValidateAttendances { get; set; } = null!;
        public virtual DbSet<ValidationGa> ValidationGas { get; set; } = null!;
        public virtual DbSet<WaitlistTable> WaitlistTables { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alarm>(entity =>
            {
                entity.ToTable("Alarm");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BranchId).HasColumnName("branch_id");

                entity.Property(e => e.Comment)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("comment");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("date")
                    .HasColumnName("updated_date");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Alarms)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Alarm_Users");
            });

            modelBuilder.Entity<CashRegisterShortage>(entity =>
            {
                entity.ToTable("Cash_Register_Shortage");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("amount");

                entity.Property(e => e.BranchId).HasColumnName("branch_id");

                entity.Property(e => e.Comment)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("comment");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("date")
                    .HasColumnName("updated_date");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.CashRegisterShortages)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cash_Register_Shortage_Users");
            });

            modelBuilder.Entity<CatAmount>(entity =>
            {
                entity.ToTable("Cat_Amount");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("amount");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("date")
                    .HasColumnName("updated_date");
            });

            modelBuilder.Entity<CatMenu>(entity =>
            {
                entity.ToTable("Cat_Menu");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name")
                    .UseCollation("Latin1_General_100_CI_AI");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_date");
            });

            modelBuilder.Entity<CatRole>(entity =>
            {
                entity.ToTable("Cat_Role");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.Description)
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasColumnName("description")
                    .UseCollation("Latin1_General_100_CI_AI");

                entity.Property(e => e.Role)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("role")
                    .UseCollation("Latin1_General_100_CI_AI");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_date");
            });

            modelBuilder.Entity<CatSection>(entity =>
            {
                entity.ToTable("Cat_Section");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name")
                    .UseCollation("Latin1_General_100_CI_AI");

                entity.Property(e => e.SubMenuId).HasColumnName("sub_menu_id");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_date");

                entity.HasOne(d => d.SubMenu)
                    .WithMany(p => p.CatSections)
                    .HasForeignKey(d => d.SubMenuId)
                    .HasConstraintName("FK_Cat_Section_Cat_Sub_Menu");
            });

            modelBuilder.Entity<CatStatusRequestTransfer>(entity =>
            {
                entity.ToTable("Cat_Status_Request_Transfer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("date")
                    .HasColumnName("updated_date");
            });

            modelBuilder.Entity<CatStatusStockChicken>(entity =>
            {
                entity.ToTable("Cat_Status_Stock_Chicken");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Status)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("date")
                    .HasColumnName("updated_date");
            });

            modelBuilder.Entity<CatStatusValidateAttendance>(entity =>
            {
                entity.ToTable("Cat_Status_Validate_Attendance");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Status)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("date")
                    .HasColumnName("updated_date");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.CatStatusValidateAttendances)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cat_Status_Validate_Attendance_Users");
            });

            modelBuilder.Entity<CatSubMenu>(entity =>
            {
                entity.ToTable("Cat_Sub_Menu");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.MenuId).HasColumnName("menu_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name")
                    .UseCollation("Latin1_General_100_CI_AI");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_date");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.CatSubMenus)
                    .HasForeignKey(d => d.MenuId)
                    .HasConstraintName("FK_Cat_Sub_Menu_Cat_Menu");
            });

            modelBuilder.Entity<LivingRoomBathroomCleaning>(entity =>
            {
                entity.ToTable("Living_Room_Bathroom_Cleaning");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BranchId).HasColumnName("branch_id");

                entity.Property(e => e.Comment)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("comment");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("date")
                    .HasColumnName("updated_date");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.LivingRoomBathroomCleanings)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Living_Room_Bathroom_Cleaning_Users");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.ToTable("Permission");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.Deleting).HasColumnName("deleting");

                entity.Property(e => e.Editing).HasColumnName("editing");

                entity.Property(e => e.IdCatMenu).HasColumnName("id_cat_menu");

                entity.Property(e => e.IdCatSection).HasColumnName("id_cat_section");

                entity.Property(e => e.IdCatSubMenu).HasColumnName("id_cat_sub_menu");

                entity.Property(e => e.Reading).HasColumnName("reading");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.Show).HasColumnName("show");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_date");

                entity.Property(e => e.Writing).HasColumnName("writing");

                entity.HasOne(d => d.IdCatMenuNavigation)
                    .WithMany(p => p.Permissions)
                    .HasForeignKey(d => d.IdCatMenu)
                    .HasConstraintName("FK_Permission_Cat_Menu");

                entity.HasOne(d => d.IdCatSectionNavigation)
                    .WithMany(p => p.Permissions)
                    .HasForeignKey(d => d.IdCatSection)
                    .HasConstraintName("FK_Permission_Cat_Section");

                entity.HasOne(d => d.IdCatSubMenuNavigation)
                    .WithMany(p => p.Permissions)
                    .HasForeignKey(d => d.IdCatSubMenu)
                    .HasConstraintName("FK_Permission_Cat_Sub_Menu");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Permissions)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_Permission_Cat_Role");
            });

            modelBuilder.Entity<PhotoAlarm>(entity =>
            {
                entity.ToTable("Photo_Alarm");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AlarmId).HasColumnName("alarm_id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Photo)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("photo");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("date")
                    .HasColumnName("updated_date");

                entity.HasOne(d => d.Alarm)
                    .WithMany(p => p.PhotoAlarms)
                    .HasForeignKey(d => d.AlarmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Photo_Alarm_Alarm");
            });

            modelBuilder.Entity<PhotoCashRegisterShortage>(entity =>
            {
                entity.ToTable("Photo_Cash_Register_Shortage");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CashRegisterShortageId).HasColumnName("cash_register_shortage_id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Photo)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("photo");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("date")
                    .HasColumnName("updated_date");

                entity.HasOne(d => d.CashRegisterShortage)
                    .WithMany(p => p.PhotoCashRegisterShortages)
                    .HasForeignKey(d => d.CashRegisterShortageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Photo_Cash_Register_Shortage_Cash_Register_Shortage");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.PhotoCashRegisterShortages)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Photo_Cash_Register_Shortage_Users");
            });

            modelBuilder.Entity<PhotoLivingRoomBathroomCleaning>(entity =>
            {
                entity.ToTable("Photo_Living_Room_Bathroom_Cleaning");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LivingRoomBathroomCleaningId).HasColumnName("living_room_bathroom_cleaning_id");

                entity.Property(e => e.Photo)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("photo");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("date")
                    .HasColumnName("updated_date");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.PhotoLivingRoomBathroomCleanings)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Photo_Living_Room_Bathroom_Cleaning_Users");

                entity.HasOne(d => d.LivingRoomBathroomCleaning)
                    .WithMany(p => p.PhotoLivingRoomBathroomCleanings)
                    .HasForeignKey(d => d.LivingRoomBathroomCleaningId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Photo_Living_Room_Bathroom_Cleaning_Living_Room_Bathroom_Cleaning");
            });

            modelBuilder.Entity<PhotoTabletSageKeeping>(entity =>
            {
                entity.ToTable("Photo_Tablet_Sage_Keeping");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Photo)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("photo");

                entity.Property(e => e.TabletSafeKeepingId).HasColumnName("tablet_safe_keeping_id");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("date")
                    .HasColumnName("updated_date");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.PhotoTabletSageKeepings)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Photo_Tablet_Sage_Keeping_Users");

                entity.HasOne(d => d.TabletSafeKeeping)
                    .WithMany(p => p.PhotoTabletSageKeepings)
                    .HasForeignKey(d => d.TabletSafeKeepingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Photo_Tablet_Sage_Keeping_Tablet_Safe_Keeping");
            });

            modelBuilder.Entity<PhotoTip>(entity =>
            {
                entity.ToTable("Photo_Tip");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Photo)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("photo");

                entity.Property(e => e.TipId).HasColumnName("tip_id");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("date")
                    .HasColumnName("updated_date");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.PhotoTips)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Photo_Tip_Users");

                entity.HasOne(d => d.Tip)
                    .WithMany(p => p.PhotoTips)
                    .HasForeignKey(d => d.TipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Photo_Tip_Tip");
            });

            modelBuilder.Entity<PhotoToSetTable>(entity =>
            {
                entity.ToTable("Photo_To_Set_Table");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Photo)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("photo");

                entity.Property(e => e.ToSetTableId).HasColumnName("to_set_table_id");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("date")
                    .HasColumnName("updated_date");

                entity.HasOne(d => d.ToSetTable)
                    .WithMany(p => p.PhotoToSetTables)
                    .HasForeignKey(d => d.ToSetTableId)
                    .HasConstraintName("FK_Photo_To_Set_Table_To_Set_Table");
            });

            modelBuilder.Entity<PhotoValidationGa>(entity =>
            {
                entity.ToTable("Photo_Validation_Gas");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Photo)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("photo");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("date")
                    .HasColumnName("updated_date");

                entity.Property(e => e.ValidationGasId).HasColumnName("validation_gas_id");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.PhotoValidationGas)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Photo_Validation_Gas_Users");

                entity.HasOne(d => d.ValidationGas)
                    .WithMany(p => p.PhotoValidationGas)
                    .HasForeignKey(d => d.ValidationGasId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Photo_Validation_Gas_Validation_Gas");
            });

            modelBuilder.Entity<RequestTransfer>(entity =>
            {
                entity.ToTable("Request_Transfer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("amount");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("code");

                entity.Property(e => e.Comment)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("comment");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.FromBranchId).HasColumnName("from_branch_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Time).HasColumnName("time");

                entity.Property(e => e.ToBranchId).HasColumnName("to_branch_id");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("date")
                    .HasColumnName("updated_date");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.RequestTransfers)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Request_Transfer_Users");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.RequestTransfers)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Request_Transfer_Cat_Status_Request_Transfer");
            });

            modelBuilder.Entity<RiskProduct>(entity =>
            {
                entity.ToTable("Risk_Product");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BranchId).HasColumnName("branch_id");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("code");

                entity.Property(e => e.Comment)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("comment");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("date")
                    .HasColumnName("updated_date");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.RiskProducts)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Risk_Product_Users");
            });

            modelBuilder.Entity<StockChickeUsed>(entity =>
            {
                entity.ToTable("Stock_Chicke_Used");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AmountUsed)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("amount_used");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StockChickenId).HasColumnName("stock_chicken_id");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("date")
                    .HasColumnName("updated_date");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.StockChickeUseds)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Stock_Chicke_Used_Users");

                entity.HasOne(d => d.StockChicken)
                    .WithMany(p => p.StockChickeUseds)
                    .HasForeignKey(d => d.StockChickenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Stock_Chicke_Used_Stock_Chicken");
            });

            modelBuilder.Entity<StockChicken>(entity =>
            {
                entity.ToTable("Stock_Chicken");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("amount");

                entity.Property(e => e.Branch).HasColumnName("branch");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("code");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("date")
                    .HasColumnName("updated_date");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.StockChickenCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sales_Expectations_Users");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.StockChickens)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Stock_Chicken_Cat_Status_Stock_Chicken");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.StockChickenUpdatedByNavigations)
                    .HasForeignKey(d => d.UpdatedBy)
                    .HasConstraintName("FK_Sales_Expectations_Users1");
            });

            modelBuilder.Entity<TabletSafeKeeping>(entity =>
            {
                entity.ToTable("Tablet_Safe_Keeping");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BranchId).HasColumnName("branch_id");

                entity.Property(e => e.Comment)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("comment");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("date")
                    .HasColumnName("updated_date");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.TabletSafeKeepings)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tablet_Safe_Keeping_Users");
            });

            modelBuilder.Entity<Tip>(entity =>
            {
                entity.ToTable("Tip");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("amount");

                entity.Property(e => e.BranchId).HasColumnName("branch_id");

                entity.Property(e => e.Comment)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("comment");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("date")
                    .HasColumnName("updated_date");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Tips)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tip_Users");
            });

            modelBuilder.Entity<ToSetTable>(entity =>
            {
                entity.ToTable("To_Set_Table");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Branch).HasColumnName("branch");

                entity.Property(e => e.Comment)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("comment");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("date")
                    .HasColumnName("updated_date");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.ToSetTables)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_To_Set_Table_Users");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClabTrab).HasColumnName("clab_trab");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasColumnName("created_date");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.MotherName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("mother_name");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.Token)
                    .IsUnicode(false)
                    .HasColumnName("token");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("date")
                    .HasColumnName("updated_date");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Cat_Role");
            });

            modelBuilder.Entity<ValidateAttendance>(entity =>
            {
                entity.ToTable("Validate_Attendance");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Attendence).HasColumnName("attendence");

                entity.Property(e => e.BranchId).HasColumnName("branch_id");

                entity.Property(e => e.ClabTrab).HasColumnName("clab_trab");

                entity.Property(e => e.Comment)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("comment");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Time)
                    .HasColumnType("datetime")
                    .HasColumnName("time");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("date")
                    .HasColumnName("updated_date");

                entity.HasOne(d => d.AttendenceNavigation)
                    .WithMany(p => p.ValidateAttendances)
                    .HasForeignKey(d => d.Attendence)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Validate_Attendance_Cat_Status_Validate_Attendance");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.ValidateAttendances)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Validate_Attendance_Users");
            });

            modelBuilder.Entity<ValidationGa>(entity =>
            {
                entity.ToTable("Validation_Gas");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("amount");

                entity.Property(e => e.Branch).HasColumnName("branch");

                entity.Property(e => e.Comment)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("comment");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("date")
                    .HasColumnName("updated_date");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.ValidationGas)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Validation_Gas_Users");
            });

            modelBuilder.Entity<WaitlistTable>(entity =>
            {
                entity.ToTable("Waitlist_Table");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Branch).HasColumnName("branch");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.HowManyTables).HasColumnName("how_many_tables");

                entity.Property(e => e.NumberPeople).HasColumnName("number_people");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("date")
                    .HasColumnName("updated_date");

                entity.Property(e => e.WaitlistTables).HasColumnName("waitlist_tables");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.WaitlistTables)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Wait_Table_Users");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

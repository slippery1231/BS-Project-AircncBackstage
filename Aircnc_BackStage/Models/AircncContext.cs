using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Aircnc_BackStage.Models
{
    public partial class AircncContext : DbContext
    {
        public AircncContext()
        {
        }

        public AircncContext(DbContextOptions<AircncContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<BankVerification> BankVerifications { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<PreOrder> PreOrders { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<RoomCalendar> RoomCalendars { get; set; }
        public virtual DbSet<RoomImg> RoomImgs { get; set; }
        public virtual DbSet<RoomServiceLabel> RoomServiceLabels { get; set; }
        public virtual DbSet<TransactionStatus> TransactionStatuses { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserVerification> UserVerifications { get; set; }
        public virtual DbSet<WishList> WishLists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:bs-2021-winter-aircnc.database.windows.net,1433;Initial Catalog=Aircnc;Persist Security Info=False;User ID=bs;Password=P@ssw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Chinese_Taiwan_Stroke_BIN");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");

                entity.Property(e => e.AccountName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.Permission).HasComment("身分別Enum(主管理者、小管理者)");
            });

            modelBuilder.Entity<BankVerification>(entity =>
            {
                entity.ToTable("BankVerification");

                entity.HasIndex(e => e.AdminId, "IX_BankVerification_AdminId");

                entity.Property(e => e.BankVerificationId).HasComment("收款帳戶驗證Id");

                entity.Property(e => e.AdminId).HasComment("後台驗者者(誰審核的)");

                entity.Property(e => e.ApplyTime)
                    .HasColumnType("datetime")
                    .HasComment("使用者申請驗證時間");

                entity.Property(e => e.BankAccount)
                    .IsRequired()
                    .HasComment("銀行帳號");

                entity.Property(e => e.BankbookImg)
                    .IsRequired()
                    .HasComment("帳本封面照");

                entity.Property(e => e.CertificationTime)
                    .HasColumnType("datetime")
                    .HasComment("後台驗證通過時間");

                entity.Property(e => e.Status).HasComment("驗證狀態Enum(驗證通過、未驗證");

                entity.HasOne(d => d.Admin)
                    .WithMany(p => p.BankVerifications)
                    .HasForeignKey(d => d.AdminId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BankVerification_Admin");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comment");

                entity.HasIndex(e => e.RoomId, "IX_Comment_RoomId");

                entity.HasIndex(e => e.UserId, "IX_Comment_UserId");

                entity.Property(e => e.CommentContent).HasMaxLength(400);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comment_Room");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comment_User");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("Message");

                entity.HasIndex(e => e.RecipientId, "IX_Message_RecipientId");

                entity.HasIndex(e => e.SenderId, "IX_Message_SenderId");

                entity.Property(e => e.RecipientId).HasComment("收信人");

                entity.Property(e => e.SendTime).HasColumnType("datetime");

                entity.Property(e => e.SenderId).HasComment("發信人");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.HasOne(d => d.Recipient)
                    .WithMany(p => p.MessageRecipients)
                    .HasForeignKey(d => d.RecipientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Message_User");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.MessageSenders)
                    .HasForeignKey(d => d.SenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Message_User1");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.HasIndex(e => e.RoomId, "IX_Order_RoomId");

                entity.HasIndex(e => e.UserId, "IX_Order_UserId");

                entity.Property(e => e.BookingDateTime).HasColumnType("datetime");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.CkeckIn).HasColumnType("date");

                entity.Property(e => e.CkeckOut).HasColumnType("date");

                entity.Property(e => e.Discount)
                    .HasColumnType("decimal(18, 0)")
                    .HasComment("折扣");

                entity.Property(e => e.District)
                    .IsRequired()
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.GuestCount).HasComment("訂購人數");

                entity.Property(e => e.OriginalPrice)
                    .HasColumnType("decimal(18, 0)")
                    .HasComment("這張訂單的原價(如果定很多晚，會是每晚單價的加總)");

                entity.Property(e => e.PaymentType).HasComment("付款方式Enum()");

                entity.Property(e => e.RoomCount).HasComment("訂購房源數");

                entity.Property(e => e.RoomName)
                    .IsRequired()
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.Status).HasComment("付款狀態Enum(已付款未入住、已付款已入住、退款處理中、已退款)");

                entity.Property(e => e.Street).IsRequired();

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Room");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_User");
            });

            modelBuilder.Entity<PreOrder>(entity =>
            {
                entity.Property(e => e.OriginalPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.RoomName).IsRequired();
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("Room");

                entity.HasIndex(e => e.HouseType, "IX_Room_HouseType");

                entity.HasIndex(e => e.RoomType, "IX_Room_RoomType");

                entity.HasIndex(e => e.UserId, "IX_Room_UserId");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.District)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.HouseType).HasComment("房源類型enum(特色房源etc)，看ron的切板頁");

                entity.Property(e => e.LastChangeTime).HasColumnType("datetime");

                entity.Property(e => e.Lat).HasColumnType("decimal(10, 6)");

                entity.Property(e => e.Lng).HasColumnType("decimal(10, 6)");

                entity.Property(e => e.Note).HasMaxLength(500);

                entity.Property(e => e.Pax).HasComment("房客人數");

                entity.Property(e => e.RoomDescription)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.RoomName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RoomType).HasComment("房間類型enum(套房雅房等etc)");

                entity.Property(e => e.Status).HasComment("enum房源狀態(建立中/已上架/已下架)");

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.UserId).HasComment("房東");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Room_User");
            });

            modelBuilder.Entity<RoomCalendar>(entity =>
            {
                entity.ToTable("RoomCalendar");

                entity.HasIndex(e => e.RoomCalendarStatus, "IX_RoomCalendar_RoomCalendarStatusId");

                entity.HasIndex(e => e.RoomId, "IX_RoomCalendar_RoomId");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.LastChangeTime)
                    .HasColumnType("datetime")
                    .HasComment("更新時間");

                entity.Property(e => e.Note).HasComment("月曆房東自行備註");

                entity.Property(e => e.RoomCalendarStatus).HasComment("enum被更改的狀態(被屏蔽、被訂)");

                entity.Property(e => e.UnitPrice)
                    .HasColumnType("decimal(18, 0)")
                    .HasComment("更改的單價");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.RoomCalendars)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoomCalendar_Room");
            });

            modelBuilder.Entity<RoomImg>(entity =>
            {
                entity.ToTable("RoomImg");

                entity.HasIndex(e => e.RoomId, "IX_RoomImg_RoomId");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.ImageUrl).IsRequired();

                entity.Property(e => e.Sort).HasComment("排序");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.RoomImgs)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoomPicture_Room");
            });

            modelBuilder.Entity<RoomServiceLabel>(entity =>
            {
                entity.ToTable("RoomServiceLabel");

                entity.HasIndex(e => e.RoomId, "IX_RoomServiceLabel_RoomId");

                entity.HasIndex(e => e.TypeOfLabel, "IX_RoomServiceLabel_TypeOfLabeId");

                entity.Property(e => e.TypeOfLabel).HasComment("enum(wifi,etc...)");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.RoomServiceLabels)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoomServiceLabel_Room");
            });

            modelBuilder.Entity<TransactionStatus>(entity =>
            {
                entity.ToTable("TransactionStatus");

                entity.HasIndex(e => e.AdminId, "IX_TransactionStatus_AdminId");

                entity.HasIndex(e => e.OrderId, "IX_TransactionStatus_OrderId");

                entity.HasIndex(e => e.UserId, "IX_TransactionStatus_UserId");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.StatusType).HasComment("交易狀態Enum(還在系統、已轉帳給房東、已退款給房客)");

                entity.Property(e => e.TotalAmount)
                    .HasColumnType("decimal(18, 0)")
                    .HasComment("扣除平台抽成後付給房東的金額");

                entity.Property(e => e.UserId).HasComment("房東Id");

                entity.HasOne(d => d.Admin)
                    .WithMany(p => p.TransactionStatuses)
                    .HasForeignKey(d => d.AdminId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TransactionStatus_Admin");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.TransactionStatuses)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TransactionStatus_Order");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TransactionStatuses)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TransactionStatus_User");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasIndex(e => e.BankVerificationId, "IX_User_AccountVerificationId");

                entity.HasIndex(e => e.UserVerificationId, "IX_User_UserVerificationId");

                entity.Property(e => e.BankVerificationId).HasComment("收款帳戶驗證Id");

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.EmergencyContactName).HasMaxLength(20);

                entity.Property(e => e.EmergencyContactPhone).HasMaxLength(20);

                entity.Property(e => e.IsDelete)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.MailIsVerify)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.UserVerificationId).HasComment("身分驗證Id");

                entity.HasOne(d => d.BankVerification)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.BankVerificationId)
                    .HasConstraintName("FK_User_BankVerification");

                entity.HasOne(d => d.UserVerification)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserVerificationId)
                    .HasConstraintName("FK_User_UserVerification");
            });

            modelBuilder.Entity<UserVerification>(entity =>
            {
                entity.ToTable("UserVerification");

                entity.HasIndex(e => e.AdminId, "IX_UserVerification_AdminId");

                entity.Property(e => e.UserVerificationId).HasComment("身分驗證Id");

                entity.Property(e => e.AdminId).HasComment("後台驗者者(誰審核的)");

                entity.Property(e => e.ApplyTime)
                    .HasColumnType("datetime")
                    .HasComment("使用者申請驗證時間");

                entity.Property(e => e.CertificationTime)
                    .HasColumnType("datetime")
                    .HasComment("後台驗證通過時間");

                entity.Property(e => e.DocumentType).HasComment("驗證文件Enum(身分證、護照、駕照)");

                entity.Property(e => e.Status).HasComment("驗證狀態IdEnum(驗證通過、未驗證");

                entity.HasOne(d => d.Admin)
                    .WithMany(p => p.UserVerifications)
                    .HasForeignKey(d => d.AdminId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserVerification_Admin");
            });

            modelBuilder.Entity<WishList>(entity =>
            {
                entity.ToTable("WishList");

                entity.HasIndex(e => e.RoomId, "IX_WishList_RoomId");

                entity.HasIndex(e => e.UserId, "IX_WishList_UserId");

                entity.HasIndex(e => e.WishListId, "IX_WishList_WishListId");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.WishLists)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WishList_Room");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.WishLists)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WishList_User1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

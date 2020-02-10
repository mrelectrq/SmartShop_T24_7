using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataLayer.Entities
{
    public partial class Lake_ShopContext : DbContext
    {
        public Lake_ShopContext()
        {
        }

        public Lake_ShopContext(DbContextOptions<Lake_ShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BagApp> BagApp { get; set; }
        public virtual DbSet<Category1> Category1 { get; set; }
        public virtual DbSet<Category2> Category2 { get; set; }
        public virtual DbSet<Category3> Category3 { get; set; }
        public virtual DbSet<Mark> Mark { get; set; }
        public virtual DbSet<Model> Model { get; set; }
        public virtual DbSet<ProductProprietes> ProductProprietes { get; set; }
        public virtual DbSet<SessionUsers> SessionUsers { get; set; }
        public virtual DbSet<UserAccountsData> UserAccountsData { get; set; }
        public virtual DbSet<Warehouse> Warehouse { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-B3HCEB1;Database=Lake_Shop;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BagApp>(entity =>
            {
                entity.HasKey(e => e.BasketId)
                    .HasName("PK__bag_app__65E4F9F0ECF63A72");

                entity.ToTable("bag_app");

                entity.Property(e => e.BasketId)
                    .HasColumnName("basket_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DateProductApp)
                    .HasColumnName("date_product_app")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateSoldOver)
                    .HasColumnName("date_sold_over")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProductFinallPrice)
                    .HasColumnName("product_finall_price")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.ProductNumber).HasColumnName("product_number");

                entity.Property(e => e.ProductStatus)
                    .HasColumnName("product_status")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProductStatusWork)
                    .HasColumnName("product_status_work")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.ProductNumberNavigation)
                    .WithMany(p => p.BagApp)
                    .HasForeignKey(d => d.ProductNumber)
                    .HasConstraintName("FK__bag_app__product__47DBAE45");
            });

            modelBuilder.Entity<Category1>(entity =>
            {
                entity.HasKey(e => e.IdCategory1)
                    .HasName("PK__category__B2FAA5AB861B96A0");

                entity.ToTable("category_1");

                entity.Property(e => e.IdCategory1).HasColumnName("id_category_1");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasColumnName("full_name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ShortName)
                    .HasColumnName("short_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Category2>(entity =>
            {
                entity.HasKey(e => e.IdCategory2)
                    .HasName("PK__category__B2FAA5AC8463CE9A");

                entity.ToTable("category_2");

                entity.Property(e => e.IdCategory2).HasColumnName("id_category_2");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasColumnName("full_name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ShortName)
                    .HasColumnName("short_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Category3>(entity =>
            {
                entity.HasKey(e => e.IdCategory3)
                    .HasName("PK__category__B2FAA5ADF53E8F31");

                entity.ToTable("category_3");

                entity.Property(e => e.IdCategory3).HasColumnName("id_category_3");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasColumnName("full_name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ShortName)
                    .HasColumnName("short_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Mark>(entity =>
            {
                entity.HasKey(e => e.IdMark)
                    .HasName("PK__mark__6FA03E665A7D8D67");

                entity.ToTable("mark");

                entity.Property(e => e.IdMark).HasColumnName("id_mark");

                entity.Property(e => e.FullName)
                    .HasColumnName("full_name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.MarkName)
                    .HasColumnName("mark_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.HasKey(e => e.IdModel)
                    .HasName("PK__model__754035282CB48AD9");

                entity.ToTable("model");

                entity.Property(e => e.IdModel).HasColumnName("id_model");

                entity.Property(e => e.FullName)
                    .HasColumnName("full_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModelName)
                    .HasColumnName("model_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProductProprietes>(entity =>
            {
                entity.HasKey(e => e.IdProduct)
                    .HasName("PK__product___BA39E84F4AD92FD5");

                entity.ToTable("product_proprietes");

                entity.Property(e => e.IdProduct)
                    .HasColumnName("id_product")
                    .ValueGeneratedNever();

                entity.Property(e => e.ProprietyDescription)
                    .HasColumnName("propriety_description")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ProprietyName)
                    .HasColumnName("propriety_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdProductNavigation)
                    .WithOne(p => p.ProductProprietes)
                    .HasForeignKey<ProductProprietes>(d => d.IdProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__product_p__id_pr__4CA06362");
            });

            modelBuilder.Entity<SessionUsers>(entity =>
            {
                entity.HasKey(e => e.IdSession)
                    .HasName("PK__session___A9E494D0BED6CBDC");

                entity.ToTable("session_users");

                entity.Property(e => e.IdSession).HasColumnName("id_session");

                entity.Property(e => e.CookieString)
                    .HasColumnName("cookie_string")
                    .IsUnicode(false);

                entity.Property(e => e.ExpiredTime)
                    .HasColumnName("expired_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserAccountsData>(entity =>
            {
                entity.HasKey(e => e.IdAccount)
                    .HasName("PK__user_acc__B2C7C783220A7662");

                entity.ToTable("user_accounts_data");

                entity.Property(e => e.IdAccount).HasColumnName("id_account");

                entity.Property(e => e.AccountEmail)
                    .IsRequired()
                    .HasColumnName("account_email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BasketId).HasColumnName("basket_id");

                entity.Property(e => e.DateBasketInit)
                    .HasColumnName("date_basket_init")
                    .HasColumnType("datetime");

                entity.Property(e => e.Ipaddress)
                    .HasColumnName("ipaddress")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.LastLogin)
                    .HasColumnName("last_login")
                    .HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("phone_number")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RoleUserAccount)
                    .HasColumnName("role_user_account")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserCountryDest)
                    .HasColumnName("user_country_dest")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.UsserAddresAcc)
                    .HasColumnName("usser_addres_acc")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ZipCode)
                    .HasColumnName("zip_code")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.HasKey(e => e.IdProduct)
                    .HasName("PK__warehous__BA39E84F853574D8");

                entity.ToTable("warehouse");

                entity.Property(e => e.IdProduct).HasColumnName("id_product");

                entity.Property(e => e.AditionalComment)
                    .HasColumnName("aditional_comment")
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateOutbox)
                    .HasColumnName("date_outbox")
                    .HasColumnType("datetime");

                entity.Property(e => e.HeadInfo)
                    .HasColumnName("head_info")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdCategory1).HasColumnName("id_category_1");

                entity.Property(e => e.IdCategory2).HasColumnName("id_category_2");

                entity.Property(e => e.IdCategory3).HasColumnName("id_category_3");

                entity.Property(e => e.IdMark).HasColumnName("id_mark");

                entity.Property(e => e.IdModel).HasColumnName("id_model");

                entity.Property(e => e.ProductName)
                    .HasColumnName("product_name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ProductPrice)
                    .HasColumnName("product_price")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.ProductQuantity).HasColumnName("product_quantity");

                entity.Property(e => e.ProductStatement)
                    .HasColumnName("product_statement")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCategory1Navigation)
                    .WithMany(p => p.Warehouse)
                    .HasForeignKey(d => d.IdCategory1)
                    .HasConstraintName("FK__warehouse__id_ca__412EB0B6");

                entity.HasOne(d => d.IdCategory2Navigation)
                    .WithMany(p => p.Warehouse)
                    .HasForeignKey(d => d.IdCategory2)
                    .HasConstraintName("FK__warehouse__id_ca__4222D4EF");

                entity.HasOne(d => d.IdCategory3Navigation)
                    .WithMany(p => p.Warehouse)
                    .HasForeignKey(d => d.IdCategory3)
                    .HasConstraintName("FK__warehouse__id_ca__4316F928");

                entity.HasOne(d => d.IdMarkNavigation)
                    .WithMany(p => p.Warehouse)
                    .HasForeignKey(d => d.IdMark)
                    .HasConstraintName("FK__warehouse__id_ma__440B1D61");

                entity.HasOne(d => d.IdModelNavigation)
                    .WithMany(p => p.Warehouse)
                    .HasForeignKey(d => d.IdModel)
                    .HasConstraintName("FK__warehouse__id_mo__44FF419A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

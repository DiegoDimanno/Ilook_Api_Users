using System;
using EFCore.Dominio;
using Microsoft.EntityFrameworkCore;


#nullable disable

namespace EFCore.Repository
{
    public partial class DB_ilookContext : DbContext
    {
        public DB_ilookContext()
        { }

        public DB_ilookContext(DbContextOptions<DB_ilookContext> options) : base(options) { }

        public virtual DbSet<Ends> Ends { get; set; }
        public virtual DbSet<Images> Images { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Sales> Sales { get; set; }
        public virtual DbSet<SaleItens> SaleItens { get; set; }
        public virtual DbSet<TypeProducts> TypeProducts { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=DESKTOP-IGRONM9;database=DB_ilook;integrated security=yes;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Ends>(entity =>
            {
                entity.HasKey(e => e.IdEnds)
                    .HasName("PK_IDENDS");

                entity.Property(e => e.IdEnds).HasColumnName("idEnds");

                entity.Property(e => e.CepEnds)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("cepEnds");

                entity.Property(e => e.CityEnds)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("cityEnds");

                entity.Property(e => e.CompEnds)
                    .HasMaxLength(100)
                    .HasColumnName("compEnds");

                entity.Property(e => e.NeighEnds)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("neighEnds");

                entity.Property(e => e.NumberEnds)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("numberEnds");

                entity.Property(e => e.ObsEnds)
                    .HasMaxLength(100)
                    .HasColumnName("obsEnds");

                entity.Property(e => e.StreetEnds)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("streetEnds");

                entity.Property(e => e.UfEnds)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("ufEnds");

                entity.Property(e => e.UserEnds).HasColumnName("userEnds");

                entity.HasOne(d => d.UserEndsNavigation)
                    .WithMany(p => p.Ends)
                    .HasForeignKey(d => d.UserEnds)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USERENDS");
            });

            modelBuilder.Entity<Images>(entity =>
            {
                entity.HasKey(e => e.IdImages)
                    .HasName("PK_IDIMAGES");

                entity.Property(e => e.IdImages).HasColumnName("idImages");

                entity.Property(e => e.PathImages)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("pathImages");

                entity.Property(e => e.ProductImages).HasColumnName("productImages");

                entity.HasOne(d => d.ProductImagesNavigation)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.ProductImages)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCTIMAGES");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.IdProducts)
                    .HasName("PK_IDPRODUCTS");

                entity.Property(e => e.IdProducts).HasColumnName("idProducts");

                entity.Property(e => e.ActiveProducts)
                    .IsRequired()
                    .HasColumnName("activeProducts")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.AvailableProducts)
                    .IsRequired()
                    .HasColumnName("availableProducts")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DescProducts)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("descProducts");

                entity.Property(e => e.HighProducts)
                    .IsRequired()
                    .HasColumnName("highProducts")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.NameProducts)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nameProducts");

                entity.Property(e => e.OrganicProducts).HasColumnName("organicProducts");

                entity.Property(e => e.PcostProducts)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("pcostProducts");

                entity.Property(e => e.PredescProducts)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("predescProducts");

                entity.Property(e => e.PsaleProducts)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("psaleProducts");

                entity.Property(e => e.SaldoProducts).HasColumnName("saldoProducts");

                entity.Property(e => e.TypeProducts).HasColumnName("typeProducts");

                entity.HasOne(d => d.TypeProductsNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.TypeProducts)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TYPEPRODUCTS");
            });

            modelBuilder.Entity<Sales>(entity =>
            {
                entity.HasKey(e => e.IdSales)
                    .HasName("PK_IDSALES");

                entity.Property(e => e.IdSales).HasColumnName("idSales");

                entity.Property(e => e.DeliveryDataSales)
                    .HasColumnType("datetime")
                    .HasColumnName("deliveryDataSales");

                entity.Property(e => e.EndSales).HasColumnName("endSales");

                entity.Property(e => e.ObsSales)
                    .HasMaxLength(100)
                    .HasColumnName("obsSales");

                entity.Property(e => e.PaymentsSales)
                    .HasColumnName("paymentsSales")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.PurchaseDataSales)
                    .HasColumnType("datetime")
                    .HasColumnName("purchaseDataSales")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserSales).HasColumnName("userSales");

                entity.Property(e => e.ValueSales)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("valueSales");

                entity.HasOne(d => d.EndSalesNavigation)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.EndSales)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ENDSALES");

                entity.HasOne(d => d.UserSalesNavigation)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.UserSales)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USERSALES");
            });

            modelBuilder.Entity<SaleItens>(entity =>
            {
                entity.HasKey(e => e.IdSalesItens)
                    .HasName("PK_IDSALESITENS");

                entity.Property(e => e.IdSalesItens).HasColumnName("idSalesItens");

                entity.Property(e => e.PriceSalesItens)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("priceSalesItens");

                entity.Property(e => e.ProductSalesItens).HasColumnName("productSalesItens");

                entity.Property(e => e.QtdSalesItens).HasColumnName("qtdSalesItens");

                entity.Property(e => e.SaleSalesItens).HasColumnName("saleSalesItens");

                entity.HasOne(d => d.ProductSalesItensNavigation)
                    .WithMany(p => p.SaleItens)
                    .HasForeignKey(d => d.ProductSalesItens)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCTSALESITENS");

                entity.HasOne(d => d.SaleSalesItensNavigation)
                    .WithMany(p => p.SaleItens)
                    .HasForeignKey(d => d.SaleSalesItens)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SALESSALESITENS");
            });

            modelBuilder.Entity<TypeProducts>(entity =>
            {
                entity.HasKey(e => e.IdType)
                    .HasName("PK_IDTYPE");

                entity.Property(e => e.IdType).HasColumnName("idType");

                entity.Property(e => e.NameType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nameType");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.IdUsers)
                    .HasName("PK_IDUSERS");

                entity.HasIndex(e => e.CpfUsers, "UQ__Users__126D4A1F2344247E")
                    .IsUnique();

                entity.HasIndex(e => e.Username, "UQ__Users__F3DBC572E3188346")
                    .IsUnique();

                entity.HasIndex(e => e.RgUsers, "UQ__Users__FB6627E202B82746")
                    .IsUnique();

                entity.Property(e => e.IdUsers).HasColumnName("idUsers");

                entity.Property(e => e.ActiveUsers)
                    .IsRequired()
                    .HasColumnName("activeUsers")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CelUsers)
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("celUsers");

                entity.Property(e => e.CpfUsers)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("cpfUsers");

                entity.Property(e => e.NameUsers)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("nameUsers");

                entity.Property(e => e.NascUsers)
                    .HasColumnType("date")
                    .HasColumnName("nascUsers");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("password");

                entity.Property(e => e.PhoneUsers)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("phoneUsers");

                entity.Property(e => e.RgUsers)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("rgUsers");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

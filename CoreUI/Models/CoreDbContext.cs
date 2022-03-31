using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CoreUI.Models
{
    public partial class CoreDbContext : DbContext
    {
        public CoreDbContext()
        {
        }

        public CoreDbContext(DbContextOptions<CoreDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<CartItem> CartItems { get; set; }
        public virtual DbSet<ComputerType> ComputerTypes { get; set; }
        public virtual DbSet<DesktopComputer> DesktopComputers { get; set; }
        public virtual DbSet<DesktopComputerPicture> DesktopComputerPictures { get; set; }
        public virtual DbSet<Laptop> Laptops { get; set; }
        public virtual DbSet<LaptopPicture> LaptopPictures { get; set; }
        public virtual DbSet<UserPhoto> UserPhotos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=CoreDb;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.LastName).HasMaxLength(250);

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.Password).HasMaxLength(250);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId, "IX_AspNetUserRoles_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.Property(e => e.UserId).HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Carts_AspNetUsers");
            });

            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.ToTable("CartItem");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.CartId)
                    .HasConstraintName("FK_CartItem_Carts");

                entity.HasOne(d => d.ItemPic)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.ItemPicId)
                    .HasConstraintName("FK_CartItem_LaptopPictures");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_CartItem_DesktopComputers");

                entity.HasOne(d => d.ProductNavigation)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_CartItem_Laptops");
            });

            modelBuilder.Entity<ComputerType>(entity =>
            {
                entity.ToTable("ComputerType");
            });

            modelBuilder.Entity<DesktopComputer>(entity =>
            {
                entity.Property(e => e.Case).HasMaxLength(250);

                entity.Property(e => e.CaseFans).HasMaxLength(250);

                entity.Property(e => e.Cpu)
                    .HasMaxLength(250)
                    .HasColumnName("CPU");

                entity.Property(e => e.Gpu)
                    .HasMaxLength(250)
                    .HasColumnName("GPU");

                entity.Property(e => e.Hdd)
                    .HasMaxLength(250)
                    .HasColumnName("HDD");

                entity.Property(e => e.MotherBoard).HasMaxLength(250);

                entity.Property(e => e.OperatingSystem).HasMaxLength(250);

                entity.Property(e => e.PowerSupply).HasMaxLength(250);

                entity.Property(e => e.Prize).HasMaxLength(250);

                entity.Property(e => e.ProcessorCooling)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Ram)
                    .HasMaxLength(250)
                    .HasColumnName("RAM");

                entity.Property(e => e.Ssd)
                    .HasMaxLength(250)
                    .HasColumnName("SSD");
            });

            modelBuilder.Entity<DesktopComputerPicture>(entity =>
            {
                entity.Property(e => e.DesktopPicPath).HasMaxLength(250);

                entity.HasOne(d => d.DesktopComuter)
                    .WithMany(p => p.DesktopComputerPictures)
                    .HasForeignKey(d => d.DesktopComuterId)
                    .HasConstraintName("FK_DesktopComputerPictures_DesktopComputers");
            });

            modelBuilder.Entity<Laptop>(entity =>
            {
                entity.Property(e => e.Brand).HasMaxLength(250);

                entity.Property(e => e.Cpu)
                    .HasMaxLength(250)
                    .HasColumnName("CPU");

                entity.Property(e => e.Gpu)
                    .HasMaxLength(250)
                    .HasColumnName("GPU");

                entity.Property(e => e.Hdd)
                    .HasMaxLength(250)
                    .HasColumnName("HDD");

                entity.Property(e => e.Model).HasMaxLength(250);

                entity.Property(e => e.Monitor).HasMaxLength(250);

                entity.Property(e => e.OperatingSystem).HasMaxLength(250);

                entity.Property(e => e.Ram)
                    .HasMaxLength(250)
                    .HasColumnName("RAM");

                entity.Property(e => e.ScreenSize).HasMaxLength(250);

                entity.Property(e => e.Ssd)
                    .HasMaxLength(250)
                    .HasColumnName("SSD");
            });

            modelBuilder.Entity<LaptopPicture>(entity =>
            {
                entity.Property(e => e.LaptopPicPath).HasMaxLength(500);

                entity.HasOne(d => d.Laptop)
                    .WithMany(p => p.LaptopPictures)
                    .HasForeignKey(d => d.LaptopId)
                    .HasConstraintName("FK_LaptopPictures_Laptops");
            });

            modelBuilder.Entity<UserPhoto>(entity =>
            {
                entity.Property(e => e.PhotoPath).HasMaxLength(1000);

                entity.Property(e => e.UserId).HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserPhotos)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserPhotos_AspNetUsers");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Mini_market_Managerment_Systerm.Models
{
    public partial class minimarketdbContext : DbContext
    {
        public minimarketdbContext()
        {
        }

        public minimarketdbContext(DbContextOptions<minimarketdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bill> Bills { get; set; } = null!;
        public virtual DbSet<BillC> BillCs { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Seller> Sellers { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("SqlConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BillC>(entity =>
            {
                

                entity.ToTable("BillC");

                entity.Property(e => e.BillCid).HasColumnName("BillCId");

                entity.Property(e => e.ProductName).HasMaxLength(50);

                entity.Property(e => e.BillCid).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Bill>(entity =>
            {
               

                entity.ToTable("Bill");

                entity.Property(e => e.BillDate).HasColumnType("date");

                entity.Property(e => e.BillId).ValueGeneratedOnAdd();

                entity.Property(e => e.SellerName).HasMaxLength(50);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CatId);

                entity.ToTable("Category");

                entity.Property(e => e.CatDes).HasMaxLength(200);

                entity.Property(e => e.CatName).HasMaxLength(50);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProdId);

                entity.ToTable("Product");

                entity.Property(e => e.ProdName).HasMaxLength(50);

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Category");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleId).ValueGeneratedNever();

                entity.Property(e => e.RoleName)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Seller>(entity =>
            {
               

                entity.ToTable("Seller");

                entity.Property(e => e.SellerId).ValueGeneratedOnAdd();

                entity.Property(e => e.SellerName)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.SellerPhone)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Seller_User");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.UserPass)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using System;
using TJ_Games.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


#nullable disable

namespace TJ_Games.DBContext
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrators> Administrator { get; set; }
        public virtual DbSet<Buyers> Buyer { get; set; }
        public virtual DbSet<Commodities> Commodity { get; set; }
        public virtual DbSet<Evaluation> Evaluations { get; set; }
        public virtual DbSet<Friends> Friend { get; set; }
        public virtual DbSet<GameLibrary> GameLibraries { get; set; }
        public virtual DbSet<Giftcode> Giftcodes { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Orders> Order { get; set; }
        public virtual DbSet<Publishers> Publisher { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<Updatelog> Updatelogs { get; set; }
        public virtual DbSet<Users> User { get; set; }
        public virtual DbSet<Wishlist> Wishlists { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("orcl");

            modelBuilder.Entity<Administrators>(entity =>
            {
                entity.ToTable("ADMINISTRATORS");

                entity.HasKey(e => e.AdminID);

                entity.Property(e => e.AdminID)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnType("number")
                    .HasColumnName("ADMIN_ID");

                entity.Property(e => e.AdminName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(true)
                    .HasColumnType("varchar(20)")
                    .HasColumnName("ADMIN_NAME");

                entity.Property(e => e.Department)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .IsUnicode(true)
                    .HasColumnName("DEPARTMENT");
            });

            modelBuilder.Entity<Buyers>(entity =>
            {
                entity.ToTable("BUYERS");

                entity.HasKey(e => e.BuyerID);

                entity.Property(e => e.BuyerID)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnType("number")
                    .HasColumnName("BUYER_ID");

                entity.Property(e => e.BuyerName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(true)
                    .HasColumnType("varchar(20)")
                    .HasColumnName("BUYER_NAME");

                entity.Property(e => e.Birthday)
                    .HasColumnType("DATA")
                    .HasColumnName("BIRTHDAT");

                entity.Property(e => e.Mail)
                    .HasMaxLength(20)
                    .HasColumnType("varchar(20)")
                    .HasColumnName("MAIL");

                entity.HasOne(d=>d.Users)
                        .WithOne(p=>p.Buyers)
                        .HasForeignKey<Buyers>(d=>d.BuyerID)
                        .HasConstraintName("FK_USER_ID");

                entity.HasOne(d => d.Users)
                         .WithOne(p => p.Buyers)
                         .HasForeignKey<Buyers>(d => d.BuyerName)
                         .HasConstraintName("FK_BUYER_NAME");

            });

            modelBuilder.Entity<Commodities>(entity =>
            {
                entity.ToTable("COMMODITIES");

                entity.HasKey(e => e.CommoditiyID)
                        .HasName("PK_COMMODITIES");

                entity.Property(e => e.CommoditiyID)
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("number")
                        .HasColumnName("COMMODITY_ID");

                entity.Property(e => e.CommodityName)
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("COMMODITY_NAME")
                        .IsUnicode(true);

                entity.Property(e => e.Publisher)
                         .IsRequired()
                         .HasMaxLength(20)
                         .HasColumnType("varchar(20)")
                         .HasColumnName("PUBLISHER")
                         .IsUnicode(true);

                entity.Property(e => e.Price)
                         .IsRequired()
                         .HasColumnType("number")
                         .HasColumnName("PRICE");

                entity.Property(e => e.PublishTime)
                         .IsRequired()
                         .HasColumnType("DATE")
                         .HasColumnName("PUBLISH_TIME");

                entity.Property(e => e.Classification)
                         .IsRequired()
                         .HasColumnType("varchar(20)")
                         .HasMaxLength(20)
                         .HasColumnName("CLASSFICATION");

                entity.Property(e => e.Description)
                         .IsRequired()
                         .HasColumnType("varchar(100)")
                         .IsUnicode(true)
                         .HasMaxLength(100)
                         .HasColumnName("DESCRIPTION");

                entity.Property(e => e.PictureURL)
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("PICTURE_URL")
                        .HasMaxLength(100);

                entity.Property(e=>e.DownLoadURL)
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("DOWNLOAD_URL")
                        .HasMaxLength(100);

                entity.Property(e => e.SalesVolume)
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("number")
                        .HasColumnName("SALES_VOLUME");
            });

            modelBuilder.Entity<ShoppingCart>(entity =>
            {
                entity.ToTable("SHOPPINGCART");

                entity.HasKey(e => new { e.ID, e.CommodityID })//对应表的主码
                    .HasName("PK_SHOPPING_CART");

                entity.Property(e => e.ID)
                    .IsRequired()
                    .HasColumnType("number")
                    .HasMaxLength(20)
                    .HasColumnName("ID");

                entity.Property(e => e.CommodityID)
                    .IsRequired()
                    .HasColumnType("number")
                    .HasMaxLength(20)
                    .HasColumnName("Commodity_ID");

                entity.Property(e => e.JoinTime)
                   .IsRequired()
                   .HasColumnType("DATE")
                   .HasColumnName("Join_Time");

                entity.HasOne(d => d.Users)
                   .WithMany(p => p.ShoppingCart)
                   .HasForeignKey(d => d.ID)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK1_SHOPPING_CART");

                entity.HasOne(d => d.Commodities)
                   .WithMany(p => p.ShoppingCart)
                   .HasForeignKey(d => d.CommodityID)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK2_SHOPPING_CART");
            });

            base.OnModelCreating(modelBuilder);
        }
    }

}

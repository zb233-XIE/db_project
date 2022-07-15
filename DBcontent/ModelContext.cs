using System;
using TJ_Games.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TJ_Games.DBContext
{
    public partial class ModelContext:DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrators> Administrator { get; set; }
        public virtual DbSet<Buyers>Buyer { get; set; }
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

            modelBuilder.Entity<GameLibrary>(entity =>
            {
                entity.ToTable("GAMELIBRARY");

                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(true)
                    .HasColumnType("varchar(20)")
                    .HasColumnName("ID");

                entity.Property(e => e.CommodityID)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(true)
                    .HasColumnType("varchar(20)")
                    .HasColumnName("COMMODITY_ID");

                entity.Property(e => e.PurchaseTime)
                    .IsRequired()
                    .HasColumnType("DATE")
                    .HasColumnName("PURCHASE_TIME");

                entity.Property(e => e.GameTime)
                    .IsRequired()
                    .HasColumnType("DATE")
                    .HasColumnName("GAME_TIME");

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.GameLibrary)
                    .HasForeignKey(d => d.ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_ID");

                entity.HasOne(d => d.Commodities)
                    .WithMany(p => p.GameLibrary)
                    .HasForeignKey(d => d.CommodityID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK1_GAME_LIBRARY_COMMODITIES");
            });

            modelBuilder.Entity<Giftcode>(entity =>
            {
                entity.ToTable("GIFTCODE");

                entity.HasKey(e => new { e.ActivateCode , e.CommoditiyID })//对应表的主码
                .HasName("PK_GIFT_CODE");

                entity.Property(e => e.ActivateCode)
                    .IsRequired()
                    .IsUnicode(true)
                    .HasMaxLength(20)
                    .HasColumnType("varchar(20)")
                    .HasColumnName("ACTIVIATE_CODE");

                entity.Property(e => e.CommoditiyID)
                    .IsRequired()
                    .IsUnicode(true)
                    .HasMaxLength(20)
                    .HasColumnType("varchar(20)")
                    .HasColumnName("COMMODITY_ID");

                entity.Property(e => e.CreateTime)
                    .IsRequired()
                    .HasColumnType("DATA")
                    .HasColumnName("CREATE_TIME");

                entity.Property(e => e.IsUsed)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnType("number")
                    .HasColumnName("IS_USED");

                entity.HasOne(d => d.Commodities)
                    .WithMany(p => p.Giftcode)
                    .HasForeignKey(d => d.CommoditiyID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK1_GIFT_CODE_COMMODITIES");

            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("MESSAGE");

                entity.HasKey(e => e.MessageID)
                        .HasName("PK_MESSAGE");

                entity.Property(e => e.MessageID)
                    .IsRequired()
                    .IsUnicode(true)
                    .HasMaxLength(20)
                    .HasColumnType("varchar(20)")
                    .HasColumnName("MESSAGE_ID");

                entity.Property(e => e.MessagTitle)
                    .IsRequired()
                    .IsUnicode(true)
                    .HasMaxLength(20)
                    .HasColumnType("varchar(20)")
                    .HasColumnName("MESSAGE_TITLE");
 
                entity.Property(e => e.MessageContent)
                    .IsRequired()
                    .IsUnicode(true)
                    .HasMaxLength(1000)
                    .HasColumnType("varchar(1000)")
                    .HasColumnName("MESSAGE_CONTENT");

                entity.Property(e => e.MessageTime)
                    .IsRequired()
                    .HasColumnType("DATE")
                    .HasColumnName("MESSAGE_TIME");

                entity.Property(e => e.ReceiverID)
                    .IsRequired()
                    .IsUnicode(true)
                    .HasMaxLength(20)
                    .HasColumnType("varchar(20)")
                    .HasColumnName("RECEIVER_ID");

                entity.Property(e => e.IsRead)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnType("number")
                    .HasColumnName("IS_READ");

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.Message)
                    .HasForeignKey(d => d.ReceiverID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK1_MESSAGE_USERS");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
   
}

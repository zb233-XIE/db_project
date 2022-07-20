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

        public virtual DbSet<Administrators> Administrators { get; set; }
        public virtual DbSet<Buyers> Buyers { get; set; }
        public virtual DbSet<Commodities> Commodities { get; set; }
        public virtual DbSet<Evaluation> Evaluation { get; set; }
        public virtual DbSet<Friends> Friends { get; set; }
        public virtual DbSet<GameLibrary> GameLibrary { get; set; }
        public virtual DbSet<Giftcode> Giftcode { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Publishers> Publishers { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCart { get; set; }
        public virtual DbSet<Updatelog> Updatelog { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Wishlist> Wishlist { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("C##xzb");

            modelBuilder.Entity<Administrators>(entity =>
            {
                entity.ToTable("ADMINISTRATORS");

                entity.HasKey(e => e.AdminID)
                    .HasName("ADMINISTRATORS_PK");

                entity.Property(e => e.AdminID)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnType("varchar(20)")
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

                entity.HasOne(d => d.Users)
                    .WithOne(p => p.Administrators)
                    .HasForeignKey<Administrators>(d => d.AdminID)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("ADMINISTRATORS_FK1");
            });

            modelBuilder.Entity<Buyers>(entity =>
            {
                entity.ToTable("BUYERS");

                entity.HasKey(e => e.BuyerID)
                    .HasName("BUYERS_PK");

                entity.Property(e => e.BuyerID)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnType("varchar(20)")
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

                entity.HasOne(d => d.Users)
                        .WithOne(p => p.Buyers)
                        .HasForeignKey<Buyers>(d => d.BuyerID)
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("BUYERS_FK1");
            });

            modelBuilder.Entity<Commodities>(entity =>
            {
                entity.ToTable("COMMODITIES");

                entity.HasKey(e => e.CommodityID)
                        .HasName("COMMODITIES_PK");

                entity.Property(e => e.CommodityID)
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("COMMODITY_ID");

                entity.Property(e => e.CommodityName)
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("COMMODITY_NAME")
                        .IsUnicode(true);

                entity.Property(e => e.PublisherID)
                         .IsRequired()
                         .HasMaxLength(20)
                         .HasColumnType("varchar(20)")
                         .HasColumnName("PUBLISHER_ID")
                         .IsUnicode(true);

                entity.Property(e => e.Price)
                         .IsRequired()
                         .HasColumnType("number(8,2)")
                         .HasColumnName("PRICE");

                entity.Property(e => e.LowestPrice)
                      .IsRequired()
                      .HasColumnType("number(8,2)")
                      .HasColumnName("LOWEST_PRICE");


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

                entity.Property(e => e.DownLoadURL)
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

                entity.HasOne(d => d.Publishers)
                        .WithMany(p => p.Commodities)
                        .HasForeignKey(d => d.PublisherID)
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("COMMODITIES_FK1");
            });

            modelBuilder.Entity<Updatelog>(entity =>
            {
                entity.ToTable("UPDATE_LOG");
;
                entity.HasKey(e => new { e.CommodityID, e.VersionNumber })
                      .HasName("UPDATE_LOG_PK");

                entity.Property(e => e.CommodityID)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnType("varchar(20)")
                    .HasColumnName("COMMODITY_ID");

                entity.Property(e => e.VersionNumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(true)
                    .HasColumnType("varchar(20)")
                    .HasColumnName("VERSION_NUMBER");

                entity.Property(e => e.UpdateTime)
                    .IsRequired()
                    .HasColumnType("date")
                    .HasColumnName("UPDATETIME");

                entity.Property(e => e.Description)
                     .IsRequired()
                     .HasColumnType("varchar(1000)")
                     .IsUnicode(true)
                     .HasColumnName("UPDATECONTENT");

                entity.HasOne(d => d.Commodities)
                      .WithMany(p => p.Updatelog)
                      .HasForeignKey(d => d.CommodityID)
                      .OnDelete(DeleteBehavior.Cascade)
                      .HasConstraintName("UPDATE_LOG_FK1");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("USERS");

                entity.HasKey(e => e.UserID)
                    .HasName("USERS_PK");

                entity.Property(e => e.UserID)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnType("varchar(20)")
                    .HasColumnName("User_ID");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(true)
                    .HasColumnType("varchar(20)")
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.UserType)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnType("varchar(20)")
                    .HasColumnName("USERTYPE");

            });

            modelBuilder.Entity<Wishlist>(entity =>
            {
                entity.ToTable("WISHLIST");

                entity.HasKey(e => new { e.ID, e.CommodityID })
                    .HasName("WISHLIST_PK");

                entity.Property(e => e.ID)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnType("varchar(20)")
                    .HasColumnName("ID");

                entity.Property(e => e.CommodityID)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnType("varchar(20)")
                    .HasColumnName("COMMODITY_ID");

                entity.Property(e => e.PromoteMessage)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(true)
                    .HasColumnType("varchar(100)")
                    .HasColumnName("PROMOTE_MESSAGE");

                entity.HasOne(d => d.Commodities)
                      .WithMany(p => p.Wishlist)
                      .HasForeignKey(d => d.CommodityID)
                      .OnDelete(DeleteBehavior.Cascade)
                      .HasConstraintName("WISHLIST_FK2");

                entity.HasOne(d => d.Users)
                      .WithMany(p => p.Wishlist)
                      .HasForeignKey(d => d.ID)
                      .OnDelete(DeleteBehavior.Cascade)
                      .HasConstraintName("WISHLIST_FK1");

            });

            modelBuilder.Entity<Evaluation>(entity =>
            {
                entity.ToTable("EVALUATION");

                entity.HasKey(e => new { e.CommodityID, e.UserID })//对应表的主码
                    .HasName("EVALUATION_PK");

                entity.Property(e => e.CommodityID)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnType("varchar(20)")
                    .HasColumnName("COMMODITY_ID");

                entity.Property(e => e.UserID)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnType("varchar(20)")
                    .HasColumnName("USER_ID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("varchar(2000)")
                    .IsUnicode(true)
                    .HasColumnName("EVALUATION");

                entity.Property(e => e.EvaluaionTime)
                    .IsRequired()
                    .HasColumnType("DATE")
                    .HasColumnName("EVALUATION_TIME");

                entity.Property(e => e.AdministratorID)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnType("varchar(20)")
                    .HasColumnName("ADMINISTRATOR_ID");

                entity.HasOne(d => d.Commodities)
                       .WithMany(p => p.Evaluation)
                       .HasForeignKey(d => d.CommodityID)
                       .OnDelete(DeleteBehavior.Cascade)
                       .HasConstraintName("EVALUATION_FK1");

                entity.HasOne(d => d.Users)
                        .WithMany(p => p.Evaluation)
                        .HasForeignKey(d => d.UserID)
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("EVALUATION_FK2");

                entity.HasOne(d => d.Administrators)
                       .WithMany(p => p.Evaluation)
                       .HasForeignKey(d => d.AdministratorID)
                       .OnDelete(DeleteBehavior.Cascade)
                       .HasConstraintName("EVALUATION_FK3");
            });

            modelBuilder.Entity<Friends>(entity =>
            {
                entity.ToTable("FRIENDS");

                entity.HasKey(e => new { e.UserID, e.FriendID })//对应表的主码
                    .HasName("FRIENDS_PK");

                entity.Property(e => e.UserID)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnType("varchar(20)")
                    .HasColumnName("USER_ID");

                entity.Property(e => e.FriendID)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnType("varchar(20)")
                    .HasColumnName("FRIEND_ID");

                //这个自引用关系我没配出来，待曹晓慈完善
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderID)
                    .HasName("ORDERS_PK");

                entity.ToTable("ORDERS");

                entity.Property(e => e.OrderID)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(true)
                    .HasColumnName("ORDER_ID");

                entity.Property(e => e.CommodityID)
                   .IsRequired()
                   .HasMaxLength(20)
                   .IsUnicode(true)
                   .HasColumnName("PRODUCT_ID");

                entity.Property(e => e.BuyerID)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(true)
                    .HasColumnName("BUYER_ID");

                entity.Property(e => e.OrderTime)
                    .HasColumnType("DATE")
                    .HasColumnName("ORDERTIME");

                entity.Property(e => e.OrderCost)
                    .HasColumnName("ORDERCOST");
                //.HasColumnType("INT64")

                entity.Property(e => e.Type)
                    .HasColumnName("TYPE")
                    .HasColumnType("int");

                entity.HasOne(d => d.Buyers)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.BuyerID)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("ORDERS_FK1");

                entity.HasOne(d => d.Commodities)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CommodityID)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("ORDERS_FK2");
            });

            modelBuilder.Entity<Publishers>(entity =>
            {
                entity.HasKey(e => e.PublisherID)
                    .HasName("PUBLISHERS_PK");

                entity.ToTable("PUBLISHERS");

                entity.Property(e => e.PublisherID)
                    .IsRequired()
                     .HasColumnType("varchar(20)")
                    .HasMaxLength(20)
                    .IsUnicode(true)
                    .HasColumnName("PUBLISHER_ID");

                entity.Property(e => e.PublisherName)
                    .IsRequired()
                     .HasColumnType("varchar(20)")
                    .HasMaxLength(20)
                    .IsUnicode(true)
                    .HasColumnName("PUBLISHER_NAME");

                entity.Property(e => e.StartTime)
                    .HasColumnType("DATE")
                    .HasColumnName("STARTTIME");

                entity.Property(e => e.Description)
                    .IsRequired()
                     .HasColumnType("varchar(2000)")
                    .HasMaxLength(2000)
                    .IsUnicode(true)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.HomepageURL)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(true)
                    .HasColumnName("HOMEPAGEURL");

                entity.HasOne(d => d.Users)
                    .WithOne(p => p.Publishers)
                    .HasForeignKey<Publishers>(d => d.PublisherID)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("PUBLISHERS_FK1");

            });

            modelBuilder.Entity<ShoppingCart>(entity =>
            {
                entity.ToTable("SHOPPINGCART");

                entity.HasKey(e => new { e.ID, e.CommodityID })//对应表的主码
                    .HasName("PK_SHOPPING_CART");

                entity.Property(e => e.ID)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasMaxLength(20)
                    .HasColumnName("ID");

                entity.Property(e => e.CommodityID)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasMaxLength(20)
                    .HasColumnName("COMMODITY_ID");

                entity.Property(e => e.JoinTime)
                   .IsRequired()
                   .HasColumnType("DATE")
                   .HasColumnName("JOIN_TIME");

                entity.HasOne(d => d.Users)
                   .WithMany(p => p.ShoppingCart)
                   .HasForeignKey(d => d.ID)
                   .OnDelete(DeleteBehavior.Cascade)
                   .HasConstraintName("SHOPPINGCART_FK1");

                entity.HasOne(d => d.Commodities)
                   .WithMany(p => p.ShoppingCart)
                   .HasForeignKey(d => d.CommodityID)
                   .OnDelete(DeleteBehavior.Cascade)
                   .HasConstraintName("SHOPPINGCART_FK2");
            });

            modelBuilder.Entity<GameLibrary>(entity =>
            {
                entity.ToTable("GAMELIBRARY");

                entity.HasKey(e => e.ID)
                    .HasName("GAMELIBRARY_PK");

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
                    .HasColumnType("varchar(20)")
                    .HasColumnName("GAME_TIME");

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.GameLibrary)
                    .HasForeignKey(d => d.ID)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("GAMELIBRARY_FK1");

                entity.HasOne(d => d.Commodities)
                    .WithMany(p => p.GameLibrary)
                    .HasForeignKey(d => d.CommodityID)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("GAMELIBRARY_FK2");
            });

            modelBuilder.Entity<Giftcode>(entity =>
            {
                entity.ToTable("GIFTCODE");

                entity.HasKey(e => e.ActivateCode)//对应表的主码
                .HasName("GIFTCODE_PK");

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
                    .HasColumnType("DATE")
                    .HasColumnName("CREATE_TIME");

                entity.Property(e => e.IsUsed)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnType("number")
                    .HasColumnName("IS_USED");

                entity.HasOne(d => d.Commodities)
                    .WithMany(p => p.Giftcode)
                    .HasForeignKey(d => d.CommoditiyID)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("GIFTCODE_FK1");

            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("MESSAGE");

                entity.HasKey(e => e.MessageID)
                        .HasName("MESSAGE_PK");

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
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("MESSAGE_FK1");
            });

            base.OnModelCreating(modelBuilder);
        }
    }

}

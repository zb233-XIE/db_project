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
            });

            modelBuilder.Entity<Buyers>(entity =>
            {
                entity.ToTable("BUYERS");

                entity.HasKey(e => e.BuyerID);

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
                        .HasConstraintName("FK_USER_ID");

                entity.HasOne(d => d.Users)
                         .WithOne(p => p.Buyers)
                         .HasForeignKey<Buyers>(d => d.BuyerName)
                         .HasConstraintName("FK_BUYER_NAME");

            });

            modelBuilder.Entity<Commodities>(entity =>
            {
                entity.ToTable("COMMODITIES");

                entity.HasKey(e => e.CommodityID)
                        .HasName("PK_COMMODITIES");

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

                entity.Property(e => e.Publisher)
                         .IsRequired()
                         .HasMaxLength(20)
                         .HasColumnType("varchar(20)")
                         .HasColumnName("PUBLISHER")
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
            });

            modelBuilder.Entity<Updatelog>(entity =>
            {
                entity.ToTable("UPDATE_LOG");

                entity.HasKey(e => new { e.CommodityID, e.VersionNumber });

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
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FK_COMMODITY_ID");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("USERS");

                entity.HasKey(e => e.UserID);

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
                    .HasColumnName("User_TYPE");


            });

            modelBuilder.Entity<Wishlist>(entity =>
            {
                entity.ToTable("WISHLIST");

                entity.HasKey(e => new { e.ID, e.CommodityID });

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
                    .HasColumnName("VERSION_NUMBER");

                entity.HasOne(d => d.Commodities)
                      .WithMany(p => p.Wishlist)
                      .HasForeignKey(d => d.CommodityID)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FK_COMMODITY_ID");

                entity.HasOne(d => d.Users)
                      .WithMany(p => p.Wishlist)
                      .HasForeignKey(d => d.ID)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FK_USER_ID");

            });

            modelBuilder.Entity<Evaluation>(entity =>
            {
                entity.ToTable("EVALUATION");

                entity.HasKey(e => new { e.CommodityID, e.UserID })//对应表的主码
                    .HasName("PK_EVALUATION");

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
                       .OnDelete(DeleteBehavior.ClientSetNull)
                       .HasConstraintName("FK_COMMODITY_ID");

                entity.HasOne(d => d.Users)
                        .WithMany(p => p.Evaluation)
                        .HasForeignKey(d => d.UserID)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_USER_ID");

                entity.HasOne(d => d.Administrators)
                       .WithMany(p => p.Evaluation)
                       .HasForeignKey(d => d.AdministratorID)
                       .OnDelete(DeleteBehavior.ClientSetNull)
                       .HasConstraintName("FK_ADMINISTRATOR_ID");
            });

            modelBuilder.Entity<Friends>(entity =>
            {
                entity.ToTable("FRIENDS");

                entity.HasKey(e => new { e.UserID, e.FriendID })//对应表的主码
                    .HasName("PK_FRIENDS");

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
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderID)
                    .HasName("PK_ORDER");

                entity.ToTable("ORDERS");

                entity.Property(e => e.OrderID)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(true)
                    .HasColumnName("ORDER_ID");
                /*[?]这里到底应该用number还是string呢？文档用的number但是Model中用的是string
                     如果确定为number类型，那么这里和下面的内容都应改为以下内容：
                    .IsRequired()
                    .HasColumnType("number")
                    .HasMaxLength(20)
                    .HasColumnName("ID");
                */

                entity.Property(e => e.CommodityID)
                   .IsRequired()
                   .HasMaxLength(20)
                   .IsUnicode(true)
                   .HasColumnName("PRODUCT_ID");

                entity.Property(e => e.BuyerID)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(true)
                    .HasColumnName("USER_ID");//[?]这里存在Buyer和User不统一的问题，7.14晚上下载的时候还是
                                              //7.12Committed的版本，不知道最新版的情况如何

                entity.Property(e => e.OrderTime)
                    .HasColumnType("DATE")
                    .HasColumnName("ORDERTIME");

                entity.Property(e => e.OrderCost)
                    .HasColumnName("ORDERCOST");
                //.HasColumnType("INT64")

                entity.Property(e => e.Type)
                    .HasColumnName("TYPE")
                    .HasColumnType("int");
                //[?]Oracle数据库中貌似没有boolean类型，取1或取0可以用INT或者1=1或者1=0这样的形式来代替？

                entity.HasOne(d => d.Buyers)//[?]还是Buyer和User的问题这里就先取Buyer了
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK1_ORDERS");

                entity.HasOne(d => d.Commodities)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CommodityID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK2_ORDERS");
            });

            modelBuilder.Entity<Publishers>(entity =>
            {
                entity.HasKey(e => e.PublisherID)
                    .HasName("PK_PUBLISHERS");

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

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(true)
                    .HasColumnName("HOMEPAGEURL");
            });

            //----这里偷懒先用一下致远哥的内容-----
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
                    .HasColumnType("varchar(20)")
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

                entity.HasKey(e => new { e.ActivateCode, e.CommoditiyID })//对应表的主码
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

﻿using System;
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
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<Commodity_Genre> Commodity_Genre { get; set; }
        public virtual DbSet<Dialog> Dialog { get; set; }
        public virtual DbSet<Order_Commodity> Order_Commmodity { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("C##SZY");

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
                    .HasColumnName("BIRTHDAY");

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
                         .HasColumnType("double")
                         .HasColumnName("PRICE");

                entity.Property(e => e.LowestPrice)
                      .IsRequired()
                      .HasColumnType("double")
                      .HasColumnName("LOWEST_PRICE");


                entity.Property(e => e.PublishTime)
                         .IsRequired()
                         .HasColumnType("DATE")
                         .HasColumnName("PUBLISH_TIME");

                entity.Property(e => e.Description)
                         .IsRequired()
                         .HasColumnType("varchar(100)")
                         .IsUnicode(true)
                         .HasMaxLength(100)
                         .HasColumnName("DESCRIPTION");

                entity.Property(e => e.PictureURL)
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("PICTURE_URL")
                        .HasMaxLength(200);

                entity.Property(e => e.DownLoadURL)
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("DOWNLOAD_URL")
                        .HasMaxLength(200);

                entity.Property(e => e.SalesVolume)
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("int")
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
                    .HasColumnName("USER_ID");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .IsUnicode(true)
                    .HasColumnType("varchar(300)")
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.UserType)
                    .IsRequired()
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

                entity.HasOne(d => d.Buyers)
                      .WithMany(p => p.Wishlist)
                      .HasForeignKey(d => d.ID)
                      .OnDelete(DeleteBehavior.Cascade)
                      .HasConstraintName("WISHLIST_FK1");

            });

            modelBuilder.Entity<Evaluation>(entity =>
            {
                entity.ToTable("EVALUATION");

                entity.HasKey(e => new { e.CommodityID, e.BuyerID })//对应表的主码
                    .HasName("EVALUATION_PK");

                entity.Property(e => e.CommodityID)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnType("varchar(20)")
                    .HasColumnName("COMMODITY_ID");

                entity.Property(e => e.BuyerID)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnType("varchar(20)")
                    .HasColumnName("BUYER_ID");

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

                entity.HasOne(d => d.Buyers)
                        .WithMany(p => p.Evaluation)
                        .HasForeignKey(d => d.BuyerID)
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

                entity.Property(e => e.BuyerID)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(true)
                    .HasColumnName("BUYER_ID");

                entity.Property(e => e.ReceiverID)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(true)
                    .HasColumnName("RECEIVER_ID");

                entity.Property(e => e.OrderTime)
                    .HasColumnType("DATE")
                    .HasColumnName("ORDERTIME");

                entity.Property(e => e.OrderCost)
                    .HasColumnName("ORDERCOST");
                //.HasColumnType("INT64")

                entity.HasOne(d => d.Buyers)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.BuyerID)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("ORDERS_FK1");

                entity.HasOne(d => d.Buyers)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ReceiverID)
                    .OnDelete(DeleteBehavior.SetNull)
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

                entity.HasOne(d => d.Buyers)
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

                entity.HasKey(e => new { e.ID, e.CommodityID })
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

                entity.HasOne(d => d.Buyers)
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

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("GENRE");

                entity.HasKey(e => e.ID)
                        .HasName("GENRE_PK");

                entity.Property(e => e.ID)
                    .IsRequired()
                    .IsUnicode(true)
                    .HasMaxLength(20)
                    .HasColumnType("varchar(20)")
                    .HasColumnName("ID");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .IsUnicode(true)
                    .HasMaxLength(20)
                    .HasColumnType("varchar(20)")
                    .HasColumnName("TYPE");
            });

            modelBuilder.Entity<Commodity_Genre>(entity =>
            {
                entity.ToTable("COMMODITY_GENRE");

                entity.HasKey(e => new { e.CommodityID,e.GenreID})
                        .HasName("COMMODITY_GENRE_PK");

                entity.Property(e => e.CommodityID)
                    .IsRequired()
                    .IsUnicode(true)
                    .HasMaxLength(20)
                    .HasColumnType("varchar(20)")
                    .HasColumnName("COMMODITY_ID");

                entity.Property(e => e.GenreID)
                    .IsRequired()
                    .IsUnicode(true)
                    .HasMaxLength(20)
                    .HasColumnType("varchar(20)")
                    .HasColumnName("GENRE_ID");

                entity.HasOne(d => d.Commodities)
                    .WithMany(p => p.Commodity_Genre)
                    .HasForeignKey(d => d.CommodityID)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("COMMODITY_GENRE_FK1");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Commodity_Genre)
                    .HasForeignKey(d => d.GenreID)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("COMMODITY_GENRE_FK2");
            });

            modelBuilder.Entity<Dialog>(entity =>
            {
                entity.ToTable("DIALOG");

                entity.HasKey(e => new { e.SenderID, e.ReceiverID, e.Time })
                        .HasName("DIALOG_PK");

                entity.Property(e => e.SenderID)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnType("varchar(20)")
                    .HasColumnName("SENDER_ID");

                entity.Property(e => e.ReceiverID)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnType("varchar(20)")
                    .HasColumnName("RECEIVER_ID");

                entity.Property(e => e.Time)
                    .HasColumnType("DATE")
                    .HasColumnName("TIME");

                entity.Property(e => e.content)
                    .IsRequired()
                    .HasColumnType("varchar(300)")
                    .HasMaxLength(300)
                    .IsUnicode(true)
                    .HasColumnName("CONTENT");

                entity.HasOne(d => d.Users)
                    .WithOne(p => p.Dialog)
                    .HasForeignKey<Dialog>(d => d.SenderID)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("DIALOG_FK1");

                entity.HasOne(d => d.Users)
                    .WithOne(p => p.Dialog)
                    .HasForeignKey<Dialog>(d => d.ReceiverID)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("DIALOG_FK2");
            });
            modelBuilder.Entity<Order_Commodity>(entity =>
            {
                entity.ToTable("ORDER_COMMODITY");

                entity.HasKey(e => new { e.CommodityID, e.OrderID })
                        .HasName("ORDER_COMMODITY_PK");

                entity.Property(e => e.CommodityID)
                    .IsRequired()
                    .IsUnicode(true)
                    .HasMaxLength(20)
                    .HasColumnType("varchar(20)")
                    .HasColumnName("PRODUCT_ID");

                entity.Property(e => e.OrderID)
                    .IsRequired()
                    .IsUnicode(true)
                    .HasMaxLength(20)
                    .HasColumnType("varchar(20)")
                    .HasColumnName("ORDER_ID");

                entity.HasOne(d => d.Orders)
                    .WithMany(p => p.Order_Commodity)
                    .HasForeignKey(d => d.OrderID)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("ORDER_COMMODITY_FK1");

                entity.HasOne(d => d.Commodities)
                    .WithMany(p => p.Order_Commodity)
                    .HasForeignKey(d => d.CommodityID)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("ORDER_COMMODITY_FK2");
            });

            base.OnModelCreating(modelBuilder);
        }
    }

}

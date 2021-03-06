﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Raffle.Dal;

namespace Raffle.Dal.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20181210181716_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new { Id = "21e2b553-7852-4d0a-8173-5d60fbacb090", ConcurrencyStamp = "b7ecdad4-aa9c-49ad-9b53-4a19a216e967", Name = "Superuser", NormalizedName = "SUPERUSER" },
                        new { Id = "a19f3c3b-503f-4eae-a01b-bd324bc2863e", ConcurrencyStamp = "52f58a78-e572-4c86-8163-36e9d1703059", Name = "Participant", NormalizedName = "PARTICIPANT" }
                    );
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Raffle.Domain.Interface.Entity.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Raffle.Domain.Interface.Entity.Customer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Gender");

                    b.Property<string>("IdentityId");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Locale");

                    b.Property<string>("Location");

                    b.HasKey("Id");

                    b.HasIndex("IdentityId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Raffle.Domain.Interface.Entity.Gift", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Image");

                    b.Property<string>("ImageLocal");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Gifts");

                    b.HasData(
                        new { Id = 1L, Description = "Смартфон Apple iPhone X – воплощение статуса, надежности и передовых технологий.", Image = "https://www.re-store.ru/upload/iblock/ea3/ea3a57da3137cf5be1c0b3d1e8999a37.jpg", IsDeleted = false, Name = "Apple iPhone X" },
                        new { Id = 2L, Description = "6.3 Смартфон Samsung Galaxy Note 8 64 ГБ – устройство, в котором внимание уделялось всем деталям.", Image = "https://cdn.images.express.co.uk/img/dynamic/galleries/x701/260002.jpg", IsDeleted = false, Name = "Samsung Galaxy Note 8" },
                        new { Id = 3L, Description = "Игровая приставка PlayStation 4 Pro в полной мере оправдывает свое название. В приставке есть все необходимое для комфортного использования любимых игр. ", Image = "https://s0.rbk.ru/v6_top_pics/resized/1440xH/media/img/5/16/754733297837165.png", IsDeleted = false, Name = "PlayStation 4 Pro" },
                        new { Id = 4L, Description = "Игровая приставка Microsoft Xbox One S + Forza Horizon 3 – лучшее, что вы можете приобрести, если являетесь заядлым поклонником видеоигр.", Image = "https://avatars.mds.yandex.net/get-mpic/195452/img_id1065977498717792190/9hq", IsDeleted = false, Name = "Microsoft Xbox One" },
                        new { Id = 5L, Description = "Смартфон Apple iPhone 7 выполнен в герметичном черном алюминиевом корпусе, защищающем его от брызг, царапин и пыли. ", Image = "https://www.o2.co.uk/shop/homepage/images/shop15/brand/apple/iphone7/apple-iphone-7-gallery-img-5.jpg", IsDeleted = false, Name = "Apple iPhone 7" },
                        new { Id = 6L, Description = "Телевизор LED LG 43UK6200 поддерживает цифровые тюнеры DVB-T, DVB-T2, DVB-C, DVB-S и DVB-S2.", ImageLocal = "LED LG 43UK6200 2.jpg", IsDeleted = false, Name = "Телевизор LED LG 43UK6200" },
                        new { Id = 7L, Description = "Микроволновая печь LG MH6336GIB выполнена в стильном матовом корпусе черного цвета.", ImageLocal = "LG MH6336GIB.jpg", IsDeleted = false, Name = "Микроволновая печь LG MH6336GIB" },
                        new { Id = 8L, Description = "9.7-дюймовый планшет Samsung GALAXY Tab S2 оснащен внушительным запасом встроенной памяти 32 ГБ и беспроводной технологией доступа к мобильной интернет-сети 3G.", ImageLocal = "Samsung GALAXY Tab S2 32 ГБ 3G, LTE черный.jpg", IsDeleted = false, Name = "Планшет Samsung GALAXY Tab S2 9.7" },
                        new { Id = 9L, Description = "Стиральная машина Samsung WW60H2200EWD/LP – модель от компании, которая давно занимается выпуском данной техники.", ImageLocal = "washmachine Samsung WW60H2200EWDLP.jpg", IsDeleted = false, Name = "Стиральная машина Samsung WW60H2200EWD/LP" },
                        new { Id = 10L, Description = "Пылесос Thomas DryBOX AMFIBIA выполнен в корпусе черного цвета с голубыми деталями.", ImageLocal = "Thomas DryBOX AMFIBIA.jpg", IsDeleted = false, Name = "Пылесос Thomas DryBOX AMFIBIA" },
                        new { Id = 11L, Description = "Смартфон Samsung Galaxy A8+ SM-A730F сможет поразить своим обширным функционалом и грандиозным техническим оснащением даже самого требовательного и капризного пользователя.", ImageLocal = "Samsung Galaxy A8+ SM-A730F 32 ГБ черный.jpg", IsDeleted = false, Name = "Смартфон Samsung Galaxy A8+ SM-A730F" }
                    );
                });

            modelBuilder.Entity("Raffle.Domain.Interface.Entity.GiftDraw", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("GiftId");

                    b.Property<string>("Info")
                        .IsRequired();

                    b.Property<bool>("IsDeleted");

                    b.Property<decimal>("Price");

                    b.Property<decimal>("PriceKey");

                    b.Property<decimal>("Reached");

                    b.HasKey("Id");

                    b.HasIndex("GiftId");

                    b.ToTable("GiftDraws");

                    b.HasData(
                        new { Id = 1L, GiftId = 1L, Info = "test info 1", IsDeleted = false, Price = 77000m, PriceKey = 250m, Reached = 0m },
                        new { Id = 2L, GiftId = 2L, Info = "test info 2", IsDeleted = false, Price = 68000m, PriceKey = 250m, Reached = 0m },
                        new { Id = 3L, GiftId = 3L, Info = "test info 3", IsDeleted = false, Price = 30000m, PriceKey = 150m, Reached = 0m },
                        new { Id = 4L, GiftId = 4L, Info = "test info 4", IsDeleted = false, Price = 25000m, PriceKey = 150m, Reached = 0m },
                        new { Id = 5L, GiftId = 5L, Info = "test info 5", IsDeleted = false, Price = 40000m, PriceKey = 200m, Reached = 0m }
                    );
                });

            modelBuilder.Entity("Raffle.Domain.Interface.Entity.GiftDrawUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("GiftDrawId");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("GiftDrawId");

                    b.HasIndex("UserId");

                    b.ToTable("GiftDrawUsers");
                });

            modelBuilder.Entity("Raffle.Domain.Interface.Entity.GiftDrawUserKey", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("GiftDrawUserId");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Key")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("GiftDrawUserId");

                    b.ToTable("GiftDrawUserKeys");
                });

            modelBuilder.Entity("Raffle.Domain.Interface.Entity.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.Property<bool>("Codepro");

                    b.Property<string>("Currency");

                    b.Property<DateTime>("Date");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Label")
                        .IsRequired();

                    b.Property<string>("NotificationType")
                        .IsRequired();

                    b.Property<string>("OperationId")
                        .IsRequired();

                    b.Property<string>("Sender");

                    b.Property<string>("Sha1Hash")
                        .IsRequired();

                    b.Property<bool>("Unaccepted");

                    b.Property<decimal>("WithdrawAmount");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Raffle.Domain.Interface.Entity.Vote", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("GiftId");

                    b.Property<bool>("IsDeleted");

                    b.Property<decimal>("Price");

                    b.Property<long>("VotesAgree");

                    b.Property<long>("VotesDisagree");

                    b.HasKey("Id");

                    b.HasIndex("GiftId");

                    b.ToTable("Votes");

                    b.HasData(
                        new { Id = 1L, GiftId = 6L, IsDeleted = false, Price = 29999m, VotesAgree = 111L, VotesDisagree = 4L },
                        new { Id = 2L, GiftId = 7L, IsDeleted = false, Price = 9999m, VotesAgree = 1L, VotesDisagree = 1L },
                        new { Id = 3L, GiftId = 8L, IsDeleted = false, Price = 29499m, VotesAgree = 23L, VotesDisagree = 0L },
                        new { Id = 4L, GiftId = 9L, IsDeleted = false, Price = 24499m, VotesAgree = 11L, VotesDisagree = 11L },
                        new { Id = 5L, GiftId = 10L, IsDeleted = false, Price = 24999m, VotesAgree = 3L, VotesDisagree = 33L },
                        new { Id = 6L, GiftId = 11L, IsDeleted = false, Price = 22999m, VotesAgree = 22L, VotesDisagree = 10L }
                    );
                });

            modelBuilder.Entity("Raffle.Domain.Interface.Entity.VoteUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("UserId");

                    b.Property<bool>("Value");

                    b.Property<long>("VoteId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("VoteId");

                    b.ToTable("VoteUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Raffle.Domain.Interface.Entity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Raffle.Domain.Interface.Entity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Raffle.Domain.Interface.Entity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Raffle.Domain.Interface.Entity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Raffle.Domain.Interface.Entity.Customer", b =>
                {
                    b.HasOne("Raffle.Domain.Interface.Entity.ApplicationUser", "Identity")
                        .WithMany()
                        .HasForeignKey("IdentityId");
                });

            modelBuilder.Entity("Raffle.Domain.Interface.Entity.GiftDraw", b =>
                {
                    b.HasOne("Raffle.Domain.Interface.Entity.Gift", "Gift")
                        .WithMany("GiftDraws")
                        .HasForeignKey("GiftId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Raffle.Domain.Interface.Entity.GiftDrawUser", b =>
                {
                    b.HasOne("Raffle.Domain.Interface.Entity.GiftDraw", "GiftDraw")
                        .WithMany()
                        .HasForeignKey("GiftDrawId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Raffle.Domain.Interface.Entity.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Raffle.Domain.Interface.Entity.GiftDrawUserKey", b =>
                {
                    b.HasOne("Raffle.Domain.Interface.Entity.GiftDrawUser", "GiftDrawUser")
                        .WithMany("Keys")
                        .HasForeignKey("GiftDrawUserId");
                });

            modelBuilder.Entity("Raffle.Domain.Interface.Entity.Vote", b =>
                {
                    b.HasOne("Raffle.Domain.Interface.Entity.Gift", "Gift")
                        .WithMany()
                        .HasForeignKey("GiftId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Raffle.Domain.Interface.Entity.VoteUser", b =>
                {
                    b.HasOne("Raffle.Domain.Interface.Entity.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.HasOne("Raffle.Domain.Interface.Entity.Vote", "Vote")
                        .WithMany("VoteUsers")
                        .HasForeignKey("VoteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

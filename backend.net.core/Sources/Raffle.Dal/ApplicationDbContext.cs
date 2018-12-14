using System;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Raffle.Dal.Mapping;
using Raffle.Domain.Interface.Entity;

namespace Raffle.Dal
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Gift> Gifts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<GiftDraw> GiftDraws { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<VoteUser> VoteUsers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<GiftDrawUser> GiftDrawUsers{ get; set; }
        public DbSet<GiftDrawUserKey> GiftDrawUserKeys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new GiftMap());
            modelBuilder.ApplyConfiguration(new GiftDrawMap());
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new VoteMap());
            modelBuilder.ApplyConfiguration(new VoteUserMap());
            modelBuilder.ApplyConfiguration(new OrderMap());
            modelBuilder.ApplyConfiguration(new GiftDrawUserMap());
            modelBuilder.ApplyConfiguration(new GiftDrawUserKeyMap());


            //modelBuilder.Entity<GiftDraw>()
            //    .HasOne<Gift>(s => s.Gift)
            //    .WithMany(g => g.GiftDraws)
            //    .HasForeignKey(s => s.GiftId);

            var roleAdmin = new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Superuser", NormalizedName = "SUPERUSER" };
            var roleStandart = new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Participant", NormalizedName = "PARTICIPANT" };

            modelBuilder.Entity<IdentityRole>().HasData(roleAdmin, roleStandart);

            //// derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            //string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            //    password: "qweqwe",
            //    salt: new byte[128 / 8],
            //    prf: KeyDerivationPrf.HMACSHA1,
            //    iterationCount: 10000,
            //    numBytesRequested: 256 / 8));

            //var user = new ApplicationUser { Email = "jusupovz@gmail.com", UserName = "jusupovz@gmail.com", NormalizedEmail = "JUSUPOVZ@GMAIL.COM", NormalizedUserName = "JUSUPOVZ@GMAIL.COM", EmailConfirmed = true, FirstName = "Zamir", LastName = "Yusupov", PasswordHash = hashed };

            //modelBuilder.Entity<ApplicationUser>().HasData(user);



            var gift1 = new Gift
            {
                Id = 1,
                Name = "Apple iPhone X",
                Description =
                    "Смартфон Apple iPhone X – воплощение статуса, надежности и передовых технологий.",
                Image = "https://www.re-store.ru/upload/iblock/ea3/ea3a57da3137cf5be1c0b3d1e8999a37.jpg",
                ImageLocal = null,
                IsDeleted = false
            };

            var gift2 = new Gift
            {
                Id = 2,
                Name = "Samsung Galaxy Note 8",
                Description =
                    "6.3 Смартфон Samsung Galaxy Note 8 64 ГБ – устройство, в котором внимание уделялось всем деталям.",
                Image = "https://cdn.images.express.co.uk/img/dynamic/galleries/x701/260002.jpg",
                ImageLocal = null,
                IsDeleted = false
            };

            var gift3 = new Gift
            {
                Id = 3,
                Name = "PlayStation 4 Pro",
                Description =
                    "Игровая приставка PlayStation 4 Pro в полной мере оправдывает свое название. В приставке есть все необходимое для комфортного использования любимых игр. ",
                Image = "https://s0.rbk.ru/v6_top_pics/resized/1440xH/media/img/5/16/754733297837165.png",
                ImageLocal = null,
                IsDeleted = false
            };

            var gift4 = new Gift
            {
                Id = 4,
                Name = "Microsoft Xbox One",
                Description =
                    "Игровая приставка Microsoft Xbox One S + Forza Horizon 3 – лучшее, что вы можете приобрести, если являетесь заядлым поклонником видеоигр.",
                Image = "https://avatars.mds.yandex.net/get-mpic/195452/img_id1065977498717792190/9hq",
                ImageLocal = null,
                IsDeleted = false
            };

            var gift5 = new Gift
            {
                Id = 5,
                Name = "Apple iPhone 7",
                Description =
                    "Смартфон Apple iPhone 7 выполнен в герметичном черном алюминиевом корпусе, защищающем его от брызг, царапин и пыли. ",
                Image = 
                    "https://www.o2.co.uk/shop/homepage/images/shop15/brand/apple/iphone7/apple-iphone-7-gallery-img-5.jpg",
                ImageLocal = null,
                IsDeleted = false
            };

            var gift6 = new Gift
            {
                Id = 6,
                Name = "Телевизор LED LG 43UK6200",
                Description = "Телевизор LED LG 43UK6200 поддерживает цифровые тюнеры DVB-T, DVB-T2, DVB-C, DVB-S и DVB-S2.",
                Image = null,
                ImageLocal = "LED LG 43UK6200 2.jpg",
                IsDeleted = false
            };

            var gift7 = new Gift
            {
                Id = 7,
                Name = "Микроволновая печь LG MH6336GIB",
                Description = "Микроволновая печь LG MH6336GIB выполнена в стильном матовом корпусе черного цвета.",
                Image = null,
                ImageLocal = "LG MH6336GIB.jpg",
                IsDeleted = false
            };

            var gift8 = new Gift
            {
                Id = 8,
                Name = "Планшет Samsung GALAXY Tab S2 9.7",
                Description = "9.7-дюймовый планшет Samsung GALAXY Tab S2 оснащен внушительным запасом встроенной памяти 32 ГБ и беспроводной технологией доступа к мобильной интернет-сети 3G.",
                Image = null,
                ImageLocal = "Samsung GALAXY Tab S2 32 ГБ 3G, LTE черный.jpg",
                IsDeleted = false
            };

            var gift9 = new Gift
            {
                Id = 9,
                Name = "Стиральная машина Samsung WW60H2200EWD/LP",
                Description = "Стиральная машина Samsung WW60H2200EWD/LP – модель от компании, которая давно занимается выпуском данной техники.",
                Image = null,
                ImageLocal = "washmachine Samsung WW60H2200EWDLP.jpg",
                IsDeleted = false
            };

            var gift10 = new Gift
            {
                Id = 10,
                Name = "Пылесос Thomas DryBOX AMFIBIA",
                Description = "Пылесос Thomas DryBOX AMFIBIA выполнен в корпусе черного цвета с голубыми деталями.",
                Image = null,
                ImageLocal = "Thomas DryBOX AMFIBIA.jpg",
                IsDeleted = false
            };

            var gift11 = new Gift
            {
                Id = 11,
                Name = "Смартфон Samsung Galaxy A8+ SM-A730F",
                Description = "Смартфон Samsung Galaxy A8+ SM-A730F сможет поразить своим обширным функционалом и грандиозным техническим оснащением даже самого требовательного и капризного пользователя.",
                Image = null,
                ImageLocal = "Samsung Galaxy A8+ SM-A730F 32 ГБ черный.jpg",
                IsDeleted = false
            };

            modelBuilder.Entity<Gift>().HasData(gift1, gift2, gift3, gift4, gift5, gift6, gift7, gift8, gift9, gift10, gift11);

            modelBuilder.Entity<GiftDraw>().HasData(
                new GiftDraw { GiftId = gift1.Id, Id = 1, Price = 77000, Info = "test info 1", PriceKey = 250, Reached = 0, IsDeleted = false },
                new GiftDraw { GiftId = gift2.Id, Id = 2, Price = 68000, Info = "test info 2", PriceKey = 250, Reached = 0, IsDeleted = false },
                new GiftDraw { GiftId = gift3.Id, Id = 3, Price = 30000, Info = "test info 3", PriceKey = 150, Reached = 0, IsDeleted = false },
                new GiftDraw { GiftId = gift4.Id, Id = 4, Price = 25000, Info = "test info 4", PriceKey = 150, Reached = 0, IsDeleted = false },
                new GiftDraw { GiftId = gift5.Id, Id = 5, Price = 40000, Info = "test info 5", PriceKey = 200, Reached = 0, IsDeleted = false }
            );

            modelBuilder.Entity<Vote>().HasData(
                new Vote { Id = 1, GiftId = 6, IsDeleted = false, Price = 29999, VotesAgree = 111, VotesDisagree = 4 },
                new Vote { Id = 2, GiftId = 7, IsDeleted = false, Price = 9999, VotesAgree = 1, VotesDisagree = 1 },
                new Vote { Id = 3, GiftId = 8, IsDeleted = false, Price = 29499, VotesAgree = 23, VotesDisagree = 0 },
                new Vote { Id = 4, GiftId = 9, IsDeleted = false, Price = 24499, VotesAgree = 11, VotesDisagree = 11 },
                new Vote { Id = 5, GiftId = 10, IsDeleted = false, Price = 24999, VotesAgree = 3, VotesDisagree = 33 },
                new Vote { Id = 6, GiftId = 11, IsDeleted = false, Price = 22999, VotesAgree = 22, VotesDisagree = 10 }
            );
        }
    }
}

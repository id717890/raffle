using System;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new GiftMap());
            //modelBuilder.ApplyConfiguration(new GiftDrawMap());
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new VoteMap());


            //modelBuilder.Entity<GiftDraw>()
            //    .HasOne<Gift>(s => s.Gift)
            //    .WithMany(g => g.GiftDraws)
            //    .HasForeignKey(s => s.GiftId);

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole {Id = Guid.NewGuid().ToString(), Name = "Superuser", NormalizedName = "SUPERUSER"},
                new IdentityRole {Id = Guid.NewGuid().ToString(), Name = "Participant", NormalizedName = "PARTICIPANT"}
            );

            var gift1 = new Gift
            {
                Id = 1,
                Name = "Apple iPhone X",
                Description =
                    "Смартфон Apple iPhone X – воплощение статуса, надежности и передовых технологий. Большой, 5.8-дюймовый безрамочный экран дарит удивительно четкое и живое изображение (разрешение 2436x1125). Привычный поклонникам бренда интерфейс здесь дополнен такими возможностями, как бесконтактная оплата и зарядка, поддержка максимального количества диапазонов LTE.",
                Image = "https://www.re-store.ru/upload/iblock/ea3/ea3a57da3137cf5be1c0b3d1e8999a37.jpg",
                IsDeleted = false
            };

            var gift2 = new Gift
            {
                Id = 2,
                Name = "Samsung Galaxy Note 8",
                Description =
                    @"6.3 Смартфон Samsung Galaxy Note 8 64 ГБ – устройство, в котором внимание уделялось всем деталям.Выполнена задняя панель в синем цвете,
                    она придает лаконичный дизайн.Устанавливается стекло Corning Gorilla Glass 5 с двух сторон.Оно не царапается при эксплуатации и обладает увеличенной прочностью.",
                Image = "https://cdn.images.express.co.uk/img/dynamic/galleries/x701/260002.jpg",
                IsDeleted = false
            };

            var gift3 = new Gift
            {
                Id = 3,
                Name = "PlayStation 4 Pro",
                Description =
                    "Игровая приставка PlayStation 4 Pro в полной мере оправдывает свое название. В приставке есть все необходимое для комфортного использования любимых игр. ",
                Image = "https://s0.rbk.ru/v6_top_pics/resized/1440xH/media/img/5/16/754733297837165.png",
                IsDeleted = false
            };

            var gift4 = new Gift
            {
                Id = 4,
                Name = "Microsoft Xbox One",
                Description =
                    "Игровая приставка Microsoft Xbox One S + Forza Horizon 3 – лучшее, что вы можете приобрести, если являетесь заядлым поклонником видеоигр.",
                Image = "https://avatars.mds.yandex.net/get-mpic/195452/img_id1065977498717792190/9hq",
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
                IsDeleted = false
            };

            modelBuilder.Entity<Gift>().HasData(gift1, gift2, gift3, gift4, gift5);

            modelBuilder.Entity<GiftDraw>().HasData(
                new GiftDraw
                {
                    //Gift = gift1,
                    GiftId = gift1.Id,
                    Id = 1,
                    Price = 77000,
                    Info = "test info 1",
                    PriceKey = 250,
                    Reached = 0,
                    IsDeleted = false
                },
                new GiftDraw
                {
                    GiftId = gift2.Id,
                    //Gift = gift2
                    Id = 2,
                    Price = 68000,
                    Info = "test info 2",
                    PriceKey = 250,
                    Reached = 0,
                    IsDeleted = false
                },
                new GiftDraw
                {
                    GiftId = gift3.Id,
                    //Gift = gift3,
                    Id = 3,
                    Price = 30000,
                    Info = "test info 3",
                    PriceKey = 150,
                    Reached = 0,
                    IsDeleted = false
                },
                new GiftDraw
                {
                    //Gift = gift4,
                    GiftId = gift4.Id,
                    Id = 4,
                    Price = 25000,
                    Info = "test info 4",
                    PriceKey = 150,
                    Reached = 0,
                    IsDeleted = false
                },
                new GiftDraw
                {
                    //Gift = gift5,
                    GiftId = gift5.Id,
                    Id = 5,
                    Price = 40000,
                    Info = "test info 5",
                    PriceKey = 200,
                    Reached = 0,
                    IsDeleted = false
                }
            );
        }
    }
}

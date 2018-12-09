using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Raffle.Dal.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gifts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    ImageLocal = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gifts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    OperationId = table.Column<string>(nullable: false),
                    NotificationType = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IdentityId = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Locale = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_AspNetUsers_IdentityId",
                        column: x => x.IdentityId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GiftDraws",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    GiftId = table.Column<long>(nullable: false),
                    Info = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    PriceKey = table.Column<decimal>(nullable: false),
                    Reached = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiftDraws", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GiftDraws_Gifts_GiftId",
                        column: x => x.GiftId,
                        principalTable: "Gifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Votes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    GiftId = table.Column<long>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    VotesAgree = table.Column<long>(nullable: false),
                    VotesDisagree = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Votes_Gifts_GiftId",
                        column: x => x.GiftId,
                        principalTable: "Gifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "05106c7c-2b56-4d8a-a704-2688c2baf0fd", "b94194a0-a97d-4de3-a999-0835776d97f3", "Superuser", "SUPERUSER" },
                    { "9990cc90-1bab-41ab-b0df-5050e907cf80", "204cfa45-d7fb-4fc4-b92a-a1a41a44539b", "Participant", "PARTICIPANT" }
                });

            migrationBuilder.InsertData(
                table: "Gifts",
                columns: new[] { "Id", "Description", "Image", "ImageLocal", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1L, "Смартфон Apple iPhone X – воплощение статуса, надежности и передовых технологий.", "https://www.re-store.ru/upload/iblock/ea3/ea3a57da3137cf5be1c0b3d1e8999a37.jpg", null, false, "Apple iPhone X" },
                    { 2L, "6.3 Смартфон Samsung Galaxy Note 8 64 ГБ – устройство, в котором внимание уделялось всем деталям.", "https://cdn.images.express.co.uk/img/dynamic/galleries/x701/260002.jpg", null, false, "Samsung Galaxy Note 8" },
                    { 3L, "Игровая приставка PlayStation 4 Pro в полной мере оправдывает свое название. В приставке есть все необходимое для комфортного использования любимых игр. ", "https://s0.rbk.ru/v6_top_pics/resized/1440xH/media/img/5/16/754733297837165.png", null, false, "PlayStation 4 Pro" },
                    { 4L, "Игровая приставка Microsoft Xbox One S + Forza Horizon 3 – лучшее, что вы можете приобрести, если являетесь заядлым поклонником видеоигр.", "https://avatars.mds.yandex.net/get-mpic/195452/img_id1065977498717792190/9hq", null, false, "Microsoft Xbox One" },
                    { 5L, "Смартфон Apple iPhone 7 выполнен в герметичном черном алюминиевом корпусе, защищающем его от брызг, царапин и пыли. ", "https://www.o2.co.uk/shop/homepage/images/shop15/brand/apple/iphone7/apple-iphone-7-gallery-img-5.jpg", null, false, "Apple iPhone 7" },
                    { 6L, "Телевизор LED LG 43UK6200 поддерживает цифровые тюнеры DVB-T, DVB-T2, DVB-C, DVB-S и DVB-S2.", null, "LED LG 43UK6200 2.jpg", false, "Телевизор LED LG 43UK6200" },
                    { 7L, "Микроволновая печь LG MH6336GIB выполнена в стильном матовом корпусе черного цвета.", null, "LG MH6336GIB.jpg", false, "Микроволновая печь LG MH6336GIB" },
                    { 8L, "9.7-дюймовый планшет Samsung GALAXY Tab S2 оснащен внушительным запасом встроенной памяти 32 ГБ и беспроводной технологией доступа к мобильной интернет-сети 3G.", null, "Samsung GALAXY Tab S2 32 ГБ 3G, LTE черный.jpg", false, "Планшет Samsung GALAXY Tab S2 9.7" },
                    { 9L, "Стиральная машина Samsung WW60H2200EWD/LP – модель от компании, которая давно занимается выпуском данной техники.", null, "washmachine Samsung WW60H2200EWDLP.jpg", false, "Стиральная машина Samsung WW60H2200EWD/LP" },
                    { 10L, "Пылесос Thomas DryBOX AMFIBIA выполнен в корпусе черного цвета с голубыми деталями.", null, "Thomas DryBOX AMFIBIA.jpg", false, "Пылесос Thomas DryBOX AMFIBIA" },
                    { 11L, "Смартфон Samsung Galaxy A8+ SM-A730F сможет поразить своим обширным функционалом и грандиозным техническим оснащением даже самого требовательного и капризного пользователя.", null, "Samsung Galaxy A8+ SM-A730F 32 ГБ черный.jpg", false, "Смартфон Samsung Galaxy A8+ SM-A730F" }
                });

            migrationBuilder.InsertData(
                table: "GiftDraws",
                columns: new[] { "Id", "GiftId", "Info", "IsDeleted", "Price", "PriceKey", "Reached" },
                values: new object[,]
                {
                    { 1L, 1L, "test info 1", false, 77000m, 250m, 0m },
                    { 2L, 2L, "test info 2", false, 68000m, 250m, 0m },
                    { 3L, 3L, "test info 3", false, 30000m, 150m, 0m },
                    { 4L, 4L, "test info 4", false, 25000m, 150m, 0m },
                    { 5L, 5L, "test info 5", false, 40000m, 200m, 0m }
                });

            migrationBuilder.InsertData(
                table: "Votes",
                columns: new[] { "Id", "GiftId", "IsDeleted", "Price", "VotesAgree", "VotesDisagree" },
                values: new object[,]
                {
                    { 1L, 6L, false, 29999m, 111L, 4L },
                    { 2L, 7L, false, 9999m, 1L, 1L },
                    { 3L, 8L, false, 29499m, 23L, 0L },
                    { 4L, 9L, false, 24499m, 11L, 11L },
                    { 5L, 10L, false, 24999m, 3L, 33L },
                    { 6L, 11L, false, 22999m, 22L, 10L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_IdentityId",
                table: "Customers",
                column: "IdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_GiftDraws_GiftId",
                table: "GiftDraws",
                column: "GiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_GiftId",
                table: "Votes",
                column: "GiftId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "GiftDraws");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Votes");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Gifts");
        }
    }
}

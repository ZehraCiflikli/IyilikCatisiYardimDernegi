using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IyilikCatisi.Data.Migrations
{
    /// <inheritdoc />
    public partial class baslangic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Aciklama = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    MenuIcon = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    UstMenuId = table.Column<int>(type: "int", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menu_Menu",
                        column: x => x.UstMenuId,
                        principalTable: "Menu",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MesajTip",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MesajTipi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MesajTip", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roller",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roller", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UyelikDurumu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UyelikDurumu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UyelikDurumu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Yetkiler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YetkiAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yetkiler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "YorumTip",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YorumTipi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YorumTip", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuYetki",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuId = table.Column<int>(type: "int", nullable: true),
                    RolId = table.Column<int>(type: "int", nullable: true),
                    InsertYetki = table.Column<bool>(type: "bit", nullable: true),
                    UpdateYetki = table.Column<bool>(type: "bit", nullable: true),
                    DeleteYetki = table.Column<bool>(type: "bit", nullable: true),
                    SelectYetki = table.Column<bool>(type: "bit", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuYetki", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuYetki_Menu",
                        column: x => x.MenuId,
                        principalTable: "Menu",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MenuYetki_Roller",
                        column: x => x.RolId,
                        principalTable: "Roller",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Soyadi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TcKimlikNo = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EpostaOnay = table.Column<bool>(type: "bit", nullable: true),
                    CepTel = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    CepTelOnay = table.Column<bool>(type: "bit", nullable: true),
                    Sifre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DogumTarihi = table.Column<DateOnly>(type: "date", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    HataliGirisSayisi = table.Column<int>(type: "int", nullable: true),
                    UyelikTarihi = table.Column<DateTime>(type: "datetime", nullable: true),
                    UyelikDurumuId = table.Column<int>(type: "int", nullable: true),
                    UniqueId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kullanicilar_UyelikDurumu",
                        column: x => x.UyelikDurumuId,
                        principalTable: "UyelikDurumu",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "YetkiRol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolId = table.Column<int>(type: "int", nullable: false),
                    YetkiId = table.Column<int>(type: "int", nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YetkiRol", x => x.Id);
                    table.ForeignKey(
                        name: "FK_YetkiRol_Roller",
                        column: x => x.RolId,
                        principalTable: "Roller",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_YetkiRol_Yetkiler",
                        column: x => x.YetkiId,
                        principalTable: "Yetkiler",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Bagislar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Soyadi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TcKimlikNo = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BagisMiktari = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    BagisTuru = table.Column<int>(type: "int", nullable: true),
                    BagisTarihi = table.Column<DateTime>(type: "datetime", nullable: false),
                    BagislaIlgiliMesaj = table.Column<string>(type: "text", nullable: true),
                    KullaniciId = table.Column<int>(type: "int", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bagislar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bagislar_Kullanicilar",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanicilar",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Bildirimler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BildirimTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BildirimBasligi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BildirimIcerigi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Durum = table.Column<bool>(type: "bit", nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bildirimler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bildirimler_Kullanicilar",
                        column: x => x.OlusturanId,
                        principalTable: "Kullanicilar",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Etkinlik",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Baslik = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tarih = table.Column<DateOnly>(type: "date", nullable: true),
                    Saat = table.Column<TimeOnly>(type: "time", nullable: true),
                    Konum = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etkinlik", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Etkinlik_Kullanicilar_OlusturanId",
                        column: x => x.OlusturanId,
                        principalTable: "Kullanicilar",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Haberler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Yazar = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Icerik = table.Column<string>(type: "text", nullable: false),
                    Etiketler = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    YayinTarihi = table.Column<DateOnly>(type: "date", nullable: true),
                    GoruntulenmeSayisi = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime", nullable: true),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime", nullable: true),
                    OlusturanKullaniciId = table.Column<int>(type: "int", nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Haberler__3214EC077EB4FA16", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Haberler_Kullanicilar_OlusturanKullaniciId",
                        column: x => x.OlusturanKullaniciId,
                        principalTable: "Kullanicilar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KullaniciRol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolId = table.Column<int>(type: "int", nullable: false),
                    KullaniciId = table.Column<int>(type: "int", nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KullaniciRol", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KullaniciRol_Kullanicilar",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanicilar",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KullaniciRol_Roller",
                        column: x => x.RolId,
                        principalTable: "Roller",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Makaleler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Yazar = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Icerik = table.Column<string>(type: "text", nullable: false),
                    AnahtarKelime = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    YayinTarihi = table.Column<DateOnly>(type: "date", nullable: true),
                    GoruntulenmeSayisi = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime", nullable: true),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime", nullable: true),
                    OlusturanKullaniciId = table.Column<int>(type: "int", nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Makalele__3214EC07E8AA2610", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Makaleler_Kullanicilar_OlusturanKullaniciId",
                        column: x => x.OlusturanKullaniciId,
                        principalTable: "Kullanicilar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mesajlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciId = table.Column<int>(type: "int", nullable: false),
                    MesajIcerigi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    MesajTipId = table.Column<int>(type: "int", nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesajlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mesajlar_Kullanicilar",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanicilar",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Mesajlar_MesajTip",
                        column: x => x.MesajTipId,
                        principalTable: "MesajTip",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UyelikAidatlari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AidatTutari = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    AidatOdemePeriyodu = table.Column<int>(type: "int", nullable: true),
                    OdemeSonTarihi = table.Column<DateOnly>(type: "date", nullable: true),
                    KayitTarihi = table.Column<DateOnly>(type: "date", nullable: true),
                    KullaniciId = table.Column<int>(type: "int", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UyelikAidatlari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UyelikAidatlari_Kullanicilar",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanicilar",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Yorumlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciId = table.Column<int>(type: "int", nullable: false),
                    YorumMetni = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    YorumTipId = table.Column<int>(type: "int", nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yorumlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Yorumlar_Kullanicilar",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanicilar",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Yorumlar_YorumTip",
                        column: x => x.YorumTipId,
                        principalTable: "YorumTip",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BildirimKullanici",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciId = table.Column<int>(type: "int", nullable: false),
                    BildirimId = table.Column<int>(type: "int", nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BildirimKullanici", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BildirimKullanici_Bildirimler",
                        column: x => x.BildirimId,
                        principalTable: "Bildirimler",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BildirimKullanici_Kullanicilar",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanicilar",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EtkinlikFotograflari",
                columns: table => new
                {
                    EtkinlikId = table.Column<int>(type: "int", nullable: false),
                    Fotograf = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FotografAciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EtkinlikFotograflari", x => x.EtkinlikId);
                    table.ForeignKey(
                        name: "FK_EtkinlikFotograflari_Etkinlik",
                        column: x => x.EtkinlikId,
                        principalTable: "Etkinlik",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bagislar_KullaniciId",
                table: "Bagislar",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_BildirimKullanici_BildirimId",
                table: "BildirimKullanici",
                column: "BildirimId");

            migrationBuilder.CreateIndex(
                name: "IX_BildirimKullanici_KullaniciId",
                table: "BildirimKullanici",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_Bildirimler_OlusturanId",
                table: "Bildirimler",
                column: "OlusturanId");

            migrationBuilder.CreateIndex(
                name: "IX_Etkinlik_OlusturanId",
                table: "Etkinlik",
                column: "OlusturanId");

            migrationBuilder.CreateIndex(
                name: "IX_Haberler_OlusturanKullaniciId",
                table: "Haberler",
                column: "OlusturanKullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_Kullanicilar_UyelikDurumuId",
                table: "Kullanicilar",
                column: "UyelikDurumuId");

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciRol_KullaniciId",
                table: "KullaniciRol",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciRol_RolId",
                table: "KullaniciRol",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Makaleler_OlusturanKullaniciId",
                table: "Makaleler",
                column: "OlusturanKullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_UstMenuId",
                table: "Menu",
                column: "UstMenuId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuYetki_MenuId",
                table: "MenuYetki",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuYetki_RolId",
                table: "MenuYetki",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Mesajlar_KullaniciId",
                table: "Mesajlar",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_Mesajlar_MesajTipId",
                table: "Mesajlar",
                column: "MesajTipId");

            migrationBuilder.CreateIndex(
                name: "IX_UyelikAidatlari_KullaniciId",
                table: "UyelikAidatlari",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_YetkiRol_RolId",
                table: "YetkiRol",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_YetkiRol_YetkiId",
                table: "YetkiRol",
                column: "YetkiId");

            migrationBuilder.CreateIndex(
                name: "IX_Yorumlar_KullaniciId",
                table: "Yorumlar",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_Yorumlar_YorumTipId",
                table: "Yorumlar",
                column: "YorumTipId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bagislar");

            migrationBuilder.DropTable(
                name: "BildirimKullanici");

            migrationBuilder.DropTable(
                name: "EtkinlikFotograflari");

            migrationBuilder.DropTable(
                name: "Haberler");

            migrationBuilder.DropTable(
                name: "KullaniciRol");

            migrationBuilder.DropTable(
                name: "Makaleler");

            migrationBuilder.DropTable(
                name: "MenuYetki");

            migrationBuilder.DropTable(
                name: "Mesajlar");

            migrationBuilder.DropTable(
                name: "UyelikAidatlari");

            migrationBuilder.DropTable(
                name: "YetkiRol");

            migrationBuilder.DropTable(
                name: "Yorumlar");

            migrationBuilder.DropTable(
                name: "Bildirimler");

            migrationBuilder.DropTable(
                name: "Etkinlik");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "MesajTip");

            migrationBuilder.DropTable(
                name: "Roller");

            migrationBuilder.DropTable(
                name: "Yetkiler");

            migrationBuilder.DropTable(
                name: "YorumTip");

            migrationBuilder.DropTable(
                name: "Kullanicilar");

            migrationBuilder.DropTable(
                name: "UyelikDurumu");
        }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using IyilikCatisi.Model.Entity;
using Infrastructure.Interceptors;

namespace IyilikCatisi.Data.Concrete.EntityFramework.context;

public partial class İyilikCatisiDbContext : DbContext
{
    public İyilikCatisiDbContext()
    {
    }

    public İyilikCatisiDbContext(DbContextOptions<İyilikCatisiDbContext> options)
        :  base(options)
    {
    }

    public virtual DbSet<Bagislar> Bagislars { get; set; }

    public virtual DbSet<BildirimKullanici> BildirimKullanicis { get; set; }

    public virtual DbSet<Bildirimler> Bildirimlers { get; set; }

    public virtual DbSet<DenetimKurulu> DenetimKurulus { get; set; }

    public virtual DbSet<Dernek> Derneks { get; set; }

    public virtual DbSet<Etkinlik> Etkinliks { get; set; }

    public virtual DbSet<EtkinlikFotograflari> EtkinlikFotograflaris { get; set; }

    public virtual DbSet<Haberler> Haberlers { get; set; }

    public virtual DbSet<KullaniciRol> KullaniciRols { get; set; }

    public virtual DbSet<Kullanicilar> Kullanicilars { get; set; }

    public virtual DbSet<Makaleler> Makalelers { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<MenuYetki> MenuYetkis { get; set; }

    public virtual DbSet<MesajTip> MesajTips { get; set; }

    public virtual DbSet<Mesajlar> Mesajlars { get; set; }

    public virtual DbSet<Roller> Rollers { get; set; }

    public virtual DbSet<UyelikAidatlari> UyelikAidatlaris { get; set; }

    public virtual DbSet<UyelikDurumu> UyelikDurumus { get; set; }

    public virtual DbSet<YetkiRol> YetkiRols { get; set; }

    public virtual DbSet<Yetkiler> Yetkilers { get; set; }

    public virtual DbSet<YonetimKurulu> YonetimKurulus { get; set; }

    public virtual DbSet<YorumTip> YorumTips { get; set; }
  
    public virtual DbSet<Tarihce> Tarihces { get; set; }

    public virtual DbSet<Tuzuk> Tuzuks { get; set; }

    public virtual DbSet<Yorumlar> Yorumlars { get; set; }

    public virtual DbSet<Fotograflar> Fotograflars { get; set; }

    public virtual DbSet<Videolar> Videolars { get; set; }

    public virtual DbSet<BagisTuru> BagisTurus { get; set; }

    public virtual DbSet<Banka> Bankas { get; set; }



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=DESKTOP-CI46R5B;database=İyilikCatisiDB;trusted_connection=true;TrustServerCertificate=true").AddInterceptors(new AuditInterceptor());
   

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bagislar>(entity =>
        {
            entity.ToTable("Bagislar");

            entity.Property(e => e.Adi).HasMaxLength(50);
            entity.Property(e => e.BagisMiktari).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.BagisTarihi).HasColumnType("date");
            entity.Property(e => e.BagislaIlgiliMesaj).HasColumnType("text");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Soyadi).HasMaxLength(50);

            entity.HasOne(d => d.Kullanici).WithMany(p => p.Bagislars)
                .HasForeignKey(d => d.KullaniciId)
                .HasConstraintName("FK_Bagislar_Kullanicilar");

            entity.HasOne(d => d.BagisTuru).WithMany(p => p.Bagislars)
                .HasForeignKey(d => d.BagisTuruId)
                .HasConstraintName("FK_Bagislar_BagisTuru");

        });

        modelBuilder.Entity<BildirimKullanici>(entity =>
        {
            entity.ToTable("BildirimKullanici");

            entity.HasOne(d => d.Bildirim).WithMany(p => p.BildirimKullanicis)
                .HasForeignKey(d => d.BildirimId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BildirimKullanici_Bildirimler");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.BildirimKullanicis)
                .HasForeignKey(d => d.KullaniciId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BildirimKullanici_Kullanicilar");
        });

        modelBuilder.Entity<Bildirimler>(entity =>
        {
            entity.ToTable("Bildirimler");

            entity.Property(e => e.BildirimBasligi).HasMaxLength(50);
            entity.Property(e => e.BildirimIcerigi).HasMaxLength(250);

            entity.HasOne(d => d.OlusturanKullanici).WithMany(p => p.Bildirimlers)
                .HasForeignKey(d => d.OlusturanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bildirimler_Kullanicilar");
        });

        modelBuilder.Entity<DenetimKurulu>(entity =>
        {
            entity.ToTable("DenetimKurulu");

            entity.Property(e => e.AdSoyad)
                .HasMaxLength(50)
                .HasColumnName("Ad_Soyad");
            entity.Property(e => e.Eposta).HasMaxLength(50);
            entity.Property(e => e.Meslek).HasMaxLength(50);
            entity.Property(e => e.Resim).HasMaxLength(100);
            entity.Property(e => e.Unvan).HasMaxLength(50);
            entity.Property(e => e.İkamet).HasMaxLength(250);
        });

        modelBuilder.Entity<Dernek>(entity =>
        {
            entity.ToTable("Dernek");

            entity.Property(e => e.SayfaAdi).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);

        modelBuilder.Entity<Etkinlik>(entity =>
        {
            entity.ToTable("Etkinlik");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Baslik).HasMaxLength(100);
            entity.Property(e => e.Konum).HasMaxLength(100);
        });

        modelBuilder.Entity<EtkinlikFotograflari>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("EtkinlikFotograflari");

            entity.Property(e => e.EtkinlikId).ValueGeneratedNever();
            entity.Property(e => e.Fotograf).HasMaxLength(50);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Etkinlik).WithMany(p => p.EtkinlikFotograflaris)
                .HasForeignKey(d => d.EtkinlikId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EtkinlikFotograflari_Etkinlik");
        });

        modelBuilder.Entity<Haberler>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Haberler__3214EC077EB4FA16");

            entity.ToTable("Haberler");

            entity.Property(e => e.Baslik)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Etiketler)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.GoruntulenmeSayisi).HasDefaultValue(0);
            //entity.Property(e => e.GuncellemeTarihi).HasColumnType("datetime");
            entity.Property(e => e.Icerik).HasColumnType("text");
            //entity.Property(e => e.OlusturmaTarihi).HasColumnType("datetime");
            entity.Property(e => e.Yazar)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<KullaniciRol>(entity =>
        {
            entity.ToTable("KullaniciRol");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.KullaniciRols)
                .HasForeignKey(d => d.KullaniciId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KullaniciRol_Kullanicilar");

            entity.HasOne(d => d.Rol).WithMany(p => p.KullaniciRols)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KullaniciRol_Roller");
        });

        modelBuilder.Entity<Kullanicilar>(entity =>
        {
            entity.ToTable("Kullanicilar");

            entity.Property(e => e.Adi).HasMaxLength(50);
            entity.Property(e => e.Adres).HasMaxLength(500);
            entity.Property(e => e.CepTel)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Sifre).HasMaxLength(50);
            entity.Property(e => e.Soyadi).HasMaxLength(50);
            entity.Property(e => e.UyelikTarihi).HasColumnType("datetime");

            entity.HasOne(d => d.UyelikDurumu).WithMany(p => p.Kullanicilars)
                .HasForeignKey(d => d.UyelikDurumuId)
                .HasConstraintName("FK_Kullanicilar_UyelikDurumu");
        });

        modelBuilder.Entity<Makaleler>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Makalele__3214EC07E8AA2610");

            entity.ToTable("Makaleler");

            entity.Property(e => e.AnahtarKelime)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.GoruntulenmeSayisi).HasDefaultValue(0);
            entity.Property(e => e.Icerik).HasColumnType("text");
                   
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.ToTable("Menu");

            entity.Property(e => e.Aciklama).HasMaxLength(200);
            entity.Property(e => e.Baslik).HasMaxLength(50);
            entity.Property(e => e.MenuIcon).HasMaxLength(200);

            entity.HasOne(d => d.UstMenu).WithMany(p => p.InverseUstMenu)
                .HasForeignKey(d => d.UstMenuId)
                .HasConstraintName("FK_Menu_Menu");
        });

        modelBuilder.Entity<MenuYetki>(entity =>
        {
            entity.ToTable("MenuYetki");

            entity.HasOne(d => d.Menu).WithMany(p => p.MenuYetkis)
                .HasForeignKey(d => d.MenuId)
                .HasConstraintName("FK_MenuYetki_Menu");

            entity.HasOne(d => d.Rol).WithMany(p => p.MenuYetkis)
                .HasForeignKey(d => d.RolId)
                .HasConstraintName("FK_MenuYetki_Roller");
        });


        modelBuilder.Entity<MesajTip>(entity =>
        {
            entity.ToTable("MesajTip");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.MesajTipi).HasMaxLength(50);
        });

        modelBuilder.Entity<Mesajlar>(entity =>
        {
            entity.ToTable("Mesajlar");

            entity.Property(e => e.MesajIcerigi).HasMaxLength(250);

            entity.HasOne(d => d.Kullanici).WithMany(p => p.Mesajlars)
                .HasForeignKey(d => d.KullaniciId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Mesajlar_Kullanicilar");

            entity.HasOne(d => d.MesajTip).WithMany(p => p.Mesajlars)
                .HasForeignKey(d => d.MesajTipId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Mesajlar_MesajTip");
        });

        modelBuilder.Entity<Roller>(entity =>
        {
            entity.ToTable("Roller");

            entity.Property(e => e.RolAdi).HasMaxLength(50);
        });

        modelBuilder.Entity<UyelikAidatlari>(entity =>
        {
            entity.ToTable("UyelikAidatlari");

            entity.Property(e => e.AidatTutari).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.UyelikAidatlaris)
                .HasForeignKey(d => d.KullaniciId)
                .HasConstraintName("FK_UyelikAidatlari_Kullanicilar");
        });

        modelBuilder.Entity<UyelikDurumu>(entity =>
        {
            entity.ToTable("UyelikDurumu");

            entity.Property(e => e.UyelikDurumu1)
                .HasMaxLength(50)
                .HasColumnName("UyelikDurumu");
        });

        modelBuilder.Entity<YetkiRol>(entity =>
        {
            entity.ToTable("YetkiRol");

            entity.HasOne(d => d.Rol).WithMany(p => p.YetkiRols)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_YetkiRol_Roller");

            entity.HasOne(d => d.Yetki).WithMany(p => p.YetkiRols)
                .HasForeignKey(d => d.YetkiId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_YetkiRol_Yetkiler");
        });

        modelBuilder.Entity<Yetkiler>(entity =>
        {
            entity.ToTable("Yetkiler");

            entity.Property(e => e.YetkiAdi).HasMaxLength(50);
        });

        modelBuilder.Entity<YonetimKurulu>(entity =>
        {
            entity.ToTable("YonetimKurulu");

            entity.Property(e => e.Aciklama).HasMaxLength(200);
            entity.Property(e => e.AdSoyadi)
                .HasMaxLength(50)
                .HasColumnName("Ad_Soyadi");
            entity.Property(e => e.Eposta).HasMaxLength(50);
            entity.Property(e => e.Meslek).HasMaxLength(50);
            entity.Property(e => e.Resim).HasMaxLength(100);
            entity.Property(e => e.Unvan).HasMaxLength(50);
            entity.Property(e => e.İkamet).HasMaxLength(250);
        });

        modelBuilder.Entity<YorumTip>(entity =>
        {
            entity.ToTable("YorumTip");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.YorumTipi).HasMaxLength(50);
        });

        modelBuilder.Entity<Yorumlar>(entity =>
        {
            entity.ToTable("Yorumlar");

            entity.Property(e => e.YorumMetni).HasMaxLength(250);

            entity.HasOne(d => d.Kullanici).WithMany(p => p.Yorumlars)
                .HasForeignKey(d => d.KullaniciId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Yorumlar_Kullanicilar");

            entity.HasOne(d => d.YorumTip).WithMany(p => p.Yorumlars)
                .HasForeignKey(d => d.YorumTipId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Yorumlar_YorumTip");
        });

		modelBuilder.Entity<Tarihce>(entity =>
		{
			entity.ToTable("Tarihce");

			
		});

        modelBuilder.Entity<Tuzuk>(entity =>
        {
            entity.ToTable("Tuzuk");


        });

        modelBuilder.Entity<Fotograflar>(entity =>
        {
            entity.ToTable("Fotograflar");


        });

        modelBuilder.Entity<Videolar>(entity =>
        {
            entity.ToTable("Videolar");


        });

        modelBuilder.Entity<BagisTuru>(entity =>
        {
            entity.ToTable("BagisTuru");

            //entity.HasOne(d => d.BagisTurus).WithMany(p => p)
            //  .HasForeignKey(d => d.b)
            //  .OnDelete(DeleteBehavior.ClientSetNull)
            //  .HasConstraintName("FK_BagisTuru_Bagislar");

            //entity.HasOne(d => d.Bagislar).WithMany(p => p.BagisTurus)
            //    .HasForeignKey(d => d.BagisTuruId)
            //    .HasConstraintName("FK_BagisTuru_Bagislar");

        });

        modelBuilder.Entity<Banka>(entity =>
        {
            entity.ToTable("Banka");


        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

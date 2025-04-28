using IyilikCatisi.Model.Entity;

namespace IyilikCatisi.WebCoreUI.Filters
{
    public interface ISessionManager
    {
        public Kullanicilar AktifKullanici {get; set;}
        public Kullanicilar AktifYonetici { get; set; }
        public string GuvenlikKodu {get; set;}

        public bool YetkisiVarmi (int MenuId, int KullaniciId);
    }
}

using IyilikCatisi.Business.Abstract;
using IyilikCatisi.Model.Entity;
using IyilikCatisi.Model.Statics;
using IyilikCatisi.WebCoreUI.Extensions;

namespace IyilikCatisi.WebCoreUI.Filters
{
    public class SessionManager : ISessionManager
    {
        IHttpContextAccessor _httpContextAccessor;
        private readonly IKullanicilarBS _kullaniciBS;
        IMenuBs _menuBs;

        public SessionManager(IHttpContextAccessor httpContextAccessor, IKullanicilarBS kullaniciBS, IMenuBs menuBs)
        {
            _httpContextAccessor = httpContextAccessor;
            _menuBs = menuBs;
            _kullaniciBS = kullaniciBS;
        }
        public Kullanicilar AktifKullanici
        {
            get
            {
                return _httpContextAccessor.HttpContext.Session.GetObject<Kullanicilar>(SessionKeys.AktifKullanici);
            }

            set
            {
                 _httpContextAccessor.HttpContext.Session.SetObject(SessionKeys.AktifKullanici, value);
            }
        }
        public Kullanicilar AktifYonetici
        {
            get
            {
                return _httpContextAccessor.HttpContext.Session.GetObject<Kullanicilar>(SessionKeys.AktifYonetici);
            }

            set
            {
                _httpContextAccessor.HttpContext.Session.SetObject(SessionKeys.AktifYonetici, value);
            }
        }

        public string GuvenlikKodu
        {
            get
            {
                return _httpContextAccessor.HttpContext.Session.GetObject<string>(SessionKeys.GuvenlikKodu);



            }
            set
            {
                _httpContextAccessor.HttpContext.Session.SetObject(SessionKeys.GuvenlikKodu, value);

            }
        }

        public bool YetkisiVarmi(int MenuId, int KullaniciId)
        {
            Menu menu = _menuBs.Get(x => x.Id == MenuId, false, "MenuYetkis", "MenuYetkis.Rol", "MenuYetkis.Rol.KullaniciRols", "MenuYetkis.Rol.KullaniciRols.Kullanici");

            Kullanicilar k = _kullaniciBS.Get(x => x.Id == KullaniciId, false, "KullaniciRols");

            bool yetki = false;

            foreach (MenuYetki myetki in menu.MenuYetkis)
            {

                foreach (KullaniciRol krol in k.KullaniciRols)
                {

                    if (myetki.SelectYetki == true && myetki.RolId == krol.RolId)
                    {
                        yetki = true;

                        break;
                    }
                }

            }


            return yetki;
        }

      
    }
    
} 


using AutoMapper;
using IyilikCatisi.Model.Entity;
using IyilikCatisi.Model.ViewModel.Areas.AdminPanel;
using IyilikCatisi.Model.ViewModel.Front;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyilikCatisi.Business.MappingRules
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<YonetimKuruluIndexViewModel, YonetimKurulu>().ReverseMap();
            CreateMap<DenetimKuruluIndexViewModel, DenetimKurulu>().ReverseMap();


            CreateMap<Kullanicilar, KullaniciIndexViewModel>()
                .ForMember(x => x.Roller, o => o.MapFrom(x => x.KullaniciRols.Select(x => x.Rol.RolAdi)))
                .ForMember(x => x.GRolIds, o => o.MapFrom(x => x.KullaniciRols != null ? x.KullaniciRols.Select(y => y.RolId.ToString()).ToList() : new List<string>()))

                .ReverseMap();


            CreateMap<Etkinlik, EtkinlikIndexViewModel>().ForMember(x=>x.KapakFoto, o=>o.MapFrom(x=>x.EtkinlikFotograflaris.Select(x=>x.Fotograf).FirstOrDefault())).ReverseMap();

            CreateMap<MakaleIndexViewModel, Makaleler>().ReverseMap();

            CreateMap<Fotograflar, FotograflarIndexViewModel>().ReverseMap();

            CreateMap<Videolar, VideolarIndexViewModel>().ReverseMap();

            CreateMap<BagisTuru, BagisTuruIndexViewModel>().ReverseMap();

            CreateMap<Banka, BankaIndexViewModel>().ReverseMap();

            CreateMap<Bagislar, BagisBasvuruIndexViewModel>().ReverseMap();

            CreateMap<Dernek, DernekSayfaEklemeViewModel>().ReverseMap();

			CreateMap<Kullanicilar, KullaniciSignupVm>().ReverseMap();

            CreateMap<Haberler, HaberlerIndexViewModel>().ReverseMap();

            CreateMap<Kullanicilar, KullaniciProfilVm>().ReverseMap();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.CrossCuttingConcern.Comunication;
using IyilikCatisi.Business.Abstract;
using IyilikCatisi.Business.Concrete.BaseConcrete.EntityFramework;
using IyilikCatisi.Data.Abstract;
using IyilikCatisi.Data.Concrete.EntityFramework.repository;
using Microsoft.Extensions.DependencyInjection;

namespace IyilikCatisi.Business
{
    public static class BusinessService
    {
        public static IServiceCollection AddBusinessService (this IServiceCollection services)
        {

            services.AddScoped<IBagislarBS, BagislarBS>();
            services.AddScoped<IBildirimKullaniciBS, BildirimKullaniciBS>();
            services.AddScoped<IBildirimlerBS, BildirimlerBS>();
            services.AddScoped<IDenetimKuruluBS, DenetimKuruluBS>();
            services.AddScoped<IDernekBS, DernekBS>();
            services.AddScoped<IEtkinlikBS, EtkinlikBS>();
            services.AddScoped<IEtkinlikFotograflariBS, EtkinlikFotograflariBS>();
            services.AddScoped<IHaberlerBS, HaberlerBS>();
            services.AddScoped<IKullanicilarBS, KullanicilarBS>();
            services.AddScoped<IKullaniciRolBS, KullaniciRolBS>();
            services.AddScoped<IMakalelerBS, MakalelerBS>();
            services.AddScoped<IMenuBs, MenuBS>();
            services.AddScoped<IMenuYetkiBs, MenuYetkiBS>();
            services.AddScoped<IMesajlarBS, MesajlarBS>();
            services.AddScoped<IMesajTipBS, MesajTipBS>();
            services.AddScoped<IRollerBS, RollerBS>();
            services.AddScoped<ITarihceBs, TarihceBS>();
            services.AddScoped<ITuzukBS, TuzukBS>();
            services.AddScoped<IUyelikAidatlariBS, UyelikAidatlariBS>();
            services.AddScoped<IUyelikDurumuBS, UyelikDurumuBS>();
            services.AddScoped<IYetkilerBS, YetkilerBS>();
            services.AddScoped<IYetkiRolBS, YetkiRolBS>();
            services.AddScoped<IYonetimKuruluBS,YonetimKuruluBS>();
            services.AddScoped<IYorumlarBS, YorumlarBS>();
            services.AddScoped<IYorumTipBS, YorumTipBS>();
            services.AddScoped<IFotograflarBS, FotograflarBS>();
            services.AddScoped<IVideolarBS, VideolarBS>();
            services.AddScoped<IBagisTuruBS, BagisTuruBS>();
            services.AddScoped<IBankaBS, BankaBS>();






            services.AddScoped<IBagislarRepository, EfBagislarRepository>();
            services.AddScoped<IBildirimKullaniciRepository, EfBildirimKullaniciRepository>();
            services.AddScoped<IBildirimlerRepository, EfBildirimlerRepository>();
            services.AddScoped<IDenetimKuruluRepository, EfDenetimKuruluRepository>();
            services.AddScoped<IDernekRepository, EfDernekRepository>();
            services.AddScoped<IEtkinlikRepository, EfEtkinlikRepository>();
            services.AddScoped<IEtkinlikFotograflariRepository, EfEtkinlikFotograflariRepository>();
            services.AddScoped<IHaberlerRepository, EFHaberlerRepository>();
            services.AddScoped<IKullanicilarRepository, EfKullanicilarRepository>();
            services.AddScoped<IKullaniciRolRepository, EfKullaniciRolRepository>();
            services.AddScoped<IMakalelerRepository, EfMakalelerRepository>();
            services.AddScoped<IMenuRepository, EfMenuRepository>();
            services.AddScoped<IMenuYetkiRepository, EfMenuYetkiRepository>();
            services.AddScoped<IMesajlarRepository, EfMesajlarRepository>();
            services.AddScoped<IMesajTipRepository, EfMesajTipRepository>();
            services.AddScoped<IRollerRepository, EfRollerRepository>();
            services.AddScoped<ITarihceRepository, EfTarihceRepository>();
            services.AddScoped<ITuzukRepository, EfTuzukRepository>();
            services.AddScoped<IUyelikAidatlariRepository, EfUyelikAidatlariRepository>();
            services.AddScoped<IUyelikDurumuRepository, EfUyelikDurumuRepository>();
            services.AddScoped<IYetkilerRepository, EfYetkilerRepository>();
            services.AddScoped<IYetkiRolRepository, EfYetkiRolRepository>();
            services.AddScoped<IYonetimKuruluRepository, EfYonetimKuruluRepository>();
            services.AddScoped<IYorumlarRepository, EfYorumlarRepository>();
            services.AddScoped<IYorumTipRepository, EfYorumTipRepository>();
            services.AddScoped<IFotograflarRepository, EfFotograflarRepository>();
            services.AddScoped<IVideolarRepository, EfVideolarRepository>();
            services.AddScoped<IBagisTuruRepository, EfBagisTuruRepository>();
            services.AddScoped<IBankaRepository, EfBankaRepository>();
            services.AddScoped<MailIslemleri>();








            return services;
        }
    }
}

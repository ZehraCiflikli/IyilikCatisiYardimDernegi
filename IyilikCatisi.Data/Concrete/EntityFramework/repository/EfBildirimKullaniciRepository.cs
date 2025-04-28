using IyilikCatisi.Data.Abstract;
using IyilikCatisi.Data.Concrete.EntityFramework.context;
using Infrastructure.Concrete.EntityFramework;
using IyilikCatisi.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using İyilikCatisiDbContext = IyilikCatisi.Data.Concrete.EntityFramework.context.İyilikCatisiDbContext;

namespace IyilikCatisi.Data.Concrete.EntityFramework.repository
{
    public class EfBildirimKullaniciRepository:EfRepositoryBase<BildirimKullanici,İyilikCatisiDbContext>,IBildirimKullaniciRepository
    {
    }
}

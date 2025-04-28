using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Concrete.EntityFramework;
using IyilikCatisi.Data.Abstract;
using IyilikCatisi.Data.Concrete.EntityFramework.context;
using IyilikCatisi.Model.Entity;

namespace IyilikCatisi.Data.Concrete.EntityFramework.repository
{
    public class EfBagisTuruRepository:EfRepositoryBase<BagisTuru,İyilikCatisiDbContext> , IBagisTuruRepository
    {
    }
}

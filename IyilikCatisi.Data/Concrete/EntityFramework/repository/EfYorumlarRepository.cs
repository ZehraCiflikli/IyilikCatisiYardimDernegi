using IyilikCatisi.Data.Abstract;
using IyilikCatisi.Data.Concrete.EntityFramework.context;
using Infrastructure.Concrete.EntityFramework;
using IyilikCatisi.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyilikCatisi.Data.Concrete.EntityFramework.repository
{
    public class EfYorumlarRepository:EfRepositoryBase<Yorumlar,İyilikCatisiDbContext>,IYorumlarRepository
    {
    }
}

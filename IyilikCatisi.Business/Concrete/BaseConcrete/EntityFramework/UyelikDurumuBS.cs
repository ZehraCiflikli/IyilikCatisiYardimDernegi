using Infrastructure.Enum;
using Infrastructure.Model;
using IyilikCatisi.Business.Abstract;
using IyilikCatisi.Data.Abstract;
using IyilikCatisi.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IyilikCatisi.Business.Concrete.BaseConcrete.EntityFramework
{
    public class UyelikDurumuBS:IUyelikDurumuBS
    {
        
        private readonly IUyelikDurumuRepository _repo;

        public UyelikDurumuBS(IUyelikDurumuRepository repo)
        {
            _repo = repo;
        }

        public UyelikDurumu Delete(UyelikDurumu entity)
        {







            return _repo.Delete(entity);
        }

        public UyelikDurumu DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public UyelikDurumu Get(Expression<Func<UyelikDurumu, bool>> filter, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<UyelikDurumu> GetAll(Expression<Func<UyelikDurumu, bool>> filter = null, Expression<Func<UyelikDurumu, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<UyelikDurumu> GetAllByAktif(Expression<Func<UyelikDurumu, bool>> filter = null, Expression<Func<UyelikDurumu, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<UyelikDurumu> GetAllPaging(int Page, int PageSize, Expression<Func<UyelikDurumu, bool>> filter = null, Expression<Func<UyelikDurumu, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public UyelikDurumu GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<UyelikDurumu, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public UyelikDurumu Insert(UyelikDurumu entity)
        {
            return _repo.Insert(entity);
        }

        public UyelikDurumu Update(UyelikDurumu entity)
        {
            return _repo.Update(entity);
        }


    }
}

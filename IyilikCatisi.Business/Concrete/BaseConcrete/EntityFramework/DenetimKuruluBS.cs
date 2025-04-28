using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Enum;
using Infrastructure.Model;
using IyilikCatisi.Business.Abstract;
using IyilikCatisi.Data.Abstract;
using IyilikCatisi.Model.Entity;

namespace IyilikCatisi.Business.Concrete.BaseConcrete.EntityFramework
{
    public class DenetimKuruluBS:IDenetimKuruluBS
    {
        private readonly IDenetimKuruluRepository _repo;

        public DenetimKuruluBS(IDenetimKuruluRepository repo)
        {
            _repo = repo;
        }

        public DenetimKurulu Delete(DenetimKurulu entity)
        {







            return _repo.Delete(entity);
        }

        public DenetimKurulu DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public DenetimKurulu Get(Expression<Func<DenetimKurulu, bool>> filter, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<DenetimKurulu> GetAll(Expression<Func<DenetimKurulu, bool>> filter = null, Expression<Func<DenetimKurulu, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<DenetimKurulu> GetAllByAktif(Expression<Func<DenetimKurulu, bool>> filter = null, Expression<Func<DenetimKurulu, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<DenetimKurulu> GetAllPaging(int Page, int PageSize, Expression<Func<DenetimKurulu, bool>> filter = null, Expression<Func<DenetimKurulu, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public DenetimKurulu GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<DenetimKurulu, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public DenetimKurulu Insert(DenetimKurulu entity)
        {
            return _repo.Insert(entity);
        }

        public DenetimKurulu Update(DenetimKurulu entity)
        {
            return _repo.Update(entity);
        }







    }
}


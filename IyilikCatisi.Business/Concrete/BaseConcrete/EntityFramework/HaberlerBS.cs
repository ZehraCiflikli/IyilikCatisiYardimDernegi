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
    public class HaberlerBS:IHaberlerBS
    {
        private readonly IHaberlerRepository _repo;

        public HaberlerBS(IHaberlerRepository repo)
        {
            _repo = repo;
        }

        public Haberler Delete(Haberler entity)
        {







            return _repo.Delete(entity);
        }

        public Haberler DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public Haberler Get(Expression<Func<Haberler, bool>> filter, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<Haberler> GetAll(Expression<Func<Haberler, bool>> filter = null, Expression<Func<Haberler, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<Haberler> GetAllByAktif(Expression<Func<Haberler, bool>> filter = null, Expression<Func<Haberler, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<Haberler> GetAllPaging(int Page, int PageSize, Expression<Func<Haberler, bool>> filter = null, Expression<Func<Haberler, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public Haberler GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<Haberler, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public Haberler Insert(Haberler entity)
        {
            return _repo.Insert(entity);
        }

        public Haberler Update(Haberler entity)
        {
            return _repo.Update(entity);
        }

    }
}

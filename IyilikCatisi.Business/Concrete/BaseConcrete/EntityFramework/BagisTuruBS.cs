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
    public class BagisTuruBS:IBagisTuruBS
    {

        private readonly IBagisTuruRepository _repo;

        public BagisTuruBS(IBagisTuruRepository repo)
        {
            _repo = repo;
        }

        public BagisTuru Delete(BagisTuru entity)
        {




            return _repo.Delete(entity);
        }

        public BagisTuru DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public BagisTuru Get(Expression<Func<BagisTuru, bool>> filter, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<BagisTuru> GetAll(Expression<Func<BagisTuru, bool>> filter = null, Expression<Func<BagisTuru, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<BagisTuru> GetAllByAktif(Expression<Func<BagisTuru, bool>> filter = null, Expression<Func<BagisTuru, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<BagisTuru> GetAllPaging(int Page, int PageSize, Expression<Func<BagisTuru, bool>> filter = null, Expression<Func<BagisTuru, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public BagisTuru GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<BagisTuru, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public BagisTuru Insert(BagisTuru entity)
        {
            return _repo.Insert(entity);
        }

        public BagisTuru Update(BagisTuru entity)
        {
            return _repo.Update(entity);
        }

    
    }
}

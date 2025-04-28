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
    public class YetkilerBS:IYetkilerBS
    {

        private readonly IYetkilerRepository _repo;

        public YetkilerBS(IYetkilerRepository repo)
        {
            _repo = repo;
        }

        public Yetkiler Delete(Yetkiler entity)
        {







            return _repo.Delete(entity);
        }

        public Yetkiler DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public Yetkiler Get(Expression<Func<Yetkiler, bool>> filter, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<Yetkiler> GetAll(Expression<Func<Yetkiler, bool>> filter = null, Expression<Func<Yetkiler, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<Yetkiler> GetAllByAktif(Expression<Func<Yetkiler, bool>> filter = null, Expression<Func<Yetkiler, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<Yetkiler> GetAllPaging(int Page, int PageSize, Expression<Func<Yetkiler, bool>> filter = null, Expression<Func<Yetkiler, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public Yetkiler GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<Yetkiler, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public Yetkiler Insert(Yetkiler entity)
        {
            return _repo.Insert(entity);
        }

        public Yetkiler Update(Yetkiler entity)
        {
            return _repo.Update(entity);
        }


    }
}

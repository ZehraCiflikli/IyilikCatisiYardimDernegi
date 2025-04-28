using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IyilikCatisi.Business.Abstract;
using Infrastructure.Enum;
using Infrastructure.Model;
using IyilikCatisi.Data.Abstract;
using IyilikCatisi.Model.Entity;
using System.Linq.Expressions;

namespace IyilikCatisi.Business.Concrete.BaseConcrete.EntityFramework
{
    public class TarihceBS: ITarihceBs
    {
        private readonly ITarihceRepository _repo;

        public TarihceBS(ITarihceRepository repo)
        {
            _repo = repo;
        }

        public Tarihce Delete(Tarihce entity)
        {







            return _repo.Delete(entity);
        }

        public Tarihce DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public Tarihce Get(Expression<Func<Tarihce, bool>> filter, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<Tarihce> GetAll(Expression<Func<Tarihce, bool>> filter = null, Expression<Func<Tarihce, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<Tarihce> GetAllByAktif(Expression<Func<Tarihce, bool>> filter = null, Expression<Func<Tarihce, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<Tarihce> GetAllPaging(int Page, int PageSize, Expression<Func<Tarihce, bool>> filter = null, Expression<Func<Tarihce, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public Tarihce GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<Tarihce, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public Tarihce Insert(Tarihce entity)
        {
            return _repo.Insert(entity);
        }

        public Tarihce Update(Tarihce entity)
        {
            return _repo.Update(entity);
        }
    }
}

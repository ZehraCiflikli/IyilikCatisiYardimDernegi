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
    public class RollerBS:IRollerBS
    {
        private readonly IRollerRepository _repo;

        public RollerBS(IRollerRepository repo)
        {
            _repo = repo;
        }

        public Roller Delete(Roller entity)
        {







            return _repo.Delete(entity);
        }

        public Roller DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public Roller Get(Expression<Func<Roller, bool>> filter, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<Roller> GetAll(Expression<Func<Roller, bool>> filter = null, Expression<Func<Roller, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<Roller> GetAllByAktif(Expression<Func<Roller, bool>> filter = null, Expression<Func<Roller, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<Roller> GetAllPaging(int Page, int PageSize, Expression<Func<Roller, bool>> filter = null, Expression<Func<Roller, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public Roller GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<Roller, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public Roller Insert(Roller entity)
        {
            return _repo.Insert(entity);
        }

        public Roller Update(Roller entity)
        {
            return _repo.Update(entity);
        }

    }
}

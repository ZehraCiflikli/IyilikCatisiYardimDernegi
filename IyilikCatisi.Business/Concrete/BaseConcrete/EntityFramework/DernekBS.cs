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
    public class DernekBS:IDernekBS
    {
        private readonly IDernekRepository _repo;

        public DernekBS(IDernekRepository repo)
        {
            _repo = repo;
        }

        public Dernek Delete(Dernek entity)
        {







            return _repo.Delete(entity);
        }

        public Dernek DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public Dernek Get(Expression<Func<Dernek, bool>> filter, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<Dernek> GetAll(Expression<Func<Dernek, bool>> filter = null, Expression<Func<Dernek, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<Dernek> GetAllByAktif(Expression<Func<Dernek, bool>> filter = null, Expression<Func<Dernek, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<Dernek> GetAllPaging(int Page, int PageSize, Expression<Func<Dernek, bool>> filter = null, Expression<Func<Dernek, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public Dernek GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<Dernek, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public Dernek Insert(Dernek entity)
        {
            return _repo.Insert(entity);
        }

        public Dernek Update(Dernek entity)
        {
            return _repo.Update(entity);
        }







    }
}


using Infrastructure.Enum;
using Infrastructure.Model;
using IyilikCatisi.Business.Abstract;
using IyilikCatisi.Data.Abstract;
using IyilikCatisi.Data.Concrete.EntityFramework.repository;
using IyilikCatisi.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IyilikCatisi.Business.Concrete.BaseConcrete.EntityFramework
{
    public class YorumlarBS:IYorumlarBS
    {

        private readonly IYorumlarRepository _repo;

        public YorumlarBS(IYorumlarRepository repo)
        {
            _repo = repo;
        }

        public Yorumlar Delete(Yorumlar entity)
        {







            return _repo.Delete(entity);
        }

        public Yorumlar DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public Yorumlar Get(Expression<Func<Yorumlar, bool>> filter, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<Yorumlar> GetAll(Expression<Func<Yorumlar, bool>> filter = null, Expression<Func<Yorumlar, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<Yorumlar> GetAllByAktif(Expression<Func<Yorumlar, bool>> filter = null, Expression<Func<Yorumlar, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<Yorumlar> GetAllPaging(int Page, int PageSize, Expression<Func<Yorumlar, bool>> filter = null, Expression<Func<Yorumlar, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public Yorumlar GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<Yorumlar, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public Yorumlar Insert(Yorumlar entity)
        {
            return _repo.Insert(entity);
        }

        public Yorumlar Update(Yorumlar entity)
        {
            return _repo.Update(entity);
        }

    }
}

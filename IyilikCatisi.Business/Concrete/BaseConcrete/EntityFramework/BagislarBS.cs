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
    public class BagislarBS:IBagislarBS
    {
        private readonly IBagislarRepository _repo;

        public BagislarBS(IBagislarRepository repo)
        {
            _repo = repo;
        }

        public Bagislar Delete(Bagislar entity)
        {







            return _repo.Delete(entity);
        }

        public Bagislar DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public Bagislar Get(Expression<Func<Bagislar, bool>> filter, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<Bagislar> GetAll(Expression<Func<Bagislar, bool>> filter = null, Expression<Func<Bagislar, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<Bagislar> GetAllByAktif(Expression<Func<Bagislar, bool>> filter = null, Expression<Func<Bagislar, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<Bagislar> GetAllPaging(int Page, int PageSize, Expression<Func<Bagislar, bool>> filter = null, Expression<Func<Bagislar, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public Bagislar GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<Bagislar, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public Bagislar Insert(Bagislar entity)
        {
            return _repo.Insert(entity);
        }

        public Bagislar Update(Bagislar entity)
        {
            return _repo.Update(entity);
        }







    }
}

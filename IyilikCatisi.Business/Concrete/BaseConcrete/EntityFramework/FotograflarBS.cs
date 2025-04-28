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
    public class FotograflarBS:IFotograflarBS
    {
        private readonly IFotograflarRepository _repo;

        public FotograflarBS(IFotograflarRepository repo)
        {
            _repo = repo;
        }

        public Fotograflar Delete(Fotograflar entity)
        {







            return _repo.Delete(entity);
        }

        public Fotograflar DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public Fotograflar Get(Expression<Func<Fotograflar, bool>> filter, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<Fotograflar> GetAll(Expression<Func<Fotograflar, bool>> filter = null, Expression<Func<Fotograflar, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<Fotograflar> GetAllByAktif(Expression<Func<Fotograflar, bool>> filter = null, Expression<Func<Fotograflar, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<Fotograflar> GetAllPaging(int Page, int PageSize, Expression<Func<Fotograflar, bool>> filter = null, Expression<Func<Fotograflar, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public Fotograflar GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<Fotograflar, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public Fotograflar Insert(Fotograflar entity)
        {
            return _repo.Insert(entity);
        }

        public Fotograflar Update(Fotograflar entity)
        {
            return _repo.Update(entity);
        }







    }

}

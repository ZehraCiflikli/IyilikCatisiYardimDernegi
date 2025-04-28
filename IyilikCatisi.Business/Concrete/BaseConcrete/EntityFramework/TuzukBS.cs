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
    public class TuzukBS:ITuzukBS
    {
        private readonly ITuzukRepository _repo;

        public TuzukBS(ITuzukRepository repo)
        {
            _repo = repo;
        }

        public Tuzuk Delete(Tuzuk entity)
        {
            return _repo.Delete(entity);
        }

        public Tuzuk DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public Tuzuk Get(Expression<Func<Tuzuk, bool>> filter, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<Tuzuk> GetAll(Expression<Func<Tuzuk, bool>> filter = null, Expression<Func<Tuzuk, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<Tuzuk> GetAllByAktif(Expression<Func<Tuzuk, bool>> filter = null, Expression<Func<Tuzuk, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<Tuzuk> GetAllPaging(int Page, int PageSize, Expression<Func<Tuzuk, bool>> filter = null, Expression<Func<Tuzuk, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public Tuzuk GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<Tuzuk, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public Tuzuk Insert(Tuzuk entity)
        {
            return _repo.Insert(entity);
        }

        public Tuzuk Update(Tuzuk entity)
        {
            return _repo.Update(entity);
        }
    }
}

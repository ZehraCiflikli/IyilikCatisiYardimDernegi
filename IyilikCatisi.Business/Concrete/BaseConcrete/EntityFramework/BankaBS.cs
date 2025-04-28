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
    public class BankaBS:IBankaBS
    {
        private readonly IBankaRepository _repo;

        public BankaBS(IBankaRepository repo)
        {
            _repo = repo;
        }

        public Banka Delete(Banka entity)
        {

            return _repo.Delete(entity);
        }

        public Banka DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public Banka Get(Expression<Func<Banka, bool>> filter, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<Banka> GetAll(Expression<Func<Banka, bool>> filter = null, Expression<Func<Banka, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<Banka> GetAllByAktif(Expression<Func<Banka, bool>> filter = null, Expression<Func<Banka, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<Banka> GetAllPaging(int Page, int PageSize, Expression<Func<Banka, bool>> filter = null, Expression<Func<Banka, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public Banka GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<Banka, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public Banka Insert(Banka entity)
        {
            return _repo.Insert(entity);
        }

        public Banka Update(Banka entity)
        {
            return _repo.Update(entity);
        }


    }

}

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
    public class BildirimKullaniciBS:IBildirimKullaniciBS
    {
        private readonly IBildirimKullaniciRepository _repo;

        public BildirimKullaniciBS(IBildirimKullaniciRepository repo)
        {
            _repo = repo;
        }

        public BildirimKullanici Delete(BildirimKullanici entity)
        {







            return _repo.Delete(entity);
        }

        public BildirimKullanici DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public BildirimKullanici Get(Expression<Func<BildirimKullanici, bool>> filter, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<BildirimKullanici> GetAll(Expression<Func<BildirimKullanici, bool>> filter = null, Expression<Func<BildirimKullanici, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<BildirimKullanici> GetAllByAktif(Expression<Func<BildirimKullanici, bool>> filter = null, Expression<Func<BildirimKullanici, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<BildirimKullanici> GetAllPaging(int Page, int PageSize, Expression<Func<BildirimKullanici, bool>> filter = null, Expression<Func<BildirimKullanici, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public BildirimKullanici GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<BildirimKullanici, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public BildirimKullanici Insert(BildirimKullanici entity)
        {
            return _repo.Insert(entity);
        }

        public BildirimKullanici Update(BildirimKullanici entity)
        {
            return _repo.Update(entity);
        }


    }
}

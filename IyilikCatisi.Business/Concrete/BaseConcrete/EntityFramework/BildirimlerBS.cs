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
    public class BildirimlerBS:IBildirimlerBS
    {

        private readonly IBildirimlerRepository _repo;

        public BildirimlerBS(IBildirimlerRepository repo)
        {
            _repo = repo;
        }

        public Bildirimler Delete(Bildirimler entity)
        {







            return _repo.Delete(entity);
        }

        public Bildirimler DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public Bildirimler Get(Expression<Func<Bildirimler, bool>> filter, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<Bildirimler> GetAll(Expression<Func<Bildirimler, bool>> filter = null, Expression<Func<Bildirimler, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<Bildirimler> GetAllByAktif(Expression<Func<Bildirimler, bool>> filter = null, Expression<Func<Bildirimler, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<Bildirimler> GetAllPaging(int Page, int PageSize, Expression<Func<Bildirimler, bool>> filter = null, Expression<Func<Bildirimler, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public Bildirimler GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<Bildirimler, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public Bildirimler Insert(Bildirimler entity)
        {
            return _repo.Insert(entity);
        }

        public Bildirimler Update(Bildirimler entity)
        {
            return _repo.Update(entity);
        }




    }
}

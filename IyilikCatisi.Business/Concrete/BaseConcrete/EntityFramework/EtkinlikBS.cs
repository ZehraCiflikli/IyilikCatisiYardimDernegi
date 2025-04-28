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
    public class EtkinlikBS:IEtkinlikBS
    {
        private readonly IEtkinlikRepository _repo;

        public EtkinlikBS(IEtkinlikRepository repo)
        {
            _repo = repo;
        }

        public Etkinlik Delete(Etkinlik entity)
        {







            return _repo.Delete(entity);
        }

        public Etkinlik DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public Etkinlik Get(Expression<Func<Etkinlik, bool>> filter, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<Etkinlik> GetAll(Expression<Func<Etkinlik, bool>> filter = null, Expression<Func<Etkinlik, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<Etkinlik> GetAllByAktif(Expression<Func<Etkinlik, bool>> filter = null, Expression<Func<Etkinlik, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<Etkinlik> GetAllPaging(int Page, int PageSize, Expression<Func<Etkinlik, bool>> filter = null, Expression<Func<Etkinlik, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public Etkinlik GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<Etkinlik, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public Etkinlik Insert(Etkinlik entity)
        {
            return _repo.Insert(entity);
        }

        public Etkinlik Update(Etkinlik entity)
        {
            return _repo.Update(entity);
        }
    }
}

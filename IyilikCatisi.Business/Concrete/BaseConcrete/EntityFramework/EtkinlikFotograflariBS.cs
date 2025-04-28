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
    public class EtkinlikFotograflariBS:IEtkinlikFotograflariBS
    {
        private readonly IEtkinlikFotograflariRepository _repo;

        public EtkinlikFotograflariBS(IEtkinlikFotograflariRepository repo)
        {
            _repo = repo;
        }

        public EtkinlikFotograflari Delete(EtkinlikFotograflari entity)
        {







            return _repo.Delete(entity);
        }

        public EtkinlikFotograflari DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public EtkinlikFotograflari Get(Expression<Func<EtkinlikFotograflari, bool>> filter, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<EtkinlikFotograflari> GetAll(Expression<Func<EtkinlikFotograflari, bool>> filter = null, Expression<Func<EtkinlikFotograflari, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<EtkinlikFotograflari> GetAllByAktif(Expression<Func<EtkinlikFotograflari, bool>> filter = null, Expression<Func<EtkinlikFotograflari, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<EtkinlikFotograflari> GetAllPaging(int Page, int PageSize, Expression<Func<EtkinlikFotograflari, bool>> filter = null, Expression<Func<EtkinlikFotograflari, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public EtkinlikFotograflari GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<EtkinlikFotograflari, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public EtkinlikFotograflari Insert(EtkinlikFotograflari entity)
        {
            return _repo.Insert(entity);
        }

        public EtkinlikFotograflari Update(EtkinlikFotograflari entity)
        {
            return _repo.Update(entity);
        }
    }
}

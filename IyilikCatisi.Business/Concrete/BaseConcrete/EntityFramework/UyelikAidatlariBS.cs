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
    public class UyelikAidatlariBS:IUyelikAidatlariBS
    {

        private readonly IUyelikAidatlariRepository _repo;

        public UyelikAidatlariBS(IUyelikAidatlariRepository repo)
        {
            _repo = repo;
        }

        public UyelikAidatlari Delete(UyelikAidatlari entity)
        {







            return _repo.Delete(entity);
        }

        public UyelikAidatlari DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public UyelikAidatlari Get(Expression<Func<UyelikAidatlari, bool>> filter, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<UyelikAidatlari> GetAll(Expression<Func<UyelikAidatlari, bool>> filter = null, Expression<Func<UyelikAidatlari, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<UyelikAidatlari> GetAllByAktif(Expression<Func<UyelikAidatlari, bool>> filter = null, Expression<Func<UyelikAidatlari, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<UyelikAidatlari> GetAllPaging(int Page, int PageSize, Expression<Func<UyelikAidatlari, bool>> filter = null, Expression<Func<UyelikAidatlari, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public UyelikAidatlari GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<UyelikAidatlari, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public UyelikAidatlari Insert(UyelikAidatlari entity)
        {
            return _repo.Insert(entity);
        }

        public UyelikAidatlari Update(UyelikAidatlari entity)
        {
            return _repo.Update(entity);
        }

    }
}

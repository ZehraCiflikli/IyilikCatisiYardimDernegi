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
    public class YonetimKuruluBS:IYonetimKuruluBS
    {
        private readonly IYonetimKuruluRepository _repo;

        public YonetimKuruluBS(IYonetimKuruluRepository repo)
        {
            _repo = repo;
        }

        public YonetimKurulu Delete(YonetimKurulu entity)
        {







            return _repo.Delete(entity);
        }

        public YonetimKurulu DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public YonetimKurulu Get(Expression<Func<YonetimKurulu, bool>> filter, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<YonetimKurulu> GetAll(Expression<Func<YonetimKurulu, bool>> filter = null, Expression<Func<YonetimKurulu, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<YonetimKurulu> GetAllByAktif(Expression<Func<YonetimKurulu, bool>> filter = null, Expression<Func<YonetimKurulu, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<YonetimKurulu> GetAllPaging(int Page, int PageSize, Expression<Func<YonetimKurulu, bool>> filter = null, Expression<Func<YonetimKurulu, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public YonetimKurulu GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<YonetimKurulu, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public YonetimKurulu Insert(YonetimKurulu entity)
        {
            return _repo.Insert(entity);
        }

        public YonetimKurulu Update(YonetimKurulu entity)
        {
            return _repo.Update(entity);
        }







    }
}


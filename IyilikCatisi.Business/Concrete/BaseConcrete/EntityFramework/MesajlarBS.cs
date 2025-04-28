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
    public class MesajlarBS:IMesajlarBS
    {
        private readonly IMesajlarRepository _repo;

        public MesajlarBS(IMesajlarRepository repo)
        {
            _repo = repo;
        }

        public Mesajlar Delete(Mesajlar entity)
        {







            return _repo.Delete(entity);
        }

        public Mesajlar DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public Mesajlar Get(Expression<Func<Mesajlar, bool>> filter, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<Mesajlar> GetAll(Expression<Func<Mesajlar, bool>> filter = null, Expression<Func<Mesajlar, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<Mesajlar> GetAllByAktif(Expression<Func<Mesajlar, bool>> filter = null, Expression<Func<Mesajlar, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<Mesajlar> GetAllPaging(int Page, int PageSize, Expression<Func<Mesajlar, bool>> filter = null, Expression<Func<Mesajlar, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public Mesajlar GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<Mesajlar, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public Mesajlar Insert(Mesajlar entity)
        {
            return _repo.Insert(entity);
        }

        public Mesajlar Update(Mesajlar entity)
        {
            return _repo.Update(entity);
        }

    }
}

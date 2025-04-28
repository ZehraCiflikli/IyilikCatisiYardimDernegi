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
    public class VideolarBS:IVideolarBS
    {
        private readonly IVideolarRepository _repo;

        public VideolarBS(IVideolarRepository repo)
        {
            _repo = repo;
        }

        public Videolar Delete(Videolar entity)
        {







            return _repo.Delete(entity);
        }

        public Videolar DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public Videolar Get(Expression<Func<Videolar, bool>> filter, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<Videolar> GetAll(Expression<Func<Videolar, bool>> filter = null, Expression<Func<Videolar, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<Videolar> GetAllByAktif(Expression<Func<Videolar, bool>> filter = null, Expression<Func<Videolar, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<Videolar> GetAllPaging(int Page, int PageSize, Expression<Func<Videolar, bool>> filter = null, Expression<Func<Videolar, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public Videolar GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<Videolar, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public Videolar Insert(Videolar entity)
        {
            return _repo.Insert(entity);
        }

        public Videolar Update(Videolar entity)
        {
            return _repo.Update(entity);
        }







    }

}

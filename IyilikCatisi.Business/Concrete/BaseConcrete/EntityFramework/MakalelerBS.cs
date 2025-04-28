using Infrastructure.Enum;
using Infrastructure.Model;
using IyilikCatisi.Business.Abstract;
using IyilikCatisi.Data.Abstract;
using IyilikCatisi.Data.Concrete.EntityFramework.repository;
using IyilikCatisi.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IyilikCatisi.Business.Concrete.BaseConcrete.EntityFramework
{
    public class MakalelerBS:IMakalelerBS

    {
        private readonly IMakalelerRepository _repo;

        public MakalelerBS(IMakalelerRepository repo)
        {
            _repo = repo;
        }

        public Makaleler Delete(Makaleler entity)
        {







            return _repo.Delete(entity);
        }

        public Makaleler DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public Makaleler Get(Expression<Func<Makaleler, bool>> filter, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<Makaleler> GetAll(Expression<Func<Makaleler, bool>> filter = null, Expression<Func<Makaleler, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<Makaleler> GetAllByAktif(Expression<Func<Makaleler, bool>> filter = null, Expression<Func<Makaleler, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<Makaleler> GetAllPaging(int Page, int PageSize, Expression<Func<Makaleler, bool>> filter = null, Expression<Func<Makaleler, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public Makaleler GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<Makaleler, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public Makaleler Insert(Makaleler entity)
        {
            return _repo.Insert(entity);
        }

        public Makaleler Update(Makaleler entity)
        {
            return _repo.Update(entity);
        }

    }
}

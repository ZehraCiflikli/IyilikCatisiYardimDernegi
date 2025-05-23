﻿using Infrastructure.Enum;
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
    public class KullanicilarBS:IKullanicilarBS
    {
        private readonly IKullanicilarRepository _repo;

        public KullanicilarBS(IKullanicilarRepository repo)
        {
            _repo = repo;
        }

        public Kullanicilar Delete(Kullanicilar entity)
        {







            return _repo.Delete(entity);
        }

        public Kullanicilar DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public Kullanicilar Get(Expression<Func<Kullanicilar, bool>> filter, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<Kullanicilar> GetAll(Expression<Func<Kullanicilar, bool>> filter = null, Expression<Func<Kullanicilar, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<Kullanicilar> GetAllByAktif(Expression<Func<Kullanicilar, bool>> filter = null, Expression<Func<Kullanicilar, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<Kullanicilar> GetAllPaging(int Page, int PageSize, Expression<Func<Kullanicilar, bool>> filter = null, Expression<Func<Kullanicilar, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public Kullanicilar GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<Kullanicilar, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public Kullanicilar Insert(Kullanicilar entity)
        {
            return _repo.Insert(entity);
        }

        public Kullanicilar Update(Kullanicilar entity)
        {
            return _repo.Update(entity);
        }

    }
}

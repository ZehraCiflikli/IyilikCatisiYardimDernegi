﻿using System;
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
    public class MenuBS:IMenuBs
    {

        private readonly IMenuRepository _repo;

        public MenuBS(IMenuRepository repo)
        {
            _repo = repo;
        }

        public Menu Delete(Menu entity)
        {

            return _repo.Delete(entity);
        }

        public Menu DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public Menu Get(Expression<Func<Menu, bool>> filter, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<Menu> GetAll(Expression<Func<Menu, bool>> filter = null, Expression<Func<Menu, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<Menu> GetAllByAktif(Expression<Func<Menu, bool>> filter = null, Expression<Func<Menu, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<Menu> GetAllPaging(int Page, int PageSize, Expression<Func<Menu, bool>> filter = null, Expression<Func<Menu, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public Menu GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<Menu, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public Menu Insert(Menu entity)
        {
            return _repo.Insert(entity);
        }

        public Menu Update(Menu entity)
        {
            return _repo.Update(entity);
        }

       
    }
}

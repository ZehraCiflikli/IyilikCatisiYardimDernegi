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
    public class MesajTipBS:IMesajTipBS
    {
        private readonly IMesajTipRepository _repo;

        public MesajTipBS(IMesajTipRepository repo)
        {
            _repo = repo;
        }

        public MesajTip Delete(MesajTip entity)
        {







            return _repo.Delete(entity);
        }

        public MesajTip DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public MesajTip Get(Expression<Func<MesajTip, bool>> filter, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<MesajTip> GetAll(Expression<Func<MesajTip, bool>> filter = null, Expression<Func<MesajTip, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<MesajTip> GetAllByAktif(Expression<Func<MesajTip, bool>> filter = null, Expression<Func<MesajTip, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<MesajTip> GetAllPaging(int Page, int PageSize, Expression<Func<MesajTip, bool>> filter = null, Expression<Func<MesajTip, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public MesajTip GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<MesajTip, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public MesajTip Insert(MesajTip entity)
        {
            return _repo.Insert(entity);
        }

        public MesajTip Update(MesajTip entity)
        {
            return _repo.Update(entity);
        }

    }
}

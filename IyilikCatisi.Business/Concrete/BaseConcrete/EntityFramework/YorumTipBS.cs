using Infrastructure.Enum;
using Infrastructure.Model;
using IyilikCatisi.Business.Abstract;
using IyilikCatisi.Data.Abstract;
using IyilikCatisi.Model.Entity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IyilikCatisi.Business.Concrete.BaseConcrete.EntityFramework
{
    public class YorumTipBS:IYorumTipBS
    {

        private readonly IYorumTipRepository _repo;

        public YorumTipBS(IYorumTipRepository repo)
        {
            _repo = repo;
        }

        public YorumTip Delete(YorumTip entity)
        {







            return _repo.Delete(entity);
        }

        public YorumTip DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public YorumTip Get(Expression<Func<YorumTip, bool>> filter, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<YorumTip> GetAll(Expression<Func<YorumTip, bool>> filter = null, Expression<Func<YorumTip, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<YorumTip> GetAllByAktif(Expression<Func<YorumTip, bool>> filter = null, Expression<Func<YorumTip, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<YorumTip> GetAllPaging(int Page, int PageSize, Expression<Func<YorumTip, bool>> filter = null, Expression<Func<YorumTip, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public YorumTip GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<YorumTip, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public YorumTip Insert(YorumTip entity)
        {
            return _repo.Insert(entity);
        }

        public YorumTip Update(YorumTip entity)
        {
            return _repo.Update(entity);
        }

    }


}

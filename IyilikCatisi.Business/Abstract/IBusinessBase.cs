using Infrastructure.Abstract;
using Infrastructure.Enum;
using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IyilikCatisi.Business.Abstract
{
    public interface IBusinessBase<T>:IRepository<T> where T : BaseEntity, new()
    {
        
    }
}

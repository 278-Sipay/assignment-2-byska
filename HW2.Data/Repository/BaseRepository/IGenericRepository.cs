using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HW2.Data.Repository.Base
{
    public interface IGenericRepository<T> where T : class
    {
        List<T> GetByParameter(Expression<Func<T, bool>> expression);
    }
}

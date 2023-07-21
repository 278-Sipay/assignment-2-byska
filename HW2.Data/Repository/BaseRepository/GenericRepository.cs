using HW2.Base.BaseModel;
using HW2.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HW2.Data.Repository.Base
{
    public class GenericRepository<T>:IGenericRepository<T> where T : BaseModel
    {
        private readonly HW2Context _dbContext;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(HW2Context dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }
        /// <summary>
        /// It returns the relevant transaction according to the given filters.
        /// </summary>
        /// <param name="expression">filters</param>
        /// <returns></returns>
        public List<T> GetByParameter(Expression<Func<T, bool>> expression) => _dbSet.Where(expression).ToList();
       
    }
}

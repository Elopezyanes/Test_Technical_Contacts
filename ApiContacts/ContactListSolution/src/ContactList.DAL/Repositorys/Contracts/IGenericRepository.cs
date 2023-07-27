using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ContactList.DAL.Repositorys.Contracts
{
    public interface IGenericRepository<TModel> where TModel : class
    {
        Task<IQueryable<TModel>> ConsultTask(Expression<Func<TModel, bool>>? filter = null);
        Task<TModel> Create(TModel model);
        Task<bool> Edit(TModel model);
        Task<bool> Delete(TModel model);
        IQueryable<TModel> ConsultNoTask(Expression<Func<TModel, bool>>? filter = null);
    }
}

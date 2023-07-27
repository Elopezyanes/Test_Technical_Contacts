using ContactList.DAL.DBContext;
using ContactList.DAL.Repositorys.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ContactList.DAL.Repositorys.Implementations
{
    public class GenericRepository<TModel> : IGenericRepository<TModel> where TModel : class
    {
        private readonly ContactsContext _context;

        public GenericRepository(ContactsContext context)
        {
            _context = context;
        }

       

        public async Task<TModel> Create(TModel model)
        {
            try
            {
                _context.Set<TModel>().Add(model);
                await _context.SaveChangesAsync();
                return model;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Edit(TModel model)
        {
            try
            {
                _context.Set<TModel>().Update(model);
                await _context.SaveChangesAsync();
                return true;


            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Delete(TModel model)
        {
            try
            {
                _context.Set<TModel>().Remove(model);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IQueryable<TModel>> ConsultTask(Expression<Func<TModel, bool>>? filter = null)
        {
            try
            {
                IQueryable<TModel> queryModelo = filter == null ? _context.Set<TModel>() : _context.Set<TModel>().Where(filter);
                return queryModelo;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IQueryable<TModel> ConsultNoTask(Expression<Func<TModel, bool>>? filter = null)
        {
            IQueryable<TModel> consulta = (filter == null) ? _context.Set<TModel>() : _context.Set<TModel>().Where(filter);
            return consulta;
        }
    }
}

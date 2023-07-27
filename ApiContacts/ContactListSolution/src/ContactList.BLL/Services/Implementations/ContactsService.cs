using AutoMapper;
using ContactList.BLL.Services.Contracts;
using ContactList.DAL.Repositorys.Contracts;
using ContactList.DTOs;
using ContactList.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList.BLL.Services.Implementations
{
    public class ContactsService : IContactsService
    {
        private readonly IGenericRepository<Contact> _modeloRepo;
        private readonly IMapper _mapper;

        public ContactsService(IGenericRepository<Contact> modeloRepo, IMapper mapper)
        {
            _modeloRepo = modeloRepo;
            _mapper = mapper;
        }

        public async Task<ContactDTOs> Create(ContactDTOs model)
        {
            try
            {
                var dbModel = _mapper.Map<Contact>(model);
                var rspModel = await _modeloRepo.Create(dbModel);

                if (rspModel.Id != 0)
                {
                    return _mapper.Map<ContactDTOs>(rspModel);

                }
                else
                {
                    throw new TaskCanceledException("No se pudo crear el Contacto");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var consulta = _modeloRepo.ConsultNoTask(p => p.Id == id);
                var fromDmModel = await consulta.FirstOrDefaultAsync();

                if (fromDmModel != null)
                {
                    var respuesta = await _modeloRepo.Delete(fromDmModel);
                    if (!respuesta)
                    {
                        throw new TaskCanceledException("No se pudo eliminar el Contacto");
                    }

                    return respuesta;
                }
                else
                {
                    throw new TaskCanceledException("No se encontro");
                }
            }
            catch (Exception)
            {

                throw;
            }

        }


        public async Task<ContactDTOs> FindById(int id)
        {
            try
            {
                var consult = _modeloRepo.ConsultNoTask(p => p.Id == id);
                var fromDbModelo = await consult.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                {
                    return _mapper.Map<ContactDTOs>(fromDbModelo);

                }
                else
                {
                    throw new TaskCanceledException("No se encontro");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<ContactDTOs>> FindRangeAge(int ageinit, int agefinal)
        {

            IQueryable<Contact> query = await _modeloRepo.ConsultTask();
            var listResult = new List<Contact>();
            try
            {
                var datemin = DateTime.Today.AddYears(-ageinit);
                var datemax = DateTime.Today.AddYears(-agefinal);

                listResult = await query
                    .Where(c =>
                c.DateBirth < datemin
                && c.DateBirth >= datemax
                    ).ToListAsync();

            }
            catch (Exception)
            {

                throw;
            }

            return _mapper.Map<List<ContactDTOs>>(listResult);

            throw new NotImplementedException();
        }

        public async Task<List<ContactDTOs>> ListFilterByAdressAndName(string search)
        {
            try
            {
                var consult = _modeloRepo.ConsultNoTask(c => string.Concat(c.FirstName.ToLower(), c.SecondName.ToLower(), c.Adresses.ToLower()).Contains(search.ToLower()));
                List<ContactDTOs> list = _mapper.Map<List<ContactDTOs>>(await consult.ToListAsync());
                return list;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Update(ContactDTOs model)
        {
            try
            {
                var consulta = _modeloRepo.ConsultNoTask(p => p.Id == model.Id);
                var fromDmModel = await consulta.FirstOrDefaultAsync();
                if (fromDmModel != null)
                {
                    fromDmModel.FirstName = model.FirstName;
                    fromDmModel.SecondName = model.SecondName;
                    fromDmModel.Adresses = model.Adresses;
                    fromDmModel.DateBirth = model.DateBirth;
                    fromDmModel.PhoneNumber = model.PhoneNumber;
                    fromDmModel.Image = model.Image;
                    var respuesta = await _modeloRepo.Edit(fromDmModel);

                    if (!respuesta)
                    {
                        throw new TaskCanceledException("No se pudo editar");
                    }
                    return respuesta;


                }
                else
                {
                    throw new TaskCanceledException("Sin Resultados");

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

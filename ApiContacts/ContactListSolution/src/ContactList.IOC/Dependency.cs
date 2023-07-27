using ContactList.BLL.Services.Contracts;
using ContactList.BLL.Services.Implementations;
using ContactList.DAL.DBContext;
using ContactList.DAL.Repositorys.Contracts;
using ContactList.DAL.Repositorys.Implementations;
using ContactList.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList.IOC
{
    public static class Dependency
    {
        public static void InyectDependencys(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ContactsContext>(Opt =>
            {
                Opt.UseSqlite(configuration.GetConnectionString("DefaultConnectionStrings"));
            });

            // interfaces of Repository
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));


            //interfaces of Services
            services.AddScoped<IContactsService, ContactsService>();

            //Add Automapper
            services.AddAutoMapper(typeof(AutoMapperProfile));



        }
    }
}

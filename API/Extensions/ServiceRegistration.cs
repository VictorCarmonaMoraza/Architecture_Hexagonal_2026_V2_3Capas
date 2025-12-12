using Hexagonal.Application.Case_Uso;
using Hexagonal.Application.Case_Uso_DTO;
using Hexagonal.Application.Case_Uso_Genericos;
using Hexagonal.Application.DTOs;
using Hexagonal.Application.Genericos;
using Hexagonal.Application.Port_Primary;
using Hexagonal.Domain.Entities;
using Hexagonal.Domain.GenericosDomain;
using Hexagonal.Domain.interfaces;
using Hexagonal.Infraestructure.DBContext;
using Hexagonal.Infraestructure.GenericosInfraestructure;
using Hexagonal.Infraestructure.Repository;
using Hexagonal.Infraestructure.RepositoryDTO;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{

    public static class ServiceRegistration
    {
        public static IServiceCollection AddProjectServices(this IServiceCollection services, string connectionString)
        {
            // DbContext
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Repositorios
            services.AddTransient<IItemRepository, ItemRepository>();
            services.AddTransient<ICommonRepository<Nota>, NoteRepository>();

            // Servicios
            services.AddTransient<IItemService, ItemService>();
            services.AddTransient<ICommonService<Nota>, NotaService>();

            //DTO en Application
            services.AddTransient<ICommonRepository<NoteDTO>, NoteDTORepository>();
            services.AddTransient<ICommonService<NoteDTO>, NoteDTOService>();


            return services;
        }
    }
}

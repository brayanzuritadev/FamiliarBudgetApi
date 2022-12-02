using FamiliarBudgetApi.BLL;
using FamiliarBudgetApi.BLL.DTOs;
using FamiliarBudgetApi.BusinessLogicalLayer.Validation;
using FamiliarBudgetApi.DAL.DAO;
using FamiliarBudgetApi.DAL.Models;
using FamiliarBudgetApi.DataAccessLayer.ContextDB;
using FamiliarBudgetApi.DataAccessLayer.DAO;
using Microsoft.EntityFrameworkCore;

namespace FamiliarBudgetApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //in this place are the services
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserDAO, UserDAO>();
            services.AddTransient<IFamilyDAO, FamilyDAO>();
            services.AddTransient<IValidator<UserDTO>, UserValidator>();
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers();
            services.AddScoped<UserService>();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //in this place are the middlewares
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}

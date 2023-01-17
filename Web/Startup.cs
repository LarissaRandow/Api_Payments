using Core.Interfaces.IRepository;
using Core.Query.Handler;
using Infra.Repositories;
using MediatR;

namespace Web
{
    public class Startup
    {
        public IConfiguration configRoot
        {
            get;
        }
        public Startup(IConfiguration configuration)
        {
            configRoot = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddMvc();

            //Handler
            services.AddMediatR(typeof(GetAllUsersQueryHandler));

            //Repositories
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IPaymentRepository, PaymentRepository>();

        }
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}

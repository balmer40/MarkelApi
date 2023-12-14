using System;
using MarkelApi.Repositories;

namespace MarkelApi
{
    public class Startup
    {
        public void AddServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddScoped<IClaimRepository, StubClaimRepository>();
            services.AddScoped<ICompanyRepository, StubCompanyRepository>();
        }

        public void Configure(WebApplication app)
        {
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}


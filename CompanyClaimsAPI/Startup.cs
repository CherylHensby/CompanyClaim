using CompanyClaimsAPI.Data;
using CompanyClaimsAPI.Data.Interfaces;
using CompanyClaimsAPI.Services;
using CompanyClaimsAPI.Services.Interfaces;

namespace CompanyClaimsAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            configuration = configuration?? throw new ArgumentNullException(nameof(configuration));
        }

        public void ConfigureServices(IServiceCollection services)
        {

            var builder = WebApplication.CreateBuilder();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            services.AddMemoryCache();

            services.AddTransient<IDataLayer, DataLayer>();
            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<IClaimService, ClaimService>();
            app.UseHttpsRedirection();


            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}





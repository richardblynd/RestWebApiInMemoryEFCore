using Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebApi
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
            services.AddControllers();
            
            var dbName = Configuration.GetValue<string>("DataBaseName");
            if (string.IsNullOrWhiteSpace(dbName))
                dbName = "MoviesDB";

            services.AddDbContext<AwardsDBContext>(options => options.UseInMemoryDatabase(databaseName: dbName));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AwardsDBContext context, ILogger<Startup> log)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            AddData(context, log);
        }

        private void AddData(AwardsDBContext context, ILogger log)
        {
            DataGenerator.Initialize(context, Configuration.GetValue<string>("CsvFilePath"), log);
        }
    }
}

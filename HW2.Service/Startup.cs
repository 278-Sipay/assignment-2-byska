using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using HW2.Data.Context;
using HW2.Data.Repository.TransactionRepository;
using HW2.Schema.Mapper;

namespace HW2.Service;

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
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sipay Api Collection", Version = "v1" });
        });


        //dbcontext
        var dbType = Configuration.GetConnectionString("DbType");
        if (dbType == "Sql")
        {
            var dbConfig = Configuration.GetConnectionString("MsSqlConnection");
            services.AddDbContext<HW2Context>(opts =>
            opts.UseSqlServer(dbConfig));
        }
       


        services.AddScoped<ITransactionRepository, TransactionRepository>();


        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new MapperConfig());
        });
        services.AddSingleton(config.CreateMapper());

    }

  
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sipay v1"));
        }

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}

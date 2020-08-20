using CS.Business.Shared.Abstract;
using CS.Business.Services;
using CS.EntityFrameworkCore.Abstract;
using CS.EntityFrameworkCore.EntityFrameworkCore;
using CS.EntityFrameworkCore.Repositories;
using CS.WebAPI.Infrastructure;
using CS.WebAPI.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using AutoMapper;
using CS.Business;
using CS.Business.AutoMapper;
using Microsoft.Extensions.Logging;
using CS.Logging.Logging;

namespace CS.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<CSDbContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:CSDbConnection"]));
            new IoC(services).Register();
            new CSDbConfigration(Configuration["ConnectionStrings:CSDbConnection"]);
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new CustomDtoMapper());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            //services.addautomapper<IMapper, CustomDtoMapper>();
            //services.AddAutoMapper(typeof(CustomDtoMapper));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ÇiçekSepeti Swagger", Version = "v1" });
                c.OperationFilter<HeaderParameter>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddProvider(new FileLogProvider());
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger");
            });
        }
    }
}

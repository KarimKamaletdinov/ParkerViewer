using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ParkerViewer.Abstractions;
using ParkerViewer.Abstractions.Commands;
using ParkerViewer.Abstractions.Dtos;
using ParkerViewer.Abstractions.Queries;
using ParkerViewer.Handlers.Pen;
using ParkerViewer.Handlers.PenItem;
using ParkerViewer.Repositories;

namespace ParkerViewer.Host
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
            services.AddControllers();

            services.AddScoped<SqlPenRepository>();

            services.AddScoped<IQueryHandler<GetPens, PenDto[]>, GetPensHandler>();
            services.AddScoped<ICommandHandler<InsertPen>, InsertPenHandler>();
            services.AddScoped<ICommandHandler<UpdatePen>, UpdatePenHandler>();
            services.AddScoped<ICommandHandler<DeletePen>, DeletePenHandler>();

            services.AddScoped<SqlPenItemRepository>();

            services.AddScoped<IQueryHandler<GetPenItems, PenItemDto[]>, GetPenItemsHandler>();
            services.AddScoped<ICommandHandler<InsertPenItem>, InsertPenItemHandler>();
            services.AddScoped<ICommandHandler<UpdatePenItem>, UpdatePenItemHandler>();
            services.AddScoped<ICommandHandler<DeletePenItem>, DeletePenItemHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
        }
    }
}

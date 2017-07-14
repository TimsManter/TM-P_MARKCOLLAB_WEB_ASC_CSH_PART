﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarkCollab.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace MarkCollab
{
  public class Startup
  {
    public Startup(IHostingEnvironment env)
    {
      var builder = new ConfigurationBuilder()
        .SetBasePath(env.ContentRootPath)
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
        .AddEnvironmentVariables();
      Configuration = builder.Build();
    }

    public IConfigurationRoot Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      // Add framework services.
      services.AddDbContext<MarkCollabDbContext>();

      services.AddIdentity<User, Role>()
        .AddEntityFrameworkStores<MarkCollabDbContext>()
        .AddDefaultTokenProviders();
      services.AddCors();
      services.AddMvc(options => {
        options.InputFormatters.Add(new TextPlainInputFormatter());
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
      loggerFactory.AddConsole(Configuration.GetSection("Logging"));
      loggerFactory.AddDebug();
      if (env.IsDevelopment()) {
        app.UseDeveloperExceptionPage();
        app.UseDatabaseErrorPage();
      }
      app.UseCors(corsBuilder => {
        corsBuilder.AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader();
      });
      app.UseMvc();

      var serviceScopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
      using (var serviceScope = serviceScopeFactory.CreateScope()) {
        var dbContext = serviceScope.ServiceProvider.GetService<MarkCollabDbContext>();
        dbContext.Database.EnsureCreated();
      }
    }
  }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TaskyServer.Middlewares;
using TS.Business.Helpers;
using TS.Business.Implementations;
using TS.Business.Interfaces;
using TS.Model;
using TS.Repository;
using UDT.Model;

namespace TaskyServer;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    private IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.Configure<AuthorizationSettings>(Configuration.GetSection("AuthorizationSettings"));
        services.Configure<EncryptionSettings>(Configuration.GetSection("EncryptionSettings"));

        var connString = Configuration.GetConnectionString("DbConnection");
        if (connString == null) return;
        services.AddDbContext<DataContext>(options => options.UseSqlServer(connString));

        services.AddControllersWithViews();

        services.AddTransient<IHashingHelper, HashingHelper>();
        services.AddTransient<IAuthorizationHelper, AuthorizationHelper>();

        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IAccountService, AccountService>();
        services.AddTransient<ITaskService, TaskService>();
        services.AddTransient<ISubtaskService, SubtaskService>();


        services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "TASKY", Version = "v1" }); });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "TASKY");
                options.RoutePrefix = string.Empty;
            });
        }
        else
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "TASKY");
                options.RoutePrefix = string.Empty;
            });
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseStaticFiles();
        app.UseRouting();

        app.UseMiddleware<AttachUserToContextMiddleware>();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                "default",
                "{controller}/{action=Index}/{id?}");
        });
    }
}
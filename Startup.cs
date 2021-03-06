using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using My.Project.adk.DataContext;
using My.Project.adk.Infrastructure;
using My.Project.adk.Models;
using My.Project.adk.Services;

namespace My.Project.adk
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
            services.AddTransient<IEleveService, EleveService>();
            services.AddTransient<IEcoleService, EcoleService>();
            services.AddTransient<IClasseService, ClasseService>();
            services.AddTransient<IAccountService, AccountService>();

            services.AddIdentity<User_pro, IdentityRole>().AddEntityFrameworkStores<ProjectDbContext>();

            services.AddTransient<IPasswordValidator<User_pro>, CustomPasswordValidator>();
            services.AddTransient<IUserValidator<User_pro>, CustomUserValidator>();
            services.AddDbContext<ProjectDbContext>(options => options.UseSqlServer(this.Configuration.GetConnectionString("DbProj")));
            
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My.Project.adk", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My.Project.adk v1"));
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

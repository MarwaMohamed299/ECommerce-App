using ECommerceBL.Managers.Product;
using ECommerceDAL.Data.Context;
using ECommerceDAL.Data.Models;
using ECommerceDAL.Repos.Products;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ECommerce_App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var ConnectionString = builder.Configuration.GetConnectionString("ECommerceSystem");
            builder.Services.AddDbContext<ECommerceContext>(options => options.UseSqlServer(ConnectionString));

            builder.Services.AddIdentity<User,  IdentityRole<Guid>>(options =>
            {
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 5;

                options.User.RequireUniqueEmail = true;
                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
            })
                .AddEntityFrameworkStores<ECommerceContext>();


                builder.Services.AddAuthentication(options=>   /////verify token using jwt bearer
                {
                    options.DefaultAuthenticateScheme = "default";
                    options.DefaultChallengeScheme = "default";
  

                }).
                 AddJwtBearer("default", options =>
                 {
                     ///secret key for request validation
                     var secretKey = builder.Configuration.GetValue<string>("SecretKey");
                     var secretKeyInBytes = Encoding.ASCII.GetBytes(secretKey);
                     var key = new SymmetricSecurityKey(secretKeyInBytes);
                     options.TokenValidationParameters = new TokenValidationParameters
                     {
                         ValidateIssuer = false,
                         ValidateAudience = false,
                         IssuerSigningKey = key
                     };
                 });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IProductManager, ProductManager>();
            builder.Services.AddScoped<IProductRepo, ProductRepo>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            var staticFilesPath = Path.Combine(Environment.CurrentDirectory,"Images"); //combine 2 paths

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider (staticFilesPath),  
                RequestPath = "/Images"  //what u set in URL to get the images 
            });
            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
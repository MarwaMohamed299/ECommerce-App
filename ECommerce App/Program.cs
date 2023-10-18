
using ECommerceDAL.Data.Context;
using ECommerceDAL.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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


                builder.Services.AddAuthentication(options=>
                {
                    options.DefaultAuthenticateScheme = "default";
                    options.DefaultChallengeScheme = "default";
  

                }).
                 AddJwtBearer("default", options =>
                 {
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

           
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
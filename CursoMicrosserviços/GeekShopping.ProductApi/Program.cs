using AutoMapper;
using GeekShopping.ProductApi.Config;
using GeekShopping.ProductApi.Model.SqlServerContext;
using GeekShopping.ProductApi.Repository;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //config bd
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<SqlServerContext>(options => options.UseSqlServer(connectionString));
            
            //config automapper
            IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
            builder.Services.AddSingleton(mapper);
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //injeção de dependencia
            builder.Services.AddScoped<IProductRepository, ProductRepository>();

            var app = builder.Build();
            
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            //para usar o HTTPS
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
using DatabaseApi.Infrastructure.DataBaseContext;
using DatabaseApi.Infrastructure.Repository;
using DatabaseApi.Interfaces.Repository;
using DatabaseApi.Interfaces.Services;
using DatabaseApi.Services;
using Microsoft.EntityFrameworkCore;

namespace DatabaseApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
            builder.Services.AddScoped<ITransactionsRepository, TransactionsRepository>();
            builder.Services.AddScoped<ITransactionsService, TransactionsService>();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<TransactionsContext>(options => options.UseSqlServer(connectionString));
            
            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
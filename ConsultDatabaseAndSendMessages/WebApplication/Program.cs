using MessagesApi.Interfaces;
using MessagesApi.Interfaces.External;
using MessagesApi.Services;

namespace MessagesApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IDatabaseApi, Services.External.DatabaseApi>();
            builder.Services.AddScoped<ISendMessages, SendMessages>();
            builder.Services.AddScoped<ISimpleHttpClient, SimpleHttpClient>();

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
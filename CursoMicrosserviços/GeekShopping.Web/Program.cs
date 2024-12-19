using GeekShopping.Web.Services;
using GeekShopping.Web.Services.IServices;

namespace GeekShopping.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //Configurando o HTTP client
            builder.Services.AddHttpClient<IProductService, ProductService>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(builder.Configuration["ServiceUrls:ProductAPI"]));

            ////Configurando a porta para rodar em HTTP ou HTTPS
            //builder.WebHost.ConfigureKestrel(options =>
            //{
            //    options.ListenAnyIP(4430); // Porta para HTTP
            //    options.ListenAnyIP(4431, listenOptions => listenOptions.UseHttps()); // Porta para HTTPS
            //});

            var app = builder.Build();

            

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseHttpsRedirection();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
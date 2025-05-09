using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace Gateway.WebApi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
            builder.Services.AddOcelot();


            var app = builder.Build();

            app.MapGet("/", () => "Hello World!");

            app.UseHttpsRedirection();
            app.UseAuthorization();

            //Use Ocelot middleware
            await app.UseOcelot();

            app.Run();
        }
    }
}

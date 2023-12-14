using Microsoft.AspNetCore.Hosting;

namespace MarkelApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var startup = new Startup();

            startup.AddServices(builder.Services);

            var app = builder.Build();

            startup.Configure(app);

            app.Run();
        }
    }
}


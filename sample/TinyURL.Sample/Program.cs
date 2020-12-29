using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using TinyURL.Core.Abstracts;
using TinyURL.SqlServer;

namespace TinyURL.Sample
{
    class Program
    {

        static async Task Main(string[] args)
        {
            var url = "www.baidu.com";
            TinyURL shortUrl = new TinyURL(
                new SqlServerStorageProcessor("Server=localhost;Database=TestDb;Trusted_Connection=True;"));
            await shortUrl.Generator(url);

            Console.WriteLine("Hello World!");
        }
        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IDataStorageProcessor>(
                new SqlServerStorageProcessor("Server=localhost;Database=TestDb;Trusted_Connection=True;"));
        }


    }
}

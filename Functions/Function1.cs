
using DAL;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Functions
{
    public static class Function1
    {
        private static IServiceProvider provider;

        static Function1()
        {
            IServiceCollection services = new ServiceCollection();

            IConfiguration config = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .Build();

            services.AddSingleton(config);

            services.AddDbContext<DataContext>(o => o.UseSqlServer(
                config.GetConnectionString("SqlConnection"),
                s => s.MigrationsAssembly("DAL")
            ));

            provider = services.BuildServiceProvider(true);
        }

        [FunctionName("Function1")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequest req, ILogger log)
        {
            using (IServiceScope scope = provider.CreateScope())
            {
                DataContext context = scope.ServiceProvider.GetRequiredService<DataContext>();
                List<User> users = context.Users.ToList();

                log.LogInformation($"Found {users.Count} users!");

                return new OkResult();
            }
        }
    }
}

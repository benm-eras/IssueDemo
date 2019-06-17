
using DAL;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace Functions
{
    public class HttpTrigger
    {
        private readonly DataContext context;

        public HttpTrigger(DataContext context) => this.context = context;

        [FunctionName("CountUsers")]
        public IActionResult Get([HttpTrigger(AuthorizationLevel.Function, "get")]HttpRequest req, ILogger log)
        {
            List<User> users = this.context.Users.ToList();

            log.LogInformation($"Found {users.Count} users!");

            return new OkResult();
        }
    }
}

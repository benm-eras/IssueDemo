using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Functions
{
    public static class Function1
    {
        [FunctionName("Function1")]
        [return: Queue("Queue1")]
        public static async Task Run([QueueTrigger("%Messaging.Email.Send:Queue%")]string message, ILogger log)
        {
            log.LogInformation(message);
        }
    }
}

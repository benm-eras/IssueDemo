using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Functions
{
    public static class Function1
    {
        [FunctionName("Messaging-Email-Send")]
        [return: Queue("%Queue2%")]
        public static async Task Run([QueueTrigger("%Queue1%")]string message, ILogger log)
        {
            log.LogInformation(message);
        }
    }
}

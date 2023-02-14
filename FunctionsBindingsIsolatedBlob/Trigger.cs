using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FunctionsBindingsIsolatedBlob
{
    public class Trigger
    {
        private readonly ILogger _logger;

        public Trigger(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Trigger>();
        }

        [Function(nameof(BlobTrigger))]
        public void BlobTrigger([BlobTrigger("marketing/{name}", Connection = "AzureWebJobsStorage")] string myBlob, string name)
        {
            _logger.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
        }
    }
}

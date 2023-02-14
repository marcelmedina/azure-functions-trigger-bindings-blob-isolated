using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FunctionsBindingsIsolatedBlob
{
    public class Input
    {
        private readonly ILogger _logger;

        public Input(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Input>();
        }

        [Function(nameof(BlobInput))]
        public void BlobInput(
            [BlobTrigger("marketing-txt/{name}.txt", Connection = "AzureWebJobsStorage")] string blobTrigger, string name,
            [BlobInput("marketing-txt/{name}.txt", Connection = "AzureWebJobsStorage")] string blobContent
            )
        {
            _logger.LogInformation($"C# Blob trigger function Processed blob\n Name:{name}.txt \n Size: {blobTrigger.Length} Bytes");

            _logger.LogInformation($"{blobContent}");
        }
    }
}

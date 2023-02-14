using Azure.Storage.Blobs;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FunctionsBindingsIsolatedBlob
{
    public class Output
    {
        private readonly ILogger _logger;

        public Output(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Output>();
        }

        [Function(nameof(BlobOutput))]
        [BlobOutput("marketing-csv/{name}.csv", Connection = "AzureWebJobsStorage")]
        public string BlobOutput([BlobTrigger("marketing-txt/{name}.csv", Connection = "AzureWebJobsStorage")] string blobTrigger, string name)
        {
            _logger.LogInformation($"C# Blob trigger function Processed blob\n Name:{name}.csv \n Size: {blobTrigger.Length} Bytes");

            // DELETE csv from marketing-txt container
            var storageConnectionString = System.Environment.GetEnvironmentVariable("AzureWebJobsStorage");
            BlobClient client = new BlobClient(storageConnectionString, "marketing-txt", $"{name}.csv");
            client.DeleteIfExists();

            return blobTrigger;
        }
    }
}

using Azure.Storage.Blobs;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.IO;

namespace FunctionsBindingsInProcessBlob
{
    public class Output
    {
        [FunctionName(nameof(BlobOutput))]
        public void BlobOutput(
            [BlobTrigger("marketing-txt/{name}.csv")] Stream blobTrigger, string name,
            [Blob("marketing-csv/{name}.csv", FileAccess.Write)] Stream blobContent, ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name}.csv \n Size: {blobTrigger.Length} Bytes");

            // DELETE csv from marketing-txt container
            var storageConnectionString = System.Environment.GetEnvironmentVariable("AzureWebJobsStorage");
            BlobClient client = new BlobClient(storageConnectionString, "marketing-txt", $"{name}.csv");
            client.DeleteIfExists();
        }
    }
}

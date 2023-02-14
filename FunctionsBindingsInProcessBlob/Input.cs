using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.IO;

namespace FunctionsBindingsInProcessBlob
{
    public class Input
    {
        [FunctionName(nameof(BlobInput))]
        public void BlobInput(
            [BlobTrigger("marketing-txt/{name}.txt")] Stream blobTrigger, string name,
            [Blob("marketing-txt/{name}.txt", FileAccess.Read)] Stream blobContent, ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name}.txt \n Size: {blobTrigger.Length} Bytes");

            // READ stream just uploaded
            using var reader = new StreamReader(blobContent);
            var data = reader.ReadToEnd();
            log.LogInformation($"{data}");
        }
    }
}

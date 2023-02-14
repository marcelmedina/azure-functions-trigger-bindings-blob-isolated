using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace FunctionsBindingsInProcessBlob
{
    public class Trigger
    {
        [FunctionName(nameof(BlobTrigger))]
        public void BlobTrigger([BlobTrigger("marketing/{name}")]Stream myBlob, string name, ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
        }
    }
}

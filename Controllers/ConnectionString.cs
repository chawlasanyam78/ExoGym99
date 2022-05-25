using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using System;
namespace BlobStorageDemo
{
    public static class ConnectionString
    {
        static string account = CloudConfigurationManager.GetSetting("StorageAccountName");
        static string key = CloudConfigurationManager.GetSetting("StorageAccountKey");
        public static CloudStorageAccount GetConnectionString()
        {
            string connectionString = string.Format("DefaultEndpointsProtocol=https;AccountName=sanyamstorage;AccountKey=5iIfLZcWV1c7c2eecuAJlpWbVkmWi+TAJJvYqUnVGTG9g0JtDNumENOPMiGHm8gVdOIuOJgyh2eu+AStjRdpTA==;EndpointSuffix=core.windows.net", account, key);
            return CloudStorageAccount.Parse(connectionString);
        }
    }
}
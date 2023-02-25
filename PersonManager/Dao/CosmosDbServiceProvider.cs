using Microsoft.Azure.Cosmos;

namespace PersonManager.Dao
{
    public static class CosmosDbServiceProvider
    {
        private const string DatabaseName = "People";
        private const string ContainerName = "People";
        private const string Account = "https://personitems.documents.azure.com:443/";
        private const string Key = "cBolqzI4Ukb20QmfwPksgKxUrvc2LRFSRsF61lRIWIUAdTdWPWUNE9pKR4OFzr6cKDlrbxhJgZrCACDbbbd1tg==";
        private static ICosmosDbService cosmosDbService;

        public static ICosmosDbService CosmosDbService { get => cosmosDbService; }

        public async static Task Init()
        {
            CosmosClient client = new CosmosClient(Account, Key);
            cosmosDbService = new CosmosDbService(client, DatabaseName, ContainerName);
            DatabaseResponse database = await client.CreateDatabaseIfNotExistsAsync(DatabaseName);
            await database.Database.CreateContainerIfNotExistsAsync(ContainerName, "/id");
        }
    }
}

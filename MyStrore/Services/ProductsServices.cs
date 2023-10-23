using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MyStrore.Data;

namespace MyStrore.Services
{
    public class ProductsServices : IProductsServices
    {
        private readonly IMongoCollection<Products> _products;
        private readonly IOptions<DatabaseSettings> _dbSetting;
        public ProductsServices(IOptions<DatabaseSettings> dbSettings)
        {
            _dbSetting = dbSettings;
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionStrings);
            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
            _products = mongoDatabase.GetCollection<Products>(dbSettings.Value.ProductsCollectionName);

        }
        //
        public async Task<IEnumerable<Products>> GetAllAsynsc() =>
            await _products.Find(_ => true).ToListAsync();


        public async Task<Products> GetById(string id) =>
            await _products.Find(a => a.Id == id).FirstOrDefaultAsync(); 

        public async Task CreateAsync(Products product) =>
            await _products.InsertOneAsync(product);

        public async Task UpdateAsync(string id, Products products) =>
          await _products
          .ReplaceOneAsync(a => a.Id == id, products);

        public async Task DeleteAysnc(string id) =>
            await _products.DeleteOneAsync(a => a.Id == id);

    }
}

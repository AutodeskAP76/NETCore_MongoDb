using MongoDB.Driver;
using NETCore_MongoDb.Models;

namespace NETCore_MongoDb.Services
{    
    public class PersonService
    {
        private IConfiguration _config;
        private readonly IMongoCollection<PersonModel> _personCollection;

        public PersonService(IConfiguration config)
        {
            var _config = config;

            var mongoClient = new MongoClient(config["BookStoreDatabase:ConnectionString"]);
            var mongoDatabase = mongoClient.GetDatabase(config["BookStoreDatabase:DatabaseName"]);
            _personCollection = mongoDatabase.GetCollection<PersonModel>(config["BookStoreDatabase:BooksCollectionName"]);
        }

        public async Task<List<PersonModel>> GetAsync() =>
       await _personCollection.Find(_ => true).ToListAsync();

        public async Task<PersonModel?> GetAsync(string id) =>
            await _personCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(PersonModel newPerson) =>
            await _personCollection.InsertOneAsync(newPerson);

        public async Task UpdateAsync(string id, PersonModel updatedPerson) =>
            await _personCollection.ReplaceOneAsync(x => x.Id == id, updatedPerson);

        public async Task RemoveAsync(string id) =>
            await _personCollection.DeleteOneAsync(x => x.Id == id);

    }
}

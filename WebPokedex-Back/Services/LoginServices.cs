using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Security.AccessControl;
using WebPokedex.Models;

namespace WebPokedex.Services
{
    public class LoginServices : ILoginServices
    {
        private readonly IMongoCollection<LoginRequest> _mongoCollection;
        private readonly IOptions<DatabaseSet> _dbSettings;

        public LoginServices(IOptions<DatabaseSet> dbSettings)
        {
            // * Configure DB Settings addedd in program.cs
            _dbSettings = dbSettings;
            // Call Client with databaseSet.ConnectionString
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            // Configure Database with databaseSet.DatabaseName
            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
            // Set Collection with databaseSet.LoginCollectionName
            _mongoCollection = mongoDatabase.GetCollection<LoginRequest>(dbSettings.Value.LoginCollectionName);
        }

        // GET from DB
        public async Task<IEnumerable<LoginRequest>> GetAllAsync()=>
           await _mongoCollection.Find(_=> true).ToListAsync();

        // SAME SOLUTION
        //public async Task<IEnumerable<LoginRequest>> GetAllAsync()
        //{
        //    var loginRequest = _mongoCollection.Find(_=> true).ToList();    
        //    return loginRequest;
        //}

        // GET BY ID from DB
        public async Task<LoginRequest> GetByIdAsync(string id) =>
            await _mongoCollection.Find(a => a.Id == id).FirstOrDefaultAsync();
       
        // POST Add new Trainer to DB
        public async Task CreateAsync(LoginRequest trainer) =>
            await _mongoCollection.InsertOneAsync(trainer);
        
        // PUT Update old Trainer to DB
        public async Task UpdateAsync(LoginRequest trainer) =>
            await _mongoCollection.ReplaceOneAsync(a => a.Id == trainer.Id, trainer);

        // PUT Delete old Trainer to DB
        public async Task DeleteAsync(string id) =>
            await _mongoCollection.DeleteOneAsync(a => a.Id == id);

    }
}

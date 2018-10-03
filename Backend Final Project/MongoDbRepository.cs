using System;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using Backend_Final_Project;

namespace game_server.Repositories
{
    public class MongoDbRepository : IRepository
    {
        private readonly IMongoCollection<Match> _collection;
        private readonly IMongoCollection<BsonDocument> _bsonDocumentCollection;
        public List<Match> matchList = new List<Match>();

        public MongoDbRepository()
        {
            var mongoClient = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase database = mongoClient.GetDatabase("Game");
            _collection = database.GetCollection<Match>("matches");
            _bsonDocumentCollection = database.GetCollection<BsonDocument>("matches");
        }

        public async Task<Match> CreateMatch(Match match)
        {
            await _collection.InsertOneAsync(match);
            return match;
        }

        public Task<Match> GetMatch(Guid id)
        {
            FilterDefinition<Match> filter = Builders<Match>.Filter.Eq("_id", id);
            return _collection.Find(filter).FirstAsync();
        }
        
        public async Task<Match[]> GetAllMatches()
        {
            List<Match> match = await _collection.Find(new BsonDocument()).ToListAsync();
            return match.ToArray();
        }

        // public async Task<Match> UpdateMatch(Guid id, ModifiedMatch match)
        // {
        //     var filter = Builders<Match>.Filter.Eq("_id", id);
        //     await _collection.ReplaceOneAsync(filter, match);
        //     return match;
        // }
        public Task<Match> DeleteMatch(Guid matchId)
        {
            var filter = Builders<Match>.Filter.Eq("_id", matchId);
            _collection.DeleteOne(filter);
            return null;
        }

         public async Task<double> PlayerOneWinrate()
         {
             //Vertaa player 1 (aloittajan) voittoja matsien kokonaismäärään
             var AllMatches = await GetAllMatches();
             FilterDefinition<Match> filter = Builders<Match>.Filter.Eq("Winner", 1);
             var result =  _collection.Find(filter);
             var resultList = await result.ToListAsync();
             double percentage = resultList.Count / AllMatches.Length;
             return percentage;
         }
         public async Task<double> CharacterPickrate(string character){
             //Tarkistaa matsin molempien teamien hahmot, vertaa kuinka usein hahmo esiintyy matseissa (per puoli)
             var AllMatches = await GetAllMatches();
             var filter1 = Builders<Match>.Filter.ElemMatch(a=>a.PlayerOneTeam, character);
             var filter2 = Builders<Match>.Filter.ElemMatch(a=>a.PlayerTwoTeam, character);
             var result1 =  _collection.Find(filter1);
             var resultList1 = await result1.ToListAsync();
             var result2 =  _collection.Find(filter2);
             var resultList2 = await result2.ToListAsync();
             double percentage = (resultList1.Count+resultList2.Count / AllMatches.Length)/2;
             return percentage;
            
         }
    }
}
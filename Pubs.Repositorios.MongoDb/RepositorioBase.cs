using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pubs.Repositorios.MongoDb
{
    public class RepositorioBase<T>
    {
        private IMongoCollection<T> _colecao;
        private IMongoDatabase _db;

        public RepositorioBase()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["pubsConnectionString"].ConnectionString;
            var databaseName = MongoUrl.Create(connectionString).DatabaseName;

            _db = new MongoClient(connectionString).GetDatabase(databaseName);
            _colecao = _db.GetCollection<T>(typeof(T).Name);
        }
    }
}

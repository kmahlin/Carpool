using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarpoolSystem.Services
{
    public class DatabaseManager
    {
        public interface IRepository<T>
        {
            T CreateNew();

            void Delete(T item);
            void Update(T item);
            void Insert(T item);

            IQueryable<T> Query { get; }
        }

        public interface IMainDB : IRepository<MainDbEntities>
        {
            IEnumerable<MainDbEntities> FindUser(int id);

        }
    }
}
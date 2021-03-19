using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookServices.Core
{
    public class BookService : IBookServices
    {
        private IMongoCollection<Book> _bookCollection;

        public BookService(IMongoClient client)
        {
            var database = client.GetDatabase("mongoTest");
            _bookCollection = database.GetCollection<Book>("books");
        }

        public Book addBook(Book data)
        {
            _bookCollection.InsertOne(data);
            return data;
        }

        public void DeleteBook(string id)
        {
            _bookCollection.DeleteOne(x => x.Id == id);
        }

        public Book GetBook(string id)
        {
            return _bookCollection.Find(x => x.Id == id).FirstOrDefault();
        }

        public List<Book> GetBooks()
        {
            return _bookCollection.Find(x => true).ToList();
        }

        public Book updateBook(string id,Book data)
        {
            var book = _bookCollection.ReplaceOne(x => x.Id == id,data);
            return data;
        }
    }
}

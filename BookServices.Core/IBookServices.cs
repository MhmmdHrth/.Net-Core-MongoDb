using System;
using System.Collections.Generic;
using System.Text;

namespace BookServices.Core
{
    public interface IBookServices
    {
        List<Book> GetBooks();

        Book GetBook(string id);

        Book addBook(Book data);

        Book updateBook(string id,Book data);

        void DeleteBook(string id);
    }
}

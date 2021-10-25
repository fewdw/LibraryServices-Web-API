using System.Collections.Generic;
using LibraryServicesData.Models;

namespace LibraryServicesData.Repositories
{
    public interface IBookRepository
    {
        List<Book> getAllBooks();

        Book GetBook(int id);

        bool AddNewBook(Book book);
        bool Remove(int id);
        List<Book> UpdateBook(int id, Book book);
    }
}
using LibraryServicesData.Models;
using System.Collections.Generic;
using System.Linq;

namespace LibraryServicesData.Repositories
{
    public class BookRepository : IBookRepository
    {
        public List<Book> books = new List<Book>()
        {
            new Book() {Id = 1, Title = "book1", Author = "author1", PublicationYear = 2010, CallNumber = "343543254"},
            new Book() {Id = 2, Title = "book2", Author = "author2", PublicationYear = 2002, CallNumber = "306716406"},
            new Book() {Id = 3, Title = "book3", Author = "author3", PublicationYear = 2005, CallNumber = "405768130"},
            new Book() {Id = 4, Title = "book4", Author = "author4", PublicationYear = 2007, CallNumber = "104760385"}
        };
        public List<Book> getAllBooks()
        {
            return books;
        }

        public Book GetBook(int id)
        {
            var book = books.FirstOrDefault(x => x.Id == id);
            return book;
        }

        public bool AddNewBook(Book book)
        {
            books.Add(book);
            return true;
        }

        public bool Remove(int id)
        {
            var book = GetBook(id);
            if (book == null)
            {
                return false;
            }

            books.Remove(book);
            return true;
        }

        public List<Book> UpdateBook(int id, Book book)
        {
            if (this.Remove(id))
            {
                this.AddNewBook(book);
                return books;
            }
            return books;
        }
    }
}
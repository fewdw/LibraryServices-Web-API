﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using LibraryServicesData.Repositories;
using LibraryServicesData.Models;

namespace LibraryServices.Controllers
{
    [EnableCors(origins:"*",headers:"*",methods:"*")]
    public class BooksController : ApiController
    {
        //option 1
        private IBookRepository books = new BookRepository();

        //option 2 is better

        //private IBookRepository books;
        //public BookController(IBookRepository _book)
        //{
        //    this.books = _book;
        //}

        //GET api/books
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return books.getAllBooks();
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var book = books.GetBook(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }
        
        [HttpPost]
        public IHttpActionResult PostBook(Book book)
        {
            bool result = books.AddNewBook(book);

            if (result)
            {
                return Ok(books);
            }

            return BadRequest();
        }

        [HttpDelete]
        public IHttpActionResult DeleteBook(int id)
        {
            if (books.Remove(id))
            {
                return Ok(books.getAllBooks());
            }

            return NotFound();
        }

        [HttpPut]
        public IHttpActionResult UpdateBook(int id, Book book)
        {
            var ubook = books.UpdateBook(id, book);
            if (ubook != null)
            {
                return Ok(ubook);
            }

            return NotFound();
        }

    }
}
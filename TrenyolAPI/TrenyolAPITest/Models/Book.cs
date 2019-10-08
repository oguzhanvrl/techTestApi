
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrenyolAPITest.Models
{
    public class Book
    {
        public int bookID { get; set; }
        public string bookAuthor { get; set; }
        public string bookTitle { get; set; }
        public List<Book> AddUser()
        {
            List<Book> books = new List<Book>();
            Book book = new Book();
            book.bookID = 1;
            book.bookAuthor = "John Smith";
            book.bookTitle = "Reliability of late night deployments";
            books.Add(book);
            Book book2 = new Book();
            book2.bookID = 2;
            book2.bookAuthor = "Jane Archer";
            book2.bookTitle = "DevOps is a lie";
            books.Add(book2);
            return books;

        }
        
        public List<Book> BookList()
        {
            return AddUser();

        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Management_App
{
    internal class Library
    {
        public List<Book> _books { get; private set; } = [];
        public List<User> _users { get; private set; } = [];

        public void AddBook(Book book)
        {
            _books.Add(book);
            Console.WriteLine("Book has been added to the library.");
        }
        public void RegisterUser(User user)
        {
            _users.Add(user);
            Console.WriteLine("User has been added succesfully");
        }
        public void BorrowBook(User user, Book book)
        {
            
            user.BorrowBook(book);
            
        }
        public void ReturnBook(User user, Book book)
        {
            user.ReturnBook(book);
        }
        public void ShowAvailableBooks()
        {
            for (int i = 0; i < _books.Count; i++)
            {
                Book book = _books[i];

                Console.WriteLine($"{i + 1} - {book.Title} by {book.Author}");
            }
        }
    }
}

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
            WriteLine("Book has been added to the library.");
        }
        public void RegisterUser(User user)
        {
            _users.Add(user);
            WriteLine("User has been added succesfully");
        }
        public User? Login(string name)
        {
            foreach (User user in _users)
            {
                if (user.Name == name)
                {
                    return user;
                }
            }

            return null;
        }
        public void BorrowBook(User user, Book book)
        {
            
            user.BorrowBook(book);
            _books.Remove(book);

        }
        public void ReturnBook(User user, Book book)
        {
            user.ReturnBook(book);
            _books.Add(book);
        }
        public void ShowAvailableBooks()
        {
            for (int i = 0; i < _books.Count; i++)
            {
                Book book = _books[i];

                WriteLine($"\n{i + 1} - {book.Title} by {book.Author}");
            }
        }

    }
}

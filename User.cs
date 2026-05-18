using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Management_App
{
    internal class User
    {
        public string Name { get; private set; }
        public int Id { get; private set; }
        public List<Book> _borrowed { get; private set; } = new();

        public User(string name, int id) {
            Name = name;
            Id = id;
            List<Book> _borrowed = new();
        }

        public bool BorrowBook(Book book)
        {
            if (book.Borrow())
            {
                _borrowed.Add(book);
                Console.WriteLine("Book has been borrowed.");
                return true;
            }
            else {
                Console.WriteLine("Book could not be borrowed.");
                return false; }
        }
        public bool ReturnBook(Book book)
        {
            if (book.Return() && _borrowed.Contains(book))
            {
                _borrowed.Remove(book);
                Console.WriteLine("Book has been returned.");
                return true;
            }
            else {
                Console.WriteLine("Book could not be returned.");
                return false; }
        }
    }
}

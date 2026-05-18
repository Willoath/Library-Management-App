using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Library_Management_App
{
    internal class Book
    {
        public string Title { get; private set; }
        public string Author { get; private set; }
        public bool IsAvailable { get; private set; }
        public int Id {  get; private set; }

        public Book(string title, string author, int id)
        {
            Title = title;
            Author = author;
            Id = id;
            IsAvailable = true;
        }

        public bool Borrow()
        {
            if (!IsAvailable)
            {
                Console.WriteLine("Book is not available.");
                return false;
            }
            else
            {
                Console.WriteLine("Book can be borrowed");
                IsAvailable = false;
                return true;
            }
        }
        public bool Return()
        {
            if (!IsAvailable)
            {
                IsAvailable = true;
                return true;
            }

            return false;
        }
    }
}

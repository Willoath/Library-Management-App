using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Library_Management_App
{
    internal partial class Book
    {
        public string Title { get;  set; }
        public string Author { get; set; }
        public bool IsAvailable { get;  set; }
        public int Id {  get;  set; }

        public Book() {

        }

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

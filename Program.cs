using Library_Management_App;
using System.ComponentModel;




 Book book1 = new Book("The Great Gatsby", "F. Scott Fitzgerald", 001);
 Book book2 = new Book("To Kill a Mockingbird", "Harper Lee", 002);

 User user1 = new User("John Doe", 001);

 Library library = new Library();

 library.AddBook(book1);
 library.AddBook(book2);
 library.RegisterUser(user1);


bool isRunning = true;

while (isRunning)
{
    Console.WriteLine();
    Console.WriteLine("===== LIBRARY MENU =====");
    Console.WriteLine("1. Show available books");
    Console.WriteLine("2. Borrow book");
    Console.WriteLine("3. Return book");
    Console.WriteLine("4. Add a book to the library");
    Console.WriteLine("5. Show borrowed books");
    Console.WriteLine("6. Exit");
    Console.Write("Choose option: ");

    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            library.ShowAvailableBooks();
            break;

        case "2":
            Console.Write("\nChoose book number: \n");
            int index = Convert.ToInt32(Console.ReadLine());
            library.BorrowBook(user1, library._books[index -1]);
            break;

        case "3":
            Console.Write("\nChoose book number: \n");
            index = Convert.ToInt32(Console.ReadLine());
            library.ReturnBook(user1, library._books[index - 1]);
            break;

        case "4":
            Console.Write("Enter book title: ");
            string title = Console.ReadLine();

            Console.Write("Enter author: ");
            string author = Console.ReadLine();

            Console.Write("Enter id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Book book = new Book(title, author, id);
            library.AddBook(book);
            break;
        case"5":
            Console.WriteLine("\nBorrowed books:\n");
            Console.WriteLine(user1._borrowed);
            break;
        case "6":
            isRunning = false;
            Console.WriteLine("Application closed.");
            break;

        default:
            Console.WriteLine("Invalid option.");
            break;
    }
}
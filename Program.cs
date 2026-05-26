using Library_Management_App;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Text.Json;

Library library = new Library();
User? currentUser = null;
Data data = new Data();
data.LoadData(library);


bool isRunning = true;


while (isRunning)
{
    Console.WriteLine();
    Console.WriteLine("===== LIBRARY MENU =====");
    Console.WriteLine("Current user: " + (currentUser?.Name ?? "No user logged in"));
    Console.WriteLine("1. Show available books");
    Console.WriteLine("2. Borrow book");
    Console.WriteLine("3. Return book");
    Console.WriteLine("4. Add a book to the library");
    Console.WriteLine("5. Show borrowed books");
    Console.WriteLine("6. Log in");
    Console.WriteLine("7. Log out");
    Console.WriteLine("8. Register user");
    Console.WriteLine("9. Exit");
    Console.Write("Choose option: \n");

    int.TryParse(Console.ReadLine(), out int choice);

        switch (choice)
    {
        case 1:
            library.ShowAvailableBooks();
            break;

        case 2:

            if (currentUser == null)
            {
                Console.WriteLine("You must log in first.");
                break;
            }

            Console.Write("\nChoose book number: \n");

            if (int.TryParse(Console.ReadLine(), out int index))
            {
                if (index > 0 && index <= library._books.Count)
                {
                    library.BorrowBook(currentUser, library._books[index - 1]);
                }
                else
                {
                    Console.WriteLine("Invalid book number.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid book number.");
            }

            data.SaveData(library);

            break;

        case 3:

            if (currentUser == null)
            {
                Console.WriteLine("You must log in first.");
                break;
            }

            Console.Write("\nChoose book number: \n");

            if (int.TryParse(Console.ReadLine(), out index))
            {
                if (index > 0 && index <= currentUser._borrowed.Count)
                {
                    library.ReturnBook(currentUser, currentUser._borrowed[index - 1]);
                }
                else
                {
                    Console.WriteLine("Invalid book number.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid book number.");
            }

            data.SaveData(library);

            break;

        case 4:

            Console.Write("Enter book title: \n");
            string title = Console.ReadLine();

            Console.Write("Enter author: ");
            string author = Console.ReadLine();

            Console.Write("Enter id: \n");

            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Book book = new Book(title, author, id);
                library.AddBook(book);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid book ID.");
            }

            data.SaveData(library);

            break;

        case 5:

            if (currentUser == null)
            {
                Console.WriteLine("You must log in first.");
                break;
            }

            Console.WriteLine("\nBorrowed books:\n");

            for (int i = 0; i < currentUser._borrowed.Count; i++)
            {
                Console.WriteLine(i + 1 + ". " +
                    currentUser._borrowed[i].Title +
                    " by " +
                    currentUser._borrowed[i].Author);
            }

            break;
        case 6:
            Console.Write("Enter user name: ");

            currentUser = library.Login(Console.ReadLine());

            if (currentUser != null)
            {
                Console.WriteLine("Logged in successfully.");
            }
            else
            {
                Console.WriteLine("User not found.");
            }

            break;
        case 7:
            currentUser = null;
            Console.WriteLine("Logged out.");
            break;
        case 8:
            Console.Write("Enter user name: ");
            string registerName = Console.ReadLine();
            User newUser = new User(registerName, library._users.Count + 1);
            library.RegisterUser(newUser);

            data.SaveData(library);

            break;
        case 9:
            isRunning = false;
            Console.WriteLine("Application closed.");
            break;

        default:
            Console.WriteLine("Invalid option.");
            break;
    }
}
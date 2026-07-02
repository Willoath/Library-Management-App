using Library_Management_App;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Text.Json;

Library library = new Library();
User? currentUser = null;
Data_ data = new Data_();
data.LoadData(library);


bool isRunning = true;


while (isRunning)
{
    WriteLine();
    WriteLine("===== LIBRARY MENU =====");
    WriteLine("Current user: " + (currentUser?.Name ?? "No user logged in"));
    WriteLine("1. Show available books");
    WriteLine("2. Borrow book");
    WriteLine("3. Return book");
    WriteLine("4. Add a book to the library");
    WriteLine("5. Show borrowed books");
    WriteLine("6. Log in");
    WriteLine("7. Log out");
    WriteLine("8. Register user");
    WriteLine("9. Exit");
    Write("Choose option: \n");

    int.TryParse(ReadLine(), out int choice);

        switch (choice)
    {
        case 1:
            library.ShowAvailableBooks();
            break;

        case 2:

            if (currentUser == null)
            {
                WriteLine("You must log in first.");
                break;
            }

            Write("\nChoose book number: \n");

            if (int.TryParse(ReadLine(), out int index))
            {
                if (index > 0 && index <= library._books.Count)
                {
                    library.BorrowBook(currentUser, library._books[index - 1]);
                }
                else
                {
                    WriteLine("Invalid book number.");
                }
            }
            else
            {
                WriteLine("Invalid input. Please enter a valid book number.");
            }

            data.SaveData(library);

            break;

        case 3:

            if (currentUser == null)
            {
                WriteLine("You must log in first.");
                break;
            }

            Write("\nChoose book number: \n");

            if (int.TryParse(ReadLine(), out index))
            {
                if (index > 0 && index <= currentUser._borrowed.Count)
                {
                    library.ReturnBook(currentUser, currentUser._borrowed[index - 1]);
                }
                else
                {
                    WriteLine("Invalid book number.");
                }
            }
            else
            {
                WriteLine("Invalid input. Please enter a valid book number.");
            }

            data.SaveData(library);

            break;

        case 4:

            Write("Enter book title: \n");
            string title = ReadLine();

            Write("Enter author: ");
            string author = ReadLine();

            Write("Enter id: \n");

            if (int.TryParse(ReadLine(), out int id))
            {
                Book book = new Book(title, author, id);
                library.AddBook(book);
            }
            else
            {
                WriteLine("Invalid input. Please enter a valid book ID.");
            }

            data.SaveData(library);

            break;

        case 5:

            if (currentUser == null)
            {
                WriteLine("You must log in first.");
                break;
            }

            WriteLine("\nBorrowed books:\n");

            for (int i = 0; i < currentUser._borrowed.Count; i++)
            {
                WriteLine(i + 1 + ". " +
                    currentUser._borrowed[i].Title +
                    " by " +
                    currentUser._borrowed[i].Author);
            }

            break;
        case 6:
            Write("Enter user name: ");

            currentUser = library.Login(ReadLine());

            if (currentUser != null)
            {
                WriteLine("Logged in successfully.");
            }
            else
            {
                WriteLine("User not found.");
            }

            break;
        case 7:
            currentUser = null;
            WriteLine("Logged out.");
            break;
        case 8:
            Write("Enter user name: ");
            string registerName = ReadLine();
            User newUser = new User(registerName, library._users.Count + 1);
            library.RegisterUser(newUser);

            data.SaveData(library);

            break;
        case 9:
            isRunning = false;
            WriteLine("Application closed.");
            break;

        default:
            WriteLine("Invalid option.");
            break;
    }
}
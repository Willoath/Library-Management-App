using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.IO;

namespace Library_Management_App
{
    internal class Data_
    {
        public void SaveData(Library library)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string booksJson =
                JsonSerializer.Serialize(library._books, options);

            File.WriteAllText("books.json", booksJson);

            string usersJson =
                JsonSerializer.Serialize(library._users, options);

            File.WriteAllText("users.json", usersJson);
        }            
        
    
        public void LoadData(Library library)
            {
                if (File.Exists("books.json"))
                {
                    string booksJson =
                        File.ReadAllText("books.json");

                    List<Book>? books =
                        JsonSerializer.Deserialize<List<Book>>(booksJson);

                    if (books != null)
                    {
                        library._books.AddRange(books);
                    }
                }

                if (File.Exists("users.json"))
                {
                    string usersJson =
                        File.ReadAllText("users.json");

                    List<User>? users =
                        JsonSerializer.Deserialize<List<User>>(usersJson);

                    if (users != null)
                    {
                        library._users.AddRange(users);
                    }
                }
            }
    } 
}

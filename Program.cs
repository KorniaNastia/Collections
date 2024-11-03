using System;
using System.Collections.Generic;

namespace UserManagerApp
{
    // Клас для користувачів
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public User(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    // Клас для управління користувачами
    public class UserManager
    {
        private List<User> users = new List<User>();

        // Додавання нового користувача
        public void AddUser(int id, string name)
        {
            User newUser = new User(id, name);
            users.Add(newUser);
            Console.WriteLine($"User {id} added: {name}");
        }

        // Видалення користувача за ідентифікатором
        public void RemoveUser(int id)
        {
            User userToRemove = users.Find(u => u.Id == id);
            if (userToRemove != null)
            {
                users.Remove(userToRemove);
                Console.WriteLine($"User {id} removed.");
            }
            else
            {
                Console.WriteLine($"User {id} not found.");
            }
        }

        // Пошук користувача за ідентифікатором
        public void FindUser(int id)
        {
            User userToFind = users.Find(u => u.Id == id);
            if (userToFind != null)
            {
                Console.WriteLine($"User found: ID: {userToFind.Id}, Name: {userToFind.Name}");
            }
            else
            {
                Console.WriteLine($"User {id} not found.");
            }
        }

        // Виведення всіх користувачів
        public void DisplayUsers()
        {
            Console.WriteLine("Current Users:");
            foreach (var user in users)
            {
                Console.WriteLine($"ID: {user.Id}, Name: {user.Name}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            UserManager userManager = new UserManager();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nOptions: Add, Remove, Find, Display, Exit");
                Console.Write("Choose an option: ");
                string option = Console.ReadLine().ToLower();

                switch (option)
                {
                    case "add":
                        Console.Write("Enter User ID: ");
                        int userId = int.Parse(Console.ReadLine());
                        Console.Write("Enter User Name: ");
                        string userName = Console.ReadLine();
                        userManager.AddUser(userId, userName);
                        break;
                    case "remove":
                        Console.Write("Enter User ID to remove: ");
                        int idToRemove = int.Parse(Console.ReadLine());
                        userManager.RemoveUser(idToRemove);
                        break;
                    case "find":
                        Console.Write("Enter User ID to find: ");
                        int idToFind = int.Parse(Console.ReadLine());
                        userManager.FindUser(idToFind);
                        break;
                    case "display":
                        userManager.DisplayUsers();
                        break;
                    case "exit":
                        exit = true;
                        Console.WriteLine("Exiting the User Manager.");
                        break;
                    default:
                        Console.WriteLine("Unknown option. Please try again.");
                        break;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;

class Program   {
    static void Main()
{
DataAccess dataAccess = new DataAccess();

    while (true)
    {
        Console.WriteLine("\n1. Add Book");
        Console.WriteLine("2. View All Books");
        Console.WriteLine("3. Find Book by ID");
        Console.WriteLine("4. Create Backup");
        Console.WriteLine("5. Exit");

        Console.Write("Enter your choice: ");
        int choice = int.Parse(Console.ReadLine());

        if (choice == 1)
        {
            Console.WriteLine("Enter Book details: ");
            string? book = Console.ReadLine();
            string[] parts = book.Split(',');

            int id = int.Parse(parts[0]);
            string title = parts[1];
            string author = parts[2];
            double price = double.Parse(parts[3]);

            Books b1 = new Books(id, title, author, price);

            dataAccess.AddBook(b1);
        }
        else if (choice == 2)
        {
            dataAccess.ViewAllBooks();
        }
        else if (choice == 3)
        {
            Console.WriteLine("Enter Book id: ");
            int id_ = int.Parse(Console.ReadLine());

            dataAccess.FindBookById(id_);
        }
        else if (choice == 4)
        {
            dataAccess.CreateBackup();
        }
        else if (choice == 5)
        {
            Console.WriteLine("Program ended.");
            break;
        }
        else
        {
            Console.WriteLine("Invalid choice!");
        }
    }
}}
class DataAccess
{
public void AddBook(Books b)
{
string book = b.id + "," + b.title + "," + b.author + "," + b.price;

    using StreamWriter writer = new StreamWriter("books.txt",true);

    writer.WriteLine(book);

    Console.WriteLine("Book added successfully.");
}


public void ViewAllBooks()
{
    if (!File.Exists("books.txt"))
    {
        Console.WriteLine("No books found.");
        return;
    }

    List<Books> books = new List<Books>();

    using StreamReader reader = new StreamReader("books.txt");

    string? book;

    while ((book = reader.ReadLine()) != null)
    {
        string[] parts = book.Split(',');

        int id = int.Parse(parts[0]);
        string title = parts[1];
        string author = parts[2];
        double price = double.Parse(parts[3]);

        Books b = new Books(id, title, author, price);
        books.Add(b);
    }

    if (books.Count == 0)
    {
        Console.WriteLine("No books found.");
        return;
    }

    foreach (Books b in books)
    {
        b.DisplayInfo();
        Console.WriteLine();
    }
}


public void FindBookById(int id)
{
    if (!File.Exists("books.txt"))
    {
        Console.WriteLine("Book not found!");
        return;
    }

    using StreamReader reader = new StreamReader("books.txt");

    string? book;

    while ((book = reader.ReadLine()) != null)
    {
        string[] parts = book.Split(',');

        int Bookid = int.Parse(parts[0]);

        if (Bookid == id)
        {
            Books b = new Books(
                int.Parse(parts[0]), parts[1], parts[2],double.Parse(parts[3])
            );

            b.DisplayInfo();
            return;
        }
    }

    Console.WriteLine("Book not found!");
}


public void CreateBackup()
{
    if (!File.Exists("books.txt"))
    {
        Console.WriteLine("No books found.");
        return;
    }

    using StreamReader source = new StreamReader("books.txt");
    using StreamWriter destination = new StreamWriter("books_backup.txt");

    string? Read;

    while ((Read = source.ReadLine()) != null)
    {
        destination.WriteLine(Read);
    }

    Console.WriteLine("Backup created successfully.");
}

}
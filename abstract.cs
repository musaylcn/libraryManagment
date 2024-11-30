using System;
using System.Collections.Generic;

abstract class Book
{
    public string Title { get; set; }
    public string Author { get; set; }

    public Book(string title, string author)
    {
        Title = title;
        Author = author;
    }

    public abstract string GetDescription();
}

class Fiction : Book
{
    public string Genre { get; set; }

    public Fiction(string title, string author, string genre) : base(title, author)
    {
        Genre = genre;
    }

    public override string GetDescription()
    {
        return $"Kurgusal Kitap: {Title}, Yazar : {Author}, Tür: {Genre}";
    }
}

class NonFiction : Book
{
    public string Subject { get; set; }

    public NonFiction(string title, string author, string subject) : base(title, author)
    {
        Subject = subject;
    }

    public override string GetDescription()
    {
        return $"Kurgusal Olmayan Kitap: {Title}, Yazar: {Author}, Tür: {Subject}";
    }
}

class Member
{
    public string Name { get; set; }
    public int MemberId { get; set; }
    private List<Book> BorrowedBooks = new List<Book>();

    public Member(string name, int memberId)
    {
        Name = name;
        MemberId = memberId;
    }

    public void BorrowBook(Book book)
    {
        BorrowedBooks.Add(book);
        Console.WriteLine($"{Name} borrowed the book: {book.Title}");
    }

    public void ReturnBook(Book book)
    {
            BorrowedBooks.Remove(book);
            Console.WriteLine($"{Name} returned the book: {book.Title}");
    }
}

class Librarian
{
    public string Name { get; set; }
    public int EmployeeId { get; set; }
    public List<Book> BookList = new List<Book>();

    public Librarian(string name, int employeeId)
    {
        Name = name;
        EmployeeId = employeeId;
    }

    public void AddBook(Book book)
    {
        BookList.Add(book);
        Console.WriteLine($"Added book: {book.Title}");
    }

    public void RemoveBook(Book book)
    {

        BookList.Remove(book);
        Console.WriteLine($"Removed book: {book.Title}");
        
    }

    public void ListBooks()
    {
        Console.WriteLine("Library Inventory:");
        foreach (var book in BookList)
        {
            Console.WriteLine(book.GetDescription());
        }
    }
}

class Program
{
    static void Main(string[] args)
    {

        Fiction fiction1 = new Fiction("The Great Gatsby", "F. Scott Fitzgerald", "Classic");
        Fiction fiction2 = new Fiction("1984", "George Orwell", "Dystopian");

        NonFiction nonFiction1 = new NonFiction("A Brief History of Time", "Stephen Hawking", "Science");
        NonFiction nonFiction2 = new NonFiction("Sapiens", "Yuval Noah Harari", "Anthropology");

        Member member1 = new Member("Alice", 1001);

        Librarian librarian1 = new Librarian("John", 2001);

        librarian1.AddBook(fiction1);
        librarian1.AddBook(fiction2);
        librarian1.AddBook(nonFiction1);
        librarian1.AddBook(nonFiction2);

        librarian1.ListBooks();
        member1.BorrowBook(fiction1);
        member1.ReturnBook(fiction1);
        librarian1.RemoveBook(nonFiction1);
        librarian1.ListBooks();
    }
}

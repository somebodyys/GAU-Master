using System.Collections.Generic;

namespace library.Models;

public class Book
{
    public int book_id { get; set; }
    public string title { get; set; }
    public int author_id { get; set; }
    public string genre { get; set; }
    public int publication_year { get; set; }

    public Author Author { get; set; }
    public ICollection<Loan> Loans { get; set; } = new List<Loan>();
}
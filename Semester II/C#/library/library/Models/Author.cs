using System.Collections.Generic;

namespace library.Models;

public class Author
{
    public int author_id { get; set; }
    public string name { get; set; }
    public string nationality { get; set; }

    public ICollection<Book> Books { get; set; } = new List<Book>();
}
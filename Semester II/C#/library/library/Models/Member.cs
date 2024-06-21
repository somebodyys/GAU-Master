using System.Collections.Generic;

namespace library.Models;

public class Member
{
    public int member_id { get; set; }
    public string first_name { get; set; }
    public string last_name { get; set; }
    public string email { get; set; }
    public string phone { get; set; }

    public ICollection<Loan> Loans { get; set; } = new List<Loan>();
}
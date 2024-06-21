using System;

namespace library.Models;

public class Loan
{
    public int loan_id { get; set; }
    public int book_id { get; set; }
    public int member_id { get; set; }
    public DateTime loan_date { get; set; }
    public DateTime return_date { get; set; }

    public Book Book { get; set; }
    public Member Member { get; set; }
}
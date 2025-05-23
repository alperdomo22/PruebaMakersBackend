namespace Entities.Entities
{
    public class Loan
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public int UserId { get; set; }
        public int LoanStatusId { get; set; }
        public User User { get; set; }
        public LoanStatus LoanStatus { get; set; }
    }
}

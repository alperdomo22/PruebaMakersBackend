using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class LoanStatus
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public ICollection<Loan> Loans { get; set; }
    }
}

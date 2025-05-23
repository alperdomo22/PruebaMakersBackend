using Domain.Class;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ILoanRepository
    {
        LoanDomain[] GetLoansByUser(int idUsuario);
        GeneralResponseDomain AddLoan(LoanDomain loanDomain);
    }
}

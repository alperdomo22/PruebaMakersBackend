using Application.Interfaces;
using Domain.Class;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Class
{
    public class LoanApplication: ILoanApplication
    {
        readonly ILoanRepository LoanRepository;
        public LoanApplication(ILoanRepository loanRepository)
        {
            LoanRepository = loanRepository;
        }

        public GeneralResponseDomain AddLoan(LoanDomain loanDomain)
        {
            GeneralResponseDomain generalResponse = new();

            try
            {
                LoanValidateDomain(loanDomain);
                generalResponse = LoanRepository.AddLoan(loanDomain);
            }
            catch (Exception ex)
            {
                generalResponse.Description = ex.Message;
                generalResponse.Success = false;
            }

            return generalResponse;
        }

        private void LoanValidateDomain(LoanDomain loanDomain)
        {
            loanDomain.AssignInitialStatus();
            loanDomain.LoanValidateDomain();
        }
    }
}

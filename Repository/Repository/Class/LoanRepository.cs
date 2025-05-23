using Domain.Class;
using Entities.Entities;
using Infraestructure;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Class
{
    public class LoanRepository: ILoanRepository
    {
        readonly ApplicationDbContext dbContext;

        public LoanRepository(ApplicationDbContext _applicationDbContext)
        {
            dbContext = _applicationDbContext;
        }

        public Loan? GetloanById (int id)
        {
            return dbContext.Loan.AsNoTracking().FirstOrDefault(loan => loan.Id == id);
        }

        public LoanDomain[] GetLoansByUser(int idUsuario)
        {
            return dbContext.Loan.AsNoTracking().Include(loan => loan.LoanStatus).Select(loan => new LoanDomain
            {
                Id = loan.Id,
                Amount = loan.Amount,
                UserId = loan.UserId,
                LoanStatusDescription = loan.LoanStatus.Description
            }).ToArray();
        }

        public GeneralResponseDomain AddLoan(LoanDomain loanDomain)
        {
            try
            {
                Loan newLoan = new() {
                    Amount = loanDomain.Amount!.Value,
                    UserId = loanDomain.UserId!.Value,
                    LoanStatusId = loanDomain.LoanStatusId!.Value
                };

                dbContext.Loan.Add(newLoan);
                dbContext.SaveChanges();

                return new GeneralResponseDomain {
                    Success = true,
                    Description = "Registro de prestamo exitoso"
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocurrió un error en el registro del prestamos, el error es el siguiente: {ex.Message}");
            }
        }

        public void ApproveLoan (int id)
        {
            Loan loanToApprove = dbContext.Loan.First(loan => loan.Id == id);

            loanToApprove.LoanStatusId = 2;

            dbContext.SaveChanges();
        }

        public void DisapproveLoan(int id)
        {
            Loan loanToApprove = dbContext.Loan.First(loan => loan.Id == id);

            loanToApprove.LoanStatusId = 3;

            dbContext.SaveChanges();
        }
    }
}

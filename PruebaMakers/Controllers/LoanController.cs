using Application.Interfaces;
using Domain.Class;
using Microsoft.AspNetCore.Mvc;

namespace PruebaMakers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoanController : ControllerBase
    {
        readonly ILoanApplication LoanApplication;
        public LoanController(ILoanApplication loanApplication)
        {
            LoanApplication = loanApplication;
        }

        [HttpPost]
        public IActionResult Add([FromBody] LoanDomain loan)
        {
            GeneralResponseDomain generalResponseDomain = LoanApplication.AddLoan(loan);

            if (generalResponseDomain.Success)
            {
                return Ok(generalResponseDomain);
            }
            else
            {
                return NotFound(generalResponseDomain);
            }
        }
    }
}

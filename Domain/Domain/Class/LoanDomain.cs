using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Class
{
    public class LoanDomain
    {
        public int? Id { get; set; }
        public decimal? Amount { get; set; }
        public int? UserId { get; set; }
        public int? LoanStatusId { get; set; }
        public string? LoanStatusDescription { get; set; }
        public void AssignInitialStatus() {
            LoanStatusId = 1;
        }
        public void LoanValidateDomain()
        {
            List<string> listErrors = new();

            if (Amount == null)
                listErrors.Add("El monto del prestamos es requerido");

            if (UserId == null)
                listErrors.Add("El id del usuario al que se le realizará el prestamos es requerido");

            if (listErrors.Count > 0)
                throw new Exception($"Para registrar el prestamos debe revisar los siguientes errores: {string.Join(", ", listErrors)}");
        }
    }
}

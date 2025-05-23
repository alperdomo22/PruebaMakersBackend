namespace Repository
{
    public class GeneralConstansLoanStatus
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public List<GeneralConstansLoanStatus> GetLoanStatus()
        {
            return new()
            {
                new()
                {
                    Id = 1,
                    Description = "Pendiente"
                },
                new()
                {
                    Id = 2,
                    Description = "Aprobado"
                },
                new()
                {
                    Id = 3,
                    Description = "Rechazado"
                },
            };
        }
    }
}

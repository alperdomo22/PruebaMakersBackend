using Domain.Class;
using Infraestructure;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;

namespace Repository.Class
{
    public class UserRepository: IUserRespository
    {
        readonly ApplicationDbContext dbContext;
        public UserRepository(ApplicationDbContext _applicationDbContext)
        {
            dbContext = _applicationDbContext;
        }

        public UserDomain[] GetAllUsers()
        {
            return dbContext.User.AsNoTracking().Select(user => new UserDomain
            {
                Id = user.Id,
                Email = user.Email,
                Identification = user.Identification,
                Name = user.Name,
                Password = user.Password
            }).ToArray();
        }

        public UserDomain? GetUserById(int id)
        {
            return dbContext.User.AsNoTracking().Select(user => new UserDomain
            {
                Id = user.Id,
                Email = user.Email,
                Identification = user.Identification,
                Name = user.Name,
                Password = user.Password
            }).FirstOrDefault(user => user.Id == id);
        }
    }
}

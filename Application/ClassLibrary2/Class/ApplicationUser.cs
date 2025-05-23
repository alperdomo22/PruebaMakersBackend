using Application.Interfaces;
using Domain.Class;
using Repository.Interfaces;

namespace Application.Class
{
    public class ApplicationUser: IApplicationUser
    {
        readonly IUserRespository UserRespository;
        public ApplicationUser(IUserRespository userRespository)
        {
            UserRespository = userRespository;
        }

        public UserDomain[] GetAllUsers()
        {
            return UserRespository.GetAllUsers();
        }

        public UserDomain GetUserById(int id)
        {
            return UserRespository.GetUserById(id);
        }

    }
}

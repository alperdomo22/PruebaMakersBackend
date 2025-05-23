using Domain.Class;

namespace Repository.Interfaces
{
    public interface IUserRespository
    {
        UserDomain[] GetAllUsers();
        UserDomain GetUserById(int id);
    }
}

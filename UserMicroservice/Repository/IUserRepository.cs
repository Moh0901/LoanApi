using UserMicroservice.DTO;
using UserMicroservice.Model;

namespace UserMicroservice.Repository
{
    public interface IUserRepository
    {
        User Authenticate(Login user);

        List<User> GetAllUsers();

        User GetUserById(int id);

        User AddUser(UserDTO user);

        User UpdateUser(int id, UserDTO user);

        User DeleteUser(int id);
    }
}

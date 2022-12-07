using Microsoft.EntityFrameworkCore;
using UserMicroservice.DTO;
using UserMicroservice.Model;

namespace UserMicroservice.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _db;

        public UserRepository(UserDbContext db)
        {
            _db = db;
        }

        public User Authenticate(Login user)
        {
            var loggedUser = _db.user.
                FirstOrDefault(x => x.username.ToLower() == user.username.ToLower() && x.password == user.password);

            if (loggedUser == null)
            {
                return null;
            }
            return loggedUser;
        }

        //Get All Users
        public List<User> GetAllUsers()
        {
            var users = _db.user.ToList();
            return users;
        }

        //Get User By Id
        public User GetUserById(int id)
        {
            var user = _db.user.Find(id);
            return user;
        }

        //Add New User
        public User AddUser(UserDTO user)
        {
            var newUser = new Model.User()
            {
                name = user.name,
                username = user.username,
                password = user.password,
                role = user.role,
            };
            _db.user.Add(newUser);
            _db.SaveChanges();
            return newUser;
        }

        //Delete User
        public User DeleteUser(int id)
        {
            var user = _db.user.Find(id);
            if (user == null)
            {
                return null;
            }
            _db.user.Remove(user);
            _db.SaveChanges();
            return user;
        }

        //Update User
        public User UpdateUser(int id, UserDTO user)
        {
            var updateUser = new Model.User()
            {
                id = id,
                name = user.name,
                username = user.username,
                password = user.password,
                role = user.role
            };

            _db.Entry(updateUser).State = EntityState.Modified;

            _db.SaveChanges();
            return _db.user.Find(id);
        }
    }
}

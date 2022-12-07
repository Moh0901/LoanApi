using UserMicroservice.Model;

namespace UserMicroservice.Repository
{
    public interface ITokenHandler
    {
        String CreateToken(User user);
    }
}

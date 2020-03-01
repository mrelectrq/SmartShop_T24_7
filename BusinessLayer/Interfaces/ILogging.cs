using BusinessLayer.Data_Model;
using DataLayer.Responses;

namespace BusinessLayer.Interfaces
{
    public interface ILogging
    {
       RegistrationResponse UserRegistrationAction(UserRegModel data);
        string SetCookie(string username, string password);
       LoginResponse UserLoginAction(UserLogModel data);

    }
}

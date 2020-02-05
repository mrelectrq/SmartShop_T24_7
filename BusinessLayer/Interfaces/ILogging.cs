using BusinessLayer.Data_Model;
using DataLayer.Responses;

namespace BusinessLayer.Interfaces
{
    public interface ILogging
    {
       RegistrationResponse UserRegistration(UserRegData data);


    }
}

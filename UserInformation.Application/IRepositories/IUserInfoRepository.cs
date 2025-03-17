using UserInformation.Domain.Entities;

namespace UserInformation.Application.IRepositories
{
    public interface IUserInfoRepository
    {
        Task<bool> CreateUser(UserInfo vm);
        Task<List<UserInfo>> GetAllUsers();
    }
}

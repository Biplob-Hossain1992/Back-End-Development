using Microsoft.EntityFrameworkCore;
using System.Data;
using UserInformation.Application.IRepositories;
using UserInformation.Domain.Context;
using UserInformation.Domain.Entities;

namespace UserInformation.Infrastructure.Repositories
{
    public class UserInfoRepository(AppDbContext db) : IUserInfoRepository
    {
        private readonly AppDbContext _db = db;


        public async Task<bool> CreateUser(UserInfo vm)
        {
            var model = new UserInfo
            {
                Name = vm.Name ?? "",
                Phone = vm.Phone ?? "",
                Email = vm.Email ?? "",
                Address = vm.Address ?? "",
            };
            bool isExist = await _db.UserInfo.AnyAsync(x => x.Phone.Equals(vm.Phone));
            if(!isExist)
            {
                await _db.UserInfo.AddAsync(model);
                await _db.SaveChangesAsync();
                return true;
            }            
            return false;
        }
        public async Task<List<UserInfo>> GetAllUsers()
        {
            var users = await _db.UserInfo
                                 .AsNoTracking()
                                 //set where condition if have like !Deleted / Active users
                                 .Select(x => new UserInfo
                                 {
                                     Id = x.Id,
                                     Name = x.Name,
                                     Phone = x.Phone,
                                     Address = x.Address,
                                     Email = x.Email,
                                 }).ToListAsync();
            return users;
        }
    }
}

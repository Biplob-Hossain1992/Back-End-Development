using Microsoft.EntityFrameworkCore;
using UserInformation.Domain.Entities;

namespace UserInformation.Domain.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> contextOptions) : base(contextOptions)
        {

        }

        public DbSet<UserInfo> UserInfo { get; set; }
    }
}

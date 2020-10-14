using Microsoft.EntityFrameworkCore;

namespace PresetApi.Models
{
    public class AccountApiContext : DbContext
    {
        public AccountApiContext(DbContextOptions<AccountApiContext> options)
            : base(options)
        {
        }
        public DbSet<Account> Accounts { get; set; }
    }
}

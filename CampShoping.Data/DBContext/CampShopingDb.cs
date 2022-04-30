using CampShoping.Domiain.Entities.Account;
using Microsoft.EntityFrameworkCore;

namespace CampShoping.Data.Db
{
    public class CampShopingDb : DbContext
    {
        public CampShopingDb(DbContextOptions<CampShopingDb> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
    }
}

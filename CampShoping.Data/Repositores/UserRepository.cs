using System.Linq;
using CampShoping.Data.Db;
using CampShoping.Domiain.Entities.Account;
using CampShoping.Domiain.IRepositories;
using CampShoping.Domiain.ViewModel.Account;

namespace CampShoping.Data.Repositores
{
    //کلاس پیاده سازی ه  IREPOSITORY
    public class UserRepository : IUserRepository
    {
        #region Constructor
        private readonly CampShopingDb _context;
        public UserRepository(CampShopingDb context)
        {
            _context = context;
        }
        #endregion



        #region user
        public void AddUser(User user)
        {
            _context.Add(user);
        }

        public void EditUser(User user)
        {
            _context.Users.Update(user);
        }

        public bool IsUserExistByEamil(string email)
        {
            return _context.Users.Any(s=>s.Email== email.ToLower().Trim());
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.SingleOrDefault(s => s.Email == email);
        }

       

        #endregion

        #region Save Change
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

      
        #endregion

    }
}

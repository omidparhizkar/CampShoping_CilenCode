using CampShoping.Domiain.Entities.Account;
using CampShoping.Domiain.ViewModel.Account;

namespace CampShoping.Domiain.IRepositories
{
       
     public interface IUserRepository : ISaveChangesRepository
    {
        #region User

        void AddUser(User user);

        void EditUser(User user);
        bool IsUserExistByEamil(string email);

        User GetUserByEmail(string email);
        //    بدست بیاریم User برای اینکه



        #endregion
    }

}

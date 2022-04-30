using CampShoping.Domiain.Entities.Account;
using CampShoping.Domiain.ViewModel.Account;

namespace CampShoping.Application.Servises.Interfaces
{
    public interface IUserService
    {
        //عملیات درخواست کاربر
        #region Account

        RegisterUserResult RegisterUser(RegisterUserViewModel register);

        LoginUserResult IsUserExistForLogin(LoginUserViewModel login);
        /*  چک کن کاربری با این اعطلاعات وجود دارد یا ن  */


        User GetUserByEmail(string email);

        ForgotPasswordResult ForgotPassword(ForgotPasswordViewModel forgot);
        #endregion

    }
}
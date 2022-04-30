using System;
using CampShoping.Application.Servises.Interfaces;
using CampShoping.Domiain.Entities.Account;
using CampShoping.Domiain.IRepositories;
using CampShoping.Domiain.ViewModel.Account;

namespace CampShoping.Application.Servises.Impiementation
{
    public class UserService : IUserService
    {
        #region Constructor

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;


        }

        //private readonly I

        #endregion

        #region Account

        public RegisterUserResult RegisterUser(RegisterUserViewModel register)
        {
            if (_userRepository.IsUserExistByEamil(register.Email))
            {
                return RegisterUserResult.DuplicateEmail;
            }
            var user = new User
            {
                Email = register.Email.ToLower().Trim(),
                Password = register.Password,
                RegisterDate = DateTime.Now,
                ActiveCode = Guid.NewGuid().ToString("N")
            };

            _userRepository.AddUser(user);
            _userRepository.SaveChanges();


            //todo: send email to user
            return RegisterUserResult.Success;

        }


        public LoginUserResult IsUserExistForLogin(LoginUserViewModel login)
        {
            var user = _userRepository.GetUserByEmail(login.Email);

            if (user == null) return LoginUserResult.WrongData;

            if (user.Password != login.Password) return LoginUserResult.WrongData;

            if (!user.IsActive) return LoginUserResult.NotActive;

            return LoginUserResult.Success;
        }

        public User GetUserByEmail(string email)
        {
            return _userRepository.GetUserByEmail(email.ToLower().Trim());
        }

        public ForgotPasswordResult ForgotPassword(ForgotPasswordViewModel forgot)
        {
            var user = _userRepository.GetUserByEmail(forgot.Email.ToLower().Trim());
            
            if (user == null) return ForgotPasswordResult.NotFoundUser;

            user.ActiveCode = Guid.NewGuid().ToString("N");

            _userRepository.EditUser(user);

            _userRepository.SaveChanges();

            //todo send forgot email for user

             return ForgotPasswordResult.Success;

        }

        #endregion
    }
}
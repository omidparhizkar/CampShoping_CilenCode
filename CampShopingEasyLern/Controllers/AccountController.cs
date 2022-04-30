using CampShoping.Application.Servises.Interfaces;
using CampShoping.Domiain.ViewModel.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace CampShopingEasyLern.Controllers
{
    public class AccountController : SiteBaseController
    {
        #region Constructor

        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        #endregion



        #region Register
        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost("register"), ValidateAntiForgeryToken]//  tokn باعث میشود ک ربات بصورت خود کار در سایت ثبت نام نکند باعث پر شدن بانک اعطلاعاتی بشود 
        public IActionResult Register(RegisterUserViewModel register)
         {
            //modelState  مدل جاری وفعلی مدل درحال ارسال شدن 
            if (ModelState.IsValid)
            {
                var res = _userService.RegisterUser(register);
                switch (res)
                {
                    case RegisterUserResult.NotSendEmail:
                        TempData[SuccessMessage] = "ثبت نام شما با موفقیت انجام شد ";
                        TempData[WarningMessage] = "ایمیل فعال سازی برای شما ارسال نشد  ";
                        break;
                    case RegisterUserResult.DuplicateEmail:
                        TempData[WarningMessage] = "از این ایمیل قبلا استفاده شده است   ";
                        ModelState.AddModelError("Email", " ایمیل استفاده شده تکراری میباشد .");
                        break;
                    case RegisterUserResult.Success:
                        TempData[SuccessMessage] = "ثبت نام شما با موفقیت انجام شد ";
                        TempData[InfoMessage] = "ایمیلی حاوی لینک فعال سازی ارسال شده است ";

                        return RedirectToAction("Login", "Account");
                }


            }
            return View(register);
        }


        #endregion

        #region Login
        [HttpGet("login")]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated) return Redirect("/");//برای اینکه دوباره کاربر صحفه لاگین نبیند برگرد به روت اصلی 
              
            
            return View();
        }
        [HttpPost("login"), ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserViewModel login)
        {
            if (ModelState.IsValid)
            {
                var res = _userService.IsUserExistForLogin(login);
                switch (res)
                {
                    case LoginUserResult.WrongData:
                        TempData[WarningMessage] = "اعطلاعات وارد شده صحیح نمیباشد ";
                        break;
                    case LoginUserResult.NotActive:
                        TempData[WarningMessage] = "حساب کاربری شما فعال نشده است ";
                        break;
                    case LoginUserResult.IsBan:
                        TempData[ErrorMessage] = "حساب کاربری شما مسدود شده است ";
                        break;
                    case LoginUserResult.Success:

                        //اینجا  لاگین میشود  user 


                        var user = _userService.GetUserByEmail(login.Email);


                        var claims = new List<Claim>()
                        {
                           new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                           new Claim(ClaimTypes.Email,user.Email.ToLower().Trim())

                        };
                        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                        var principal = new ClaimsPrincipal(identity);

                        var properties = new AuthenticationProperties
                        {
                            IsPersistent = login.RememmbMe
                        };

                        await HttpContext.SignInAsync(principal, properties);





                        return RedirectToAction("Index", "Home");



                }

            }
            return View(login);
        }

        #endregion

        #region forgot password
        [HttpGet("forgot-pass")]
     
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost("forgot-pass")]
        public IActionResult ForgotPassword(ForgotPasswordViewModel forgot)
        {
            if (ModelState.IsValid)
            {
                var res = _userService.ForgotPassword(forgot);
                switch (res)
                {
                    case ForgotPasswordResult.NotFoundUser:
                        TempData[WarningMessage] = "کاربر مورد نظر یافت نشد ";
                        break;
                    case ForgotPasswordResult.Success:
                        TempData[SuccessMessage] = "ایمیل بازیابی برای شما ارسال شد ";
                        return RedirectToAction("Login");
                }
            }
            return View(forgot);
        }
        #endregion
    }
}

using CampShoping.Application.Servises.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CampShopingEasyLern.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }


    }
}

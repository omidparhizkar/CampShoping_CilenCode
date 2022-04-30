using Microsoft.AspNetCore.Mvc;

namespace CampShopingEasyLern.ViewComponents
{
    public class SiteHeaderViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("SiteHeader");
        }

    }
}

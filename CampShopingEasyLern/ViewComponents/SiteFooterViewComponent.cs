using Microsoft.AspNetCore.Mvc;

namespace CampShopingEasyLern.ViewComponents
{
    public class SiteFooterViewComponent : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View("SiteFooter");
        }
    }
}

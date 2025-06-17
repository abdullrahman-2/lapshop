using lapshop.Areas.bl;
using lapshop.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Configuration;

namespace lapshop.Areas.admin.Controllers
{
    [Area("admin")]
    public class HomeController : Controller
    {
        public HomeController(iCategory category, ITems items,ISetting settings)
        {
            
            clsItems = items;
            ClsCategory = category;
            clsSetting = settings; ;

        }

        iCategory ClsCategory;
        ITems clsItems;
        ISetting clsSetting;

        LapShopContext LapShopContext = new LapShopContext();
        VwHomePage OvwHomePage  = new VwHomePage();


        public IActionResult AboutUs()
        {
           

            return View(clsSetting.getAll().FirstOrDefault());
        }
        public IActionResult AllProducts() {

            OvwHomePage.AllItems = clsItems.getAllData(null).ToList();
           

            return View(OvwHomePage);
        }
        public IActionResult Main()
        {

           OvwHomePage.AllItems = clsItems.getAllData(null).Take(10).ToList();
            OvwHomePage.Categories = ClsCategory.getAll().Take(10).ToList();
            OvwHomePage.RecomendeItems = clsItems.getAllData(null).Skip(40).Take(10).ToList();
            OvwHomePage.HomePageSetting = LapShopContext.TbHomePageSetting.FirstOrDefault();
            OvwHomePage.TbSetting = clsSetting.getAll().FirstOrDefault();





            return View(OvwHomePage);
        }
    }
}

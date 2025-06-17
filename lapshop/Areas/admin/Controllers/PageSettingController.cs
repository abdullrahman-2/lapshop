using lapshop.Areas.bl;
using lapshop.Models;
using Microsoft.AspNetCore.Mvc;

namespace lapshop.Areas.admin.Controllers
{
    [Area("admin")]
    public class PageSettingController : Controller
    {
        ISetting Osetting;
        public PageSettingController(ISetting setting) {
        
            Osetting = setting;
        
        }

        public IActionResult SettingList() { 
        
      
        return View(Osetting.getAll().FirstOrDefault());
        }

        public IActionResult SettingForm()
        {
            var setting = Osetting.getAll().FirstOrDefault();

            return View(setting);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditSetting(TbSetting Setting) {

            if (!ModelState.IsValid)
            { return View("SettingForm",Setting ); }


        
            Osetting.save(Setting);


            return RedirectToAction("SettingList");
        }

      
            
    }
}


using lapshop.Areas.bl;
using lapshop.Models;
using lapshop.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace firstASP.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "AdMIN")]

    public class CategoryController : Controller
    {

        public CategoryController(iCategory category) { 
        
           ocategory = category;
        
        }

       iCategory ocategory;
        public IActionResult DashBord()
        {
            return View();
        }

        public IActionResult  List()
        {

            return View(ocategory.getAll());
        }

        public IActionResult New(int? Categoryid) {
            

            var category = new TbCategory();

            if (Categoryid != null) {

                ocategory.getById(Convert.ToInt32(Categoryid));

            }
          

            return View(category);
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult save(TbCategory category,IFormFile files) {
            

            if (!ModelState.IsValid)
            { return RedirectToAction("List");
            

            }

            category.ImageName =  clsHelper.UpldadFile(files);
         ocategory.save(category);



            return RedirectToAction("List",category);
        }

        

        public IActionResult Delete(int? Categoryid)
        {
            ocategory.delete(Convert.ToInt32(Categoryid));

            return RedirectToAction("List");
        }

        public IActionResult form()
        {
            return View();
        }

    }
}

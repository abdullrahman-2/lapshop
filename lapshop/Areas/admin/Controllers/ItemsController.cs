using lapshop.Areas.bl;
using lapshop.Models;
using lapshop.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace firstASP.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "AdMIN")]

    public class ItemsController : Controller

    {

        public ItemsController(iCategory category, ITems items,Iitemtype itemtype,Ios ios) {

            clsItems = items;
            ClsCategory = category;
            clsOs = ios;
            clsItemType = itemtype;



        }

        ITems clsItems;
        iCategory ClsCategory;
        Iitemtype clsItemType;
        Ios clsOs;
        
        public IActionResult listItems()
        {
            ViewBag.Categories = ClsCategory.getAll();

            var items =  clsItems.getAllData(null);
            
            return View(items);
        }

        public IActionResult search(int id)
        {
            ViewBag.Categories = ClsCategory.getAll();

            var items = clsItems.getAllData(id);

            return View("listItems", items);
        }

        public IActionResult EditItem(int? itemId) {
            var item =new TbItem();
            if (itemId != null)
            {  item = clsItems.getById(Convert.ToInt32(itemId)); }

            ViewBag.Categories = ClsCategory.getAll();
            ViewBag.ItemType = clsItemType.getAll();
            ViewBag.lstOs = clsOs.getAll();

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult save(TbItem item, IFormFile files)
        {
            ViewBag.Categories = ClsCategory.getAll();
            ViewBag.ItemType = clsItemType.getAll();
            ViewBag.lstOs = clsOs.getAll();
            if (!ModelState.IsValid)
            {
           
                return View("EditItem", item);
            }

            clsHelper.UpldadFile(files);
             string message;
            clsItems.save(item);



            return RedirectToAction("listItems");
        }

        public IActionResult Delete(int? Itemid)
        {
            clsItems.delete(Convert.ToInt32(Itemid));

            return RedirectToAction("listItems");
        }
    }
}

       



    
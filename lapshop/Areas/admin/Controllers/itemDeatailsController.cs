using lapshop.Areas.bl;
using lapshop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lapshop.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize]

    public class itemDeatailsController : Controller
    {
        ITems Oitem;

        public itemDeatailsController(ITems oitem) { 
        
            Oitem = oitem;
        
        }
        VmItemDetails itemDetails = new VmItemDetails();
        public IActionResult DetailsOfItemView(int itemId)
        {
             itemDetails.Items = Oitem.getVitemById(itemId);
            itemDetails.RelatedItems = Oitem.getRlatedItems(itemId);

           

            return View(itemDetails);
        }
    }
}

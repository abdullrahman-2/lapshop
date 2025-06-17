using lapshop.Areas.bl;
using lapshop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace lapshop.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize]
    public class OrderController : Controller
    {
        public OrderController(
            ITems item,
            ISalesInvoice salesInvoice,
            ISalesInvoiceItem salesInvoiceItem,
            UserManager<IdentityUser> userManager)
        {
            Oitems = item;
            OsalesInvoice = salesInvoice;
            OsalesInvoiceItem = salesInvoiceItem;
            _userManager = userManager;
        }

        private readonly ITems Oitems;
        private readonly ISalesInvoice OsalesInvoice;
        private readonly ISalesInvoiceItem OsalesInvoiceItem;
        private readonly UserManager<IdentityUser> _userManager;

        public IActionResult Cart()
        {
            string cookieCart = "";
            if (HttpContext.Request.Cookies["cart"] != null)
            {
                cookieCart = HttpContext.Request.Cookies["cart"];
            }

            var cartItem = JsonConvert.DeserializeObject<ShoppingCartItem>(cookieCart);
            return View(cartItem);
        }

        public IActionResult AddToCart(int itemId)
        {
            ShoppingCartItem cart;
            if (HttpContext.Request.Cookies["cart"] != null)
            {
                cart = JsonConvert.DeserializeObject<ShoppingCartItem>(HttpContext.Request.Cookies["cart"]);
            }
            else
            {
                cart = new ShoppingCartItem();
            }

            var items = Oitems.getById(itemId);

            var itemInList = cart.CartItems.FirstOrDefault(a => a.ItemId == itemId);
            if (itemInList != null)
            {
                itemInList.Qty++;
                itemInList.totalPice = itemInList.totalPice * itemInList.Qty;
            }
            else
            {
                cart.CartItems.Add(new ShoppingCart
                {
                    ItemId = items.ItemId,
                    ItemName = items.ItemName,
                    Price = items.SalesPrice,
                    Qty = 1,
                    totalPice = items.SalesPrice
                });
            }

            cart.total = cart.CartItems.Sum(a => a.totalPice);
            HttpContext.Response.Cookies.Append("cart", JsonConvert.SerializeObject(cart));
            return RedirectToAction("Cart");
        }

        public async Task<ActionResult> OrderSuccess()
        {
            ShoppingCartItem OshoppingCart = new ShoppingCartItem();
            if (HttpContext.Request.Cookies["cart"] != null)
            {
                OshoppingCart = JsonConvert.DeserializeObject<ShoppingCartItem>(HttpContext.Request.Cookies["cart"]);
            }

            await SaveOrder(OshoppingCart);
            return View();
        }

        public async Task<IActionResult> SaveOrder(ShoppingCartItem Ocart)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }

            TbSalesInvoice OmsalesInvoice = new TbSalesInvoice()
            {
                InvoiceDate = DateTime.Now,
                CustomerId = Guid.Parse(user.Id),
                DelivryDate = DateTime.Now.AddDays(5),
                CreatedBy = user.Id,
                CreatedDate = DateTime.Now,
                CurrentState = 1
            };

            List<TbSalesInvoiceItem> lstSalesInvoiceItems = new List<TbSalesInvoiceItem>();

            foreach (var item in Ocart.CartItems)
            {
                lstSalesInvoiceItems.Add(new TbSalesInvoiceItem()
                {
                    ItemId = item.ItemId,
                    Qty = item.Qty,
                    InvoicePrice = item.Price
                });
            }

            OsalesInvoice.save(OmsalesInvoice, lstSalesInvoiceItems, true);
            HttpContext.Response.Cookies.Delete("cart");

            return View("OrderSuccess");
        }
    }
}

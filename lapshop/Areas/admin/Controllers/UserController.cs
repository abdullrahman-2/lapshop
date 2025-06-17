using lapshop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace lapshop.Areas.admin.Controllers
{
    [Area("admin")]
    public class UserController : Controller
    {
        public UserController(UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager) {

            userManegerIdentiy = userManager;
            userSignINManegerIdentiy = signInManager;

        }

        UserManager<IdentityUser> userManegerIdentiy;
        SignInManager<IdentityUser> userSignINManegerIdentiy;

        UserModel model = new UserModel();
     
        
        public IActionResult Login(string ReturnUrl)

        {
            model.ReturnUrl = ReturnUrl;
            return View(model);
        }

        public async Task<IActionResult> LogOut()
        {

            await userSignINManegerIdentiy.SignOutAsync();


            return View("Login");
        }

        [HttpPost]
        public async Task<IActionResult> LoginAction(UserModel uModel, string ReturnUrl)
        {


            model.ReturnUrl = ReturnUrl;

            //if (!ModelState.IsValid)
            //{ return View("Login", model); }

            IdentityUser user = new IdentityUser()
            {
                Email = uModel.EmailAddress,
                UserName = uModel.EmailAddress


            };
            

            var result = await userSignINManegerIdentiy.PasswordSignInAsync(user.Email, uModel.Password, true, true);

            
           
                if (result.Succeeded) {

                if (string.IsNullOrEmpty(model.ReturnUrl))
                    
                    return Redirect("~/");
                else
                     return Redirect(model.ReturnUrl);
     
                }
 


            return View("Login");
        }




        public IActionResult Register()
        {

            return View(model);
        }

        [HttpPost]
        public async Task <IActionResult> RegisterAction(UserModel uModel)
        {
            IdentityUser user = new IdentityUser();


            if (!ModelState.IsValid)
            { return View("Register", model); }

            user.Email = uModel.FirstName;
            user.UserName = uModel.EmailAddress;

            var result = await userManegerIdentiy.CreateAsync(user, uModel.Password);

            try {
                if (result.Succeeded) {


                    await userManegerIdentiy.AddToRoleAsync(user, "Custmer");

                    return RedirectToAction("Login");

                }

                else { }

            }
            catch { }


            return View("Register");
        }
    }
}

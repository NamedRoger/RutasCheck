using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RutasCheck.Helpers;
using RutasCheck.Models.ViewModels;
using System.Threading.Tasks;

namespace RutasCheck.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IUserHelper _userHelper;
        public AccountController(IUserHelper userHelper)
        {
            _userHelper = userHelper;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login(string returnUrl = "")
        {
            ViewData["ReturnUrl"] = returnUrl;
            LoginModel loginModel = new LoginModel();
            return View(loginModel);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel login)
        {
            var findUser = _userHelper.FindByUserName(login.UserName.Trim().ToLower());
            if (findUser == null)
            {
                ModelState.AddModelError("UserName","No existe el Usuario");
            }
            else
            {
                var pass = Hash.GetSha256(login.Password.Trim());
                if (findUser.Password != pass)
                {
                    ModelState.AddModelError("Password", "El password no corresponde al Usuario");
                }
            }
           
            if (!ModelState.IsValid)
            {
                return View();

            }

            await _userHelper.SigInAsyc(this,findUser,login.Recordar);

            return RedirectToAction("Index","Home");
        }

        public IActionResult AccessDenied(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/account/login");
        } 

    }
}
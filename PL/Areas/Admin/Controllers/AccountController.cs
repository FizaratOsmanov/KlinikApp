using BL.DTOs;
using BL.Exceptions;
using BL.Services.Abstractions;
using CORE.Enums;
using Microsoft.AspNetCore.Mvc;

namespace PL.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class AccountController : Controller
    {

        private readonly IAccountService _service;
        public AccountController(IAccountService service)
        {
            _service = service;
        }


        public IActionResult Login()
        {
            if (User.Identity is not null && User.Identity.IsAuthenticated)
                return Redirect(User.IsInRole(RoleEnum.Admin.ToString()) ? "/admin" : "/");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginDTO dto, string? returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            try
            {
                await _service.LoginAsync(dto);
            }
            catch (BaseException ex)
            {
                ModelState.AddModelError("Error", ex.Message);
                return View(dto);
            }
            catch
            {
                ModelState.AddModelError("Error", "Error");
                return View(dto);
            }

            return Redirect(returnUrl ?? (User.IsInRole(RoleEnum.Admin.ToString()) ? "/admin" : "/"));
        }






        public IActionResult Register()
        {
            if (User.Identity is not null && User.Identity.IsAuthenticated)
                return Redirect(User.IsInRole(RoleEnum.Admin.ToString()) ? "/admin" : "/");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            try
            {
                await _service.RegisterAsync(dto);
            }
            catch (BaseException ex)
            {
                ModelState.AddModelError("Error", ex.Message);
                return View(dto);
            }
            catch
            {
                ModelState.AddModelError("Error", "Error");
                return View(dto);
            }

            return Redirect("/Admin/Account/Login");
        }

        public async Task<IActionResult> Logout()
        {
            try
            {
                await _service.LogoutAsync();
                return Redirect("/");
            }
            catch (BaseException ex)
            {
                return BadRequest();
            }
        }
    }
}

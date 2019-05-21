using Library.Application.Web.Common;
using Library.Application.Web.Views.Users;
using Library.Domain.Model;
using Library.Domain.Requests;
using Library.Domain.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Application.Web.Views.Account
{
    //[Authorize]
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationUserService _applicationUserService;

        public UsersController(UserManager<ApplicationUser> userManager, IMailService mailService)
        {
            _userManager = userManager;
            _applicationUserService = new ApplicationUserService(userManager, mailService);
        }

        [HttpGet]
        public IActionResult Index()
        {
            var applicationUsers = _userManager.Users.ToArray();
            var viewModel = new ListModel(applicationUsers);
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new CreateApplicationUserRequest();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateApplicationUserRequest viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            var baseUrl = Request.Scheme + "://" + Request.Host.Value;
            var callbackUrl = baseUrl + Url.Action("ConfirmEmail", "Account");
            var result = await _applicationUserService.CreateUser(viewModel, callbackUrl);            
            if (!result.Succeeded)
            {
                ModelState.AddModelError(result);
                return View(viewModel);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var applicationUser = await _userManager.FindByIdAsync(id);
            var viewModel = new EditApplicationUserModel(applicationUser);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditApplicationUserModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var result = await _applicationUserService.EditUser(viewModel.Request);
            if (!result.Succeeded)
            {
                ModelState.AddModelError(result);
                return View(viewModel);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var applicationUser = await _userManager.FindByIdAsync(id);
            var viewModel = new DeleteApplicationUserModel(applicationUser);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteApplicationUserModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var result = await _applicationUserService.DeleteUserById(viewModel.Id);
            if (!result.Succeeded)
            {
                ModelState.AddModelError(result);
                return View(viewModel);
            }

            return RedirectToAction("Index");
        }
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatColor.Models;
using WhatColor.ViewModels;

namespace WhatColor.Controllers
{
    //Authorization staat op controller niveau -> alles wat met users te maken heeft is beveiligd
    [Authorize(Roles = "admin")]
    public class UserController : Controller
    {
        public readonly UserManager<User> _userManager;
        public readonly RoleManager<IdentityRole> _roleManager;

        public UserController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Users()
        {
            UserViewModel viewModel = new UserViewModel()
            {
                Users = _userManager.Users.ToList()
            };
            return View(viewModel);
        }

        public IActionResult Details(string id)
        {
            User user = _userManager.Users.Where(u => u.Id == id).FirstOrDefault();
            if (user != null)
            {
                UserDetailsViewModel viewModel = new UserDetailsViewModel()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Country = user.Country,
                    Email = user.Email
                };
                return View(viewModel);
            }
            else
            {
                UserViewModel viewModel = new UserViewModel()
                {
                    Users = _userManager.Users.ToList()
                };
                return View("Users", viewModel);
            }
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateUserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    //Username word verkregen uit viewModel.Email aangezien een unieke Username de Identity breekt
                    UserName = viewModel.Email,
                    Email = viewModel.Email,
                    Country = viewModel.Country,
                };
                IdentityResult result = await _userManager.CreateAsync(user, viewModel.Password);
                if (result.Succeeded)
                    return RedirectToAction("Users");
                else
                {
                    foreach (IdentityError error in result.Errors)
                        ModelState.AddModelError("", error.Description);
                }
            }
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                    return RedirectToAction("Users");
                else
                    foreach (IdentityError error in result.Errors)
                        ModelState.AddModelError("", error.Description);
            }
            else
                ModelState.AddModelError("", "User not found");
            return View("Users", _userManager.Users.ToList());
        }

        public IActionResult GrantPermissions()
        {
            GrantPermissionsViewModel viewModel = new GrantPermissionsViewModel()
            {
                Users = new SelectList(_userManager.Users.ToList(), "Id", "UserName"),
                Roles = new SelectList(_roleManager.Roles.ToList(), "Id", "Name")
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GrantPermissions(GrantPermissionsViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(viewModel.UserID);
                IdentityRole role = await _roleManager.FindByIdAsync(viewModel.RoleID);
                if (user != null && role != null)
                {
                    IdentityResult result = await _userManager.AddToRoleAsync(user, role.Name);
                    if (result.Succeeded)
                        return RedirectToAction("Users");
                    else
                    {
                        foreach (IdentityError error in result.Errors)
                            ModelState.AddModelError("", error.Description);
                    }
                }
                else
                    ModelState.AddModelError("", "User or role not found");
            }
            return View(viewModel);
        }
    }
}
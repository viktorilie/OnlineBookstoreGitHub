﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using OnlineBookstore.Areas.Identity;
using Microsoft.AspNetCore.Identity;


namespace OnlineBookstore.Controllers
{

    [Authorize(Roles="admin")]
    public class UserController : Controller
    {

        private UserManager<IdentityUser> _userManager;
        private IPasswordHasher<IdentityUser> _passwordHasher;
        private RoleManager<IdentityRole> _roleManager;


        public UserController(UserManager<IdentityUser> userManager,
            IPasswordHasher<IdentityUser> passwordHasher, 
            RoleManager<IdentityRole> roleManager)

        {
            _userManager = userManager;
            _passwordHasher = passwordHasher;
            _roleManager = roleManager;
        }

        // GET: User
        public ActionResult Index()
        {
            return View(_userManager.Users);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        [HttpGet]
        public ActionResult Create()
        {
            var roles = _roleManager.Roles;
            var userModel = new UserModel();
            userModel.Roles = GetSelectListRoles(roles);
            return View(userModel);
        }


        [HttpPost]
        public async Task<IActionResult>Create(UserModel user)
        {
            if (ModelState.IsValid)
            {
                IdentityUser appUser = new IdentityUser
                {
                    UserName = user.Name,
                    Email = user.Email,
                    EmailConfirmed = true
                };


                //istoto sto i  gore
                //IdentityUser appUser = new IdentityUser();
                //appUser.UserName = user.Name;
                //appUser.Email = user.Email;
                //appUser.EmailConfirmed = true;


                IdentityResult result = await _userManager.CreateAsync(appUser, user.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(appUser, user.RoleName);
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                        ModelState.AddModelError("", error.Description);
                }

            }
            return View(user);
        }


        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            IdentityUser user = await _userManager.FindByIdAsync(id);
            var roles = _roleManager.Roles;
            if (user != null)
            {
                var getUserRole= await _userManager.GetRolesAsync(user);
                var userModel = new UserModel()
                {
                    Id = user.Id,
                    Email = user.Email,
                    Roles = GetSelectListRoles(roles)
                };
                return View(userModel);
            }
            else
                return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit (string id, string email, string password, string RoleName)
        {
            IdentityUser user = await _userManager.FindByIdAsync(id);
            if (User != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var GetUserOldRole = _roleManager.FindByNameAsync(userRoles[0]);

                if (!string.IsNullOrEmpty(email))
                    user.Email = email;
                else
                    ModelState.AddModelError("", "Email cannot be empty");

                if (!string.IsNullOrEmpty(password))
                    user.PasswordHash = _passwordHasher.HashPassword(user, password);
                else
                    ModelState.AddModelError("", "Password cannot be empty");

                if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
                {
                    IdentityResult result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        await _userManager.RemoveFromRoleAsync(user, GetUserOldRole.Result.Name);
                        await _userManager.AddToRoleAsync(user, RoleName);
                        return RedirectToAction("Index");
                    }
                    else
                        Errors(result);
                }
            }
            else
                ModelState.AddModelError("", "User Not Found");
            return View(user);
        }



        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }




        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        #region Helpers 
        private IQueryable<SelectListItem> GetSelectListRoles(IQueryable<IdentityRole> roles)
        {
            var selectList = new List<SelectListItem>();
            selectList.Add(new SelectListItem
            {
                Value = "0",
                Text = "Select role..."
            });

            foreach(var element in roles)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element.Id,
                    Text=element.Name

                });
            }
            return selectList.AsQueryable(); 
        }

        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }
        #endregion 


    }
}
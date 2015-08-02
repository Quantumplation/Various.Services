﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Website.Models;
using Website.ViewModels.Web;

namespace Website.Controllers.Web
{
    [RoutePrefix("Admin")]
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        public AdminController()
            : this(new DatabaseContext())
        {
        }

        public AdminController(DatabaseContext context)
            : this(new UserManager<User>(new UserStore<User>(context)))
        {
            DbContext = context;
        }

        public AdminController(UserManager<User> userManager)
        {
            UserManager = userManager;
        }

        public UserManager<User> UserManager { get; private set; }

        private DatabaseContext DbContext { get; set; }

        
        [Route("")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("AddRole")]
        public ActionResult AddRole()
        {
            return View();
        }

        [HttpPost, Route("AddRole")]
        public async Task<ActionResult> AddRole(AddRoleViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var user = UserManager.FindByName(vm.Username);
                if (user == null)
                {
                    ModelState.AddModelError("", "User not found");
                    return View();
                }
                var result = await UserManager.AddClaimAsync(user.Id, new Claim(ClaimTypes.Role, vm.Role));
                if (result.Succeeded)
                {
                    return View("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }
            }
            return View();
        }
    }
}
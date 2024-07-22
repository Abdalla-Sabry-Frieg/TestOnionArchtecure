using LearnCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace LearnCore.Controllers
{
    [Authorize(Roles =ClassRoles.roleAdmin)]
    public class RolesController : Controller
    {
        public RolesController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public async Task<IActionResult> Index()
        {
            var _users = await _userManager.Users.ToListAsync();
            return View("Index", _users); // =    return View(_users);
        }

        public async Task<IActionResult> addRoles (string userId)
        {
            // find userId and this user roles
            var user = await _userManager.FindByIdAsync(userId);
            var userRoles = await _userManager.GetRolesAsync(user);

            //find all Roles
            var allRoles = await _roleManager.Roles.ToListAsync();

            if (allRoles != null)
            {
                var roleList = allRoles.Select(x => new RoleViewModel()
                {
                    roleId = x.Id,
                    roleName = x.Name,
                    useRole = userRoles.Any(r => r == x.Name), // check userRole is found in userRoles list or not
                });
                ViewBag.userName = user.UserName; // viewbag to display user name 
                ViewBag.userId = user.Id;   // viewbag to display user Id and will reuseit in post method
                return View(roleList);  
            }
            else return NotFound();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> addRoles(string userId , string jsonRoles)
        {
            var user = await _userManager.FindByIdAsync(userId);

            List<RoleViewModel> myRoles = JsonConvert.DeserializeObject<List<RoleViewModel>>(jsonRoles);

            if (user != null)
            {
                var userRole = await _userManager.GetRolesAsync(user);

                foreach (var role in myRoles)
                {
                    if (userRole.Any(x => x == role.roleName) && !role.useRole)
                    {
                        await _userManager.RemoveFromRoleAsync(user, role.roleName);
                    }
                    if (!userRole.Any(x => x == role.roleName) && role.useRole)
                    {
                        await _userManager.AddToRoleAsync(user, role.roleName);
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            else
                return NotFound();
        }

    }
}

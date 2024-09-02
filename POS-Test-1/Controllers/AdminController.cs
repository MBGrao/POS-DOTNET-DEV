using Microsoft.AspNetCore.Mvc;
using POS_Test_1.Interfaces;
using POS_Test_1.Models;
using POS_Test_1.ViewModels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace POS_Test_1.Controllers
{
    [Authorize(Policy = "AdminOnly")]
    public class AdminController : Controller
    {
        private readonly IRoleRepository _roleRepository;

        public AdminController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        // GET: /Admin/Index
        public async Task<IActionResult> Index()
        {
            var roles = await _roleRepository.GetAllRolesAsync();
            return View(roles);
        }

        // GET: /Admin/EditRole/5
        public async Task<IActionResult> EditRole(int id)
        {
            var role = await _roleRepository.GetRoleByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            var viewModel = new RoleViewModel
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description
            };
            return View(viewModel);
        }

        // POST: /Admin/EditRole/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditRole(RoleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var role = new Role
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description
            };

            var result = await _roleRepository.UpdateRoleAsync(role);
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError("", "Unable to update role.");
            return View(model);
        }

        // GET: /Admin/CreateRole
        public IActionResult CreateRole()
        {
            return View();
        }

        // POST: /Admin/CreateRole
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRole(RoleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var role = new Role
            {
                Name = model.Name,
                Description = model.Description
            };

            var result = await _roleRepository.CreateRoleAsync(role);
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError("", "Unable to create role.");
            return View(model);
        }

        // POST: /Admin/DeleteRole/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var result = await _roleRepository.DeleteRoleAsync(id);
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError("", "Unable to delete role.");
            return RedirectToAction(nameof(Index));
        }
    }
}

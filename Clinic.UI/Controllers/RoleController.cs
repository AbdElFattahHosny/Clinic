using Clinic.Domain.Models;
using Clinic.Domain.ViewModels;
using Clinic.Services.UnitOfWorkInterface;
using Clinic.UI.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Clinic.UI.Controllers
{
    public class RoleController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public RoleController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            return View(await unitOfWork.Role.GetAll());
        }
        [HttpGet]
        public IActionResult Create()
        {          
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RoleViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Role newRole = new Role
                {
                    Name = vm.Name,
                    CreatedOn = DateTime.Now
                };
                unitOfWork.Role.Add(newRole);
                var result = await unitOfWork.Save();
                if (result > 0)
                {
                    return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", unitOfWork.Role.GetAll().Result) });
                }
                else
                {
                    return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Create", vm) });
                }
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Create", vm) });
        }


        [HttpGet]
        public async Task<IActionResult> Update(long id)
        {
            Role oldRole = await unitOfWork.Role.GetById(id);
            RoleViewModel vm = new RoleViewModel
            {
                Name = oldRole.Name,
            };
            ViewBag.Id = id;
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(byte id, RoleViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Role newRole = new Role
                {
                    Name = vm.Name,

                };
                unitOfWork.Role.Edit(id,newRole);
                var result = await unitOfWork.Save();
                if (result > 0)
                {
                    return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", unitOfWork.Role.GetAll().Result) });
                }
                else
                {
                    return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Update", vm) });
                }
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Update", vm) });
        }




        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            Role role = await unitOfWork.Role.GetById(id);
            unitOfWork.Role.Delete(role);
            var result = await unitOfWork.Save();
            if (result > 0)
            {
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", unitOfWork.Role.GetAll().Result) });
            }
            else
            {
                return RedirectToAction("Index");
            }

            //return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", await unitOfWork.User.GetAll()) });
        }


    }
}

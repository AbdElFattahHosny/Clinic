using Clinic.Domain.Models;
using Clinic.Domain.ViewModels;
using Clinic.Services.UnitOfWorkInterface;
using Clinic.UI.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Clinic.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            return View(await unitOfWork.User.GetAll());
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            UserViewModel vm = new UserViewModel
            {
                Roles = await unitOfWork.Role.GetAll()
            };

            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Create(UserViewModel vm)
        {
            if(ModelState.IsValid)
            {
                User newUser = new User
                {
                    UserName = vm.UserName,
                    RoleId = vm.RoleId,
                    Password = vm.Password,
                    CreatedOn = DateTime.Now
                };
                unitOfWork.User.Add(newUser);
                var result = await unitOfWork.Save();
                if (result > 0)
                {
                    return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", unitOfWork.User.GetAll().Result) });
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
            User oldUser = await unitOfWork.User.GetById(id);
            UserViewModel vm = new UserViewModel
            {
                UserName = oldUser.UserName,
                Password = oldUser.Password,
                RoleId = oldUser.RoleId,
                Roles = await unitOfWork.Role.GetAll()
            };
            ViewBag.Id = id;
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(long id,UserViewModel vm)
        {
            if (ModelState.IsValid)
            {
                User newUser = new User
                {
                    UserName = vm.UserName,
                    RoleId = vm.RoleId,
                    Password = vm.Password,
                    
                };
                unitOfWork.User.Edit(id,newUser);
                var result = await unitOfWork.Save();
                if (result > 0)
                {
                    return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", unitOfWork.User.GetAll().Result) });
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
            User user = await unitOfWork.User.GetById(id);
            unitOfWork.User.Delete(user);
            var result = await unitOfWork.Save();
            if (result > 0)
            {
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", unitOfWork.User.GetAll().Result) });
            }
            else
            {
                return RedirectToAction("Index");
            }

            //return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", await unitOfWork.User.GetAll()) });
        }

    }
}

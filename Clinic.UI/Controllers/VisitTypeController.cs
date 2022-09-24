using Clinic.Domain.Models;
using Clinic.Domain.ViewModels;
using Clinic.Services.UnitOfWorkInterface;
using Clinic.UI.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Clinic.UI.Controllers
{
    public class VisitTypeController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public VisitTypeController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            return View(await unitOfWork.VisitType.GetAll());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(VisitTypeViewModel vm)
        {
            if (ModelState.IsValid)
            {
                VisitType newVisitType = new VisitType
                {
                    TypeName = vm.TypeName,
                    CreatedOn = DateTime.Now
                };
                unitOfWork.VisitType.Add(newVisitType);
                var result = await unitOfWork.Save();
                if (result > 0)
                {
                    return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", unitOfWork.VisitType.GetAll().Result) });
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
            VisitType oldVisitType = await unitOfWork.VisitType.GetById(id);
            VisitTypeViewModel vm = new VisitTypeViewModel
            {
                TypeName = oldVisitType.TypeName,
            };
            ViewBag.Id = id;
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(long id, VisitTypeViewModel vm)
        {
            if (ModelState.IsValid)
            {
                VisitType newVisitType = new VisitType
                {
                    TypeName = vm.TypeName,

                };
                unitOfWork.VisitType.Edit(id,newVisitType);
                var result = await unitOfWork.Save();
                if (result > 0)
                {
                    return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", unitOfWork.VisitType.GetAll().Result) });
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
            VisitType visitType = await unitOfWork.VisitType.GetById(id);
            unitOfWork.VisitType.Delete(visitType);
            var result = await unitOfWork.Save();
            if (result > 0)
            {
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", unitOfWork.VisitType.GetAll().Result) });
            }
            else
            {
                return RedirectToAction("Index");
            }

            //return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", await unitOfWork.User.GetAll()) });
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalonAndSpaReservation.Domain.Abstract;
using SalonAndSpaReservation.Domain.Entities;

namespace SalonAndSpaReservation.WebUI.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        private IMaterialRepository repository;
        public AdminController(IMaterialRepository repo)
        {
            repository = repo;
        }
        // GET: Admin/Admin
        public ActionResult Index()
        {
            var model = repository.Materials;
            return View(model);
        }
        public ViewResult Add()
        {
            return View(new Material());
        }


        [HttpPost]
        public ActionResult Add(Material material)
        {
            if (ModelState.IsValid)
            {
                repository.SaveMaterial(material);
                TempData["message"] = string.Format("{0} has been saved", material.Name);
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(material);
            }
        }
         //[Authorize(Roles = "Administrator")]
        public ViewResult Edit(int id)
        {
            Material material = repository.Materials
            .FirstOrDefault(p => p.ID == id);
             return View(material);
        }


        [HttpPost]
        public ActionResult Edit(Material material)
        {
            if (ModelState.IsValid)
            {
                repository.SaveMaterial(material);
                TempData["message"] = string.Format("{0} has been saved", material.Name);
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(material);
            }
        }

        // GET: Admin/Admin/Delete/5
        //[Authorize(Roles = "Administrator")]
        public ActionResult Delete(int id)
        {
            Material material = repository.Materials
            .FirstOrDefault(p => p.ID == id);
            return View(material);
        }

        // POST: Admin/Admin/Delete/5
        [HttpPost]
        //[Authorize(Roles = "Administrator")]
        public ActionResult Delete(Material material)
        {
            Material deletedmaterial = repository.DeleteMaterial(material.ID);
            if (deletedmaterial != null)
            {
                TempData["message"] = string.Format("{0} was deleted",
                deletedmaterial.Name);
            }
            return RedirectToAction("Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalonAndSpaReservation.Domain.Abstract;
using SalonAndSpaReservation.Domain.Entities;

namespace SalonAndSpaReservation.WebUI.Areas.Admin.Controllers
{
    public class MaterialToServiceController : Controller
    {
        // GET: Admin/MaterialToService
        private IMaterialToServiceRepository repository;
        private IMaterialRepository _matrRepo;

        public MaterialToServiceController(IMaterialToServiceRepository repo, IMaterialRepository matrRepo)
        {
            repository = repo;
            _matrRepo = matrRepo;
        }
        public ActionResult Index()
        {
            var model = repository.MaterialsToServices;
            return View(model);
        }

        public ActionResult Details(int id = 1)
        {
            Material material = _matrRepo.GetMaterialById(id);
            if (material == null)
            {
                return HttpNotFound();
            }
            return View(material);
        }
        public ViewResult Add()
        {
            return View(new MaterialToService());
        }


        [HttpPost]
        public ActionResult Add(MaterialToService materialToService)
        {
            if (ModelState.IsValid)
            {
                repository.SaveMaterialToService(materialToService);
                //TempData["message"] = string.Format("{0} has been saved", materialToService.Name);
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(materialToService);
            }
        }
        // [Authorize(Roles = "Administrator")]
        public ViewResult Edit(int id)
        {
            MaterialToService materialToService = repository.MaterialsToServices
            .FirstOrDefault(p => p.ID == id);
            return View(materialToService);
        }


        [HttpPost]
        public ActionResult Edit(MaterialToService materialToService)
        {
            if (ModelState.IsValid)
            {
                repository.SaveMaterialToService(materialToService);
               // TempData["message"] = string.Format("{0} has been saved", materialToService.Name);
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(materialToService);
            }
        }

        // GET: Admin/Admin/Delete/5
        //[Authorize(Roles = "Administrator")]
        public ActionResult Delete(int id)
        {
            MaterialToService materialToService = repository.MaterialsToServices
            .FirstOrDefault(p => p.ID == id);
            return View(materialToService);
        }

        // POST: Admin/Admin/Delete/5
        [HttpPost]
        //[Authorize(Roles = "Administrator")]
        public ActionResult Delete(MaterialToService materialToService)
        {
            MaterialToService deletedmaterialToService = repository.DeleteMaterialToService(materialToService.ID);
            if (deletedmaterialToService != null)
            {
              //  TempData["message"] = string.Format("{0} was deleted",
              //  deletedmaterialToService.Name);
            }
            return RedirectToAction("Index");
        }
    }
}
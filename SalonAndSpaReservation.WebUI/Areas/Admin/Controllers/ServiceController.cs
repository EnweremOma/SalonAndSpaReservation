using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalonAndSpaReservation.Domain.Abstract;
using SalonAndSpaReservation.Domain.Entities;

namespace SalonAndSpaReservation.WebUI.Areas.Admin.Controllers
{
    public class ServiceController : Controller
    {
        private IServiceRepository repository;
        private IMaterialRepository _matRepo;
        private IMaterialToServiceRepository _matToRepo;
        public ServiceController(IServiceRepository repo, IMaterialRepository matRepo, IMaterialToServiceRepository matToRepo)
        {
            repository = repo;
            _matRepo = matRepo;
            _matToRepo = matToRepo;
        }
        public ActionResult Index()
        {
            var model = repository.Services;
            return View(model);
        }
        public ViewResult Add()
        {
            return View(new Service());
        }

        [HttpPost]
        public ActionResult Add(Service service)
        {
            if (ModelState.IsValid)
            {
                repository.SaveServices(service);
                TempData["message"] = string.Format("{0} has been saved", service.Name);
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(service);
            }
        }

        public ViewResult Edit(int id)
        {
            Service service = repository.Services
            .FirstOrDefault(p => p.ID == id);
            return View(service);
        }

        [HttpPost]
        public ActionResult Edit(Service service)
        {
            if (ModelState.IsValid)
            {
                repository.SaveServices(service);
                TempData["message"] = string.Format("{0} has been saved", service.Name);
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(service);
            }
        }

        
        //[Authorize(Roles = "Administrator")]
        public ActionResult Delete(int id)
        {
            Service service = repository.Services
            .FirstOrDefault(p => p.ID == id);
            return View(service);
        }


        [HttpPost]
        //[Authorize(Roles = "Administrator")]
        public ActionResult Delete(Service service)
        {
            Service deletedservice = repository.DeleteServices(service.ID);
            if (deletedservice != null)
            {
                TempData["message"] = string.Format("{0} was deleted",
                deletedservice.Name);
            }
            return RedirectToAction("Index");
        }

        public ActionResult AddMaterial(int id)
        {
            IEnumerable<Material> mat = _matRepo.Materials;
            var matList = new List<SelectListItem>();
            foreach (Material item in mat)
            {
                matList.Add(new SelectListItem { Value = item.ID.ToString(), Text = item.Name });
            }
            ViewBag.materialList = matList;

            Service service = repository.GetServiceById(id);
            return View(new MaterialToService { ServiceID=service.ID});
        }

        [HttpPost]
        public ActionResult AddMaterial(MaterialToService materialToService) 
        {
            if (ModelState.IsValid)
            {
                _matToRepo.SaveMaterialToService(materialToService);
                TempData["message"] = string.Format("material has been saved");
                return RedirectToAction("Index", "Service");
            }
            return View(materialToService);
        }

        public ViewResult ViewMaterial(int id)
        {
            Service service = repository.GetServiceById(id);
            return View(service);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web_app_asp_net_mvc_code_first.Models;
using web_app_asp_net_mvc_code_first.Models.Entities;

namespace web_app_asp_net_mvc_code_first.Controllers
{
    public class ErrorTypesController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var db = new ErrorLogContext();
            var errorTypes = db.ErrorTypes.ToList();

            return View(errorTypes);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var errorTypes = new ErrorType();
            return View(errorTypes);
        }

        [HttpPost]
        public ActionResult Create(ErrorType model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var db = new ErrorLogContext();

            db.ErrorTypes.Add(model);
            db.SaveChanges();

            return RedirectPermanent("/ErrorTypes/Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var db = new ErrorLogContext();
            var errorTypes = db.ErrorTypes.FirstOrDefault(x => x.Id == id);
            if (errorTypes == null)
                return RedirectPermanent("/ErrorTypes/Index");

            db.ErrorTypes.Remove(errorTypes);
            db.SaveChanges();

            return RedirectPermanent("/ErrorTypes/Index");
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var db = new ErrorLogContext();
            var errorTypes = db.ErrorTypes.FirstOrDefault(x => x.Id == id);
            if (errorTypes == null)
                return RedirectPermanent("/ErrorTypes/Index");

            return View(errorTypes);
        }

        [HttpPost]
        public ActionResult Edit(ErrorType model)
        {
            var db = new ErrorLogContext();
            var errorTypes = db.ErrorTypes.FirstOrDefault(x => x.Id == model.Id);
            if (errorTypes == null)
                ModelState.AddModelError("Id", "ошибка не найдена");

            if (!ModelState.IsValid)
                return View(model);

            MappingSolution(model, errorTypes);

            db.Entry(errorTypes).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectPermanent("/ErrorTypes/Index");
        }

        private void MappingSolution(ErrorType sourse, ErrorType destination)
        {
            destination.Type = sourse.Type;
        }
    }
}
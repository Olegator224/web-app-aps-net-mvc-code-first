using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web_app_asp_net_mvc_code_first.Models;
using web_app_asp_net_mvc_code_first.Models.Entities;

namespace web_app_asp_net_mvc_code_first.Controllers
{
    public class ErrorsController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var db = new ErrorLogContext();
            var errors = db.Errors.ToList();

            return View(errors);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var error = new Error();
            return View(error);
        }

        [HttpPost]
        public ActionResult Create(Error model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var db = new ErrorLogContext();
            model.Date = DateTime.Now;

            if (model.ErrorImageFile != null)
            {
                var data = new byte[model.ErrorImageFile.ContentLength];
                model.ErrorImageFile.InputStream.Read(data, 0, model.ErrorImageFile.ContentLength);

                model.ErrorImage = new ErrorImage()
                {
                    Guid = Guid.NewGuid(),
                    DateChanged = DateTime.Now,
                    Data = data,
                    ContentType = model.ErrorImageFile.ContentType,
                    FileName = model.ErrorImageFile.FileName
                };
            }

            if (model.ErrorTypeIds != null && model.ErrorTypeIds.Any())
            {
                var errorType = db.ErrorTypes.Where(s => model.ErrorTypeIds.Contains(s.Id)).ToList();
                model.ErrorTypes = errorType;
            }

            db.Errors.Add(model);
            db.SaveChanges();

            return RedirectPermanent("/Errors/Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var db = new ErrorLogContext();
            var error = db.Errors.FirstOrDefault(x => x.Id == id);
            if (error == null)
                return RedirectPermanent("/Errrors/Index");

            db.Errors.Remove(error);
            db.SaveChanges();

            return RedirectPermanent("/Errors/Index");
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var db = new ErrorLogContext();
            var error = db.Errors.FirstOrDefault(x => x.Id == id);
            if (error == null)
                return RedirectPermanent("/Errors/Index");

            return View(error);
        }

        [HttpPost]
        public ActionResult Edit(Error model)
        {
            var db = new ErrorLogContext();
            var error = db.Errors.FirstOrDefault(x => x.Id == model.Id);
            if (error == null)
                ModelState.AddModelError("Id", "Ошибка не найдена");

            if (!ModelState.IsValid)
                return View(model);

            MappingError(model, error, db);

            db.Entry(error).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectPermanent("/Errors/Index");
        }

        private void MappingError(Error sourse, Error destination, ErrorLogContext db)
        {
            destination.Description = sourse.Description;
            destination.Code = sourse.Code;
            destination.UserId = sourse.UserId;
            destination.User = sourse.User;




            if (destination.ErrorTypes != null)
                destination.ErrorTypes.Clear();

            if (sourse.ErrorTypeIds != null && sourse.ErrorTypeIds.Any())
                destination.ErrorTypes = db.ErrorTypes.Where(s => sourse.ErrorTypeIds.Contains(s.Id)).ToList();



            if (sourse.ErrorImageFile != null)
            {
                var image = db.ErrorImage.FirstOrDefault(x => x.Id == sourse.Id);
                db.ErrorImage.Remove(image);

                var data = new byte[sourse.ErrorImageFile.ContentLength];
                sourse.ErrorImageFile.InputStream.Read(data, 0, sourse.ErrorImageFile.ContentLength);

                destination.ErrorImage = new ErrorImage()
                {
                    Guid = Guid.NewGuid(),
                    DateChanged = DateTime.Now,
                    Data = data,
                    ContentType = sourse.ErrorImageFile.ContentType,
                    FileName = sourse.ErrorImageFile.FileName
                };
            }
        }

        [HttpGet]
        public ActionResult GetImage(int id)
        {
            var db = new ErrorLogContext();
            var image = db.ErrorImage.FirstOrDefault(x => x.Id == id);
            if (image == null)
            {
                FileStream fs = System.IO.File.OpenRead(Server.MapPath(@"~/Content/not-foto.png"));
                byte[] fileData = new byte[fs.Length];
                fs.Read(fileData, 0, (int)fs.Length);
                fs.Close();

                return File(new MemoryStream(fileData), "image/jpeg");
            }

            return File(new MemoryStream(image.Data), image.ContentType);
        }
    }
}
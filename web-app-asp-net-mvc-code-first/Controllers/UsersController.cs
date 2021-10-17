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
    public class UsersController : Controller
    {
       
            [HttpGet]
            public ActionResult Index()
            {
                var db = new ErrorLogContext();
                var users = db.Users.ToList();

                return View(users);
            }

            [HttpGet]
            public ActionResult Create()
            {
                var user = new User();
                return View(user);
            }

            [HttpPost]
            public ActionResult Create(User model)
            {
                if (!ModelState.IsValid)
                    return View(model);

                var db = new ErrorLogContext();

                db.Users.Add(model);
                db.SaveChanges();

                return RedirectPermanent("/Users/Index");
            }

            [HttpGet]
            public ActionResult Delete(int id)
            {
                var db = new ErrorLogContext();
                var user = db.Users.FirstOrDefault(x => x.Id == id);
                if (user == null)
                    return RedirectPermanent("/Users/Index");

                db.Users.Remove(user);
                db.SaveChanges();

                return RedirectPermanent("/Users/Index");
            }


            [HttpGet]
            public ActionResult Edit(int id)
            {
                var db = new ErrorLogContext();
                var user = db.Users.FirstOrDefault(x => x.Id == id);
                if (user == null)
                    return RedirectPermanent("/Users/Index");

                return View(user);
            }

            [HttpPost]
            public ActionResult Edit(User model)
            {
                var db = new ErrorLogContext();
                var user = db.Users.FirstOrDefault(x => x.Id == model.Id);
                if (user == null)
                    ModelState.AddModelError("Id", "Жанр не найден");

                if (!ModelState.IsValid)
                    return View(model);

                MappingUser(model, user);

                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectPermanent("/Users/Index");
            }

            private void MappingUser(User sourse, User destination)
            {
                destination.Name = sourse.Name;
                destination.Gender = sourse.Gender;
        }
        }
    }
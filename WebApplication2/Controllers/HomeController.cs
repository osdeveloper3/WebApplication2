using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        Database1Entities db = new Database1Entities();

        // GET: Home
        public ActionResult Index()
        {
            return View(db.user_table.ToList());
        }


        public ActionResult Popup()
        {
            ViewBag.action = "AddUser";
            ViewBag.btntext = "Add";
            return View();
        }

        [HttpPost]
        public string AddUser(user_table user)
        {
            string data;
            if (ModelState.IsValid)
            {
                var check = db.user_table.Select(x=>x.user_name == user.user_name).FirstOrDefault();
                if(!check) {
                    db.user_table.Add(user);
                    db.SaveChanges();                
                    return data = "1";
                }
                else {
                    return data = user.user_name;
                }
            }
            return data = "0";
        }


        public ActionResult Edit(int id)
        {
            ViewBag.action = "EditUser";
            ViewBag.btntext = "Edit";
            ViewBag.id = id;
            return View("Popup",db.user_table.Find(id));
        }


        [HttpPost]
        public string EditUser(user_table user)
        {
            string data;
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return data = "1";
            }
            return data = "0";
        }


        public ActionResult Details(int id)
        {
            return View("Popup", db.user_table.Find(id));
        }


        public int Delete(int id)
        {
            var row = db.user_table.Find(id);
            db.user_table.Remove(row);
            db.SaveChanges();
            return 1;
        }


    }
}
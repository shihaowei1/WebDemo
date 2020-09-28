using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LoginTest.Models;


namespace LoginTest.Controllers
{

    public class LoginDBsController : Controller
    {
        private LoginDBContext db = new LoginDBContext();

      

        // GET: LoginDBs
        public ActionResult Index()
        {
            return View(db.Others.ToList());
        }

        [HttpPost]
        public ActionResult Login(string name, string passwd)
        {
            if(name == "shw" && passwd == "123")
                return View("success");
            return View("Error");
        }

        // GET: LoginDBs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoginDB loginDB = db.Others.Find(id);
            if (loginDB == null)
            {
                return HttpNotFound();
            }
            return View(loginDB);
        }

        // GET: LoginDBs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoginDBs/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,passwd")] LoginDB loginDB)
        {
            if (ModelState.IsValid)
            {
                db.Others.Add(loginDB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loginDB);
        }

        // GET: LoginDBs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoginDB loginDB = db.Others.Find(id);
            if (loginDB == null)
            {
                return HttpNotFound();
            }
            return View(loginDB);
        }

        // POST: LoginDBs/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,passwd")] LoginDB loginDB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loginDB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loginDB);
        }

        // GET: LoginDBs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoginDB loginDB = db.Others.Find(id);
            if (loginDB == null)
            {
                return HttpNotFound();
            }
            return View(loginDB);
        }

        // POST: LoginDBs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoginDB loginDB = db.Others.Find(id);
            db.Others.Remove(loginDB);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }

}

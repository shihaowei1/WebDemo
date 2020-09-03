﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcDemo.Models;

namespace MvcDemo.Controllers
{
    public class MovieDBsController : Controller
    {
        private MovieDBContext db = new MovieDBContext();

        // GET: MovieDBs
        public ActionResult Index()
        {
            return View(db.Movies.ToList());
        }

        // GET: MovieDBs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieDB movieDB = db.Movies.Find(id);
            if (movieDB == null)
            {
                return HttpNotFound();
            }
            return View(movieDB);
        }

        // GET: MovieDBs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MovieDBs/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Director,Date")] MovieDB movieDB)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movieDB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movieDB);
        }

        // GET: MovieDBs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieDB movieDB = db.Movies.Find(id);
            if (movieDB == null)
            {
                return HttpNotFound();
            }
            return View(movieDB);
        }

        // POST: MovieDBs/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Director,Date")] MovieDB movieDB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movieDB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movieDB);
        }

        // GET: MovieDBs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieDB movieDB = db.Movies.Find(id);
            if (movieDB == null)
            {
                return HttpNotFound();
            }
            return View(movieDB);
        }

        // POST: MovieDBs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MovieDB movieDB = db.Movies.Find(id);
            db.Movies.Remove(movieDB);
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

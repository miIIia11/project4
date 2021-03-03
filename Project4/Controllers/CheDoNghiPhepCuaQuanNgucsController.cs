using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project4.Models;

namespace Project4.Controllers 
{
    public class CheDoNghiPhepCuaQuanNgucsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CheDoNghiPhepCuaQuanNgucs
        public ActionResult Index()
        {
            var khuList = db.Khu.ToList();
            ViewBag.KhuQuanLi = new SelectList(khuList, "ID", "ID"); 
            return View(db.CheDoNghiPhepCuaQuanNguc.ToList());
        }

        // GET: CheDoNghiPhepCuaQuanNgucs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheDoNghiPhepCuaQuanNguc cheDoNghiPhepCuaQuanNguc = db.CheDoNghiPhepCuaQuanNguc.Find(id);
            if (cheDoNghiPhepCuaQuanNguc == null)
            {
                return HttpNotFound();
            }
            return View(cheDoNghiPhepCuaQuanNguc);
        }

        // GET: CheDoNghiPhepCuaQuanNgucs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CheDoNghiPhepCuaQuanNgucs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,QuanNgucID,SoNgayNghi,LyDoNghi")] CheDoNghiPhepCuaQuanNguc cheDoNghiPhepCuaQuanNguc)
        {
            if (ModelState.IsValid)
            {
                db.CheDoNghiPhepCuaQuanNguc.Add(cheDoNghiPhepCuaQuanNguc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cheDoNghiPhepCuaQuanNguc);
        }

        // GET: CheDoNghiPhepCuaQuanNgucs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheDoNghiPhepCuaQuanNguc cheDoNghiPhepCuaQuanNguc = db.CheDoNghiPhepCuaQuanNguc.Find(id);
            if (cheDoNghiPhepCuaQuanNguc == null)
            {
                return HttpNotFound();
            }
            return View(cheDoNghiPhepCuaQuanNguc);
        }

        // POST: CheDoNghiPhepCuaQuanNgucs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,QuanNgucID,SoNgayNghi,LyDoNghi")] CheDoNghiPhepCuaQuanNguc cheDoNghiPhepCuaQuanNguc)
        {
            if (ModelState.IsValid) 
            {
                db.Entry(cheDoNghiPhepCuaQuanNguc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cheDoNghiPhepCuaQuanNguc);
        }

        // GET: CheDoNghiPhepCuaQuanNgucs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheDoNghiPhepCuaQuanNguc cheDoNghiPhepCuaQuanNguc = db.CheDoNghiPhepCuaQuanNguc.Find(id);
            if (cheDoNghiPhepCuaQuanNguc == null)
            {
                return HttpNotFound();
            }
            return View(cheDoNghiPhepCuaQuanNguc);
        }

        // POST: CheDoNghiPhepCuaQuanNgucs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CheDoNghiPhepCuaQuanNguc cheDoNghiPhepCuaQuanNguc = db.CheDoNghiPhepCuaQuanNguc.Find(id);
            db.CheDoNghiPhepCuaQuanNguc.Remove(cheDoNghiPhepCuaQuanNguc);
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Project4.Models;

namespace Project4.Controllers
{
    public class LaoDongCongIchesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LaoDongCongIches 
        public ActionResult Index(string tenPhamNhan, int? i)
        {
<<<<<<< HEAD
            if (User.Identity.GetQuanNgucId() == "")
            {
                return RedirectToAction("DangNhap", "TaiKhoan");
            }
            return View(db.LaoDongCongIch.ToList());
=======
            if (string.IsNullOrEmpty(tenPhamNhan)) tenPhamNhan = "";
            var laodongCaitaoList = from l in db.LaoDongCongIch
                                    join p in db.PhamNhan
                                           on l.PhamNhanID equals p.ID
                                    join q in db.QuanNguc
                                           on l.QuanNgucID equals q.ID
                                    where p.TenPhamNhan.Contains(tenPhamNhan)
                                    select new LaoDongCongIchesParam
                                    {
                                        ID = l.ID,
                                        PhamNhanID = p.TenPhamNhan,
                                        QuanNgucID = q.TenQuanNguc,
                                        KhuVucLamViec = l.KhuVucLamViec,
                                        BieuHien = l.BieuHien
                                    };
            int pageSize = 5;  
            int pageNumber = (i ?? 1); 
            return View(laodongCaitaoList.OrderBy(l => l.PhamNhanID)
                        .ToPagedList(pageNumber, pageSize));
>>>>>>> 1439f1cc4c1ae0c0eac42faa59d45066190de158
        }

        // GET: LaoDongCongIches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LaoDongCongIch laoDongCongIch = db.LaoDongCongIch.Find(id);
            if (laoDongCongIch == null)
            {
                return HttpNotFound();
            }
            return View(laoDongCongIch);
        }

        // GET: LaoDongCongIches/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LaoDongCongIches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PhamNhanID,QuanNgucID,KhuVucLamViec,BieuHien")] LaoDongCongIch laoDongCongIch)
        {
            if (ModelState.IsValid)
            {
                db.LaoDongCongIch.Add(laoDongCongIch);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(laoDongCongIch);
        }

        // GET: LaoDongCongIches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LaoDongCongIch laoDongCongIch = db.LaoDongCongIch.Find(id);
            if (laoDongCongIch == null)
            {
                return HttpNotFound();
            }
            return View(laoDongCongIch);
        }

        // POST: LaoDongCongIches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PhamNhanID,QuanNgucID,KhuVucLamViec,BieuHien")] LaoDongCongIch laoDongCongIch)
        {
            if (ModelState.IsValid)
            {
                db.Entry(laoDongCongIch).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(laoDongCongIch);
        }

        // GET: LaoDongCongIches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LaoDongCongIch laoDongCongIch = db.LaoDongCongIch.Find(id);
            if (laoDongCongIch == null)
            {
                return HttpNotFound();
            }
            return View(laoDongCongIch);
        }

        // POST: LaoDongCongIches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LaoDongCongIch laoDongCongIch = db.LaoDongCongIch.Find(id);
            db.LaoDongCongIch.Remove(laoDongCongIch);
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

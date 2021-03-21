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
    public class BenhsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Benhs
        public ActionResult Index() 
        {
            if (User.Identity.GetQuanNgucId() == "")
            {
                return RedirectToAction("DangNhap", "TaiKhoan");
            }
            return View(db.Benh.ToList());
        }

        // GET: Benhs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Benh benh = db.Benh.Find(id);
            if (benh == null)
            {
                return HttpNotFound(); 
            }
            return View(benh);
        }

        // GET: Benhs/Create
        public ActionResult Create()
        {
            if (User.IsInRole("QuanNgucTruong"))
            {
                var allPhamNhan = db.PhamNhan;
                var allBenh = db.Benh;
                foreach (var item in allPhamNhan)
                {
                    var biBenh = db.Benh.Where(w => w.PhamNhanID == item.ID);
                    if (biBenh != null && biBenh.Where(w => DbFunctions.DiffDays(DateTime.Now, w.NgayBatDauChuaTri) <= w.NgayChuaTri).Any())
                    {
                        allPhamNhan.Remove(item);
                    }
                }
                ViewBag.PhamNhanID = new SelectList(allPhamNhan, "ID", "TenPhamNhan", null);
            }
            else
            {
                var quanNgucHienTai = db.QuanNguc.Find(Guid.Parse(User.Identity.GetQuanNgucId()));
                var phongPhamNhan = db.PhongGiam.Where(w => w.KhuID == quanNgucHienTai.KhuID).Select(s => s.ID);
                var phamNhan = db.PhamNhan.Where(w => phongPhamNhan.Contains(w.PhongGiamID)).ToList();
                List<PhamNhan> phamNhanRemove = new List<PhamNhan>();
                foreach (var item in phamNhan)
                {
                    var biBenh = db.Benh.Where(w => w.PhamNhanID == item.ID);
                    if (biBenh != null && biBenh.Where(w => DbFunctions.DiffDays(DateTime.Now, w.NgayBatDauChuaTri) <= w.NgayChuaTri).Any())
                    {
                        phamNhanRemove.Add(item);
                    }
                }
                foreach (var item in phamNhanRemove)
                {
                    phamNhan.Remove(item);
                }
                ViewBag.PhamNhanID = new SelectList(phamNhan, "ID", "TenPhamNhan", null);
            }
            if (ViewBag.PhamNhanID == null)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        // POST: Benhs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PhamNhanID,NgayChuaTri")] Benh benh)
        {
            if (ModelState.IsValid)
            {
                benh.NgayBatDauChuaTri = DateTime.Now.AddDays(1);
                db.Benh.Add(benh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(benh);
        }

        // GET: Benhs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Benh benh = db.Benh.Find(id);
            if (benh == null)
            {
                return HttpNotFound();
            }
            ViewBag.PhamNhanID = new SelectList(db.PhamNhan, "ID", "TenPhamNhan", benh.PhamNhanID);
            return View(benh);
        }

        // POST: Benhs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PhamNhanID,NgayChuaTri")] Benh benh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(benh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(benh);
        }

        // GET: Benhs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Benh benh = db.Benh.Find(id);
            if (benh == null)
            {
                return HttpNotFound();
            }
            return View(benh);
        }

        // POST: Benhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Benh benh = db.Benh.Find(id);
            db.Benh.Remove(benh);
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

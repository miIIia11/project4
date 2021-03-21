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

            if (User.Identity.GetQuanNgucId() == "")
            {
                return RedirectToAction("DangNhap", "TaiKhoan");
            }
            //return View(db.LaoDongCongIch.ToList());
            IQueryable<LaoDongCongIchesParam> laodongCaitaoList = null;
            if (User.IsInRole("QuanNgucTruong"))
            {
                if (string.IsNullOrEmpty(tenPhamNhan)) tenPhamNhan = "";
                laodongCaitaoList = from l in db.LaoDongCongIch
                                        join p in db.PhamNhan
                                               on l.PhamNhanID equals p.ID
                                        join q in db.QuanNguc
                                               on l.QuanNgucID equals q.ID
                                        where p.TenPhamNhan.Contains(tenPhamNhan)
                                        select new LaoDongCongIchesParam
                                        {
                                            ID = l.ID,
                                            PhamNhanID = p.ID,
                                            TenPhamNhan = p.TenPhamNhan,
                                            QuanNgucID = q.TenQuanNguc,
                                            KhuVucLamViec = l.KhuVucLamViec,
                                            BieuHien = l.BieuHien
                                        };
            }
            else
            {
                var quanNgucHienTai = db.QuanNguc.Find(Guid.Parse(User.Identity.GetQuanNgucId()));
                if (string.IsNullOrEmpty(tenPhamNhan)) tenPhamNhan = "";
                laodongCaitaoList = from l in db.LaoDongCongIch
                                        join p in db.PhamNhan
                                               on l.PhamNhanID equals p.ID
                                        join q in db.QuanNguc
                                               on l.QuanNgucID equals q.ID
                                        where p.TenPhamNhan.Contains(tenPhamNhan) && q.KhuID == quanNgucHienTai.KhuID
                                        select new LaoDongCongIchesParam
                                        {
                                            ID = l.ID,
                                            PhamNhanID = p.ID,
                                            TenPhamNhan = p.TenPhamNhan,
                                            QuanNgucID = q.TenQuanNguc,
                                            KhuVucLamViec = l.KhuVucLamViec,
                                            BieuHien = l.BieuHien
                                        };
            }

            var model = laodongCaitaoList.ToList();
            foreach (var item in model)
            {
                var benhNhanBiBenh = db.Benh.Where(w => w.PhamNhanID == item.PhamNhanID && DbFunctions.DiffDays(DateTime.Now, w.NgayBatDauChuaTri) <= w.NgayChuaTri);
                if (benhNhanBiBenh.Any())
                {
                    item.DangBiBenh = true;
                }
                else
                {
                    item.DangBiBenh = false;
                }
            }
            int pageSize = 5;  
            int pageNumber = (i ?? 1); 
            return View(model.OrderBy(l => l.PhamNhanID)
                        .ToPagedList(pageNumber, pageSize));

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
            //var allPhamNhan = from a in db.PhamNhan
            //                  join b in db.Benh on a.ID equals b.PhamNhanID
            //                  where DbFunctions.DiffDays(DateTime.Now, b.NgayBatDauChuaTri) <= b.NgayChuaTri
            //                  select new PhamNhan
            //                  {
            //                      ID = a.ID,
            //                      TenPhamNhan = a.TenPhamNhan
            //                  };
            var allPhamNhan = db.PhamNhan.ToList();
            if (!User.IsInRole("QuanNgucTruong"))
            {
                var quanNgucHienTai = db.QuanNguc.Find(Guid.Parse(User.Identity.GetQuanNgucId()));
                allPhamNhan = allPhamNhan.Where(w => w.IDKhu == quanNgucHienTai.KhuID).ToList();
            }
            var allBenh = db.Benh;
            List<PhamNhan> phamNhanBiBenh = new List<PhamNhan>();
            foreach (var item in allPhamNhan)
            {
                var biBenh = db.Benh.Where(w => w.PhamNhanID == item.ID);
                if (biBenh != null && biBenh.Where(w => DbFunctions.DiffDays(DateTime.Now, w.NgayBatDauChuaTri) <= w.NgayChuaTri).Any())
                {
                    phamNhanBiBenh.Add(item);
                }
            }
            if (phamNhanBiBenh != null)
            {
                foreach (var item in phamNhanBiBenh)
                {
                    allPhamNhan.Remove(item);
                }
            }
            ViewBag.PhamNhanID = new SelectList(allPhamNhan, "ID", "TenPhamNhan", null);
            return View();
        }

        // POST: LaoDongCongIches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PhamNhanID,KhuVucLamViec,BieuHien")] LaoDongCongIch laoDongCongIch)
        {
            if (ModelState.IsValid)
            {
                var khucuaphamNhan = db.PhamNhan.Find(laoDongCongIch.PhamNhanID).IDKhu;
                var khuID = db.Khu.FirstOrDefault(f => f.ID == khucuaphamNhan).ID;
                laoDongCongIch.QuanNgucID = db.QuanNguc.FirstOrDefault(f => f.KhuID == khuID).ID;
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
            if (db.Benh.Where(w => w.PhamNhanID == laoDongCongIch.PhamNhanID && DbFunctions.DiffDays(DateTime.Now, w.NgayBatDauChuaTri) <= w.NgayChuaTri).Any())
            {
                return RedirectToAction("Index","LaoDongCongIches");
            }
            return View(laoDongCongIch);
        }

        // POST: LaoDongCongIches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PhamNhanID,KhuVucLamViec,BieuHien")] LaoDongCongIch laoDongCongIch)
        {
            if (ModelState.IsValid)
            {
                var khucuaphamNhan = db.PhamNhan.Find(laoDongCongIch.PhamNhanID).IDKhu;
                var khuID = db.Khu.FirstOrDefault(f => f.ID == khucuaphamNhan).ID;
                laoDongCongIch.QuanNgucID = db.QuanNguc.FirstOrDefault(f => f.KhuID == khuID).ID;
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

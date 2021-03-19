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
    public class PhamNhansController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PhamNhans oh yes
        public ActionResult Index()      
        {
            if (User.Identity.GetQuanNgucId() == "")
            {
                return RedirectToAction("DangNhap", "TaiKhoan");
            }
            var khu = db.Khu.ToList();
            if (khu != null)
            {
                ViewBag.Khu = khu;

                var khu1 = khu.Select(s => s.ID).FirstOrDefault();

                ViewBag.Phong = db.PhongGiam.Where(w => w.KhuID == khu1).ToList();
            }
            else
            {
                
            }

            ViewBag.ToiDanh = Common.CommonConstant.toiDanh;
            ViewBag.MucDoNguyHiem = Common.CommonConstant.mucDoNguyHiem;

            return View(db.PhamNhan.ToList());
        } 

        public ActionResult ThanhTimKiem(string khuID)
        {
            ViewBag.Khu = db.Khu.ToList();
            ViewBag.SelectedKhu = khuID;
            int idKhu = int.Parse(khuID);
            ViewBag.Phong = db.PhongGiam.Where(w => w.KhuID == idKhu).ToList();

            return PartialView("_PhamNhansSearchBar");
        }

        public ActionResult TimKiem(string txtTenHoacMa, string khuID, string phongID)
        {
            IQueryable<PhamNhan> listPhamNhan = db.PhamNhan;
            if (txtTenHoacMa.Length == 5)
            {
                //listPhamNhan = db.PhamNhan.Where(w => w. == txtTenOrMa);
            }
            else
            {
                listPhamNhan = listPhamNhan.Where(w => w.TenPhamNhan.Contains(txtTenHoacMa));
            }
            var IDkhu = int.Parse(khuID);
            listPhamNhan = listPhamNhan.Where(w => w.IDKhu == IDkhu);
            if (phongID != string.Empty || phongID != "null")
            {
                var IDphong = int.Parse(phongID);
                listPhamNhan = listPhamNhan.Where(w => w.PhongGiamID == IDphong);
            }
            return PartialView("_PhamNhansDataTable", listPhamNhan);
        }
        // GET: PhamNhans/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhamNhan phamNhan = db.PhamNhan.Find(id);
            if (phamNhan == null)
            {
                return HttpNotFound();
            }
            return View(phamNhan);
        }

        // GET: PhamNhans/Create
        public ActionResult Create()
        {
            ViewBag.GioiTinh = new SelectList(Common.CommonConstant.gioiTinh, "Key", "Value", null);
            ViewBag.ToiDanh = new SelectList(Common.CommonConstant.toiDanh, "Key", "Value", null);
            ViewBag.MucDoNguyHiem = new SelectList(Common.CommonConstant.mucDoNguyHiem, "Key", "Value", null);
            ViewBag.IDKhu = new SelectList(db.Khu, "ID", "TenKhu" , null);
            ViewBag.PhongGiamID = new SelectList(db.PhongGiam, "ID", "TenPhong", null);
            return View();
        }

        // POST: PhamNhans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TenPhamNhan,BiDanh,AnhNhanDien,QueQuan,NgaySinh,GioiTinh,IDKhu,ToiDanh,MucDoNguyHiem,SoNgayGiamGiu,CMND,QuaTrinhGayAn,DiaDiemGayAn,PhongGiamID")] PhamNhan phamNhan)
        {
            if (ModelState.IsValid)
            {
                phamNhan.ID = Guid.NewGuid();
                db.PhamNhan.Add(phamNhan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(phamNhan);
        }

        // GET: PhamNhans/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhamNhan phamNhan = db.PhamNhan.Find(id);
            if (phamNhan == null)
            {
                return HttpNotFound();
            }
            ViewBag.GioiTinh = new SelectList(Common.CommonConstant.gioiTinh, "Key", "Value", phamNhan.GioiTinh);
            ViewBag.ToiDanh = new SelectList(Common.CommonConstant.toiDanh, "Key", "Value", phamNhan.ToiDanh);
            ViewBag.MucDoNguyHiem = new SelectList(Common.CommonConstant.mucDoNguyHiem, "Key", "Value", phamNhan.MucDoNguyHiem);
            ViewBag.IDKhu = new SelectList(db.Khu, "ID", "TenKhu", phamNhan.IDKhu);
            ViewBag.PhongGiamID = new SelectList(db.PhongGiam, "ID", "TenPhong", phamNhan.PhongGiamID);
            return View(phamNhan);
        }

        // POST: PhamNhans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TenPhamNhan,BiDanh,AnhNhanDien,QueQuan,NgaySinh,GioiTinh,IDKhu,ToiDanh,MucDoNguyHiem,SoNgayGiamGiu,CMND,QuaTrinhGayAn,DiaDiemGayAn,PhongGiamID")] PhamNhan phamNhan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phamNhan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phamNhan);
        }

        // GET: PhamNhans/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhamNhan phamNhan = db.PhamNhan.Find(id);
            if (phamNhan == null)
            {
                return HttpNotFound();
            }
            return View(phamNhan);
        }

        // POST: PhamNhans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            PhamNhan phamNhan = db.PhamNhan.Find(id);
            db.PhamNhan.Remove(phamNhan);
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

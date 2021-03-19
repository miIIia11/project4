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
    public class ThamGuisController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ThamGuis
        public ActionResult Index()
        {
            if (User.Identity.GetQuanNgucId() == "")
            {
                return RedirectToAction("DangNhap", "TaiKhoan");
            }
            ViewBag.Khu = db.Khu.ToList();

            ViewBag.Phong = db.PhongGiam.ToList();
            return View(db.ThamGui.ToList());
        }

        public ActionResult ThanhTimKiem(string khuID)
        {
            ViewBag.Khu = db.Khu.ToList();
            ViewBag.SelectedKhu = khuID;
            int idKhu = int.Parse(khuID);
            ViewBag.Phong = db.PhongGiam.Where(w => w.KhuID == idKhu).ToList();

            return PartialView("_ThamGuisSearchBar");
        }

        public ActionResult TimKiem(string txtTenHoacMa, string khuID, string phongID)
        {
            IQueryable<PhamNhan> listPhamNhan = db.PhamNhan;
            List<ThamGui> listThamGui = db.ThamGui.ToList();
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
            foreach (var item in listPhamNhan)
            {
                listThamGui.Add(listThamGui.FirstOrDefault(f => f.PhamNhanID == item.ID));
            }
            return PartialView("_ThamGuisDataTable", listThamGui);
        }
        // GET: ThamGuis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThamGui thamGui = db.ThamGui.Find(id);
            if (thamGui == null)
            {
                return HttpNotFound();
            }
            return View(thamGui);
        }

        // GET: ThamGuis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ThamGuis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PhamNhanID,QuanNgucID,KeHoachThamGui,NgayThamGui,ThongTinNguoiThamHoi,SoLanThamHoi")] ThamGui thamGui)
        {
            if (ModelState.IsValid)
            {
                db.ThamGui.Add(thamGui);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(thamGui);
        }

        // GET: ThamGuis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThamGui thamGui = db.ThamGui.Find(id);
            if (thamGui == null)
            {
                return HttpNotFound();
            }
            return View(thamGui);
        }

        // POST: ThamGuis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PhamNhanID,QuanNgucID,KeHoachThamGui,NgayThamGui,ThongTinNguoiThamHoi,SoLanThamHoi")] ThamGui thamGui)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thamGui).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(thamGui);
        }

        // GET: ThamGuis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThamGui thamGui = db.ThamGui.Find(id);
            if (thamGui == null)
            {
                return HttpNotFound();
            }
            return View(thamGui);
        }

        // POST: ThamGuis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ThamGui thamGui = db.ThamGui.Find(id);
            db.ThamGui.Remove(thamGui);
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

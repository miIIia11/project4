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
    public class QuanNgucsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: QuanNgucs 
        public ActionResult Index(string tenQuanNguc, string khuID, int? i)
        {
            ViewBag.Khu = db.Khu.ToList();
            int _khuid = 0;
            if (string.IsNullOrEmpty(khuID)) _khuid = 1;
            else _khuid = Convert.ToInt32(khuID);

            if (string.IsNullOrEmpty(tenQuanNguc)) tenQuanNguc = "";

            //List<QuanNguc> listQuanNguc = db.QuanNguc
            //   .Where(q => (q.TenQuanNguc.Contains(tenQuanNguc) || tenQuanNguc == null) && (q.KhuID == _khuid))
            //   .ToList(); 
            var quanngucList = from q in db.QuanNguc
                               join k in db.Khu
                                    on q.KhuID equals k.ID
                               where q.TenQuanNguc.Contains(tenQuanNguc) && q.KhuID == _khuid
                               select new QuanNgucsParam
                               {
                                   ID = q.ID,
                                   TenQuanNguc = q.TenQuanNguc,
                                   NgaySinh = q.NgaySinh,
                                   QueQuan = q.QueQuan,
                                   GioiTinh = q.GioiTinh,
                                   KhuID = k.TenKhu,
                                   NamCongTac = q.NamCongTac,
                                   ThoiHanCongTac = q.ThoiHanCongTac,
                                   CMND = q.CMND,
                                   ChucVu = q.ChucVu,
                                   QuanHam = q.QuanHam   
                               };
            int pageSize = 5;
            int pageNumber = (i ?? 1);
            return View(quanngucList.OrderBy(q => q.TenQuanNguc).ToPagedList(pageNumber, pageSize));
        }

        public ActionResult TimKiem(string txtTenHoacMa, string khuID)
        {
            IQueryable<QuanNguc> listQuanNguc = db.QuanNguc;
            if (txtTenHoacMa.Length == 5)
            {
                //listPhamNhan = db.PhamNhan.Where(w => w. == txtTenOrMa);
            }
            else
            {
                listQuanNguc = listQuanNguc.Where(w => w.TenQuanNguc.Contains(txtTenHoacMa));
            }
            var IDkhu = int.Parse(khuID);
            listQuanNguc = listQuanNguc.Where(w => w.KhuID == IDkhu);

            return PartialView("_QuanNgucsDataTable", listQuanNguc);
        }
        // GET: QuanNgucs/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuanNguc quanNguc = db.QuanNguc.Find(id);
            if (quanNguc == null)
            {
                return HttpNotFound();
            }
            return View(quanNguc);
        }

        // GET: QuanNgucs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuanNgucs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TenQuanNguc,NgaySinh,QueQuan,GioiTinh,KhuID,NamCongTac,ThoiHanCongTac,CMND,ChucVu,QuanHam")] QuanNguc quanNguc)
        {
            if (ModelState.IsValid)
            {
                quanNguc.ID = Guid.NewGuid();
                db.QuanNguc.Add(quanNguc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(quanNguc);
        }

        // GET: QuanNgucs/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuanNguc quanNguc = db.QuanNguc.Find(id);
            if (quanNguc == null)
            {
                return HttpNotFound();
            }
            return View(quanNguc);
        }

        // POST: QuanNgucs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TenQuanNguc,NgaySinh,QueQuan,GioiTinh,KhuID,NamCongTac,ThoiHanCongTac,CMND,ChucVu,QuanHam")] QuanNguc quanNguc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quanNguc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quanNguc);
        }

        // GET: QuanNgucs/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuanNguc quanNguc = db.QuanNguc.Find(id);
            if (quanNguc == null)
            {
                return HttpNotFound();
            }
            return View(quanNguc);
        }

        // POST: QuanNgucs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            QuanNguc quanNguc = db.QuanNguc.Find(id);
            db.QuanNguc.Remove(quanNguc);
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

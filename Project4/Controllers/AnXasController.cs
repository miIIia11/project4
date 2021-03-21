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
    public class AnXasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AnXas   hihi4444 
        public ActionResult Index(string tenPhamNhan, int? i)
        {

            if (User.Identity.GetQuanNgucId() == "")
            {
                return RedirectToAction("DangNhap", "TaiKhoan");
            }
            ViewBag.Khu = db.Khu.ToList();

            ViewBag.Phong = db.PhongGiam.ToList();
            //return View(db.AnXa.ToList());

            if (string.IsNullOrEmpty(tenPhamNhan)) tenPhamNhan = "";
            var anxaList = from a in db.AnXa
                           join p in db.PhamNhan
                                   on a.PhamNhanID equals p.ID
                           where p.TenPhamNhan.Contains(tenPhamNhan)
                           select new AnXaParam
                           {
                               ID = a.ID,
                               PhamNhanID = p.TenPhamNhan,
                               MucDoAnXa = a.MucDoAnXa,
                               MucDoCaiTao = a.MucDoCaiTao
                           };
            int pageSize = 5;
            int pageNumber = (i ?? 1);
            return View(anxaList.OrderBy(t => t.PhamNhanID).ToPagedList(pageNumber, pageSize));

        }

        [HttpGet]
        public JsonResult getAllAnXa(string txtSearch, int? page)
        {
            var data = (from s in db.AnXa select s);
            if (!String.IsNullOrEmpty(txtSearch))
            {
                ViewBag.txtSearch = txtSearch;
                data = data.Where(s => s.PhamNhanID.ToString().Contains(txtSearch));
            }

            if (page > 0)
            {
                page = page;
            }
            else
            {
                page = 1;
            }
            int start = (int)(page - 1) * 3;

            ViewBag.pageCurrent = page;
            int totalPage = data.Count();
            float totalNumsize = (totalPage / (float)3);
            int numSize = (int)Math.Ceiling(totalNumsize);
            ViewBag.numSize = numSize;
            var dataPost = data.OrderByDescending(x => x.ID).Skip(start).Take(3);
            List<AnXa> listAnXa = new List<AnXa>();
            listAnXa = dataPost.ToList();
            // return Json(listPost);
            return Json(new { data = listAnXa, pageCurrent = page, numSize = numSize }, JsonRequestBehavior.AllowGet);
        }


        //public ActionResult ThanhTimKiem(string khuID)
        //{
        //    ViewBag.Khu = db.Khu.ToList();
        //    ViewBag.SelectedKhu = khuID;
        //    int idKhu = int.Parse(khuID);
        //    ViewBag.Phong = db.PhongGiam.Where(w => w.KhuID == idKhu).ToList();

        //    return PartialView("_AnXaSearchBar");
        //}

        //public ActionResult TimKiem(string txtTenHoacMa, string khuID, string phongID)
        //{
        //    IQueryable<PhamNhan> listPhamNhan = db.PhamNhan;
        //    List<AnXa> listAnXa = db.AnXa.ToList();
        //    if (txtTenHoacMa.Length == 5)
        //    {
        //        //listPhamNhan = db.PhamNhan.Where(w => w. == txtTenOrMa);
        //    }
        //    else
        //    {
        //        listPhamNhan = listPhamNhan.Where(w => w.TenPhamNhan.Contains(txtTenHoacMa));
        //    }
        //    var IDkhu = int.Parse(khuID);
        //    listPhamNhan = listPhamNhan.Where(w => w.IDKhu == IDkhu);
        //    if (phongID != string.Empty || phongID != "null")
        //    {
        //        var IDphong = int.Parse(phongID);
        //        listPhamNhan = listPhamNhan.Where(w => w.PhongGiamID == IDphong);
        //    }
        //    foreach (var item in listPhamNhan)
        //    {
        //        listAnXa.Add(listAnXa.FirstOrDefault(f => f.PhamNhanID == item.ID));
        //    }
        //    return PartialView("_AnXaDataTable", listAnXa);
        //}
        // GET: AnXas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnXa anXa = db.AnXa.Find(id);
            if (anXa == null)
            {
                return HttpNotFound();
            }
            return View(anXa);
        }

        // GET: AnXas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AnXas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PhamNhanID,MucDoAnXa,MucDoCaiTao")] AnXa anXa)
        {
            if (ModelState.IsValid)
            {
                db.AnXa.Add(anXa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(anXa);
        }

        // GET: AnXas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnXa anXa = db.AnXa.Find(id);
            if (anXa == null)
            {
                return HttpNotFound();
            }
            return View(anXa);
        }

        // POST: AnXas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PhamNhanID,MucDoAnXa,MucDoCaiTao")] AnXa anXa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(anXa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(anXa);
        }

        // GET: AnXas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnXa anXa = db.AnXa.Find(id);
            if (anXa == null)
            {
                return HttpNotFound();
            }
            return View(anXa);
        }

        // POST: AnXas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AnXa anXa = db.AnXa.Find(id);
            db.AnXa.Remove(anXa);
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

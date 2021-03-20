using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Project4.Models;

namespace Project4.Controllers
{
    public class PhamNhansController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PhamNhans oh yes
        public ActionResult Index()
        {
            var khu = db.Khu.ToList();
            if (khu != null)
            {
                //view bag 2 dropdown
                ViewBag.Khu = khu;
                ViewBag.SelectedKhu = khuID;
                int idKhu = 1;
                if (string.IsNullOrEmpty(khuID))
                {
                }
                else
                {
                    idKhu = int.Parse(khuID);
                }
                ViewBag.Phong = db.PhongGiam.Where(w => w.KhuID == idKhu).ToList();
            }
            else
            {

            }
            //search  
            int khuid = 0, phongid = 0;
            if (string.IsNullOrEmpty(khuID)) khuid = 1;
            else khuid = Convert.ToInt32(khuID);

            if (string.IsNullOrEmpty(phongID)) phongid = 1;
            else phongid = Convert.ToInt32(phongID);

            if (string.IsNullOrEmpty(txtTenHoacMa)) txtTenHoacMa = "";

            //List<PhamNhan> listPhamNhan = db.PhamNhan
            //    .Where(w => (w.TenPhamNhan.Contains(txtTenHoacMa) || txtTenHoacMa == null)
            //     && (w.IDKhu == khuid)
            //     && (w.PhongGiamID == phongid))
            //    .ToList();  
            var listPhamNhan = from p in db.PhamNhan
                               join k in db.Khu
                                    on p.IDKhu equals k.ID
                               join ph in db.PhongGiam
                                    on p.PhongGiamID equals ph.ID
                               where p.TenPhamNhan.Contains(txtTenHoacMa)
                                   && p.IDKhu == khuid && p.PhongGiamID == phongid
                               select new PhamNhanParams
                               {
                                   ID = p.ID,
                                   TenPhamNhan = p.TenPhamNhan,
                                   BiDanh = p.BiDanh,
                                   AnhNhanDien = p.AnhNhanDien,
                                   QueQuan = p.QueQuan,
                                   NgaySinh = p.NgaySinh,
                                   GioiTinh = p.GioiTinh,
                                   IDKhu = k.TenKhu,
                                   ToiDanh = p.ToiDanh,
                                   MucDoNguyHiem = p.MucDoNguyHiem,
                                   SoNgayGiamGiu = p.SoNgayGiamGiu,
                                   CMND = p.CMND,
                                   QuaTrinhGayAn = p.QuaTrinhGayAn,
                                   DiaDiemGayAn = p.DiaDiemGayAn,
                                   PhongGiamID = ph.TenPhong,
                               };
            int pageSize = 5;
            int pageNumber = (i ?? 1); 

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

        //public ActionResult TimKiem(string txtTenHoacMa, string khuID, string phongID, int? i)
        //{
        //    IQueryable<PhamNhan> listPhamNhan = db.PhamNhan;
        //    if (txtTenHoacMa.Length == 5)
        //    {
        //        //listPhamNhan = db.PhamNhan.Where(w => w. == txtTenOrMa);
        //    }
        //    else
        //    {
        //    }


        //    var listPhamNhan = db.PhamNhan.Where(w => w.TenPhamNhan.Contains(txtTenHoacMa));
        //    if (string.IsNullOrEmpty(khuID))
        //    {
        //        khuID = "1";
        //    }
        //    var IDkhu = int.Parse(khuID);
        //    listPhamNhan = listPhamNhan.Where(w => w.IDKhu == IDkhu);
        //    if (phongID != string.Empty || phongID != "null")
        //    {
        //        var IDphong = int.Parse(phongID);
        //        listPhamNhan = listPhamNhan.Where(w => w.PhongGiamID == IDphong);
        //    }
        //    return View("", listPhamNhan.OrderBy(o => o.TenPhamNhan).ToPagedList(i ?? 1, 7));
        //    return PartialView("_PhamNhansDataTable", listPhamNhan.OrderBy(p => p.TenPhamNhan).ToPagedList(i ?? 1, 7));
        //}


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
            ViewBag.IDKhu = new SelectList(db.Khu, "ID", "TenKhu", null);
            ViewBag.PhongGiamID = new SelectList(db.PhongGiam, "ID", "TenPhong", null);
            return View();
        }

        // POST: PhamNhans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TenPhamNhan,BiDanh,AnhNhanDien,QueQuan,NgaySinh,GioiTinh,IDKhu,ToiDanh,MucDoNguyHiem,SoNgayGiamGiu,CMND,QuaTrinhGayAn,DiaDiemGayAn,PhongGiamID")] PhamNhan phamNhan, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                string url = string.Empty;
                phamNhan.ID = Guid.NewGuid();
                phamNhan.NgayVaoTrai = DateTime.Now;
                FileUpload(file, phamNhan.ID, out url);
                if (url == string.Empty)
                {
                    //error = "You must include a Featured Image for event.";
                    //ViewBag.Error = error;
                    ViewBag.NgaySinh = phamNhan.NgaySinh.HasValue ? phamNhan.NgaySinh.Value.ToString("MM/dd/yyyy") : null;
                    return View(phamNhan);
                }
                phamNhan.AnhNhanDien = url;

                db.PhamNhan.Add(phamNhan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NgaySinh = phamNhan.NgaySinh.HasValue ? phamNhan.NgaySinh.Value.ToString("MM/dd/yyyy") : null;
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
            ViewBag.NgaySinh = phamNhan.NgaySinh.HasValue ? phamNhan.NgaySinh.Value.ToString("MM/dd/yyyy") : null;
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
        public ActionResult Edit([Bind(Include = "ID,TenPhamNhan,BiDanh,AnhNhanDien,QueQuan,NgaySinh,GioiTinh,IDKhu,ToiDanh,MucDoNguyHiem,SoNgayGiamGiu,CMND,QuaTrinhGayAn,DiaDiemGayAn,PhongGiamID,NgayVaoTrai")] PhamNhan phamNhan, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                string url = string.Empty;
                FileUpload(file, phamNhan.ID, out url);
                if (url != string.Empty)
                {
                    phamNhan.AnhNhanDien = url;
                }
                db.Entry(phamNhan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NgaySinh = phamNhan.NgaySinh.HasValue ? phamNhan.NgaySinh.Value.ToString("MM/dd/yyyy") : null;
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

        public void FileUpload(HttpPostedFileBase file, Guid phamNhanID, out string url)
        {
            url = string.Empty;
            try
            {
                if (file != null)
                {
                    string pic = System.IO.Path.GetFileName(file.FileName);
                    DirectoryInfo di = Directory.CreateDirectory(Server.MapPath($"~\\Common\\Image\\PhamNhans\\{phamNhanID}"));
                    string path = System.IO.Path.Combine(
                                           Server.MapPath($"~/Common/Image/PhamNhans/{phamNhanID}"), pic);
                    url = $"~/Common/Image/PhamNhans/{phamNhanID}/" + pic;
                    // file is uploaded
                    file.SaveAs(path);

                    // save the image path path to the database or you can send image 
                    // directly to database
                    // in-case if you want to store byte[] ie. for DB
                    using (MemoryStream ms = new MemoryStream())
                    {
                        file.InputStream.CopyTo(ms);
                        byte[] array = ms.GetBuffer();
                    }

                }
            }
            catch (Exception ex)
            {

            }

            // after successfully uploading redirect the user
            //return RedirectToAction("actionname", "controller name");
        }
    }
}

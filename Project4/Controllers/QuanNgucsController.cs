using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project4.Models;

namespace Project4.Controllers
{
    public class QuanNgucsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: QuanNgucs 
        public ActionResult Index()
        {
            ViewBag.Khu = db.Khu.ToList();
            return View(db.QuanNguc.ToList());
        }

        public ActionResult ViewDetails(Guid id)
        {
            QuanNguc quanNguc;
            quanNguc = db.QuanNguc.Find(id);
            return PartialView("_Details", quanNguc);
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
        //public ActionResult Details(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    QuanNguc quanNguc = db.QuanNguc.Find(id);
        //    if (quanNguc == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(quanNguc);
        //}

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
        public ActionResult Create([Bind(Include = "ID,TenQuanNguc,AnhNhanDien,NgaySinh,QueQuan,GioiTinh,KhuID,NamCongTac,ThoiHanCongTac,CMND,ChucVu,QuanHam")] QuanNguc quanNguc, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                quanNguc.ID = Guid.NewGuid();
                string url = string.Empty;
                quanNguc.ID = Guid.NewGuid();
                FileUpload(file, quanNguc.ID, out url);
                if (url == string.Empty)
                {
                    //error = "You must include a Featured Image for event.";
                    //ViewBag.Error = error;
                    ViewBag.NgaySinh = quanNguc.NgaySinh.HasValue ? quanNguc.NgaySinh.Value.ToString("MM/dd/yyyy") : null;
                    return View(quanNguc);
                }
                quanNguc.AnhNhanDien = url;
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
            ViewBag.NgaySinh = quanNguc.NgaySinh.HasValue ? quanNguc.NgaySinh.Value.ToString("MM/dd/yyyy") : null;
            return View(quanNguc);
        }

        // POST: QuanNgucs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TenQuanNguc,AnhNhanDien,NgaySinh,QueQuan,GioiTinh,KhuID,NamCongTac,ThoiHanCongTac,CMND,ChucVu,QuanHam")] QuanNguc quanNguc, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                string url = string.Empty;
                FileUpload(file, quanNguc.ID, out url);
                if (url != string.Empty)
                {
                    quanNguc.AnhNhanDien = url;
                }
                db.Entry(quanNguc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NgaySinh = quanNguc.NgaySinh.HasValue ? quanNguc.NgaySinh.Value.ToString("MM/dd/yyyy") : null;
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
        public void FileUpload(HttpPostedFileBase file, Guid quanNgucID, out string url)
        {
            url = string.Empty;
            try
            {
                if (file != null)
                {
                    string pic = System.IO.Path.GetFileName(file.FileName);
                    DirectoryInfo di = Directory.CreateDirectory(Server.MapPath($"~\\Common\\Image\\QuanNgucs\\{quanNgucID}"));
                    string path = System.IO.Path.Combine(
                                           Server.MapPath($"~/Common/Image/QuanNgucs/{quanNgucID}"), pic);
                    url = $"~/Common/Image/QuanNgucs/{quanNgucID}/" + pic;
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

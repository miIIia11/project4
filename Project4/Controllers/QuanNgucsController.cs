using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project4.Models;
using System.Text.RegularExpressions;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Project4.Controllers
{
    public class QuanNgucsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize(Roles = "QuanNgucTruong")]
        // GET: QuanNgucs 
        public ActionResult Index()
        {
            if (User.Identity.GetQuanNgucId() == "")
            {
                return RedirectToAction("DangNhap", "TaiKhoan");
            }
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
        public ActionResult Create([Bind(Include = "ID,TenQuanNguc,NgaySinh,QueQuan,GioiTinh,KhuID,NamCongTac,ThoiHanCongTac,CMND,ChucVu,QuanHam")] QuanNguc quanNguc)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            if (ModelState.IsValid)
            {
                quanNguc.ID = Guid.NewGuid();
                db.QuanNguc.Add(quanNguc);
                db.SaveChanges();
                var newUser = new ApplicationUser();
                var generatedEmail = RemoveUnicodeAndSpace(quanNguc.TenQuanNguc) + @"@chihoa.com";
                newUser.UserName = generatedEmail;
                newUser.Email = generatedEmail;
                string password = "123456";
                var checkUser = UserManager.Create(newUser,password);
                if (checkUser.Succeeded)
                {
                    var checkRole = UserManager.AddToRole(newUser.Id ,"QuanNguc");
                }
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

        public static string RemoveUnicodeAndSpace(string text)
        {
            string[] arr1 = new string[] { "á", "à", "ả", "ã", "ạ", "â", "ấ", "ầ", "ẩ", "ẫ", "ậ", "ă", "ắ", "ằ", "ẳ", "ẵ", "ặ",
            "đ",
            "é","è","ẻ","ẽ","ẹ","ê","ế","ề","ể","ễ","ệ",
            "í","ì","ỉ","ĩ","ị",
            "ó","ò","ỏ","õ","ọ","ô","ố","ồ","ổ","ỗ","ộ","ơ","ớ","ờ","ở","ỡ","ợ",
            "ú","ù","ủ","ũ","ụ","ư","ứ","ừ","ử","ữ","ự",
            "ý","ỳ","ỷ","ỹ","ỵ",};
            string[] arr2 = new string[] { "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a",
            "d",
            "e","e","e","e","e","e","e","e","e","e","e",
            "i","i","i","i","i",
            "o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o",
            "u","u","u","u","u","u","u","u","u","u","u",
            "y","y","y","y","y",};
            for (int i = 0; i < arr1.Length; i++)
            {
                text = text.Replace(arr1[i], arr2[i]);
                text = text.Replace(arr1[i].ToUpper(), arr2[i].ToUpper());
            }
            text = Regex.Replace(text, @"\s", "");
            text = text.ToLower();
            return text;
        }
    }
}

using Project4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project4.Controllers
{
    public class TaiKhoanController : Controller
    {
        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost] 
        public ActionResult DangNhap(TaiKhoan tk)
        {
            if (tk.TenDangNhap == "streamer" && tk.MatKhau == "streamer123")
            {
                return RedirectToAction("Index", "TrangChu");
            }
            else
            {
                ViewBag.CheckValid = "Thông tin đăng nhập không hợp lệ";
                return View(tk);
            }

        }
    }
}

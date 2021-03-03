using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project4.Models
{  
    public class TaiKhoan 
    { 
        [DisplayName("Tên đăng nhập")]
        public string TenDangNhap { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("Mật khẩu")] 
        public string MatKhau { get; set; } 
    }
} 
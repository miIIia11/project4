using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Project4.Models
{
    public class QuanNguc
    {
        public Guid ID { get; set; }

        [DisplayName("Tên quản ngục")]
        public string TenQuanNguc { get; set; }

        [DisplayName("Ngày sinh")]
        public DateTime NgaySinh { get; set; }

        [DisplayName("Quê quán")]
        public string QueQuan { get; set; }

        [DisplayName("Giới tính")]
        public int GioiTinh { get; set; }

        [DisplayName("Khu")]
        public int KhuID { get; set; }

        [DisplayName("Năm công tác")]
        public int NamCongTac { get; set; }

        [DisplayName("Thời hạn công tác")]
        public int ThoiHanCongTac { get; set; }

        [DisplayName("Số thẻ căn cước")]
        public string CMND { get; set; }

        [DisplayName("Chức vụ")]
        public int ChucVu { get; set; } //enum

        [DisplayName("Quân hàm")]
        public int QuanHam { get; set; } //enum
    }
}
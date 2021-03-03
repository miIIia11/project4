using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Project4.Models
{
    public class CheDoNghiPhepCuaQuanNguc
    {
        public int ID { get; set; } 

        [DisplayName("Quản ngục ID")]
        public Guid QuanNgucID { get; set; }

        [DisplayName("Số ngày nghỉ")]
        public int SoNgayNghi { get; set; }

        [DisplayName("Lý do nghỉ")]
        public string LyDoNghi { get; set; }
    }
}
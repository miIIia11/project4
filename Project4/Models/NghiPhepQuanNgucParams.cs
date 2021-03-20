using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web; 

namespace Project4.Models
{
    public class NghiPhepQuanNgucParams
    {

        public int ID { get; set; } 

        [DisplayName("Tên quản ngục")] 
        public string TenQuanNguc { get; set; }

        [DisplayName("Số ngày nghỉ")]
        public int SoNgayNghi { get; set; }

        [DisplayName("Lý do nghỉ")]
        public string LyDoNghi { get; set; } 
    }
}
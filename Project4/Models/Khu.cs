using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Project4.Models
{
    public class Khu
    {
        public int ID { get; set; }

        public string TenKhu { get; set; }

        [DisplayName("Quản ngục ID")]
        public Guid QuanNgucID { get; set; }

        //[DisplayName("Phòng ID")]
        //public int PhongID { get; set; }
    }
}
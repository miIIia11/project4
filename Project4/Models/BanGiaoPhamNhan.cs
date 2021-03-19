using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project4.Models
{
    public class BanGiaoPhamNhan
    {
        public int ID { get; set; }
        public Guid QuanNgucNghiID { get; set; }
        public Guid QuanNgucNhanID { get; set; }
        public int PhongID { get; set; }
        public DateTime NgayNhan { get; set; }
        public int SoNgayBanGiao { get; set; }
    }
}
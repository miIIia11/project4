using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Project4.Models 
{
    public class PhongGiam 
    {
        public int ID { get; set; }

        public string TenPhong { get; set; }

        [DisplayName("Khu")]
        public int KhuID { get; set; }

        [DisplayName("Số phạm nhân tối đa")]
        public int SoLuongPhamNhanMax { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Project4.Models
{
    public class QuanLyBenhTat
    {
        public int ID { get; set; }

        [DisplayName("Phạm nhân")]
        public Guid PhamNhanID { get; set; }

        [DisplayName("Bệnh")]
        public int BenhID { get; set; }

        [DisplayName("Thời gian điều trị")]
        public int ThoiGianDieuTri { get; set; }

        [DisplayName("Nơi điều trị")]
        public string NoiDieuTri { get; set; }

    }
}
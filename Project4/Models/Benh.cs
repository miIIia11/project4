using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Project4.Models
{
    public class Benh
    {
        public int ID { get; set; }

        [DisplayName("Mã Phạm nhân")]
        public Guid PhamNhanID { get; set; }

        [DisplayName("Ngày Chữa Trị")]
        public int NgayChuaTri { get; set; }

        public DateTime NgayBatDauChuaTri { get; set; }
    }
}
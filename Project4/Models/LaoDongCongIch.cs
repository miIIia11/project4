using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Project4.Models
{
    public class LaoDongCongIch
    {
        public int ID { get; set; }

        [DisplayName("Phạm nhân")] 
        public Guid PhamNhanID { get; set; }

        [DisplayName("Quản Ngục")]
        public Guid QuanNgucID { get; set; }

        [DisplayName("Khu làm việc")]
        public int KhuVucLamViec { get; set; } //enum

        [DisplayName("Biểu hiện")]
        public int BieuHien { get; set; } //enum
    }
}
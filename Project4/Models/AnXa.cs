using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Project4.Models
{
    public class AnXa
    {
        public int ID { get; set; }

        [DisplayName("Phạm nhân ID")]
        public Guid PhamNhanID { get; set; }

        [DisplayName("Mức độ ân xá")]
        public int MucDoAnXa { get; set; } //enum

        [DisplayName("Mức độ cải tạo")]
        public int MucDoCaiTao { get; set; } //enum
    }
}
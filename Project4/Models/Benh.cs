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

        [DisplayName("Tên bệnh")]
        public string TenBenh { get; set; }
    }
}
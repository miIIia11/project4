using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project4.Models
{
    public class BanGiaoCongViecCuaQuanNgucNghi
    {
        public int ID { get; set; }
        public Guid QuanNgucNhanID { get; set; }
        public DateTime NgayNhan { get; set; }
        [ForeignKey("PhongGiam")]
        public virtual int? PhongID { get; set; }
        public virtual PhongGiam PhongGiam { get; set; }
    }
}
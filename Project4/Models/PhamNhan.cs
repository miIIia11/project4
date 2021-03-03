using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Project4.Models
{
    public class PhamNhan
    {
        public Guid ID { get; set; }

        [DisplayName("Tên phạm nhân")]
        public string TenPhamNhan { get; set; }

        [DisplayName("Bí danh")]
        public string BiDanh { get; set; }

        [DisplayName("Ảnh nhận dạng")]
        public string AnhNhanDien { get; set; }

        [DisplayName("Quê quán")] 
        public string QueQuan { get; set; }

        [DisplayName("Ngày sinh")]
        public DateTime NgaySinh { get; set; }

        [DisplayName("Giới tính")]
        public int GioiTinh { get; set; } //enum

        [DisplayName("Khu")]
        public int IDKhu { get; set; }

        [DisplayName("Tội danh")]
        public int ToiDanh { get; set; } //enum

        [DisplayName("Mức độ nguy hiểm")]
        public int MucDoNguyHiem { get; set; } //enum

        [DisplayName("Thời gian giam giữ")]
        public int SoNgayGiamGiu { get; set; }

        [DisplayName("Số thẻ căn cước")]
        public string CMND { get; set; }

        [DisplayName("Quá trình gây án")]
        public string QuaTrinhGayAn { get; set; }

        [DisplayName("Địa điểm gây án")]
        public string DiaDiemGayAn { get; set; }

        [DisplayName("Phòng giam")]
        public int PhongGiamID { get; set; }

    }
}
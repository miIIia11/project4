using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project4.Common
{
    public class CommonConstant
    {
        public static string USER_SESSION = "USER_SESSION";
        public static string USERID = "USERID";
        public static string PERMISSION_SESSION = "PERMISSION_SESSION";

        Dictionary<int, string> mucDoAnXa = new Dictionary<int, string>()
        {
            {1, "1 Tháng" }, //adding key/value using the Add() method
            {2, "3 Tháng" },
            {3, "6 Tháng" },
            {4, "9 Tháng"},
            {5, "1 Năm"},
            {6, "2 Năm"},
            {7, "3 Năm"},
            {8, "4 Năm"},
        };

        Dictionary<int, string> mucDoCaiTao = new Dictionary<int, string>()
        {
            {1, "Tốt"},
            {2, "Khá"},
            {3, "Trung Bình" },
            {4, "Yếu"},
            {5, "Kém"}
        };

        Dictionary<int, string> khuVucLamViec = new Dictionary<int, string>()
        {
            {1, "Trồng trọt"},
            {2, "Chăn nuôi"},
            {3, "Chế biến đá"},
            {4, "Gia công vàng mã"},
            {5, "Thủ công mỹ nghệ"},
            {6, "Cơ khí"},
            {7, "May mặc"}
        };

        Dictionary<int, string> bieuHien = new Dictionary<int, string>()
        {
            {1, "Tốt"},
            {2, "Khá"},
            {3, "Trung Bình" },
            {4, "Yếu"},
            {5, "Kém"}
        };

        Dictionary<int, string> gioiTinh = new Dictionary<int, string>()
        {
            {1, "Nam"},
            {2, "Nữ"},
        };
        Dictionary<int, string> toiDanh = new Dictionary<int, string>()
        {
            {1, "Tội cưỡng hiếp người dưới 16 tuổi"},
            {2, "Tội cướp tài sản"},
            {3, "Tội sản xuất, buôn bán hàng giả là lương thực, thực phẩm, phụ gia thực phẩm" },
            {4, "Tội đầu hàng địch"},
            {5, "Tội chống mệnh lệnh"},
            {6, "Tội phá hủy công trình, cơ sở, phương tiện quan trọng về an ninh quốc gia"},
            {7, "Tội tàng trữ trái phép chất ma túy"}
        };

        Dictionary<int, string> mucDoNguyHiem = new Dictionary<int, string>()
        {
            { 1, "Tội phạm ít nghiêm trọng"},
            { 2, "Tội phạm nghiêm trọng" },
            { 3, "Tội phạm rất nghiêm trọng" },
            { 4, "Tội phạm đặc biệt nghiêm trọng." }
        };

        // bang AnXa
        public enum MucDoAnXa // cái này ko hiểu lắm vì sao ko enum dc nên ông check xem nhé
        {
            motthang = 1,
            bathang = 2,
            sauthang = 3,
            chinthang = 4,
            motnam = 5,
            hainam = 6,
            banam = 7,
            bonnam = 8
        }



        // giờ làm thé nào thêm dấu cách vs

        public enum MucDoCaiTao
        {
            tot = 1,
            kha = 2,
            trungbinh = 3,
            yeu = 4,
            kem = 5
        }


        //Bang lao dong cong ich
        public enum KhuVucLamViec
        {
            trongtrot = 1,
            channuoi = 2,
            //Chếbiếnđá
            chebienda = 3,
            //Giácôngvàngmã
            giacongvangma = 4,
            //Thủcôngmỹnghệ
            thucongmynghe = 5,
            //Cơkhí
            cokhi = 6,
            //Maymặc
            maymac = 7
        }

        public enum BieuHien
        {
            tot = 1,
            kha = 2,
            trungbinh = 3,
            yeu = 4,
            kem = 5
        }

        public enum GioiTinh
        {
            nam = 1,
            nu = 2
        }

        public enum ToiDanh
        {
            toihiepdamnguoiduoimuoisautuoi = 1,
            toicuoptaisan = 2,
            //    Tội sản xuất, buôn bán hàng giả là lương thực, thực phẩm, phụ gia thực phẩm
            toisanxuatbuonbanhanggia = 3,
            //    Tội đầu hàng địch
            toidauhangdich = 4,
            //    Tộichống mệnh lệnh 
            toichongmenhlenh = 5,
            //    Tộiphá hủy công trình, cơ sở, phương tiện quan trọng về an ninh quốc gia = 6,
            toiphahoaitaisanquocgia = 6,
            //    Tội tàng trữ trái phép chất ma túy = 7
            toitangtrumatuy = 7
        }

        public enum MucDoNguyHiem
        {
            //    Tội phạm ít nghiêm trọng,
            toiphamitnghiemtrong = 1,
            //    Tội phạm nghiêm trọng,
            toiphamnghiemtrong = 2,
            //    Tội phạm rất nghiêm trọng,
            toiphamratnghiemtrong = 3,
            //    Tội phạm đặc biệt nghiêm trọng
            toiphamdacbietnghiemtrong = 4
        }
    }
}
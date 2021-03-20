using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project4.Common
{
    public class CommonConstant
    {
        public static string USER_SESSION = "USER_SESSION";
        public static string QUANNGUCID = "QUANNGUCID";
        public static string PERMISSION_SESSION = "PERMISSION_SESSION";

        public static Dictionary<int, string> mucDoAnXa = new Dictionary<int, string>()
        {
            { (int)MucDoAnXa.motthang , "1 Tháng" }, //adding key/value using the Add() method
            { (int)MucDoAnXa.bathang, "3 Tháng" },
            { (int)MucDoAnXa.sauthang, "6 Tháng" },
            { (int)MucDoAnXa.chinthang, "9 Tháng"},
            { (int)MucDoAnXa.motnam, "1 Năm"},
            { (int)MucDoAnXa.hainam, "2 Năm"},
            { (int)MucDoAnXa.banam, "3 Năm"},
            { (int)MucDoAnXa.bonnam, "4 Năm"},
        };

        public static Dictionary<int, string> mucDoCaiTao = new Dictionary<int, string>()
        {
            { (int)MucDoCaiTao.tot, "Tốt"},
            { (int)MucDoCaiTao.kha, "Khá"},
            { (int)MucDoCaiTao.trungbinh, "Trung Bình" },
            { (int)MucDoCaiTao.yeu, "Yếu"},
            { (int)MucDoCaiTao.kem, "Kém"}
        };

        public static Dictionary<int, string> khuVucLamViec = new Dictionary<int, string>()
        {
            { (int)KhuVucLamViec.trongtrot, "Trồng trọt"},
            { (int)KhuVucLamViec.channuoi, "Chăn nuôi"},
            { (int)KhuVucLamViec.chebienda, "Chế biến đá"},
            { (int)KhuVucLamViec.giacongvangma, "Gia công vàng mã"},
            { (int)KhuVucLamViec.thucongmynghe, "Thủ công mỹ nghệ"},
            { (int)KhuVucLamViec.cokhi, "Cơ khí"},
            { (int)KhuVucLamViec.maymac, "May mặc"}
        };

        public static Dictionary<int, string> bieuHien = new Dictionary<int, string>()
        {
            { (int)BieuHien.tot, "Tốt"},
            { (int)BieuHien.kha, "Khá"},
            { (int)BieuHien.trungbinh, "Trung Bình" },
            { (int)BieuHien.yeu, "Yếu"},
            { (int)BieuHien.kem, "Kém"}
        };

        public static Dictionary<int, string> gioiTinh = new Dictionary<int, string>()
        {
            { (int)GioiTinh.nam, "Nam"},
            { (int)GioiTinh.nu, "Nữ"},
        };
        public static Dictionary<int, string> toiDanh = new Dictionary<int, string>()
        {
            { (int)ToiDanh.toihiepdamnguoiduoimuoisautuoi, "Tội cưỡng hiếp người dưới 16 tuổi"},
            { (int)ToiDanh.toicuoptaisan, "Tội cướp tài sản"},
            { (int)ToiDanh.toisanxuatbuonbanhanggia, "Tội sản xuất, buôn bán hàng giả là lương thực, thực phẩm, phụ gia thực phẩm" },
            { (int)ToiDanh.toidauhangdich, "Tội đầu hàng địch"},
            { (int)ToiDanh.toichongmenhlenh, "Tội chống mệnh lệnh"},
            { (int)ToiDanh.toiphahoaitaisanquocgia, "Tội phá hủy công trình, cơ sở, phương tiện quan trọng về an ninh quốc gia"},
            { (int)ToiDanh.toitangtrumatuy, "Tội tàng trữ trái phép chất ma túy"}
        };

        public static Dictionary<int, string> mucDoNguyHiem = new Dictionary<int, string>()
        {
            { (int)MucDoNguyHiem.toiphamitnghiemtrong, "Tội phạm ít nghiêm trọng"},
            { (int)MucDoNguyHiem.toiphamnghiemtrong, "Tội phạm nghiêm trọng" },
            { (int)MucDoNguyHiem.toiphamratnghiemtrong, "Tội phạm rất nghiêm trọng" },
            { (int)MucDoNguyHiem.toiphamdacbietnghiemtrong, "Tội phạm đặc biệt nghiêm trọng." }
        };
		
		public static Dictionary<int, string> chucVu = new Dictionary<int, string>()
        {
			{ (int)ChucVu.congnhanvienchuc, "Công nhân viên chức" },
            { (int)ChucVu.chiensi, "Chiến sĩ"},
			{ (int)ChucVu.hasiquan, "Hạ sĩ quan"},
			{ (int)ChucVu.quannhanchuyennghiep, "Quân nhân chuyên nghiệp"},
            { (int)ChucVu.siquan, "Sĩ quan"},
			{ (int)ChucVu.phodoitruong, "Phó đội trưởng"},
			{ (int)ChucVu.doitruong, "Đội trưởng"},
            { (int)ChucVu.photruongphantrai, "Phó trưởng phân trại" },
			{ (int)ChucVu.truongphantrai, "Trưởng phân trại"},
			{ (int)ChucVu.phogiamthi, "Phó giám thị"},
            { (int)ChucVu.giamthi, "Giám thị" }
        };
		
		public static Dictionary<int, string> quanHam = new Dictionary<int, string>()
        {
			{ (int)QuanHam.hasi, "Hạ sĩ"},
			{ (int)QuanHam.trungsi, "Trung sĩ"},
			{ (int)QuanHam.thuongsi, "Hạ sĩ"},
			{ (int)QuanHam.thieuuy, "Thiếu úy"},
			{ (int)QuanHam.trunguy, "Trung úy"},
			{ (int)QuanHam.thuonguy, "Thượng úy"},
			{ (int)QuanHam.daiuy, "Đại úy"},
			{ (int)QuanHam.thieuta, "Thiếu tá"},
			{ (int)QuanHam.trungta, "Trung tá"},
			{ (int)QuanHam.thuongta, "Thượng tá"},
			{ (int)QuanHam.daita, "Đại tá"},
			{ (int)QuanHam.thieutuong, "Thiếu tướng"},
			{ (int)QuanHam.trungtuong, "Trung tướng"},
			{ (int)QuanHam.thuongtuong, "Thượng tướng"},
			{ (int)QuanHam.daituong, "Đại tướng"}
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
		
		// quan ngục
		public enum ChucVu
		{
			// Giám thị
			giamthi = 1,
			// phó giá thị
			phogiamthi = 2,
			// trưởng phân trại
			truongphantrai = 3,
			// phó trưởng phân trại
			photruongphantrai = 4,
			// đội trưởng
			doitruong = 5,
			// phó đội trưởng
			phodoitruong = 6,
			// sĩ quan
			siquan = 7,
			// quân nhân chuyên nghiệp
			quannhanchuyennghiep = 8,
			// hạ sĩ quan
			hasiquan = 9,
			// chiến sĩ
			chiensi = 10,
			// công nhân viên chức
			congnhanvienchuc = 11
		}
		
		public enum QuanHam 
		{
			// hạ sĩ
			hasi = 1,
			// trung sĩ
			trungsi = 2,
			// thượng sĩ
			thuongsi = 3,
			// thiếu úy
			thieuuy = 4,
			// trung úy
			trunguy = 5,
			// thượng úy
			thuonguy = 6,
			// đại úy
			daiuy = 7,
			// thiếu tá
			thieuta = 8,
			//trung tá
			trungta = 9,
			//thượng tá
			thuongta = 10,
			//đại tá
			daita = 11,
			//thiếu tướng
			thieutuong = 12,
			//trung tướng
			trungtuong = 13,
			//thượng tá
			thuongtuong = 14,
			//đại tá
			daituong = 15,
		}
    }
}
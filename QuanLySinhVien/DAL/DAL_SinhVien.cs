using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.DAL
{
    public class DAL_SinhVien
    {
        private static DAL_SinhVien instance;

        public static DAL_SinhVien Instance
        {

            get { if (instance == null) instance = new DAL_SinhVien(); return instance; }
            private set => instance
            =
            value;
        }

        private DAL_SinhVien() { }
        public bool Them(string MaSV, string TenSV, string Ngaysinh, string GioiTinh, string QueQuan, string NgayNhapHoc, string MaLop, string MaKhoa, string MaCVHT)
        {
            string sql = "INSERT INTO SinhVien (MaSV,TenSV,Ngaysinh,GioiTinh,QueQuan,NgayNhapHoc,MaLop,MaKhoa,MaCVHT) VALUES ( @MaSV, @TenSV,@Ngaysinh,@GioiTinh,@QueQuan,@NgayNhapHoc,@MaLop,@MaKhoa,@MaCVHT)";
            return KetNoi.Instance.ExcuteNonQuery(sql, new object[] { MaSV, TenSV, Ngaysinh, GioiTinh, QueQuan, NgayNhapHoc, MaLop, MaKhoa, MaCVHT });
        }

        public bool Sua(string MaSV, string TenSV, string Ngaysinh, string GioiTinh, string QueQuan, string NgayNhapHoc, string MaLop, string MaKhoa, string MaCVHT, int id)
        {
            string sql = "UPDATE SinhVien SET MaSV = @MaSV, TenSV = @TenSV, Ngaysinh=@NgaySinh, GioiTinh=@GioiTinh, QueQuan=@QueQuan, NgayNhapHoc=@NgayNhapHoc, MaLop=@MaLop, MaKhoa=@MaKhoa, MaCVHT=@MaCVHT WHERE Id = @id";
            return KetNoi.Instance.ExcuteNonQuery(sql, new object[] { MaSV, TenSV, Ngaysinh, GioiTinh, QueQuan, NgayNhapHoc, MaLop, MaKhoa, MaCVHT, id });
        }


        public bool Xoa(int id)
        {
            string sql = "DELETE FROM SinhVien WHERE Id = @id";
            return KetNoi.Instance.ExcuteNonQuery(sql, new object[] { id });
        }

        public DataTable DanhSach()
        {
            return KetNoi.Instance.ExcuteQuery("SELECT * FROM SinhVien");
        }
    }
}

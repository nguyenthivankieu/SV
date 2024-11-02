using QuanLySinhVien.DAL;
using System;
using System.Data;

namespace QuanLySinhVien.DAL
{
    public class DAL_TaiKhoan
    {
        private static DAL_TaiKhoan instance;

        public static DAL_TaiKhoan Instance
        {

            get { if (instance == null) instance = new DAL_TaiKhoan(); return instance; }
            private set => instance
            =
            value;
        }

        private DAL_TaiKhoan() { }
        public bool Them(string ten, string matkhau, string loai)
        {
            string sql = "INSERT INTO TaiKhoan (TenDangNhap, MatKhau, LoaiTaiKhoan) VALUES (@TenDangNhap, @MatKhau, @LoaiTaiKhoan)";
            return KetNoi.Instance.ExcuteNonQuery(sql, new object[] { ten, matkhau, loai });
        }

        public bool Sua_Het(string ten, string matkhau, string loai, int id)
        {
            string sql = "UPDATE Taikhoan SET TenDangNhap = @TenDangNhap, MatKhau = @MatKhau, LoaiTaiKhoan = @LoaiTaiKhoan WHERE Id = @id";
            return KetNoi.Instance.ExcuteNonQuery(sql, new object[] { ten, matkhau, loai, id });
        }
        public bool KhongSuaMatKhau(string ten, string loai, int id)
        {
            string sql = "UPDATE Taikhoan SET TenDangNhap = @TenDangNhap, LoaiTaiKhoan = @LoaiTaiKhoan WHERE Id = @id";
            return KetNoi.Instance.ExcuteNonQuery(sql, new object[] { ten, loai, id });
        }
        public bool Xoa(int id)
        {
            string sql = "DELETE FROM Taikhoan WHERE Id = @id";
            return KetNoi.Instance.ExcuteNonQuery(sql, new object[] { id });
        }

        public DataTable DanhSach()
        {
            return KetNoi.Instance.ExcuteQuery("SELECT * FROM TaiKhoan");
        }
        public DataTable DangNhap(string ten, string matkhau)
        {
            string sql = "select*from TaiKhoan where TenDangNhap =@TenDangNhap and MatKhau =@MatKhau";
            return KetNoi.Instance.ExcuteQuery(sql, new object[] { ten, matkhau });
        }
    }


}

using QuanLySinhVien.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.BLL
{
    public class BLL_SinhVien
    {
        private static BLL_SinhVien instance;

        public static BLL_SinhVien Instance
        {

            get { if (instance == null) instance = new BLL_SinhVien(); return instance; }
            private set => instance
            =
            value;
        }

        private BLL_SinhVien() { }

        public DataTable DanhSach()
        {
            return DAL_SinhVien.Instance.DanhSach();
        }

        public bool Them(string MaSV, string TenSV, string Ngaysinh, string GioiTinh, string QueQuan, string NgayNhgapHoc, string MaLop, string MaKhoa, string MaCVHT)
        
        {
            return DAL_SinhVien.Instance.Them(MaSV, TenSV, Ngaysinh, GioiTinh, QueQuan, NgayNhgapHoc, MaLop, MaKhoa, MaCVHT);

        }
        public bool Sua(string MaSV, string TenSV, string Ngaysinh, string GioiTinh, string QueQuan, string NgayNhgapHoc, string MaLop, string MaKhoa, string MaCVHT, int id)
        {
            return DAL_SinhVien.Instance.Sua(MaSV, TenSV, Ngaysinh, GioiTinh, QueQuan, NgayNhgapHoc, MaLop, MaKhoa, MaCVHT, id);

        }

        public bool Xoa(int id)
        {
            return DAL_SinhVien.Instance.Xoa(id);

        }
    }
}

    

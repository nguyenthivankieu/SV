using QuanLySinhVien.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.BLL
{
    public class BLL_Diem
    {
        private static BLL_Diem instance;

        public static BLL_Diem Instance
        {

            get { if (instance == null) instance = new BLL_Diem(); return instance; }
            private set => instance
            =
            value;
        }

        private BLL_Diem() { }

        public DataTable DanhSach()
        {
            return DAL_Diem.Instance.DanhSach();
        }

        public bool Them(string MaSV, string MaMH, int PhanTramTrenLop, int PhanTramThi, float DiemTrenLop, float DiemThi, float DiemTB, string Loai, int NamHoc)
        {
            return DAL_Diem.Instance.Them(MaSV, MaMH, PhanTramTrenLop, PhanTramThi, DiemTrenLop, DiemThi, DiemTB, Loai, NamHoc);

        }
        public bool Sua(string MaSV, string MaMH, int PhanTramTrenLop, int PhanTramThi, float DiemTrenLop, float DiemThi, float DiemTB, string Loai, int NamHoc, int id)
        {
            return DAL_Diem.Instance.Sua(MaSV, MaMH, PhanTramTrenLop, PhanTramThi, DiemTrenLop, DiemThi, DiemTB, Loai, NamHoc, id);

        }

        public bool Xoa(int id)
        {
            string query = "DELETE FROM Diem WHERE id = @id"; // Đảm bảo rằng tên cột là đúng
            return KetNoi.Instance.ExcuteNonQuery(query, new object[] { id });
        }

    }
}


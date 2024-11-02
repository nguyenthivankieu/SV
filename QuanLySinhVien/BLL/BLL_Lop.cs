using QuanLySinhVien.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.BLL
{
    public class BLL_Lop
    {
        private static BLL_Lop instance;

        public static BLL_Lop Instance
        {

            get { if (instance == null) instance = new BLL_Lop(); return instance; }
            private set => instance
            =
            value;
        }

        private BLL_Lop() { }

        public DataTable DanhSach()
        {
            return DAL_Lop.Instance.DanhSach();
        }

        public bool Them(string maLop, string tenLop,int soluong,string makhoa)
        {
            return DAL_Lop.Instance.Them(maLop, tenLop,soluong,makhoa);

        }
        public bool Sua(string maLop, string tenLop, int soluong, string makhoa, int id)
        {
            return DAL_Lop.Instance.Sua(maLop, tenLop, soluong, makhoa, id);

        }

        public bool Xoa(int id)
        {
            string query = "DELETE FROM Lop WHERE id = @id"; // Đảm bảo rằng tên cột là đúng
            return KetNoi.Instance.ExcuteNonQuery(query, new object[] { id });
        }

    }
}


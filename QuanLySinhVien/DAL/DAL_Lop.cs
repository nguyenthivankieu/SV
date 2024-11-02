using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.DAL
{
    public class DAL_Lop
    {
 
            private static DAL_Lop instance;

        public static DAL_Lop Instance
        {

            get { if (instance == null) instance = new DAL_Lop(); return instance; }
            private set => instance
            =
            value;
        }

        private DAL_Lop() { }
        public bool Them(string maLop, string tenLop, int soluong,string makhoa)
        {
            string sql = "INSERT INTO Lop (MaLop,TenLop,SoLuong,MaKhoa) VALUES ( @MaLop, @TenLop,@SoLuong,@MaKhoa)";
           
            //return KetNoi.Instance.ExcuteNonQuery(sql, new object[] { maLop, tenLop }); //có 4 param mà truyền 2
            return KetNoi.Instance.ExcuteNonQuery(sql, new object[] { maLop, tenLop, soluong, makhoa });
        }

        public bool Sua(string maLop, string tenLop, int soluong, string makhoa, int id)
        {
            string sql = "UPDATE Lop SET MaLop = @MaLop, TenLop = @TenLop,SoLuong =@SoLuong,MaKhoa=@MaKhoa WHERE Id = @id";
            return KetNoi.Instance.ExcuteNonQuery(sql, new object[] { maLop, tenLop,soluong,makhoa, id });
        }


        public bool Xoa(int id)
        {
            string sql = "DELETE FROM Lop WHERE Id = @id";
            return KetNoi.Instance.ExcuteNonQuery(sql, new object[] { id });
        }

        public DataTable DanhSach()
        {
            return KetNoi.Instance.ExcuteQuery("SELECT * FROM Lop");
        }

    }
}


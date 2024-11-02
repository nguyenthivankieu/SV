using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.DAL
{
    public class DAL_MonHoc
    {
        private static DAL_MonHoc instance;

        public static DAL_MonHoc Instance
        {

            get { if (instance == null) instance = new DAL_MonHoc(); return instance; }
            private set => instance
            =
            value;
        }

        private DAL_MonHoc() { }
        public bool Them(string MaMH, string TenMH, int SoTC, int TietLT, int TietTH)
        {
            //string sql = "INSERT INTO MonHoc (MaMH,TenMH,SoTC,TietLT,TietTH) VALUES ( @MaMH, @TenMH,@SoTC,@TietLT,@TietTH,@MaLop)";//lại lệch param
            string sql = "INSERT INTO MonHoc (MaMH,TenMH,SoTC,TietLT,TietTH) VALUES ( @MaMH, @TenMH,@SoTC,@TietLT,@TietTH)";
            return KetNoi.Instance.ExcuteNonQuery(sql, new object[] { MaMH, TenMH, SoTC, TietLT, TietTH });
        }

        public bool Sua(string MaMH, string TenMH, int SoTC, int TietLT, int TietTH, int id)
        {
            string sql = "UPDATE MonHoc SET MaMH = @MaMH, TenMH = @TenMH,SoTC = @SoTC,TietLT = @TietLT,TietTH = @TietTH WHERE Id = @id";
            return KetNoi.Instance.ExcuteNonQuery(sql, new object[] { MaMH, TenMH, SoTC, TietLT, TietTH, id });
        }


        public bool Xoa(int id)
        {
            string sql = "DELETE FROM MonHoc WHERE Id = @id";
            return KetNoi.Instance.ExcuteNonQuery(sql, new object[] { id });
        }

        public DataTable DanhSach()
        {
            return KetNoi.Instance.ExcuteQuery("SELECT * FROM MonHoc");
        }
    }
}

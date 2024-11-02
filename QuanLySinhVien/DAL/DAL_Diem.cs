using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.DAL
{
    public class DAL_Diem
    {
        private static DAL_Diem instance;

        public static DAL_Diem Instance
        {

            get { if (instance == null) instance = new DAL_Diem(); return instance; }
            private set => instance
            =
            value;
        }

        private DAL_Diem() { }
        public bool Them(string MaSV, string MaMH, int PhanTramTrenLop, int PhanTramThi,float DiemTrenLop,float DiemThi,float DiemTB,string Loai,int NamHoc)
        {
            string sql = "INSERT INTO Diem (MaSV, MaMH,PhanTramTrenLop,PhanTramThi,DiemTrenLop,DiemThi,DiemTB,Loai,NamHoc) VALUES ( @MaSV, @MaMH,@PhanTramTrenLop,@PhanTramThi,@DiemTrenLop,@DiemThi,@DiemTB,@Loai,@NamHoc)";
            return KetNoi.Instance.ExcuteNonQuery(sql, new object[] { MaSV, MaMH,PhanTramTrenLop,PhanTramThi,DiemTrenLop,DiemThi,DiemTB,Loai,NamHoc });
        }

        public bool Sua(string MaSV, string MaMH, int PhanTramTrenLop, int PhanTramThi, float DiemTrenLop, float DiemThi, float DiemTB, string Loai, int NamHoc, int id)
        {
            string sql = "UPDATE Diem SET MaSV=@MaSV, MaMH=@MaMH,PhanTramTrenLop=@PhanTramTrenLop,PhanTramThi=@PhanTramThi,DiemTrenLop=@DiemTrenLop,DiemThi=@DiemThi,DiemTB=@DiemTB,Loai=@Loai,NamHoc=@NamHoc WHERE Id = @id";
            return KetNoi.Instance.ExcuteNonQuery(sql, new object[] { MaSV, MaMH, PhanTramTrenLop, PhanTramThi, DiemTrenLop, DiemThi, DiemTB, Loai, NamHoc, id });
        }


        public bool Xoa(int id)
        {
            string sql = "DELETE FROM Diem WHERE Id = @id";
            return KetNoi.Instance.ExcuteNonQuery(sql, new object[] { id });
        }

        public DataTable DanhSach()
        {
            return KetNoi.Instance.ExcuteQuery("SELECT * FROM Diem");
        }

    }
}


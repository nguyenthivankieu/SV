using QuanLySinhVien.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.BLL
{
    public class BLL_CoVanHocTap
    {
        private static BLL_CoVanHocTap instance;

        public static BLL_CoVanHocTap Instance
        {

            get { if (instance == null) instance = new BLL_CoVanHocTap(); return instance; }
            private set => instance
            =
            value;
        }

        private BLL_CoVanHocTap() { }

        public DataTable DanhSach()
        {
            return DAL_CoVanHocTap.Instance.DanhSach();
        }

        public bool Them(string MaCVHT, string TenCVHT, DateTime NgaySinh, string GioiTinh, string MaKhoa, string MaLop)
        {
            return DAL_CoVanHocTap.Instance.Them(MaCVHT, TenCVHT, NgaySinh, GioiTinh, MaKhoa, MaLop);

        }
        public bool Sua(string MaCVHT, string TenCVHT, DateTime NgaySinh, string GioiTinh, string MaKhoa, string MaLop,int id)
        {
            return DAL_CoVanHocTap.Instance.Sua(MaCVHT, TenCVHT, NgaySinh, GioiTinh, MaKhoa, MaLop, id);

        }

        public bool Xoa(int id)
        {
            return DAL_CoVanHocTap.Instance.Xoa(id);

        }

        internal bool them(string maCVHT, string tenCVHT, string ngaySinh, string gioiTinh, string maKhoa, string maLop)
        {
            throw new NotImplementedException();
        }
    }
}


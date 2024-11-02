using QuanLySinhVien.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySinhVien.GUI
{
    public partial class fQuanLyDiem : Form
    {
        public fQuanLyDiem()
        {
            InitializeComponent();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            dgvDiem.DataSource = BLL_Diem.Instance.DanhSach();
            cmbMaSV.DataSource = BLL_SinhVien.Instance.DanhSach();
            cmbMaSV.DisplayMember= "TenSV";
            cmbMaSV.ValueMember = "MaSV";
            cmbMaMH.DataSource=BLL_MonHoc.Instance.DanhSach();
            cmbMaMH.DisplayMember = "TenMH";
            cmbMaMH.ValueMember = "MaMH";
        }

        private void fQuanLyDiem_Load(object sender, EventArgs e)
        {
            btnLamMoi.PerformClick();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string MaSV = cmbMaSV.SelectedValue.ToString();
            string MaMH=cmbMaMH.SelectedValue.ToString();
            int PhanTramTrenLop=(int)numPhanTramTrenLop.Value;
            int PhanTramThi =(int)numPhanTramThi.Value;
            float DiemTrenLop = float.Parse(txbDiemTrenLop.Text);
            float DiemThi =float.Parse(txbDiemThi.Text);
            float DiemTB =float.Parse(txbDiemTB.Text);
            string Loai = cmbLoai.SelectedValue?.ToString() ?? "A";
            int NamHoc=DateTime.Now.Year;

            if (BLL_Diem.Instance.Them(MaSV, MaMH, PhanTramTrenLop, PhanTramThi, DiemTrenLop, DiemThi, DiemTB, Loai, NamHoc) == true)
                btnLamMoi.PerformClick();
        }
        //Tự Them cellclick nhu bảng Khoa Anh sủi đây
        private void btnSua_Click(object sender, EventArgs e)
        {
            int id=int.Parse(txbID.Text);
            string MaSV = cmbMaSV.SelectedValue.ToString();
            string MaMH = cmbMaMH.SelectedValue.ToString();
            int PhanTramTrenLop = (int)numPhanTramTrenLop.Value;
            int PhanTramThi = (int)numPhanTramThi.Value;
            float DiemTrenLop = float.Parse(txbDiemTrenLop.Text);
            float DiemThi = float.Parse(txbDiemThi.Text);
            float DiemTB = float.Parse(txbDiemTB.Text);
            string Loai = cmbLoai.SelectedValue?.ToString() ?? "A";//Thiếu value Loại anh không biết thêm tạm để A
            int NamHoc = DateTime.Now.Year;

            if (BLL_Diem.Instance.Sua(MaSV, MaMH, PhanTramTrenLop, PhanTramThi, DiemTrenLop, DiemThi, DiemTB, Loai, NamHoc,id) == true)
                btnLamMoi.PerformClick();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDiem.CurrentRow != null && int.TryParse(dgvDiem.CurrentRow.Cells[0].Value.ToString(), out int id))
            {
                string ten = dgvDiem.CurrentRow.Cells[1].Value.ToString().Trim();
                if (MessageBox.Show($"Bạn có muốn xóa điểm {ten}?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        if (BLL_Diem.Instance.Xoa(id))
                            btnLamMoi.PerformClick();
                    }
                    catch
                    {
                        MessageBox.Show("Phát sinh lỗi khi xóa...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy tài khoản để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}

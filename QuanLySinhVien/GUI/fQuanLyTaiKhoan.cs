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
    public partial class fQuanLyTaiKhoan : Form
    {
        public fQuanLyTaiKhoan()
        {
            InitializeComponent();
        }
        private void fQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            // Thiết lập kiểu DropDownList để người dùng chỉ có thể chọn các mục
            cmbLoaiTaiKhoan.DropDownStyle = ComboBoxStyle.DropDownList;

            // Nạp dữ liệu vào ComboBox
            cmbLoaiTaiKhoan.Items.Add("Admin");
            cmbLoaiTaiKhoan.Items.Add("User");
            cmbLoaiTaiKhoan.Items.Add("Moderator");
            // Thêm các loại tài khoản khác nếu cần
            btnLamMoi.PerformClick();
            cmbLoaiTaiKhoan.SelectedIndex = 0;

        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string tendangnhap = txbTenDangNhap.Text.Trim();
            string matkhau = txbMatKhau.Text.Trim();
            string LoaiTK = cmbLoaiTaiKhoan.SelectedItem?.ToString(); // Sử dụng toán tử điều kiện null

            if (tendangnhap.Length > 0 && matkhau.Length >= 6 && !string.IsNullOrEmpty(LoaiTK))
            {
                try
                {
                    if (BLL_TaiKhoan.Instance.Them(tendangnhap, matkhau, LoaiTK))
                        btnLamMoi.PerformClick();
                }
                catch
                {
                    MessageBox.Show("Tên đăng nhập bị trùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu không được dưới 6 ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /* private void btnThem_Click(object sender, EventArgs e)
         {
             string tendangnhap = txbTenDangNhap.Text.Trim();
             string matkhau = txbMatKhau.Text.Trim();

             // Kiểm tra xem có mục nào được chọn trong ComboBox
             if (cmbLoaiTaiKhoan.SelectedItem != null)
             {
                 string LoaiTK = cmbLoaiTaiKhoan.SelectedItem.ToString();

                 if (tendangnhap.Length > 0 && matkhau.Length >= 6 && LoaiTK.Length > 0)
                 {
                     if (BLL_TaiKhoan.Instance.Them(tendangnhap, matkhau, LoaiTK)==true)
                         btnLamMoi.PerformClick();
                 }
                 else
                 {
                     MessageBox.Show("Mật khẩu không được dưới 6 ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 }
             }
             else
             {
                 MessageBox.Show("Vui lòng chọn loại tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
             }
         }*/


        private void btnSua_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txbID.Text, out int id))
            {
                string tendangnhap = txbTenDangNhap.Text.Trim();
                string matkhau = txbMatKhau.Text.Trim();
                string LoaiTK = cmbLoaiTaiKhoan.SelectedItem?.ToString();

                if (tendangnhap.Length > 0 && !string.IsNullOrEmpty(LoaiTK))
                {
                    try
                    {
                        if (matkhau.Length == 0)
                        {
                            if (BLL_TaiKhoan.Instance.KhongSuaMatKhau(tendangnhap, LoaiTK, id))
                                btnLamMoi.PerformClick();
                        }
                        else
                        {
                            if (BLL_TaiKhoan.Instance.Sua_Het(tendangnhap, matkhau, LoaiTK, id))
                                btnLamMoi.PerformClick();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Tên đăng nhập bị trùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập và loại tài khoản không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("ID không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvTaiKhoan.CurrentRow != null && int.TryParse(dgvTaiKhoan.CurrentRow.Cells[0].Value.ToString(), out int id))
            {
                string ten = dgvTaiKhoan.CurrentRow.Cells[1].Value.ToString().Trim();
                if (MessageBox.Show($"Bạn có muốn xóa tài khoản {ten}?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        if (BLL_TaiKhoan.Instance.Xoa(id))
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


        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            dgvTaiKhoan.DataSource = BLL_TaiKhoan.Instance.DanhSach();
        }

        private void txbTenDangNhap_TextChanged(object sender, EventArgs e)
        {

        }
        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txbID.Text=dgvTaiKhoan.CurrentRow.Cells[0].Value.ToString().Trim();
            txbTenDangNhap.Text = dgvTaiKhoan.CurrentRow.Cells[1].Value.ToString().Trim();
            txbMatKhau.Text = dgvTaiKhoan.CurrentRow.Cells[2].Value.ToString().Trim();
            cmbLoaiTaiKhoan.SelectedItem = dgvTaiKhoan.CurrentRow.Cells[3].Value.ToString().Trim();
        }
    }
}

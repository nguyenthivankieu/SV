using QuanLySinhVien.BLL;
using QuanLySinhVien.DAL;
using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLySinhVien.GUI
{
    public partial class fQuanLyLop : Form
    {
        public fQuanLyLop()
        {
            InitializeComponent();
        }

        private void fQuanLyLop_Load(object sender, EventArgs e)
        {
            btnLamMoi.PerformClick();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            dgvLop.DataSource = BLL_Lop.Instance.DanhSach();
            cmbMaKhoa.DataSource = BLL_Khoa.Instance.DanhSach();
            cmbMaKhoa.DisplayMember = "TenKhoa";
            cmbMaKhoa.ValueMember = "MaKhoa";
            if (BLL_Khoa.Instance.DanhSach().Rows.Count > 0)
                cmbMaKhoa.SelectedIndex = 0;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string malop = txbMaLop.Text.Trim();
            string tenlop = txbTenLop.Text.Trim();
            string makhoa = cmbMaKhoa.SelectedValue.ToString().Trim();
            int soluong = (int)numSoLuong.Value;

            if (malop.Length > 0 && tenlop.Length > 0)
            {
                try
                {
                    if (BLL_Lop.Instance.Them(malop, tenlop, soluong, makhoa))
                        btnLamMoi.PerformClick();
                }
                catch
                {
                    MessageBox.Show("Mã lớp đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng không bỏ trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //Anh học ngu C# không biết bắt event click
        private void dgvLop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvLop.CurrentRow != null)
            {
                txbID.Text = dgvLop.CurrentRow.Cells[0].Value.ToString().Trim();
                txbMaLop.Text = dgvLop.CurrentRow.Cells[1].Value.ToString().Trim();
                txbTenLop.Text = dgvLop.CurrentRow.Cells[2].Value.ToString().Trim();
                numSoLuong.Value = (int)dgvLop.CurrentRow.Cells[3].Value; // Tránh lỗi
                cmbMaKhoa.SelectedValue = dgvLop.CurrentRow.Cells[4].Value.ToString().Trim(); // Gán giá trị cho cmbMaKhoa
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvLop.CurrentRow != null)
            {
                if (int.TryParse(dgvLop.CurrentRow.Cells[0].Value.ToString(), out int id)) // Sử dụng TryParse
                {
                    if (MessageBox.Show($"Bạn có muốn xóa lớp {txbTenLop.Text}?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            if (BLL_Lop.Instance.Xoa(id))
                            {
                                MessageBox.Show("Xóa lớp thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btnLamMoi.PerformClick(); // Làm mới dữ liệu
                            }
                            else
                            {
                                MessageBox.Show("Không thể xóa lớp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Phát sinh lỗi khi xóa: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("ID không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy lớp để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            if (int.TryParse(txbID.Text, out int id)) // Sử dụng TryParse
            {
                string malop = txbMaLop.Text.Trim();
                string tenlop = txbTenLop.Text.Trim();
                string makhoa = cmbMaKhoa.SelectedValue.ToString().Trim();
                int soluong = (int)numSoLuong.Value;

                if (malop.Length > 0 && tenlop.Length > 0)
                {
                    try
                    {
                        if (BLL_Lop.Instance.Sua(malop, tenlop, soluong, makhoa, id))
                            btnLamMoi.PerformClick();
                    }
                    catch
                    {
                        MessageBox.Show("Mã lớp đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng không bỏ trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("ID không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}

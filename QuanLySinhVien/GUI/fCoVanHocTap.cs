using QuanLySinhVien.BLL;
using QuanLySinhVien.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySinhVien.GUI
{
    public partial class fCoVanHocTap : Form
    {
        public fCoVanHocTap()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbMaKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvCoVanHocTap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbMaLop_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void rdNu_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdNam_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        
        private void dtpkNgaySinh_ValueChanged(object sender, EventArgs e)
        {

        }
        //cái này tự làm đi coi bàng lớp ấy
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txbID.Text, out int id)) // Sử dụng TryParse để kiểm tra ID hợp lệ
            {
                string MaCVHT = txbMaCVHT?.Text.Trim() ?? string.Empty;
                string TenCVHT = txbTenCVHT?.Text.Trim() ?? string.Empty;
                DateTime NgaySinh = dtpkNgaySinh.Value;
                string GioiTinh = rdNam.Checked ? "Nam" : "Nữ";

                // Kiểm tra giá trị SelectedValue để đảm bảo không có lỗi null
                string MaKhoa = cmbMaKhoa.SelectedValue?.ToString() ?? string.Empty;
                string MaLop = cmbMaLop.SelectedValue?.ToString() ?? string.Empty;

                if (!string.IsNullOrEmpty(MaCVHT) && !string.IsNullOrEmpty(TenCVHT) && !string.IsNullOrEmpty(MaKhoa) && !string.IsNullOrEmpty(MaLop))
                {
                    try
                    {
                        if (BLL_CoVanHocTap.Instance.Sua(MaCVHT, TenCVHT, NgaySinh, GioiTinh, MaKhoa, MaLop, id))
                            btnLamMoi.PerformClick();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng không bỏ trống và chọn giá trị hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("ID không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }




        //private void btnSua_Click(object sender, EventArgs e)
        //{
        //    string MaCVHT = txbMaCVHT.Text.Trim();
        //    string TenCVHT = txbTenCVHT.Text.Trim();
        //    DateTime NgaySinh = dtpkNgaySinh.Value;
        //    string GioiTinh = rdNam.Checked ? "Nam" : "Nữ";
        //    string MaKhoa = cmbMaKhoa.SelectedValue.ToString();
        //    string MaLop = cmbMaLop.SelectedValue.ToString();
        //    int id = int.Parse(txbID.Text);
        //    if (string.IsNullOrEmpty(MaCVHT) || string.IsNullOrEmpty(TenCVHT))
        //    {
        //        MessageBox.Show("Vui lòng không để trống mã và tên cố vấn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }



        //    try
        //    {
        //        if (BLL_CoVanHocTap.Instance.Sua(MaCVHT, TenCVHT, NgaySinh, GioiTinh, MaKhoa, MaLop, id))
        //        {
        //            MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            LoadData(); // Refresh data
        //        }
        //        else
        //        {
        //            MessageBox.Show("Thêm không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Lỗi khi thêm: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        private void LoadData()
        {
            dgvCoVanHocTap.DataSource = BLL_CoVanHocTap.Instance.DanhSach();
            cmbMaKhoa.DataSource = BLL_Khoa.Instance.DanhSach();
            cmbMaKhoa.DisplayMember = "TenKhoa";
            cmbMaKhoa.ValueMember = "MaKhoa";
            cmbMaLop.DataSource = BLL_Lop.Instance.DanhSach();
            cmbMaLop.DisplayMember = "TenLop";
            cmbMaLop.ValueMember = "MaLop"; // Ensure this is the correct value member
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbID.Text))
            {
                MessageBox.Show("Vui lòng chọn một cố vấn để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = int.Parse(txbID.Text);
            string MaCVHT = txbMaCVHT.Text;

            if (MessageBox.Show($"Bạn có muốn xóa Cố Vấn {MaCVHT}?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (BLL_CoVanHocTap.Instance.Xoa(id))
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData(); // Refresh data
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa cố vấn này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            dgvCoVanHocTap.DataSource = BLL_CoVanHocTap.Instance.DanhSach();
            cmbMaKhoa.DataSource =BLL_Khoa.Instance.DanhSach();
            cmbMaKhoa.DisplayMember = "TenKhoa";
            cmbMaKhoa.ValueMember = "MaKhoa";
            cmbMaLop.DataSource =BLL_Lop.Instance.DanhSach();  
            cmbMaLop.DisplayMember = "TenLop";
            cmbMaLop.ValueMember = "MaLop";//Fuck
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            string MaCVHT = txbMaCVHT.Text.Trim();
            string TenCVHT = txbTenCVHT.Text.Trim();
            DateTime NgaySinh = dtpkNgaySinh.Value;
            string GioiTinh = rdNam.Checked ? "Nam" : "Nữ";
            string MaKhoa = cmbMaKhoa.SelectedValue.ToString();//sao mã khoa đúng mà mã lớp sai ta
            string MaLop = cmbMaLop.SelectedValue.ToString();

            if (string.IsNullOrEmpty(MaCVHT) || string.IsNullOrEmpty(TenCVHT))
            {
                MessageBox.Show("Vui lòng không để trống mã và tên cố vấn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

         
            try
            {
                if (BLL_CoVanHocTap.Instance.Them(MaCVHT, TenCVHT, NgaySinh, GioiTinh, MaKhoa, MaLop))
                {
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(); // Refresh data
                }
                else
                {
                    MessageBox.Show("Thêm không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txbTenCVHT_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txbMaCVHT_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txbID_TextChanged(object sender, EventArgs e)
        {

        }

        private void fCoVanHocTap_Load(object sender, EventArgs e)
        {
            btnLamMoi.PerformClick();
        }
        private void dgvCoVanHocTap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCoVanHocTap.CurrentRow != null)
            {
                txbID.Text = dgvCoVanHocTap.CurrentRow.Cells[0].Value.ToString();
                txbMaCVHT.Text = dgvCoVanHocTap.CurrentRow.Cells[1].Value.ToString();
                txbTenCVHT.Text = dgvCoVanHocTap.CurrentRow.Cells[2].Value.ToString();
                dtpkNgaySinh.Value = Convert.ToDateTime(dgvCoVanHocTap.CurrentRow.Cells[3].Value);
                string gioiTinh = dgvCoVanHocTap.CurrentRow.Cells[4].Value.ToString().Trim();
                rdNam.Checked = (gioiTinh == "Nam");
                rdNu.Checked = (gioiTinh == "Nữ");
                cmbMaKhoa.SelectedValue = dgvCoVanHocTap.CurrentRow.Cells[5].Value.ToString();
                cmbMaLop.SelectedValue = dgvCoVanHocTap.CurrentRow.Cells[6].Value.ToString();
            }
        }

    }

}

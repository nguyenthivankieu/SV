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
    public partial class fSinhVien : Form
    {
        private object btnQuanLy;

        public fSinhVien()
        {
            InitializeComponent();
            //Lấy data tà db khi vừa vào UI
            button2_Click(null, null);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string masv=txbMaSV.Text;
            string tensv=txbTenSV.Text;
            string ngaysinh =dtpkNgaySinh.Value.ToShortDateString();
            string gioitinh = (rdNam.Checked == true) ? "Nam" : "Nữ";
            string quequan =txbQueQuan.Text;
            string ngaynhaphoc =dtpkNgayNhapHoc.Value.ToShortDateString();
            string malop =cmbMaLop.SelectedValue.ToString();
            string makhoa =cmbMaKhoa.SelectedValue.ToString();
            string macvht =cmbMaCVHT.SelectedValue.ToString();
            if(BLL_SinhVien.Instance.Them(masv,tensv,ngaysinh,gioitinh, quequan, ngaynhaphoc, malop,makhoa,macvht)==true)
                btnLamMoi.PerformClick();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id =int.Parse(txbID.Text);
            string masv = txbMaSV.Text;
            string tensv = txbTenSV.Text;
            string ngaysinh = dtpkNgaySinh.Value.ToShortDateString();
            string gioitinh = (rdNam.Checked == true) ? "Nam" : "Nữ";
            string quequan = txbQueQuan.Text;
            string ngaynhaphoc = dtpkNgayNhapHoc.Value.ToShortDateString();
            string malop = cmbMaLop.SelectedValue.ToString();
            string makhoa = cmbMaKhoa.SelectedValue.ToString();
            string macvht = cmbMaCVHT.SelectedValue.ToString();
            if (BLL_SinhVien.Instance.Sua(masv, tensv, ngaysinh, gioitinh, quequan, ngaynhaphoc, malop, makhoa, macvht,id) == true)
                btnLamMoi.PerformClick();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id;
            if (int.TryParse(txbID.Text, out id))
            {
                string MaSV = txbMaSV.Text;
                if (MessageBox.Show($"Bạn có muốn xóa Sinh Vien {MaSV}?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (BLL_SinhVien.Instance.Xoa(id) == true)
                        btnLamMoi.PerformClick();
                }
            }
            else
            {
                MessageBox.Show("ID không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dgvSinhVien.DataSource = BLL_SinhVien.Instance.DanhSach();
            cmbMaCVHT.DataSource= BLL_CoVanHocTap.Instance.DanhSach();
            cmbMaCVHT.DisplayMember = "TenCVHT";
            cmbMaCVHT.ValueMember = "MaCVHT";
            cmbMaKhoa.DataSource=BLL_Khoa.Instance.DanhSach();
            cmbMaKhoa.DisplayMember = "TenKhoa";
            cmbMaKhoa.ValueMember = "MaKhoa";
            cmbMaLop.DataSource=BLL_Lop.Instance.DanhSach();
            cmbMaLop.DisplayMember = "TenLop";
            cmbMaLop.ValueMember = "MaLop";
        }

        private void quảnLýTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fQuanLyTaiKhoan f = new fQuanLyTaiKhoan();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void quảnLýToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fQuanLyKhoa f = new fQuanLyKhoa();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void quảnLýLớpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fQuanLyLop f = new fQuanLyLop();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void quảnLýCốVấnHọcTậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fCoVanHocTap f = new fCoVanHocTap();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void quảnLýMônHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fQuanLyMonHoc f = new fQuanLyMonHoc();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void quảnLýDiểmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fQuanLyDiem f = new fQuanLyDiem();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new fThongTinChiTiet().ShowDialog();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new fDoiMatKhau().ShowDialog();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void fSinhVien_Load(object sender, EventArgs e)
        {
            //if (HeThong.LOAITAIKHOAN != "Quản Trị")
            //{
            //    btnQuanLy.Visible = false;  // Hide button if not "Quản Trị"
            //}
            //else

            //    btnQuanLy.Visible = true;    // Show button if "Quản Trị"
            //btnTaiLai.PerformClick();
        }

        private void quảnLýToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void dgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txbID.Text=dgvSinhVien.CurrentRow.Cells[0].Value.ToString();
            txbMaSV.Text = dgvSinhVien.CurrentRow.Cells[1].Value.ToString();
            txbTenSV.Text = dgvSinhVien.CurrentRow.Cells[2].Value.ToString();
            dtpkNgaySinh.Value =(DateTime) dgvSinhVien.CurrentRow.Cells[3].Value;
            if(dgvSinhVien.CurrentRow.Cells[4].Value.ToString().Trim()=="Nam")
                rdNam.Checked = true;
            else
                rdNu.Checked = true;
            txbQueQuan.Text = dgvSinhVien.CurrentRow.Cells[5].Value.ToString();
            dtpkNgayNhapHoc.Value = (DateTime)dgvSinhVien.CurrentRow.Cells[6].Value;
            cmbMaLop.SelectedValue = dgvSinhVien.CurrentRow.Cells[7].Value.ToString();
            cmbMaKhoa.SelectedValue = dgvSinhVien.CurrentRow.Cells[8].Value.ToString();
            cmbMaCVHT.SelectedValue = dgvSinhVien.CurrentRow.Cells[9].Value.ToString();
        }
    }

    }



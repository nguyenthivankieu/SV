using QuanLySinhVien.BLL;
using QuanLySinhVien.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class fDangNhap : Form
    {
        public fDangNhap()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            //string tendangnhap = txbTenDangNhap.Text;
            //string matkhau = txbMatKhau.Text;
            //if(BLL_TaiKhoan.Instance.DangNhap(tendangnhap,matkhau)==true)
            //{
                txbMatKhau.Clear();
                fSinhVien f = new fSinhVien();
                this.Hide();
                f.ShowDialog();
                this.Close();
            //}
            //else
            //{
            //    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng", "Thông báo",  MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}

            
        }

        private void fDangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}

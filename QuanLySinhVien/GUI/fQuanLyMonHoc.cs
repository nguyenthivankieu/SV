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
    public partial class fQuanLyMonHoc : Form
    {
        public fQuanLyMonHoc()
        {
            InitializeComponent();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            dgvMonHoc.DataSource = BLL_MonHoc.Instance.DanhSach();

        }
        //private void dgvMonHoc_CellClck(object sender, DataGridViewCellEventArgs e)
        //{
        //    txbID.Text = dgvMonHoc.CurrentRow.Cells[0].Value.ToString().Trim();
        //    txbMaMH.Text = dgvMonHoc.CurrentRow.Cells[1].Value.ToString().Trim();
        //    txbTenMH.Text = dgvMonHoc.CurrentRow.Cells[2].Value.ToString().Trim();
        //    numSoTC.Value = int.Parse(dgvMonHoc.CurrentRow.Cells[3].Value.ToString());
        //    numTietLT.Value = int.Parse(dgvMonHoc.CurrentRow.Cells[4].Value.ToString());
        //    numTietTH.Value = int.Parse(dgvMonHoc.CurrentRow.Cells[5].Value.ToString());

        //}

        private void numSoTC_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string MaMH = txbMaMH.Text;
                string TenMH = txbTenMH.Text;
                int SoTC = (int)numSoTC.Value;
                int TietLT = (int)numTietLT.Value;
                int TietTH = (int)numTietTH.Value;

                if (BLL_MonHoc.Instance.Them(MaMH, TenMH, SoTC, TietLT, TietTH))
                    btnLamMoi.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in btnThem: {ex.Message}");
            }
        }

        //private void btnXoa_Click(object sender, EventArgs e)
        //{
        //    int id =int.Parse(txbID.Text);
        //    string MaMH = txbMaMH.Text;
        //    if(MessageBox.Show($"Bạn có muốn xoa môn học {MaMH}?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
        //    {
        //        if (BLL_MonHoc.Instance.Xoa(id) == true)
        //            btnLamMoi.PerformClick();
        //    }    
        //}
        private void dgvMonHoc_CellClick(object sender, DataGridViewCellEventArgs e)//Them event vào cell
        {
            if (dgvMonHoc.CurrentRow != null)
            {
                try
                {
                    // Log or check cell values
                    var cellValue = dgvMonHoc.CurrentRow.Cells[3].Value;
                    //MessageBox.Show($"Cell Value: {cellValue}");

                    txbID.Text = dgvMonHoc.CurrentRow.Cells[0].Value.ToString().Trim();
                    txbMaMH.Text = dgvMonHoc.CurrentRow.Cells[1].Value.ToString().Trim();
                    txbTenMH.Text = dgvMonHoc.CurrentRow.Cells[2].Value.ToString().Trim();

                    int soTC, tietLT, tietTH;
                    if (int.TryParse(dgvMonHoc.CurrentRow.Cells[3].Value?.ToString(), out soTC))
                    {
                        numSoTC.Value = soTC;
                    }
                    else
                    {
                        MessageBox.Show("Invalid value for SoTC.");
                    }

                    if (int.TryParse(dgvMonHoc.CurrentRow.Cells[4].Value?.ToString(), out tietLT))
                    {
                        numTietLT.Value = tietLT;
                    }
                    else
                    {
                        MessageBox.Show("Invalid value for TietLT.");
                    }

                    if (int.TryParse(dgvMonHoc.CurrentRow.Cells[5].Value?.ToString(), out tietTH))
                    {
                        numTietTH.Value = tietTH;
                    }
                    else
                    {
                        MessageBox.Show("Invalid value for TietTH.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            int id;
            if (int.TryParse(txbID.Text, out id))
            {
                string MaMH = txbMaMH.Text;
                if (MessageBox.Show($"Bạn có muốn xóa môn học {MaMH}?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (BLL_MonHoc.Instance.Xoa(id) == true)
                        btnLamMoi.PerformClick();
                }
            }
            else
            {
                MessageBox.Show("ID không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txbID.Text);
            string MaMH = txbMaMH.Text;
            string TenMH = txbTenMH.Text;
            int SoTC = (int)numSoTC.Value;
            int TietLT = (int)numTietLT.Value;
            int TietTH = (int)numTietTH.Value;

            if (BLL_MonHoc.Instance.Sua(MaMH, TenMH, SoTC, TietLT, TietTH,id) == true)
                btnLamMoi.PerformClick();
        }

        private void fQuanLyMonHoc_Load(object sender, EventArgs e)
        {
            btnLamMoi.PerformClick();
        }
    }
}

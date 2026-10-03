using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.AccessControl;
using System.Text;
using System.Windows.Forms;
using WinFormsApp1.Entity;

namespace WinFormsApp1
{
    public partial class frmungdungquanlysv : Form
    {
        private List<SinhVien> sinhvien = new List<SinhVien>();
        private List<LopHoc> lopHocs = new List<LopHoc>();

        public frmungdungquanlysv()
        {
            InitializeComponent();
            // Load sample data after components are initialized
            LoadData();
        }

        private void frmungdungquanlysv_Load(object sender, EventArgs e)
        {
            // already loaded in constructor; kept for designer hookup
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Refresh / clear inputs - placeholder
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoadData()
        {
            // sample classes
            lopHocs = new List<LopHoc>
            {
                new LopHoc { MaLop = "LOP1001", TenLop = "10A1" },
                new LopHoc { MaLop = "LOP1002", TenLop = "10A2" }
            };

            // sample students
            sinhvien = new List<SinhVien>
            {
                new SinhVien { MaSV = "SV001", HoTen = "Nguyen Van A", NgaySinh = new DateTime(2003,1,15), GioiTinh = "Nam", Lop = "10A1", Diem = 8.5 },
                new SinhVien { MaSV = "SV002", HoTen = "Tran Thi B", NgaySinh = new DateTime(2003,5,20), GioiTinh = "Nu", Lop = "10A2", Diem = 7.2 },
                new SinhVien { MaSV = "SV003", HoTen = "Le Van C", NgaySinh = new DateTime(2002,11,3), GioiTinh = "Nam", Lop = "10A1", Diem = 9.1 }
            };

            // bind to DataGridView
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = new BindingList<SinhVien>(sinhvien);
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
        private void label12_Click(object sender, EventArgs e)
        {
            // placeholder for designer event
        }
    }
}

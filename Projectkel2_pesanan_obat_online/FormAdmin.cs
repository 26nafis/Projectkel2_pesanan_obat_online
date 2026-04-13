using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projectkel2_pesanan_obat_online
{
    public partial class FormAdmin : Form
    {
        string namaUser;

        public FormAdmin()
        {
            InitializeComponent();
        }


        public FormAdmin(string nama)
        {
            InitializeComponent();
            namaUser = nama;
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            label1.Text = "Dashboard Admin\nSelamat datang, " + namaUser;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormObat f = new FormObat();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            login.Show();
            this.Hide();
        }
    }
}

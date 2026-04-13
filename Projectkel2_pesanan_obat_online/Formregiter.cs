using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Projectkel2_pesanan_obat_online
{
    public partial class Formregiter : Form
    {
        SqlConnection conn;
        SqlCommand cmd;

        public Formregiter()
        {
            InitializeComponent();

            conn = new SqlConnection("Data Source=NAFIS\\NAFISCOY;Initial Catalog=ApotekDB;Integrated Security=True");

            txtPassword.UseSystemPasswordChar = true;
        }

        private void Formregiter_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNama.Text == "" || txtEmail.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Semua field wajib diisi!");
                return;
            }

            try
            {
                conn.Open();

                SqlCommand cek = new SqlCommand(
                "SELECT COUNT(*) FROM akun WHERE email=@email", conn);

                cek.Parameters.AddWithValue("@email", txtEmail.Text);

                int ada = (int)cek.ExecuteScalar();

                if (ada > 0)
                {
                    MessageBox.Show("Email sudah terdaftar!");
                    conn.Close();
                    return;
                }
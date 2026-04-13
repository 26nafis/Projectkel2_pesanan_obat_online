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
    public partial class Form1 : Form
    {
        SqlConnection conn;
        SqlCommand cmd;

        public Form1()
        {
            InitializeComponent();

            conn = new SqlConnection("Data Source=NAFIS\\NAFISCOY;Initial Catalog=ApotekDB;Integrated Security=True");

            txtPassword.UseSystemPasswordChar = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Email dan Password wajib diisi!");
                return;
            }

            try
            {
                conn.Open();

                cmd = new SqlCommand(
                "SELECT * FROM akun WHERE email=@email AND password=@password", conn);

                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@password", txtPassword.Text);

                SqlDataReader rd = cmd.ExecuteReader();

                if (rd.Read())
                {
                    string nama = rd["nama"].ToString();
                    string role = rd["role"].ToString();

                    MessageBox.Show("Login Berhasil! Selamat datang " + nama);

                    // 🔥 PEMISAHAN DASHBOARD
                    if (role == "admin")
                    {
                        FormAdmin admin = new FormAdmin(nama);
                        admin.Show();
                    }
                    else
                    {
                        FormCustomer cust = new FormCustomer(nama);
                        cust.Show();
                    }

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Login Gagal!");

                    txtPassword.Clear();
                    txtEmail.Focus();
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormRegister reg = new FormRegister();
            reg.Show();
        }
    }
}
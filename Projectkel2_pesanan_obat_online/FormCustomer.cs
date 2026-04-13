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
    public partial class FormCustomer : Form
    {
        SqlConnection conn;
        string namaUser;

        public FormCustomer()
        {
            InitializeComponent();

            conn = new SqlConnection("Data Source=NAFIS\\NAFISCOY;Initial Catalog=ApotekDB;Integrated Security=True");
        }

        public FormCustomer(string nama)
        {
            InitializeComponent();

            namaUser = nama;

            conn = new SqlConnection("Data Source=NAFIS\\NAFISCOY;Initial Catalog=ApotekDB;Integrated Security=True");
        }

        private void FormCustomer_Load(object sender, EventArgs e)
        {
            label1.Text = "Dashboard Customer\nHalo, " + namaUser;
            tampilObat();
        }
        void tampilObat()
        {
            try
            {
                conn.Open();

                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM obat", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                conn.Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            tampilObat();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            login.Show();
            this.Hide();
        }
    }
}







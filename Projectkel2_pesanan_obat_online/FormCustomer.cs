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


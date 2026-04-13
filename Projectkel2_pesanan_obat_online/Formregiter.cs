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

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

namespace İlişkili_Tablolar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source = EMIRMONSTER\\SQLEXPRESS;Initial Catalog=SehirlerListesi;Integrated Security=True");

        private void Form1_Load(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select SehirAd From Tbl_Sehirler",baglan);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }
            baglan.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            baglan.Open();
            SqlCommand komut2 = new SqlCommand("Select ilcead from tbl_ilçeler where ilid=@1",baglan);
            komut2.Parameters.AddWithValue("@p1", comboBox1.SelectedIndex +1);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                comboBox2.Items.Add(dr2[0]);
            }
            baglan.Close();
        }
    }
}

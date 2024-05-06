using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace YolcuBiletSistemi
{
    public partial class Bilet_Sorgu_Kontrol : Form
    {
        public Bilet_Sorgu_Kontrol()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-GO1G284\\SQLEXPRESS;Initial Catalog=YolcuBilet;Integrated Security=True");

        private void txtAdSoyad_TextChanged(object sender, EventArgs e) //İsme göre bilet sorgusu
        {
            string metin = "%" + txtAdSoyad.Text + "%";
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("Select * from TBLBILETLER where AD_SOYAD like @metin", conn);
            cmd.Parameters.AddWithValue("@metin", metin);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void txtKalkisVaris_TextChanged(object sender, EventArgs e) //kalkış-varış yönüne göre bilet sorgusu
        {
            string metin = "%" + txtKalkisVaris.Text + "%";
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("Select * from TBLBILETLER where KALKIS_VARIS like @metin", conn);
            cmd.Parameters.AddWithValue("@metin", metin);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void mskTCNO_TextChanged(object sender, EventArgs e) //bilet sahibinin TC Kimlik Numarasına göre bilet sorgusu
        {
            string tc = Convert.ToString(mskTCNO.Text);
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT * FROM TBLBILETLER WHERE TC LIKE @tc+'%'", conn);
            cmd.Parameters.AddWithValue("@tc", tc);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) //Bileti detaylı görüntüleme.
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            lblBiletADS.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            lblBiletKV.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            lblBiletTarih.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            lblBiletKoltuk.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();

            txtAdSoyad.Text = "";
            mskTCNO.Text = "";
            txtKalkisVaris.Text = "";
        }
    }
}

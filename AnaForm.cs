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

namespace YolcuBiletSistemi
{
    public partial class AnaForm : Form
    {
        public AnaForm()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-GO1G284\\SQLEXPRESS;Initial Catalog=YolcuBilet;Integrated Security=True");
        string connString = "Data Source=DESKTOP-GO1G284\\SQLEXPRESS;Initial Catalog = YolcuBilet; Integrated Security = True";

        void SeferListele()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TBLSEFERBILGI where SEFERDURUM=1", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        void koltukdurum()  //seçilen sefere göre dolu veya boş koltukları görüntüleme.
        {

            Button[] buttons = { K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11 }; //tum koltuk butonlarını tek bir dizide topladım

            foreach (Button btn in buttons)
            {
                btn.BackColor = Color.DarkSeaGreen; //arka planı default renk yaptım. Bu işlem olmasaydı bir önce sectigim sefere ait koltuklar hala kırmızı kalıyordu.
            }

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * from TBLBILETLER where SEFERNO = @seferNo ", conn);
            da.SelectCommand.Parameters.AddWithValue("@seferNo", txtRzvSeferNo.Text);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                string seatNumber = dr["KOLTUK"].ToString().Trim();
                Button button = this.Controls.Find(seatNumber, true).FirstOrDefault() as Button;

                if (button != null)
                {

                    button.BackColor = Color.Red;
                }
            }
        }

        void KaptanListeleCMB() //kaptanları combobxa çekme
        {

            SqlDataAdapter da = new SqlDataAdapter("SELECT ADSOYAD,KAPTANNO FROM TBLKAPTAN", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cmbKaptan.DisplayMember = "ADSOYAD";
            cmbKaptan.ValueMember = "KAPTANNO";
            cmbKaptan.DataSource = dt;
            cmbKaptan.Text = "";
        }

        void butonInaktif()
        {
            btnKaydet.Enabled = false;
            btnSeferAktiflestir.Enabled = false;
            btnSeferKaldır.Enabled = false;
            btnSeferIptal.Enabled = false;
        }

        void butonAktif()
        {
            btnKaydet.Enabled = true;
            btnSeferAktiflestir.Enabled = true;
            btnSeferKaldır.Enabled = true;
            btnSeferIptal.Enabled = true;
        }

        void Temizle()
        {
            List<Control> tumKontroller = new List<Control>();
            tumKontroller.AddRange(groupBox1.Controls.Cast<Control>());
            tumKontroller.AddRange(groupBox2.Controls.Cast<Control>());
            tumKontroller.AddRange(groupBox3.Controls.Cast<Control>());
            tumKontroller.AddRange(groupBox4.Controls.Cast<Control>());

            foreach (Control control in tumKontroller)
                if (control is TextBox)
                {
                    TextBox textBox = (TextBox)control;
                    textBox.Text = "";
                }
                else if (control is MaskedTextBox)
                {
                    MaskedTextBox mskBox = (MaskedTextBox)control;
                    mskBox.Text = "";
                }

            foreach (Control control in groupBox1.Controls)
            {
                if (control is Button)
                {
                    Button button = (Button)control;
                    button.BackColor = Color.DarkSeaGreen;
                }
            }
            lblSefer.Text = "";
            lblKoltukBilgi.Text = "";
            cmbKalkis.Text = "";
            cmbVaris.Text = "";
            btnBiletIptal.Enabled = false;
            butonInaktif();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SeferListele();
            KaptanListeleCMB();
            butonInaktif();

            K1.Click += KoltukClick; //eventi butonların doubleclickine bağladım 
            K2.Click += KoltukClick;
            K3.Click += KoltukClick;
            K4.Click += KoltukClick;
            K5.Click += KoltukClick;
            K6.Click += KoltukClick;
            K7.Click += KoltukClick;
            K8.Click += KoltukClick;
            K9.Click += KoltukClick;
            K10.Click += KoltukClick;
            K11.Click += KoltukClick;

        }

        private void KoltukClick(object sender, EventArgs e)
        {
            Button button = sender as Button; //Secilen koltuk doluysa
            if (button != null)
            {
                btnBiletIptal.Enabled = true;
                btnKaydet.Enabled = false;
                txtKoltukNo.Text = "K" + button.Text;
            }

            Button tiklananButon = sender as Button; //TIKLANAN KOLTUKTA KIMIN OLDUGUNU GOSTERME.
            if (tiklananButon != null && tiklananButon.BackColor == Color.Red)
            {

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT AD_SOYAD FROM TBLBILETLER where SEFERNO=@sfrno and KOLTUK=@k", conn);
                    cmd.Parameters.AddWithValue("@sfrno", txtRzvSeferNo.Text);
                    cmd.Parameters.AddWithValue("@k", txtKoltukNo.Text);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        lblKoltukBilgi.Text = dr[0].ToString();
                    }
                }
            }
            else
            {
                btnBiletIptal.Enabled = false;
                btnKaydet.Enabled = true;
                lblKoltukBilgi.Text = "";
            }
        }

        string kalkisvaris, tarihsaat;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtRzvSeferNo.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            koltukdurum();

            //textBox1.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();

            kalkisvaris = dataGridView1.Rows[secilen].Cells[1].Value + "-" + dataGridView1.Rows[secilen].Cells[2].Value;
            tarihsaat = dataGridView1.Rows[secilen].Cells[3].Value + " " + dataGridView1.Rows[secilen].Cells[4].Value;

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select KALKIS,VARIS,SAAT from TBLSEFERBILGI where SEFERNO=" + txtRzvSeferNo.Text, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    lblSefer.Text = (dr["KALKIS"] + "-" + dr["VARIS"] + " " + dr["SAAT"]).ToUpper();
                }
                conn.Close();
            }
            catch (Exception)
            {
                return;
            }
            butonAktif();
            lblKoltukBilgi.Text = "";
            txtKoltukNo.Text = "";
        }

        private void btnBiletIptal_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Delete from TBLBILETLER where KOLTUK=@kno and SEFERNO=@sno", conn);
                cmd.Parameters.AddWithValue("@kno", txtKoltukNo.Text);
                cmd.Parameters.AddWithValue("@sno", txtRzvSeferNo.Text);
                cmd.ExecuteNonQuery();
            }
            koltukdurum();
            MessageBox.Show("Bilet iptal edilmiştir");
            Temizle();
            SeferListele();
        }


        private void btnKaydet_Click(object sender, EventArgs e) //BİLET OLUŞTURMA
        {
            foreach (Control control in groupBox2.Controls)
            {
                if (control is TextBox || control is MaskedTextBox)
                {
                    if (string.IsNullOrEmpty(control.Text) || mskTel.Text.Length < mskTel.Mask.Length || mskTc.Text.Length < mskTc.Mask.Length)
                    {
                        MessageBox.Show("Tüm alanları eksiksiz doldurunuz");
                        return; // Hata durumunda geri dön
                    }
                }
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO TBLBILETLER (SEFERNO,KOLTUK,AD_SOYAD,KALKIS_VARIS,TARIH_SAAT,TELEFON,TC) VALUES(@sno,@k,@ads,@kv,@ts,@tel,@tc)", conn);
                    cmd.Parameters.AddWithValue("@sno", txtRzvSeferNo.Text);
                    cmd.Parameters.AddWithValue("@k", txtKoltukNo.Text);
                    cmd.Parameters.AddWithValue("@ads", txtAd.Text + " " + txtSoyad.Text);
                    cmd.Parameters.AddWithValue("@kv", kalkisvaris);
                    cmd.Parameters.AddWithValue("@ts", tarihsaat);
                    cmd.Parameters.AddWithValue("@tel", mskTel.Text);
                    cmd.Parameters.AddWithValue("@tc", mskTc.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("YOLCU KAYDI YAPILMIŞTIR");

                    Temizle();
                    SeferListele();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Seferde kayıtlı olan bir yolcuya bilet oluşturmaya çalışıyorsunuz, TC Kimlik numarasını kontrol edin.");
                return;
                mskTc.Focus();
            }
        }

        private void btnKaptanEkle_Click(object sender, EventArgs e) //KAPTAN KAYIT
        {
            if (string.IsNullOrEmpty(txtKaptanNo.Text) || string.IsNullOrEmpty(txtKaptanAdSyd.Text) || mskKaptanTel.Text.Length < mskKaptanTel.Mask.Length) //**********
            {
                MessageBox.Show("Tüm alanları doldurunuz");
                return;
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO TBLKAPTAN (KAPTANNO,ADSOYAD,TELEFON) VALUES(@p1,@p2,@p3)", conn);
                    cmd.Parameters.AddWithValue("@p1", txtKaptanNo.Text);
                    cmd.Parameters.AddWithValue("@p2", txtKaptanAdSyd.Text);
                    cmd.Parameters.AddWithValue("@p3", mskKaptanTel.Text);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("KAPTAN KAYDI YAPILMIŞTIR");
                KaptanListeleCMB();
                Temizle();
            }
        }

        private void btnSeferOlstr_Click(object sender, EventArgs e)
        {
            foreach (Control control in groupBox3.Controls)
            {
                if (control is TextBox || control is MaskedTextBox)
                {
                    if (string.IsNullOrEmpty(control.Text) || mskTarih.Text.Length < mskTarih.Mask.Length || mskSaat.Text.Length < mskSaat.Mask.Length)
                    {
                        MessageBox.Show("Tüm alanları eksiksiz doldurduğunuzdan emin olun");
                        return;
                    }
                }
            }
            if (cmbKaptan.Text == "")
            {
                MessageBox.Show("Kaptan seçimi boş bırakılamaz");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO TBLSEFERBILGI (KALKIS,VARIS,TARIH,SAAT,KAPTAN,BILET_FIYATI) VALUES(@1,@2,@3,@4,@5,@6)", conn);
                cmd.Parameters.AddWithValue("@1", cmbKalkis.Text);
                cmd.Parameters.AddWithValue("@2", cmbVaris.Text);
                cmd.Parameters.AddWithValue("@3", mskTarih.Text);
                cmd.Parameters.AddWithValue("@4", mskSaat.Text);
                cmd.Parameters.AddWithValue("@5", cmbKaptan.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@6", txtFiyat.Text);
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("SEFER OLUŞTURULMUŞTUR");
            cmbKaptan.Text = "";
            SeferListele();
            Temizle();
        }


        private void btnSeferler_Tarih_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT * FROM TBLSEFERBILGI WHERE TARIH=@p1", conn);
            cmd.Parameters.AddWithValue("@p1", dateTimePicker1.Value.Date.ToString("dd.MM.yyyy"));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void txtSeferAra_TextChanged(object sender, EventArgs e)
        {
            string metin = "%" + txtSeferAra.Text + "%";
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("Select * from TBLSEFERBILGI where VARIS like @metin", conn);
            cmd.Parameters.AddWithValue("@metin", metin);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }


        private void btnSeferIptal_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Update TBLSEFERBILGI set SEFERDURUM=0 where SEFERNO=@sno", conn);
                cmd.Parameters.AddWithValue("@sno", txtRzvSeferNo.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sefer iptal edilmiştir");
            }
            txtRzvSeferNo.Text = "";
        }

        private void btnSeferAktiflestir_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Update TBLSEFERBILGI set SEFERDURUM=1 where SEFERNO=@sno", conn);
                cmd.Parameters.AddWithValue("@sno", txtRzvSeferNo.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sefer aktif edilmiştir");
            }
            SeferListele();
            txtRzvSeferNo.Text = "";
        }

        private void btnDoluSeferler_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TBLSEFERBILGI WHERE SEFERDURUM=0", conn);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnSeferKaldır_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Emin misiniz?", "Sefer Silme Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Delete from TBLSEFERBILGI where SEFERNO=@sno", conn);
                    cmd.Parameters.AddWithValue("@sno", txtRzvSeferNo.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sefer sistemden kaldırılmıştır.");
                }
            }
            txtRzvSeferNo.Text = "";
            SeferListele();
        }

        private void btnBosSeferler_Click(object sender, EventArgs e)
        {
            SeferListele();
        }

        private void bnBiletKontrol_Click(object sender, EventArgs e) //Bilet Sorgu/Kontrol formuna yönlendirme
        {
            Bilet_Sorgu_Kontrol fr = new Bilet_Sorgu_Kontrol();
            fr.Show();
        }

    }
}

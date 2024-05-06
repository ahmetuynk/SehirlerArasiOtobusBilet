namespace YolcuBiletSistemi
{
    partial class Bilet_Sorgu_Kontrol
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bilet_Sorgu_Kontrol));
            this.txtAdSoyad = new System.Windows.Forms.TextBox();
            this.txtKalkisVaris = new System.Windows.Forms.TextBox();
            this.mskTCNO = new System.Windows.Forms.MaskedTextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblBiletADS = new System.Windows.Forms.Label();
            this.lblBiletKV = new System.Windows.Forms.Label();
            this.lblBiletTarih = new System.Windows.Forms.Label();
            this.lblBiletKoltuk = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAdSoyad
            // 
            this.txtAdSoyad.Location = new System.Drawing.Point(42, 52);
            this.txtAdSoyad.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAdSoyad.Name = "txtAdSoyad";
            this.txtAdSoyad.Size = new System.Drawing.Size(203, 30);
            this.txtAdSoyad.TabIndex = 0;
            this.txtAdSoyad.TextChanged += new System.EventHandler(this.txtAdSoyad_TextChanged);
            // 
            // txtKalkisVaris
            // 
            this.txtKalkisVaris.Location = new System.Drawing.Point(348, 52);
            this.txtKalkisVaris.Name = "txtKalkisVaris";
            this.txtKalkisVaris.Size = new System.Drawing.Size(208, 30);
            this.txtKalkisVaris.TabIndex = 1;
            this.txtKalkisVaris.TextChanged += new System.EventHandler(this.txtKalkisVaris_TextChanged);
            // 
            // mskTCNO
            // 
            this.mskTCNO.Location = new System.Drawing.Point(643, 52);
            this.mskTCNO.Name = "mskTCNO";
            this.mskTCNO.Size = new System.Drawing.Size(203, 30);
            this.mskTCNO.TabIndex = 2;
            this.mskTCNO.TextChanged += new System.EventHandler(this.mskTCNO_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(42, 121);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(806, 218);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(678, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 26);
            this.label1.TabIndex = 4;
            this.label1.Text = "TC Kimlik No";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(359, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 26);
            this.label2.TabIndex = 5;
            this.label2.Text = "Kalkış-Varış Yönü";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(91, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 26);
            this.label3.TabIndex = 6;
            this.label3.Text = "Ad Soyad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(371, 345);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(179, 26);
            this.label4.TabIndex = 7;
            this.label4.Text = "BİLET BİLGİLERİ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(80, 418);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 26);
            this.label5.TabIndex = 8;
            this.label5.Text = "Kalkış - Varış:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(112, 382);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 26);
            this.label6.TabIndex = 9;
            this.label6.Text = "Ad Soyad:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(46, 491);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(183, 26);
            this.label7.TabIndex = 10;
            this.label7.Text = "Koltuk Numarası:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(138, 455);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 26);
            this.label8.TabIndex = 11;
            this.label8.Text = "Tarih:";
            // 
            // lblBiletADS
            // 
            this.lblBiletADS.AutoSize = true;
            this.lblBiletADS.Location = new System.Drawing.Point(249, 382);
            this.lblBiletADS.Name = "lblBiletADS";
            this.lblBiletADS.Size = new System.Drawing.Size(0, 26);
            this.lblBiletADS.TabIndex = 12;
            // 
            // lblBiletKV
            // 
            this.lblBiletKV.AutoSize = true;
            this.lblBiletKV.Location = new System.Drawing.Point(249, 418);
            this.lblBiletKV.Name = "lblBiletKV";
            this.lblBiletKV.Size = new System.Drawing.Size(0, 26);
            this.lblBiletKV.TabIndex = 13;
            // 
            // lblBiletTarih
            // 
            this.lblBiletTarih.AutoSize = true;
            this.lblBiletTarih.Location = new System.Drawing.Point(249, 455);
            this.lblBiletTarih.Name = "lblBiletTarih";
            this.lblBiletTarih.Size = new System.Drawing.Size(0, 26);
            this.lblBiletTarih.TabIndex = 14;
            // 
            // lblBiletKoltuk
            // 
            this.lblBiletKoltuk.AutoSize = true;
            this.lblBiletKoltuk.Location = new System.Drawing.Point(249, 491);
            this.lblBiletKoltuk.Name = "lblBiletKoltuk";
            this.lblBiletKoltuk.Size = new System.Drawing.Size(0, 26);
            this.lblBiletKoltuk.TabIndex = 15;
            // 
            // Bilet_Sorgu_Kontrol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tan;
            this.ClientSize = new System.Drawing.Size(928, 552);
            this.Controls.Add(this.lblBiletKoltuk);
            this.Controls.Add(this.lblBiletTarih);
            this.Controls.Add(this.lblBiletKV);
            this.Controls.Add(this.lblBiletADS);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.mskTCNO);
            this.Controls.Add(this.txtKalkisVaris);
            this.Controls.Add(this.txtAdSoyad);
            this.Font = new System.Drawing.Font("Sitka Small", 10.8F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Bilet_Sorgu_Kontrol";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bilet Kontrol / Sorgu";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAdSoyad;
        private System.Windows.Forms.TextBox txtKalkisVaris;
        private System.Windows.Forms.MaskedTextBox mskTCNO;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblBiletADS;
        private System.Windows.Forms.Label lblBiletKV;
        private System.Windows.Forms.Label lblBiletTarih;
        private System.Windows.Forms.Label lblBiletKoltuk;
    }
}
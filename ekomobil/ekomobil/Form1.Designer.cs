namespace ekomobil
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnHesapla = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lstSonuclar = new System.Windows.Forms.ListBox();
            this.txtBaslangicLat = new System.Windows.Forms.TextBox();
            this.txtBaslangicLon = new System.Windows.Forms.TextBox();
            this.txtHedefLat = new System.Windows.Forms.TextBox();
            this.txtHedefLon = new System.Windows.Forms.TextBox();
            this.cmbYolcuTipi = new System.Windows.Forms.ComboBox();
            this.cmbOdemeTipi = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnHesapla
            // 
            this.btnHesapla.BackColor = System.Drawing.Color.Cyan;
            this.btnHesapla.Location = new System.Drawing.Point(73, 498);
            this.btnHesapla.Name = "btnHesapla";
            this.btnHesapla.Size = new System.Drawing.Size(101, 50);
            this.btnHesapla.TabIndex = 0;
            this.btnHesapla.Text = "Rota Oluştur";
            this.btnHesapla.UseVisualStyleBackColor = false;
            this.btnHesapla.Click += new System.EventHandler(this.btnHesapla_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Lime;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(26, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Başlangıç Koordinatları";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Lime;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(26, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hedef Koordinatları";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Lime;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(69, 277);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Yolcu Türü";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Lime;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(51, 417);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Ödeme Yöntemi";
            
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Lime;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(500, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "GÜZERGAH";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Lime;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(500, 259);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "HARİTA";
            // 
            // lstSonuclar
            // 
            this.lstSonuclar.BackColor = System.Drawing.SystemColors.Window;
            this.lstSonuclar.FormattingEnabled = true;
            this.lstSonuclar.ItemHeight = 16;
            this.lstSonuclar.Location = new System.Drawing.Point(269, 60);
            this.lstSonuclar.Name = "lstSonuclar";
            this.lstSonuclar.Size = new System.Drawing.Size(629, 180);
            this.lstSonuclar.TabIndex = 7;
            // 
            // txtBaslangicLat
            // 
            this.txtBaslangicLat.Location = new System.Drawing.Point(27, 60);
            this.txtBaslangicLat.Name = "txtBaslangicLat";
            this.txtBaslangicLat.Size = new System.Drawing.Size(186, 22);
            this.txtBaslangicLat.TabIndex = 8;
            // 
            // txtBaslangicLon
            // 
            this.txtBaslangicLon.Location = new System.Drawing.Point(27, 102);
            this.txtBaslangicLon.Name = "txtBaslangicLon";
            this.txtBaslangicLon.Size = new System.Drawing.Size(186, 22);
            this.txtBaslangicLon.TabIndex = 9;
            // 
            // txtHedefLat
            // 
            this.txtHedefLat.Location = new System.Drawing.Point(27, 179);
            this.txtHedefLat.Name = "txtHedefLat";
            this.txtHedefLat.Size = new System.Drawing.Size(186, 22);
            this.txtHedefLat.TabIndex = 10;
            // 
            // txtHedefLon
            // 
            this.txtHedefLon.Location = new System.Drawing.Point(27, 221);
            this.txtHedefLon.Name = "txtHedefLon";
            this.txtHedefLon.Size = new System.Drawing.Size(186, 22);
            this.txtHedefLon.TabIndex = 11;
            // 
            // cmbYolcuTipi
            // 
            this.cmbYolcuTipi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYolcuTipi.FormattingEnabled = true;
            this.cmbYolcuTipi.Location = new System.Drawing.Point(45, 318);
            this.cmbYolcuTipi.Name = "cmbYolcuTipi";
            this.cmbYolcuTipi.Size = new System.Drawing.Size(153, 24);
            this.cmbYolcuTipi.TabIndex = 12;
            // 
            // cmbOdemeTipi
            // 
            this.cmbOdemeTipi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOdemeTipi.FormattingEnabled = true;
            this.cmbOdemeTipi.Location = new System.Drawing.Point(45, 450);
            this.cmbOdemeTipi.Name = "cmbOdemeTipi";
            this.cmbOdemeTipi.Size = new System.Drawing.Size(153, 24);
            this.cmbOdemeTipi.TabIndex = 13;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(269, 297);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(628, 301);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(910, 622);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cmbOdemeTipi);
            this.Controls.Add(this.cmbYolcuTipi);
            this.Controls.Add(this.txtHedefLon);
            this.Controls.Add(this.txtHedefLat);
            this.Controls.Add(this.txtBaslangicLon);
            this.Controls.Add(this.txtBaslangicLat);
            this.Controls.Add(this.lstSonuclar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnHesapla);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "EKOMOBİL";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHesapla;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox lstSonuclar;
        private System.Windows.Forms.TextBox txtBaslangicLat;
        private System.Windows.Forms.TextBox txtBaslangicLon;
        private System.Windows.Forms.TextBox txtHedefLat;
        private System.Windows.Forms.TextBox txtHedefLon;
        private System.Windows.Forms.ComboBox cmbYolcuTipi;
        private System.Windows.Forms.ComboBox cmbOdemeTipi;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
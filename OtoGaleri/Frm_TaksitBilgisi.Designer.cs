namespace OtoGaleri
{
    partial class Frm_TaksitBilgisi
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LstVw_TaksitBilg = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Lbl_ToplamFiyat = new System.Windows.Forms.Label();
            this.label73 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LstVw_TaksitBilg);
            this.groupBox1.Controls.Add(this.Lbl_ToplamFiyat);
            this.groupBox1.Controls.Add(this.label73);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(228, 441);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // LstVw_TaksitBilg
            // 
            this.LstVw_TaksitBilg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.LstVw_TaksitBilg.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.LstVw_TaksitBilg.HideSelection = false;
            this.LstVw_TaksitBilg.Location = new System.Drawing.Point(6, 12);
            this.LstVw_TaksitBilg.Name = "LstVw_TaksitBilg";
            this.LstVw_TaksitBilg.Size = new System.Drawing.Size(213, 409);
            this.LstVw_TaksitBilg.TabIndex = 25;
            this.LstVw_TaksitBilg.UseCompatibleStateImageBehavior = false;
            this.LstVw_TaksitBilg.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Taksit";
            this.columnHeader1.Width = 78;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Ücret";
            this.columnHeader2.Width = 120;
            // 
            // Lbl_ToplamFiyat
            // 
            this.Lbl_ToplamFiyat.AutoSize = true;
            this.Lbl_ToplamFiyat.Location = new System.Drawing.Point(70, 424);
            this.Lbl_ToplamFiyat.Name = "Lbl_ToplamFiyat";
            this.Lbl_ToplamFiyat.Size = new System.Drawing.Size(16, 13);
            this.Lbl_ToplamFiyat.TabIndex = 0;
            this.Lbl_ToplamFiyat.Text = "---";
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Location = new System.Drawing.Point(6, 424);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(48, 13);
            this.label73.TabIndex = 0;
            this.label73.Text = "Toplam :";
            // 
            // Frm_TaksitBilgisi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 441);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_TaksitBilgisi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Taksit Bilgileri";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        public System.Windows.Forms.ListView LstVw_TaksitBilg;
        public System.Windows.Forms.Label Lbl_ToplamFiyat;
    }
}
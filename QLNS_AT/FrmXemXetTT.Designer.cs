namespace QLNS_AT
{
    partial class FrmXemXetTT
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmXemXetTT));
            this.dgvXXTT = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnTT = new System.Windows.Forms.Button();
            this.rdbKN = new System.Windows.Forms.RadioButton();
            this.rdbDA = new System.Windows.Forms.RadioButton();
            this.btnCuoi = new System.Windows.Forms.Button();
            this.btnSau = new System.Windows.Forms.Button();
            this.btnTruoc = new System.Windows.Forms.Button();
            this.btnDau = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvXXTT)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvXXTT
            // 
            this.dgvXXTT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvXXTT.BackgroundColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvXXTT.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvXXTT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvXXTT.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvXXTT.Location = new System.Drawing.Point(12, 161);
            this.dgvXXTT.Name = "dgvXXTT";
            this.dgvXXTT.ReadOnly = true;
            this.dgvXXTT.RowHeadersVisible = false;
            this.dgvXXTT.RowHeadersWidth = 51;
            this.dgvXXTT.RowTemplate.Height = 24;
            this.dgvXXTT.Size = new System.Drawing.Size(1238, 500);
            this.dgvXXTT.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnThoat);
            this.groupBox1.Controls.Add(this.btnTT);
            this.groupBox1.Controls.Add(this.rdbKN);
            this.groupBox1.Controls.Add(this.rdbDA);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Violet;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(958, 143);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tiêu chí xét tiến cử:";
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.Color.Violet;
            this.btnThoat.Location = new System.Drawing.Point(687, 81);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(164, 55);
            this.btnThoat.TabIndex = 45;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnTT
            // 
            this.btnTT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTT.ForeColor = System.Drawing.Color.Violet;
            this.btnTT.Location = new System.Drawing.Point(687, 15);
            this.btnTT.Name = "btnTT";
            this.btnTT.Size = new System.Drawing.Size(164, 60);
            this.btnTT.TabIndex = 2;
            this.btnTT.Text = "Tiến cử";
            this.btnTT.UseVisualStyleBackColor = true;
            this.btnTT.Click += new System.EventHandler(this.btnTT_Click);
            // 
            // rdbKN
            // 
            this.rdbKN.AutoSize = true;
            this.rdbKN.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbKN.Location = new System.Drawing.Point(343, 64);
            this.rdbKN.Name = "rdbKN";
            this.rdbKN.Size = new System.Drawing.Size(261, 27);
            this.rdbKN.TabIndex = 1;
            this.rdbKN.TabStop = true;
            this.rdbKN.Text = "Theo số kỹ năng thuần thục";
            this.rdbKN.UseVisualStyleBackColor = true;
            this.rdbKN.CheckedChanged += new System.EventHandler(this.rdbKN_CheckedChanged);
            // 
            // rdbDA
            // 
            this.rdbDA.AutoSize = true;
            this.rdbDA.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbDA.Location = new System.Drawing.Point(6, 64);
            this.rdbDA.Name = "rdbDA";
            this.rdbDA.Size = new System.Drawing.Size(265, 27);
            this.rdbDA.TabIndex = 0;
            this.rdbDA.TabStop = true;
            this.rdbDA.Text = "Theo tổng dự án hoàn thành";
            this.rdbDA.UseVisualStyleBackColor = true;
            this.rdbDA.CheckedChanged += new System.EventHandler(this.rdbDA_CheckedChanged);
            // 
            // btnCuoi
            // 
            this.btnCuoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCuoi.BackColor = System.Drawing.Color.Transparent;
            this.btnCuoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCuoi.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnCuoi.ForeColor = System.Drawing.Color.Violet;
            this.btnCuoi.Location = new System.Drawing.Point(1186, 116);
            this.btnCuoi.Name = "btnCuoi";
            this.btnCuoi.Size = new System.Drawing.Size(64, 39);
            this.btnCuoi.TabIndex = 30;
            this.btnCuoi.Text = "Cuối";
            this.btnCuoi.UseVisualStyleBackColor = false;
            this.btnCuoi.Click += new System.EventHandler(this.btnCuoi_Click);
            // 
            // btnSau
            // 
            this.btnSau.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSau.BackColor = System.Drawing.Color.Transparent;
            this.btnSau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSau.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnSau.ForeColor = System.Drawing.Color.Violet;
            this.btnSau.Location = new System.Drawing.Point(1116, 116);
            this.btnSau.Name = "btnSau";
            this.btnSau.Size = new System.Drawing.Size(64, 39);
            this.btnSau.TabIndex = 31;
            this.btnSau.Text = "Sau";
            this.btnSau.UseVisualStyleBackColor = false;
            this.btnSau.Click += new System.EventHandler(this.btnSau_Click);
            // 
            // btnTruoc
            // 
            this.btnTruoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTruoc.BackColor = System.Drawing.Color.Transparent;
            this.btnTruoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTruoc.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnTruoc.ForeColor = System.Drawing.Color.Violet;
            this.btnTruoc.Location = new System.Drawing.Point(1046, 116);
            this.btnTruoc.Name = "btnTruoc";
            this.btnTruoc.Size = new System.Drawing.Size(64, 39);
            this.btnTruoc.TabIndex = 32;
            this.btnTruoc.Text = "Trước";
            this.btnTruoc.UseVisualStyleBackColor = false;
            this.btnTruoc.Click += new System.EventHandler(this.btnTruoc_Click);
            // 
            // btnDau
            // 
            this.btnDau.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDau.BackColor = System.Drawing.Color.Transparent;
            this.btnDau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDau.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDau.ForeColor = System.Drawing.Color.Violet;
            this.btnDau.Location = new System.Drawing.Point(976, 116);
            this.btnDau.Name = "btnDau";
            this.btnDau.Size = new System.Drawing.Size(64, 39);
            this.btnDau.TabIndex = 29;
            this.btnDau.Text = "Đầu";
            this.btnDau.UseVisualStyleBackColor = false;
            this.btnDau.Click += new System.EventHandler(this.btnDau_Click);
            // 
            // FrmXemXetTT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.btnCuoi);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSau);
            this.Controls.Add(this.dgvXXTT);
            this.Controls.Add(this.btnTruoc);
            this.Controls.Add(this.btnDau);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmXemXetTT";
            this.Text = "Xem xét tiến cử Amazing Tech";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmXemXetTT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvXXTT)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvXXTT;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbKN;
        private System.Windows.Forms.RadioButton rdbDA;
        private System.Windows.Forms.Button btnTT;
        private System.Windows.Forms.Button btnCuoi;
        private System.Windows.Forms.Button btnSau;
        private System.Windows.Forms.Button btnTruoc;
        private System.Windows.Forms.Button btnDau;
        private System.Windows.Forms.Button btnThoat;
    }
}
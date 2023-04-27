
namespace QuanLyThietBiMayTinh
{
    partial class FRMQuanLyHoaDonNhap
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
            this.labelNvNhap = new System.Windows.Forms.Label();
            this.ListNV = new System.Windows.Forms.ComboBox();
            this.lbNCC = new System.Windows.Forms.Label();
            this.txtTenNCC = new System.Windows.Forms.TextBox();
            this.grxlistHoaDon = new System.Windows.Forms.DataGridView();
            this.MaHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NhanVienNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngaytao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tongtien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnXem = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grxlistHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // labelNvNhap
            // 
            this.labelNvNhap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNvNhap.AutoSize = true;
            this.labelNvNhap.Location = new System.Drawing.Point(32, 21);
            this.labelNvNhap.Name = "labelNvNhap";
            this.labelNvNhap.Size = new System.Drawing.Size(108, 17);
            this.labelNvNhap.TabIndex = 0;
            this.labelNvNhap.Text = "Nhân viên nhập";
            // 
            // ListNV
            // 
            this.ListNV.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.ListNV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListNV.FormattingEnabled = true;
            this.ListNV.Items.AddRange(new object[] {
            "\"\""});
            this.ListNV.Location = new System.Drawing.Point(187, 18);
            this.ListNV.Name = "ListNV";
            this.ListNV.Size = new System.Drawing.Size(537, 24);
            this.ListNV.Sorted = true;
            this.ListNV.TabIndex = 1;
            // 
            // lbNCC
            // 
            this.lbNCC.AutoSize = true;
            this.lbNCC.Location = new System.Drawing.Point(35, 66);
            this.lbNCC.Name = "lbNCC";
            this.lbNCC.Size = new System.Drawing.Size(123, 17);
            this.lbNCC.TabIndex = 2;
            this.lbNCC.Text = "Tên nhà cung cấp";
            // 
            // txtTenNCC
            // 
            this.txtTenNCC.AcceptsReturn = true;
            this.txtTenNCC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenNCC.Location = new System.Drawing.Point(187, 63);
            this.txtTenNCC.Name = "txtTenNCC";
            this.txtTenNCC.Size = new System.Drawing.Size(537, 22);
            this.txtTenNCC.TabIndex = 3;
            // 
            // grxlistHoaDon
            // 
            this.grxlistHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grxlistHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grxlistHoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaHD,
            this.NhanVienNhap,
            this.ngaytao,
            this.NCC,
            this.tongtien});
            this.grxlistHoaDon.Location = new System.Drawing.Point(2, 150);
            this.grxlistHoaDon.Name = "grxlistHoaDon";
            this.grxlistHoaDon.RowHeadersWidth = 51;
            this.grxlistHoaDon.RowTemplate.Height = 24;
            this.grxlistHoaDon.Size = new System.Drawing.Size(1070, 319);
            this.grxlistHoaDon.TabIndex = 4;
            // 
            // MaHD
            // 
            this.MaHD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MaHD.DataPropertyName = "iMaHD";
            this.MaHD.HeaderText = "MaHD";
            this.MaHD.MinimumWidth = 6;
            this.MaHD.Name = "MaHD";
            // 
            // NhanVienNhap
            // 
            this.NhanVienNhap.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NhanVienNhap.DataPropertyName = "sTen";
            this.NhanVienNhap.HeaderText = "Nhan vien Nhap";
            this.NhanVienNhap.MinimumWidth = 6;
            this.NhanVienNhap.Name = "NhanVienNhap";
            // 
            // ngaytao
            // 
            this.ngaytao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ngaytao.DataPropertyName = "dNgayTao";
            this.ngaytao.HeaderText = "Ngày tạo";
            this.ngaytao.MinimumWidth = 6;
            this.ngaytao.Name = "ngaytao";
            // 
            // NCC
            // 
            this.NCC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NCC.DataPropertyName = "sNCC";
            this.NCC.HeaderText = "nhà cung cấp";
            this.NCC.MinimumWidth = 6;
            this.NCC.Name = "NCC";
            // 
            // tongtien
            // 
            this.tongtien.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tongtien.DataPropertyName = "fTongTien";
            this.tongtien.HeaderText = "Tổng Tiền";
            this.tongtien.MinimumWidth = 6;
            this.tongtien.Name = "tongtien";
            // 
            // btnThem
            // 
            this.btnThem.AutoSize = true;
            this.btnThem.Location = new System.Drawing.Point(50, 110);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 30);
            this.btnThem.TabIndex = 5;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.AutoSize = true;
            this.btnUpdate.Location = new System.Drawing.Point(175, 110);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 30);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = true;
            this.btnDelete.Location = new System.Drawing.Point(300, 110);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 30);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.Location = new System.Drawing.Point(559, 110);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "bỏ qua";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnReport
            // 
            this.btnReport.AutoSize = true;
            this.btnReport.Location = new System.Drawing.Point(681, 110);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(100, 30);
            this.btnReport.TabIndex = 9;
            this.btnReport.Text = "báo cáo";
            this.btnReport.UseVisualStyleBackColor = true;
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(805, 110);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(100, 30);
            this.btnXem.TabIndex = 10;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(937, 110);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 30);
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.AutoSize = true;
            this.btnTimKiem.Location = new System.Drawing.Point(429, 110);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(100, 30);
            this.btnTimKiem.TabIndex = 13;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // FRMQuanLyHoaDonNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 469);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.grxlistHoaDon);
            this.Controls.Add(this.txtTenNCC);
            this.Controls.Add(this.lbNCC);
            this.Controls.Add(this.ListNV);
            this.Controls.Add(this.labelNvNhap);
            this.Name = "FRMQuanLyHoaDonNhap";
            this.Text = "FRMQuanLyHoaDonNhap";
            this.Load += new System.EventHandler(this.FRMQuanLyHoaDonNhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grxlistHoaDon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNvNhap;
        private System.Windows.Forms.ComboBox ListNV;
        private System.Windows.Forms.Label lbNCC;
        private System.Windows.Forms.TextBox txtTenNCC;
        private System.Windows.Forms.DataGridView grxlistHoaDon;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn NhanVienNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngaytao;
        private System.Windows.Forms.DataGridViewTextBoxColumn NCC;
        private System.Windows.Forms.DataGridViewTextBoxColumn tongtien;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnTimKiem;
    }
}

namespace QuanLyThietBiMayTinh
{
    partial class FRMQuanLyChiTietHoaDonNhap
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
            this.labelHD = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbloaihang = new System.Windows.Forms.Label();
            this.cbloaihang = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbmathang = new System.Windows.Forms.ComboBox();
            this.lbsoluong = new System.Windows.Forms.Label();
            this.soluong = new System.Windows.Forms.TextBox();
            this.dataGRVdetailHDNhap = new System.Windows.Forms.DataGridView();
            this.maHd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maMH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iMaLH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenNVNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sNCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sTenHH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iSoluong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fdongia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fthanhtien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnThem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textGiaNhap = new System.Windows.Forms.TextBox();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTonKho = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGRVdetailHDNhap)).BeginInit();
            this.SuspendLayout();
            // 
            // labelHD
            // 
            this.labelHD.AutoSize = true;
            this.labelHD.Location = new System.Drawing.Point(280, 22);
            this.labelHD.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelHD.Name = "labelHD";
            this.labelHD.Size = new System.Drawing.Size(144, 13);
            this.labelHD.TabIndex = 0;
            this.labelHD.Text = "Thêm mặt hàng cho hóa dơn";
            this.labelHD.Click += new System.EventHandler(this.labelHD_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 52);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 1;
            // 
            // lbloaihang
            // 
            this.lbloaihang.AutoSize = true;
            this.lbloaihang.Location = new System.Drawing.Point(38, 52);
            this.lbloaihang.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbloaihang.Name = "lbloaihang";
            this.lbloaihang.Size = new System.Drawing.Size(50, 13);
            this.lbloaihang.TabIndex = 2;
            this.lbloaihang.Text = "loại hàng";
            // 
            // cbloaihang
            // 
            this.cbloaihang.FormattingEnabled = true;
            this.cbloaihang.Location = new System.Drawing.Point(110, 52);
            this.cbloaihang.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbloaihang.Name = "cbloaihang";
            this.cbloaihang.Size = new System.Drawing.Size(126, 21);
            this.cbloaihang.TabIndex = 14;
            this.cbloaihang.SelectedIndexChanged += new System.EventHandler(this.cbloaihang_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(389, 52);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "mặt hàng";
            // 
            // cbmathang
            // 
            this.cbmathang.FormattingEnabled = true;
            this.cbmathang.Location = new System.Drawing.Point(459, 52);
            this.cbmathang.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbmathang.Name = "cbmathang";
            this.cbmathang.Size = new System.Drawing.Size(127, 21);
            this.cbmathang.TabIndex = 5;
            this.cbmathang.SelectedIndexChanged += new System.EventHandler(this.cbmathang_SelectedIndexChanged);
            // 
            // lbsoluong
            // 
            this.lbsoluong.AutoSize = true;
            this.lbsoluong.Location = new System.Drawing.Point(39, 83);
            this.lbsoluong.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbsoluong.Name = "lbsoluong";
            this.lbsoluong.Size = new System.Drawing.Size(49, 13);
            this.lbsoluong.TabIndex = 6;
            this.lbsoluong.Text = "Số lượng";
            // 
            // soluong
            // 
            this.soluong.Location = new System.Drawing.Point(111, 83);
            this.soluong.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.soluong.Name = "soluong";
            this.soluong.Size = new System.Drawing.Size(76, 20);
            this.soluong.TabIndex = 8;
            // 
            // dataGRVdetailHDNhap
            // 
            this.dataGRVdetailHDNhap.AllowUserToOrderColumns = true;
            this.dataGRVdetailHDNhap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGRVdetailHDNhap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGRVdetailHDNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGRVdetailHDNhap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maHd,
            this.maMH,
            this.iMaLH,
            this.tenNVNhap,
            this.sNCC,
            this.sTenHH,
            this.iSoluong,
            this.fdongia,
            this.fthanhtien});
            this.dataGRVdetailHDNhap.Location = new System.Drawing.Point(15, 208);
            this.dataGRVdetailHDNhap.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGRVdetailHDNhap.Name = "dataGRVdetailHDNhap";
            this.dataGRVdetailHDNhap.RowHeadersWidth = 51;
            this.dataGRVdetailHDNhap.RowTemplate.Height = 24;
            this.dataGRVdetailHDNhap.Size = new System.Drawing.Size(734, 214);
            this.dataGRVdetailHDNhap.StandardTab = true;
            this.dataGRVdetailHDNhap.TabIndex = 9;
            // 
            // maHd
            // 
            this.maHd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.maHd.DataPropertyName = "iMaHD";
            this.maHd.HeaderText = "Mã Hóa đơn";
            this.maHd.MinimumWidth = 6;
            this.maHd.Name = "maHd";
            // 
            // maMH
            // 
            this.maMH.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.maMH.DataPropertyName = "iMaMH";
            this.maMH.HeaderText = "Mã mặt hàng";
            this.maMH.MinimumWidth = 6;
            this.maMH.Name = "maMH";
            // 
            // iMaLH
            // 
            this.iMaLH.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.iMaLH.DataPropertyName = "iMaLH";
            this.iMaLH.HeaderText = "Mã loại hàng";
            this.iMaLH.MinimumWidth = 6;
            this.iMaLH.Name = "iMaLH";
            // 
            // tenNVNhap
            // 
            this.tenNVNhap.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tenNVNhap.DataPropertyName = "tenNVNhap";
            this.tenNVNhap.HeaderText = "Tên nhân viên nhập";
            this.tenNVNhap.MinimumWidth = 6;
            this.tenNVNhap.Name = "tenNVNhap";
            // 
            // sNCC
            // 
            this.sNCC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.sNCC.DataPropertyName = "sNCC";
            this.sNCC.HeaderText = "nhà cung cấp";
            this.sNCC.MinimumWidth = 6;
            this.sNCC.Name = "sNCC";
            // 
            // sTenHH
            // 
            this.sTenHH.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.sTenHH.DataPropertyName = "sTenHH";
            this.sTenHH.HeaderText = "tên mặt hàng";
            this.sTenHH.MinimumWidth = 6;
            this.sTenHH.Name = "sTenHH";
            // 
            // iSoluong
            // 
            this.iSoluong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.iSoluong.DataPropertyName = "iSoLuong";
            this.iSoluong.HeaderText = "số lượng";
            this.iSoluong.MinimumWidth = 6;
            this.iSoluong.Name = "iSoluong";
            // 
            // fdongia
            // 
            this.fdongia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fdongia.DataPropertyName = "fDonGia";
            this.fdongia.HeaderText = "Dơn Giá";
            this.fdongia.MinimumWidth = 6;
            this.fdongia.Name = "fdongia";
            // 
            // fthanhtien
            // 
            this.fthanhtien.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fthanhtien.DataPropertyName = "fThanhTien";
            this.fthanhtien.HeaderText = "Thành tiền";
            this.fthanhtien.MinimumWidth = 6;
            this.fthanhtien.Name = "fthanhtien";
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(38, 162);
            this.btnThem.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 24);
            this.btnThem.TabIndex = 10;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(392, 83);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "giá nhập";
            // 
            // textGiaNhap
            // 
            this.textGiaNhap.Location = new System.Drawing.Point(460, 83);
            this.textGiaNhap.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textGiaNhap.Name = "textGiaNhap";
            this.textGiaNhap.Size = new System.Drawing.Size(76, 20);
            this.textGiaNhap.TabIndex = 12;
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(131, 162);
            this.btnSua.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 24);
            this.btnSua.TabIndex = 15;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(225, 162);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 24);
            this.btnDelete.TabIndex = 16;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 116);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "tồn kho";
            // 
            // txtTonKho
            // 
            this.txtTonKho.Location = new System.Drawing.Point(111, 116);
            this.txtTonKho.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTonKho.Name = "txtTonKho";
            this.txtTonKho.ReadOnly = true;
            this.txtTonKho.Size = new System.Drawing.Size(76, 20);
            this.txtTonKho.TabIndex = 18;
            // 
            // FRMQuanLyChiTietHoaDonNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 431);
            this.Controls.Add(this.txtTonKho);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.textGiaNhap);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dataGRVdetailHDNhap);
            this.Controls.Add(this.soluong);
            this.Controls.Add(this.lbsoluong);
            this.Controls.Add(this.cbmathang);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbloaihang);
            this.Controls.Add(this.lbloaihang);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelHD);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FRMQuanLyChiTietHoaDonNhap";
            this.Text = " ";
            this.Load += new System.EventHandler(this.FRMQuanLyChiTietHoaDonNhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGRVdetailHDNhap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelHD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbloaihang;
        private System.Windows.Forms.ComboBox cbloaihang;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbmathang;
        private System.Windows.Forms.Label lbsoluong;
        private System.Windows.Forms.TextBox soluong;
        private System.Windows.Forms.DataGridView dataGRVdetailHDNhap;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridViewTextBoxColumn maHd;
        private System.Windows.Forms.DataGridViewTextBoxColumn maMH;
        private System.Windows.Forms.DataGridViewTextBoxColumn iMaLH;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenNVNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn sNCC;
        private System.Windows.Forms.DataGridViewTextBoxColumn sTenHH;
        private System.Windows.Forms.DataGridViewTextBoxColumn iSoluong;
        private System.Windows.Forms.DataGridViewTextBoxColumn fdongia;
        private System.Windows.Forms.DataGridViewTextBoxColumn fthanhtien;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textGiaNhap;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTonKho;
    }
}
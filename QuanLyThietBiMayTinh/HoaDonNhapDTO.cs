using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThietBiMayTinh
{
    class HoaDonNhapDTO
    {
        private int iMaHD;
        private int iMaNV;
        private string sNCC;
        private String dNgayTao;
        private float fTongTien;

        public HoaDonNhapDTO() { }
        public HoaDonNhapDTO(int iMaHD, int iMaNV, string sNCC, String dNgayTao, float fTongTien)
        {
            this.iMaHD = iMaHD;
            this.iMaNV = iMaNV;
            this.sNCC = sNCC;
            this.dNgayTao = dNgayTao;
            this.fTongTien = fTongTien;
        }
        public int maHD
        {
            get
            {
                return this.iMaHD;
            }
            set
            {
                this.iMaHD = value;
            }
        }
        public int maNV
        {
            get
            {
                return this.iMaNV;
            }
            set
            {
                this.iMaNV = value;
            }
        }

        public string tenNCC
        {
            get
            {
                return this.sNCC;
            }
            set
            {
                this.sNCC = value;
            }
        }

        public String ngayTao
        {
            get
            {
                return this.dNgayTao;
            }
            set
            {
                this.dNgayTao = value;
            }
        }

        public float tongTien
        {
            get
            {
                return this.fTongTien;
            }
            set
            {
                this.fTongTien = value;
            }
        }
    }
}

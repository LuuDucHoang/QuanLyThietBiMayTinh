using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThietBiMayTinh
{
    class NhanVienDTO
    {
        private int iMaNV;
        private string sTenNV;
        private string sSDT;
        public NhanVienDTO(int iMaNV, string sTenNV, string sSDT)
        {
            this.iMaNV = iMaNV;
            this.sTenNV = sTenNV;
            this.sSDT = sSDT;
        }

        public int MaNV
        {
            get
            {
                return iMaNV;
            }
            set
            {
                iMaNV = value;
            }
        }

        public string TenNV
        {
            get
            {
                return sTenNV;
            }
            set
            {
                sTenNV = value;
            }
        }

        public string SDT
        {
            get
            {
                return sSDT;
            }
            set
            {
                sSDT = value;
            }
        }
    }
}

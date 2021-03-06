//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebTruyen.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Truyen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Truyen()
        {
            this.ChuongTruyens = new HashSet<ChuongTruyen>();
            this.HanhDongCuaTKs = new HashSet<HanhDongCuaTK>();
            this.TruyenTacGias = new HashSet<TruyenTacGia>();
        }
    
        public int MaTruyen { get; set; }
        public string TenTruyen { get; set; }
        public int MaLoai { get; set; }
        public string TacGiaGoc { get; set; }
        public System.DateTime NgayTao { get; set; }
        public Nullable<System.DateTime> NgayDang { get; set; }
        public bool TamAn { get; set; }
        public Nullable<bool> DaDuyet { get; set; }
        public Nullable<bool> Khoa { get; set; }
        public int LoaiTruyen { get; set; }
        public Nullable<int> TinhTrang { get; set; }
        public int AnhBia { get; set; }
        public string MoTa { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChuongTruyen> ChuongTruyens { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HanhDongCuaTK> HanhDongCuaTKs { get; set; }
        public virtual QuanLyHinhAnh QuanLyHinhAnh { get; set; }
        public virtual TheLoai TheLoai { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TruyenTacGia> TruyenTacGias { get; set; }
    }
}

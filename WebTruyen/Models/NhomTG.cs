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
    
    public partial class NhomTG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhomTG()
        {
            this.HanhDongCuaTKs = new HashSet<HanhDongCuaTK>();
            this.ThanhVienNhoms = new HashSet<ThanhVienNhom>();
        }
    
        public int MaNhom { get; set; }
        public string TenNhom { get; set; }
        public System.DateTime NgayThanhLap { get; set; }
        public Nullable<int> NguoiThanhLap { get; set; }
        public int TinhTrang { get; set; }
        public string Khauhieu { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HanhDongCuaTK> HanhDongCuaTKs { get; set; }
        public virtual TaiKhoan TaiKhoan { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThanhVienNhom> ThanhVienNhoms { get; set; }
    }
}

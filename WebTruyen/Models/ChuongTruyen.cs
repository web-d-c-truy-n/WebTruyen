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
    
    public partial class ChuongTruyen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChuongTruyen()
        {
            this.HanhDongCuaTKs = new HashSet<HanhDongCuaTK>();
        }
    
        public int MaTruyen { get; set; }
        public int SoChuong { get; set; }
        public string TenChuong { get; set; }
        public System.DateTime NgayTao { get; set; }
        public string NoiDung { get; set; }
        public bool Dang { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HanhDongCuaTK> HanhDongCuaTKs { get; set; }
        public virtual Truyen Truyen { get; set; }
    }
}

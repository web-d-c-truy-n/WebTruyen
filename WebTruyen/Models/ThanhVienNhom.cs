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
    
    public partial class ThanhVienNhom
    {
        public int MaTK { get; set; }
        public int MaNhom { get; set; }
        public System.DateTime Ngayvaonhom { get; set; }
        public int Vaitro { get; set; }
        public string GhiChu { get; set; }
        public bool DaDuyet { get; set; }
    
        public virtual NhomTG NhomTG { get; set; }
        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}

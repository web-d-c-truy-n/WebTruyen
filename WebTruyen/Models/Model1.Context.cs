﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class webtruyenptEntities : DbContext
    {
        public webtruyenptEntities()
            : base("name=webtruyenptEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ChuongTruyen> ChuongTruyens { get; set; }
        public virtual DbSet<HanhDongCuaTK> HanhDongCuaTKs { get; set; }
        public virtual DbSet<NhomTG> NhomTGs { get; set; }
        public virtual DbSet<QuanLyHinhAnh> QuanLyHinhAnhs { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<ThanhVienNhom> ThanhVienNhoms { get; set; }
        public virtual DbSet<TheLoai> TheLoais { get; set; }
        public virtual DbSet<Truyen> Truyens { get; set; }
        public virtual DbSet<TruyenTacGia> TruyenTacGias { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<BinhLuan> BinhLuans { get; set; }
        public virtual DbSet<LuotThichChuong> LuotThichChuongs { get; set; }
        public virtual DbSet<LuotThichTruyen> LuotThichTruyens { get; set; }
        public virtual DbSet<LuotXem> LuotXems { get; set; }
        public virtual DbSet<TheodoTG> TheodoTGs { get; set; }
        public virtual DbSet<ThongBao> ThongBaos { get; set; }
        public virtual DbSet<TraoDoiNhom> TraoDoiNhoms { get; set; }
        public virtual DbSet<vTruyen> vTruyens { get; set; }
        public virtual DbSet<TacGia> TacGias { get; set; }
        public virtual DbSet<vvTruyen> vvTruyens { get; set; }
    }
}

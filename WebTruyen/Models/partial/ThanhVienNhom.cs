using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebTruyen.Helper;

namespace WebTruyen.Models
{
    public partial class ThanhVienNhom
    {
        // vai trò nhóm trưởng
        public void DuyetThanhVien(int maTK)
        {

            try
            {
                if (this.Vaitro != vtNhom.nhomTruong) return;
                webtruyenptEntities db = new webtruyenptEntities();
                ThanhVienNhom thanhVienNhom = db.ThanhVienNhoms.Where(x => x.MaTK == maTK && x.MaNhom == this.MaNhom).First();
                thanhVienNhom.DaDuyet = true;
                db.SaveChanges();
                ThongBao thongBao = new ThongBao();
                thongBao.MaTK = maTK;
                thongBao.MaNhom = this.MaNhom;
                thongBao.ThongBao1 = $"Bạn đã được duyệt vào nhóm {this.NhomTG.TenNhom}";
                HanhDongCuaTK hanhDongCuaTK = new HanhDongCuaTK();
                hanhDongCuaTK.thongBao(thongBao);
            }
            catch (DbUpdateException ex)
            {
                SqlException Ex = ex.GetBaseException() as SqlException;
                throw Ex;
            }
        }
        // vai trò nhóm trưởng
        public void ThangChuc(int maTK)
        {
            try
            {
                if (this.Vaitro != vtNhom.nhomTruong) return;
                webtruyenptEntities db = new webtruyenptEntities();
                ThanhVienNhom thanhVienNhom = db.ThanhVienNhoms.Where(x => x.MaTK == maTK && x.MaNhom == this.MaNhom).First();
                thanhVienNhom.Vaitro = thanhVienNhom.Vaitro == vtNhom.nhomTruong?vtNhom.thanhVien:vtNhom.nhomTruong;
                db.SaveChanges();
                ThongBao thongBao = new ThongBao();
                thongBao.MaTK = maTK;
                thongBao.MaNhom = this.MaNhom;
                thongBao.ThongBao1 = thanhVienNhom.Vaitro==vtNhom.nhomTruong?$"Bạn đã được thăng chức làm nhóm trưởng của nhóm {this.NhomTG.TenNhom}":$"Bạn đã bị cắt chức nhóm trưởng của nhóm {this.NhomTG.TenNhom}";
                HanhDongCuaTK hanhDongCuaTK = new HanhDongCuaTK();
                hanhDongCuaTK.thongBao(thongBao);
            }
            catch (DbUpdateException ex)
            {
                SqlException Ex = ex.GetBaseException() as SqlException;
                throw Ex;
            }
        }
        // vai trò nhóm trưởng
        public void xoaThanhVien(int maTK)
        {
            try
            {
                if (this.Vaitro != vtNhom.nhomTruong) return;
                webtruyenptEntities db = new webtruyenptEntities();
                ThanhVienNhom thanhVienNhom = db.ThanhVienNhoms.Where(x => x.MaTK == maTK && x.MaNhom == this.MaNhom).First();
                db.ThanhVienNhoms.Remove(thanhVienNhom);
                db.SaveChanges();
                ThongBao thongBao = new ThongBao();
                thongBao.MaTK = maTK;
                thongBao.MaNhom = this.MaNhom;
                thongBao.ThongBao1 = $"Bạn đã bị xóa khỏi nhóm {this.NhomTG.TenNhom}";
                HanhDongCuaTK hanhDongCuaTK = new HanhDongCuaTK();
                hanhDongCuaTK.thongBao(thongBao);
            }
            catch (DbUpdateException ex)
            {
                SqlException Ex = ex.GetBaseException() as SqlException;
                throw Ex;
            }
        }
        public void roiNhom(webtruyenptEntities db)
        {
            try
            {
                db.ThanhVienNhoms.Remove(this);
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                SqlException Ex = ex.GetBaseException() as SqlException;
                throw Ex;
            }
        }
        // vai trò nhóm trưởng
        public void vietTruyen(Truyen truyen,int vaiTro)
        {
            try
            {
                webtruyenptEntities db = new webtruyenptEntities();
                if (this.Vaitro != vtNhom.nhomTruong) return;
                List<TruyenTacGia> truyenTacGia = new List<TruyenTacGia>();
                ThanhVienNhom[] thanhViens = db.ThanhVienNhoms.Where(x => x.MaNhom == MaNhom).ToArray();
                truyenTacGia.Add(new TruyenTacGia()
                {
                    MaTK = this.MaTK,
                    VaiTro = vaiTro,
                    DangNhom = this.MaNhom
                });
                truyen.CreateOrUpdate(truyenTacGia);
            }
            catch (DbUpdateException ex)
            {
                SqlException Ex = ex.GetBaseException() as SqlException;
                throw Ex;
            }
        }

        public void traoDoi(string noiDung, int? phanHoi)
        {
            try
            {
                TraoDoiNhom traoDoiNhom = new TraoDoiNhom();
                traoDoiNhom.MaNhom = this.MaNhom;
                traoDoiNhom.MaTV = this.MaTK;
                traoDoiNhom.NoiDung = noiDung;
                traoDoiNhom.PhanHoi = phanHoi;
                HanhDongCuaTK hanhDongCuaTK = new HanhDongCuaTK();
                hanhDongCuaTK.traoDoiNhom(traoDoiNhom);
            }catch(Exception e)
            {
                throw;
            }
            
        }
        /// <summary>
        /// nhóm trưởng
        /// </summary>
        public void suaTTNhom(string tenNhom, string khauHieu)
        {
            if (this.Vaitro != vtNhom.nhomTruong) return;
            try
            {
                webtruyenptEntities db = new webtruyenptEntities();
                NhomTG nhomTG = db.NhomTGs.Find(MaNhom);
                nhomTG.TenNhom = tenNhom;
                nhomTG.Khauhieu = khauHieu;
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                SqlException Ex = ex.GetBaseException() as SqlException;
                throw Ex;
            }
        }
    }
}
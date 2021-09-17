using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebTruyen.Helper;

namespace WebTruyen.Models
{
    public partial class NhomTG
    {
        public void taoNhom()
        {
            webtruyenptEntities db = new webtruyenptEntities();
            using (System.Data.Entity.DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {                
                    this.NgayThanhLap = DateTime.Now;
                    db.NhomTGs.Add(this);
                    db.SaveChanges();
                    ThanhVienNhom thanhVienNhom = new ThanhVienNhom();
                    thanhVienNhom.MaTK = Auth.MaTk();
                    thanhVienNhom.MaNhom = this.MaNhom;
                    thanhVienNhom.Ngayvaonhom = DateTime.Now;
                    thanhVienNhom.DaDuyet = true;
                    thanhVienNhom.Vaitro = vtNhom.nhomTruong;
                    db.ThanhVienNhoms.Add(thanhVienNhom);
                    db.SaveChanges();
                    transaction.Commit();
                }
                catch (DbUpdateException ex)
                {
                    transaction.Rollback();
                    SqlException Ex = ex.GetBaseException() as SqlException;
                    throw Ex;
                }
            }
            
        }
        public void sua(webtruyenptEntities db)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                SqlException Ex = ex.GetBaseException() as SqlException;
                throw Ex;
            }
        }
        public void xoa(webtruyenptEntities db)
        {
            try
            {
                db.NhomTGs.Remove(this);
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                SqlException Ex = ex.GetBaseException() as SqlException;
                throw Ex;
            }
        }

        public List<TacGia> xemDanhSachThanhVien()
        {
            webtruyenptEntities db = new webtruyenptEntities();
            List<TacGia> tacGias = (from tv in db.ThanhVienNhoms where tv.MaNhom == this.MaNhom
                                    join tg in db.TacGias
                                    on tv.MaTK equals tg.MaTG
                                    select tg).ToList();
            return tacGias;
        }
        public List<Truyen> xemDanhSachTruyen()
        {
            webtruyenptEntities db = new webtruyenptEntities();
            List<Truyen> truyens = (from tg in db.TruyenTacGias
                                    where tg.DangNhom == this.MaNhom
                                    join tr in db.Truyens
                                    on tg.MaTruyen equals tr.MaTruyen
                                    select tr).ToList();
            return truyens;
        }
        // vào nhóm
        public void vaoNhom(int maTK)
        {
            try
            {
                webtruyenptEntities db = new webtruyenptEntities();
                ThanhVienNhom thanhVienNhom = new ThanhVienNhom();
                thanhVienNhom.MaTK = maTK;
                thanhVienNhom.Ngayvaonhom = DateTime.Now;
                thanhVienNhom.Vaitro = vtNhom.thanhVien;
                thanhVienNhom.DaDuyet = false;
                thanhVienNhom.MaNhom = this.MaNhom;
                db.ThanhVienNhoms.Add(thanhVienNhom);
                db.SaveChanges();
                ThanhVienNhom[] nhomTruongs = db.ThanhVienNhoms.Where(x => x.Vaitro == vtNhom.nhomTruong).ToArray();
                foreach(ThanhVienNhom nhomTruong in nhomTruongs)
                {
                    ThongBao thongBao = new ThongBao();
                    thongBao.MaNhom = this.MaNhom;
                    thongBao.MaTK = nhomTruong.MaTK;
                    string butDanh = db.TaiKhoans.Find(maTK).ButDanh;
                    thongBao.ThongBao1 = $"{butDanh} yêu cầu tham gia nhóm {this.TenNhom}";
                    HanhDongCuaTK hanhDongCuaTK = new HanhDongCuaTK();
                    hanhDongCuaTK.thongBao(thongBao);
                }
            }
            catch (DbUpdateException ex)
            {
                SqlException Ex = ex.GetBaseException() as SqlException;
                if (Ex?.Number == 2627)
                {
                    throw new InvalidOperationException("Bạn đã tham gia nhóm này");
                }
                else
                {
                    throw Ex;
                }
            }
        }
    }
}
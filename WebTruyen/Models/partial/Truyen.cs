using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebTruyen.Helper;

namespace WebTruyen.Models
{
    public partial class Truyen
    {
        public void them(List<TruyenTacGia> truyenTacGias)
        {
            webtruyenptEntities db = new webtruyenptEntities();
            using (System.Data.Entity.DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {
                    this.NgayTao = DateTime.Now;
                    this.DaDuyet = false;
                    this.Khoa = false;
                    db.Truyens.Add(this);
                    db.SaveChanges();
                    if (truyenTacGias != null && truyenTacGias.Count > 0)
                    {
                        foreach (TruyenTacGia truyenTacGia in truyenTacGias)
                        {
                            truyenTacGia.MaTruyen = this.MaTruyen;
                            db.TruyenTacGias.Add(truyenTacGia);
                        }
                    }
                    db.SaveChanges();                  
                    transaction.Commit();
                    List<Admin> admins = db.Admins.ToList();
                    foreach (Admin admin in admins)
                    {
                        ThongBao thongBao = new ThongBao();
                        thongBao.MaTK = admin.MaTK;
                        thongBao.MaTruyen = this.MaTruyen;
                        thongBao.ThongBao1 = $"Truyện {this.TenTruyen} cần được phê duyệt";
                        HanhDongCuaTK hanhDongCuaTK = new HanhDongCuaTK();
                        hanhDongCuaTK.thongBao(thongBao);
                    }
                }
                catch (DbUpdateException ex)
                {
                    SqlException Ex = ex.GetBaseException() as SqlException;
                    transaction.Rollback();
                    throw Ex;
                }
            }
        }
        public void sua(webtruyenptEntities db,List<TruyenTacGia> truyenTacGias)
        {
            using (System.Data.Entity.DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {
                    if (!Auth.user().isTruyenCuaToi(MaTruyen)) return;
                    db.SaveChanges();
                    var TruyenTGs = db.TruyenTacGias.Where(x => x.MaTruyen == this.MaTruyen);
                    int? maNhom = null;
                    foreach (TruyenTacGia tacGia in TruyenTGs)
                    {
                        maNhom = tacGia.DangNhom;
                        db.TruyenTacGias.Remove(tacGia);
                    }
                    db.SaveChanges();
                    foreach (TruyenTacGia tacGia1 in truyenTacGias)
                    {
                        tacGia1.MaTruyen = this.MaTruyen;
                        tacGia1.DangNhom = maNhom;
                        db.TruyenTacGias.Add(tacGia1);
                    }
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
        public static List<vvTruyen> timKiem(string timKiem, int skip, int take)
        {
            try
            {
                webtruyenptEntities db = new webtruyenptEntities();
                return db.Database.SqlQuery<vvTruyen>($"TIMKIEM_Truyen N'{timKiem}',{skip},{take}").ToList();
            }
            catch (DbUpdateException ex)
            {
                SqlException Ex = ex.GetBaseException() as SqlException;
                throw Ex;
            }
        }
        public static List<Truyen> timKiem2(string timKiem, int skip, int take)
        {
            try
            {
                webtruyenptEntities db = new webtruyenptEntities();
                return db.Database.SqlQuery<Truyen>($"TIMKIEM_Truyen2 N'{timKiem}',{skip},{take}").ToList();
            }
            catch (DbUpdateException ex)
            {
                SqlException Ex = ex.GetBaseException() as SqlException;
                throw Ex;
            }
        }

        public void guiThongBao()
        {
            try
            {
                webtruyenptEntities db = new webtruyenptEntities();
                void thongBaoNguoiXem(int maTG)
                {
                    TaiKhoan tacGia = db.TaiKhoans.Find(maTG);
                    string tenTG = tacGia.ButDanh;                    
                    List<TheodoTG> theodoiTGs = db.TheodoTGs.Where(x => x.MaTG == maTG).ToList();
                    foreach (TheodoTG theodoiTG in theodoiTGs)
                    {
                        ThongBao thongBao = new ThongBao();
                        thongBao.ThongBao1 = $"Tác giả {tenTG} đã lên sóng truyện {this.TenTruyen}";
                        thongBao.MaTruyen = this.MaTruyen;
                        thongBao.MaTK = theodoiTG.MaTK;
                        HanhDongCuaTK hanhDongCuaTK = new HanhDongCuaTK();
                        hanhDongCuaTK.thongBao(thongBao);
                    }
                }
                TruyenTacGia[] truyen = db.TruyenTacGias.Where(x => x.MaTruyen == MaTruyen).ToArray();
                foreach (TruyenTacGia truyenTacGia in truyen)
                {
                    thongBaoNguoiXem(truyenTacGia.MaTK);
                }
                
            }
            catch (DbUpdateException ex)
            {
                SqlException Ex = ex.GetBaseException() as SqlException;
                throw Ex;
            }
        }

        public void CapNhatLuotThich(int maTK)
        {
            try
            {
                webtruyenptEntities db = new webtruyenptEntities();
                HanhDongCuaTK hanhDong = new HanhDongCuaTK();
                hanhDong.MaTK = maTK;
                hanhDong.MaTruyen = this.MaTruyen;
                hanhDong.NgayHanhDong = DateTime.Now;
                hanhDong.LoaiHD = hdTaiKhoan.thichTruyen;
                db.HanhDongCuaTKs.Add(hanhDong);
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                SqlException Ex = ex.GetBaseException() as SqlException;
            }
        }

        public int luotXem()
        {
            webtruyenptEntities db = new webtruyenptEntities();
            return db.LuotXems.Where(x => x.MaTruyen == this.MaTruyen).ToList().Count;
        }

        public int luotThich()
        {
            webtruyenptEntities db = new webtruyenptEntities();
            return db.LuotThichTruyens.Where(x => x.MaTruyen == this.MaTruyen).ToList().Count;
        }

        public List<BinhLuan> binhLuan()
        {
            webtruyenptEntities db = new webtruyenptEntities();
            return db.BinhLuans.Where(x => x.MaTruyen == this.MaTruyen).ToList();
        }
        public int soLuonDanhGia()
        {
            webtruyenptEntities db = new webtruyenptEntities();
            return db.DanhGias.Where(x => x.MaTruyen == this.MaTruyen).ToArray().Length;
        }

        public double trungBinhDanhGia()
        {
            double soLuong;
            double trungBinh;
            double tong = 0;
            DanhGia[] danhGias;
            webtruyenptEntities db = new webtruyenptEntities();
            soLuong = db.DanhGias.Where(x => x.MaTruyen == this.MaTruyen).ToArray().Length;
            danhGias = db.DanhGias.Where(x => x.MaTruyen == this.MaTruyen).ToArray();
            foreach (DanhGia danhGia in danhGias)
            {
                tong += int.Parse(danhGia.DanhGia1);
            }
            trungBinh = Math.Round(tong / soLuong, 1);
            return trungBinh;
        }

        public List<LuotThichTruyen> LuotThich()
        {
            webtruyenptEntities db = new webtruyenptEntities();
            return db.LuotThichTruyens.Where(x => x.MaTruyen == this.MaTruyen).ToList();
        }
        public void CreateOrUpdate(List<TruyenTacGia> truyenTacGias)
        {
            webtruyenptEntities db = new webtruyenptEntities();
            if(this.MaTruyen != 0)
            {
                Truyen truyen = db.Truyens.Find(MaTruyen);
                truyen.TenTruyen = this.TenTruyen;
                truyen.MoTa = this.MoTa;
                truyen.AnhBia = this.AnhBia;
                truyen.MaLoai = this.MaLoai;
                truyen.TacGiaGoc = this.TacGiaGoc;
                truyen.LoaiTruyen = this.LoaiTruyen;
                truyen.TamAn = this.TamAn;
                truyen.sua(db, truyenTacGias);
            }
            else
            {
                them(truyenTacGias);
            }
        }
    }
}
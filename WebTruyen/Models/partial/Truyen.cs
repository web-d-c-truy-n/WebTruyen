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
                    if (truyenTacGias != null && truyenTacGias.Count >0)
                    {
                        foreach (TruyenTacGia truyenTacGia in truyenTacGias)
                        {
                            truyenTacGia.MaTruyen = this.MaTruyen;
                            db.TruyenTacGias.Add(truyenTacGia);
                        }
                    }
                    db.SaveChanges();
                    guiThongBao();
                    transaction.Commit();
                }
                catch (DbUpdateException ex)
                {
                    SqlException Ex = ex.GetBaseException() as SqlException;
                    transaction.Rollback();
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
        public static List<vvTruyen> timKiem(string timKiem)
        {
            try
            {
                webtruyenptEntities db = new webtruyenptEntities();
                return db.Database.SqlQuery<vvTruyen>($"TIMKIEM_Truyen N'{timKiem}'").OrderBy(x=>x.NgayDang).ToList();
            }
            catch (DbUpdateException ex)
            {
                SqlException Ex = ex.GetBaseException() as SqlException;
                throw Ex;
            }
        }

        private void guiThongBao()
        {
            try
            {
                int maTG = Helper.Auth.tacGia().MaTG;
                string tenTG = Helper.Auth.tacGia().ButDanh;
                webtruyenptEntities db = new webtruyenptEntities();
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
            return db.LuotXems.Where(x => x.MaTruyen == this.MaTruyen).ToArray().Length;
        }

        public int luotThich()
        {
            webtruyenptEntities db = new webtruyenptEntities();
            return db.LuotThichTruyens.Where(x => x.MaTruyen == this.MaTruyen).ToArray().Length;
        }

        public List<BinhLuan> binhLuan()
        {
            webtruyenptEntities db = new webtruyenptEntities();
            return db.BinhLuans.Where(x=>x.MaTruyen == this.MaTruyen).ToList();
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
            foreach(DanhGia danhGia in danhGias)
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
    }
}
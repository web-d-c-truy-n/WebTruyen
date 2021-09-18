using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebTruyen.Helper;

namespace WebTruyen.Models
{
    public partial class TaiKhoan
    {
        public int soLanNhapSai { get; set; }
        private void tangLanNhap()
        {
            this.soLanNhapSai++;
            switch (soLanNhapSai)
            {
                case 5:
                    this.TinhTrang = ttTaiKhoan.biKhoa30p;
                    this.NgayKhoa = DateTime.Now;
                    break;
                case 10:
                    this.TinhTrang = ttTaiKhoan.biKhoa1h;
                    this.NgayKhoa = DateTime.Now;
                    break;
                case 15:
                    this.TinhTrang = ttTaiKhoan.biKhoanVV;
                    this.NgayKhoa = DateTime.Now;
                    break;
            }
            refresh();
        }

        public void DangNhap(string matKhau)
        {
            int _30p = 1800;
            int _1h = 3600;
            matKhau = Commons.MD5(matKhau);
            if (this.TinhTrang == ttTaiKhoan.biKhoa30p && Commons.khoanCach2Giay(this.NgayKhoa ?? DateTime.Now, DateTime.Now) <= _30p)
            {
                throw new InvalidOperationException("Tài khoản đã bị khóa 30 phút");
            }
            else if (this.TinhTrang == ttTaiKhoan.biKhoa1h && Commons.khoanCach2Giay(this.NgayKhoa ?? DateTime.Now, DateTime.Now) <= _1h)
            {
                throw new InvalidOperationException("Tài khoản đã bị khóa 1h");
            }
            else if (this.TinhTrang == ttTaiKhoan.biKhoanVV)
            {
                throw new InvalidOperationException("Tài khoản đã bị khóa vĩnh viễn");
            }
            else if (this.MatKhau != matKhau)
            {
                tangLanNhap();
                Auth.themTKNoiBo(this);
                throw new InvalidOperationException("Tài khoản hoặc mật khẩu không chính xác");
            }
            else
            {
                this.TinhTrang = 0;
                this.soLanNhapSai = 0;
                Auth.themTKNoiBo(this);
                refresh();
            }
        }

        public void DangKy()
        {
            try
            {
                webtruyenptEntities db = new webtruyenptEntities();
                this.MatKhau = Commons.MD5(this.MatKhau);
                this.NgayTao = DateTime.Now;
                this.TinhTrang = 0;
                db.TaiKhoans.Add(this);
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                SqlException Ex = ex.GetBaseException() as SqlException;
                throw Ex;
            }
        }

        private void refresh()
        {
            webtruyenptEntities db = new webtruyenptEntities();
            TaiKhoan taiKhoan = db.TaiKhoans.Find(this.MaTK);
            taiKhoan.NgayKhoa = this.NgayKhoa;
            taiKhoan.TinhTrang = this.TinhTrang;
            try
            {
                taiKhoan.sua(db);
            }
            catch
            {
                throw;
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
        public void xoaTK(webtruyenptEntities db)
        {
            try
            {
                db.TaiKhoans.Remove(this);
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                SqlException Ex = ex.GetBaseException() as SqlException;
                throw Ex;
            }
        }
        // vai trò admin
        public void xoaTK(int maTK)
        {
            try
            {
                if (this.VaiTro != vtTaiKhoan.admin) return;
                webtruyenptEntities db = new webtruyenptEntities();
                TaiKhoan taiKhoan = db.TaiKhoans.Find(maTK);
                if (taiKhoan.Mail == "admin")
                    throw new InvalidOperationException();
                db.TaiKhoans.Remove(taiKhoan);
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                SqlException Ex = ex.GetBaseException() as SqlException;
                throw Ex;
            }
        }
        // vai trò admin
        public void khoaTK(webtruyenptEntities db, int tinhTrang)
        {
            try
            {
                this.TinhTrang = tinhTrang;
                this.NgayKhoa = DateTime.Now;
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                SqlException Ex = ex.GetBaseException() as SqlException;
                throw Ex;
            }
        }
        public List<ThongBao> nhanThongBao()
        {
            webtruyenptEntities db = new webtruyenptEntities();
            return db.ThongBaos.Where(x => x.MaTK == this.MaTK).ToList();
        }
        // vai trò admin 
        public void GuiThongBao(string tb)
        {
            try
            {
                if (this.VaiTro != vtTaiKhoan.admin) return;
                ThongBao thongBao = new ThongBao();
                thongBao.ThongBao1 = tb;
                thongBao.MaTK = this.MaTK;
                HanhDongCuaTK hanhDongCuaTK = new HanhDongCuaTK();
                hanhDongCuaTK.thongBao(thongBao);
            }
            catch (DbUpdateException ex)
            {
                SqlException Ex = ex.GetBaseException() as SqlException;
                throw Ex;
            }
        }
        public static List<TaiKhoan> timKiem(string timkiem, int skip, int take)
        {
            try
            {
                webtruyenptEntities db = new webtruyenptEntities();
                return db.Database.SqlQuery<TaiKhoan>($"TIMKIEM_TAIKHOAN N'{timkiem}',{skip},{take}").ToList();
            }
            catch (DbUpdateException ex)
            {
                SqlException Ex = ex.GetBaseException() as SqlException;
                throw Ex;
            }
        }

        public static List<TaiKhoan> timKiem_admin(string timkiem, int skip, int take)
        {
            try
            {
                webtruyenptEntities db = new webtruyenptEntities();
                return db.Database.SqlQuery<TaiKhoan>($"TIMKIEM_ADMIN N'{timkiem}',{skip},{take}").ToList();
            }
            catch (DbUpdateException ex)
            {
                SqlException Ex = ex.GetBaseException() as SqlException;
                throw Ex;
            }
        }

        public void dangKyTacGia(webtruyenptEntities db, int vaiTro, string butDanh)
        {
            try
            {
                this.ButDanh = butDanh;
                this.VaiTro = vaiTro == vtTacGia.tacGia ? vtTaiKhoan.tacGiaChuaDuyet : vtTaiKhoan.dichGiaChuaDuyet;
                this.ngayDKTG = DateTime.Now;
                db.SaveChanges();
                List<Admin> admins = db.Admins.ToList();
                foreach (Admin admin in admins)
                {
                    ThongBao thongBao = new ThongBao();
                    thongBao.MaTK = admin.MaTK;
                    thongBao.TacGia = this.MaTK;
                    thongBao.ThongBao1 = $"Tác giả {this.ButDanh} cần được phê duyệt";
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

        public void dangKyAdmin(webtruyenptEntities db)
        {
            try
            {
                this.NgayTao = DateTime.Now;
                this.MatKhau = Commons.MD5(this.MatKhau);
                this.VaiTro = vtTaiKhoan.admin;
                db.TaiKhoans.Add(this);
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                SqlException Ex = ex.GetBaseException() as SqlException;
                throw Ex;
            }
        }
        // vai trò admin
        public void duyetTacGia(int maTK)
        {
            try
            {
                if (this.VaiTro != vtTaiKhoan.admin) return;
                webtruyenptEntities db = new webtruyenptEntities();
                TacGia tacGia = db.TacGias.Where(x => x.MaTG == maTK).First();
                tacGia.duyetTG();
                ThongBao thongBao = new ThongBao();
                thongBao.MaTK = maTK;
                thongBao.ThongBao1 = "Bạn đã được duyệt tác giả";
                HanhDongCuaTK hanhDongCuaTK = new HanhDongCuaTK();
                hanhDongCuaTK.thongBao(thongBao);
            }
            catch (DbUpdateException ex)
            {
                SqlException Ex = ex.GetBaseException() as SqlException;
                throw Ex;
            }
        }
        // vai trò tác giả
        public void duyetTruyen(int maTruyen)
        {
            try
            {
                if (this.VaiTro != vtTaiKhoan.admin) return;
                webtruyenptEntities db = new webtruyenptEntities();
                Truyen truyen = db.Truyens.Find(maTruyen);
                truyen.DaDuyet = true;
                truyen.NgayDang = DateTime.Now;
                db.SaveChanges();
                foreach(TruyenTacGia truyenTacGia in truyen.TruyenTacGias)
                {
                    ThongBao thongBao = new ThongBao();
                    thongBao.MaTK = truyenTacGia.MaTK;
                    thongBao.MaTruyen = truyen.MaTruyen;
                    thongBao.ThongBao1 = $"Truyện {truyen.TenTruyen} đã được duyệt";
                    HanhDongCuaTK hanhDongCuaTK = new HanhDongCuaTK();
                    hanhDongCuaTK.thongBao(thongBao);
                }
                truyen.guiThongBao();
            }
            catch (DbUpdateException ex)
            {
                SqlException Ex = ex.GetBaseException() as SqlException;
                throw Ex;
            }
        }
        // vai trò admin
        public void xoaTacGia(int maTK)
        {
            try
            {
                if (this.VaiTro != vtTaiKhoan.admin) return;
                webtruyenptEntities db = new webtruyenptEntities();
                TacGia tacGia = db.TacGias.Where(x => x.MaTG == maTK).First();
                tacGia.xoaTG();
                ThongBao thongBao = new ThongBao();
                thongBao.MaTK = maTK;
                thongBao.ThongBao1 = $"Bạn đã bị xóa tác giả";
                HanhDongCuaTK hanhDongCuaTK = new HanhDongCuaTK();
                hanhDongCuaTK.thongBao(thongBao);
            }
            catch (DbUpdateException ex)
            {
                SqlException Ex = ex.GetBaseException() as SqlException;
                throw Ex;
            }
        }
        // vai trò admin
        public void khoaTacGia(int maTK)
        {
            try
            {
                if (this.VaiTro != vtTaiKhoan.admin) return;
                webtruyenptEntities db = new webtruyenptEntities();
                TacGia tacGia = db.TacGias.Where(x => x.MaTG == maTK).First();
                tacGia.khoaTG();
                ThongBao thongBao = new ThongBao();
                thongBao.MaTK = maTK;                
                thongBao.ThongBao1 = $"Bạn đã bị khóa tác giả";
                HanhDongCuaTK hanhDongCuaTK = new HanhDongCuaTK();
                hanhDongCuaTK.thongBao(thongBao);
            }
            catch (DbUpdateException ex)
            {
                SqlException Ex = ex.GetBaseException() as SqlException;
                throw Ex;
            }
        }
        // vai trò tác giả
        public void xoaTruyen(int maTruyen)
        {
            try
            {
                webtruyenptEntities db = new webtruyenptEntities();
                Truyen truyen = db.Truyens.Find(maTruyen);
                List<TruyenTacGia> truyenTacGias = truyen.TruyenTacGias.ToList();
                bool hopLe = truyenTacGias.Exists(x => x.MaTK == this.MaTK);                
                if (hopLe)
                {
                    db.Truyens.Remove(truyen);
                    db.SaveChanges();
                    foreach (TruyenTacGia truyenTacGia in truyenTacGias)
                    {
                        ThongBao thongBao = new ThongBao();
                        thongBao.MaTK = truyenTacGia.MaTK;
                        thongBao.ThongBao1 = $"Truyện {truyen.TenTruyen} đã bị xóa";
                        HanhDongCuaTK hanhDongCuaTK = new HanhDongCuaTK();
                        hanhDongCuaTK.thongBao(thongBao);
                    }
                }
            }
            catch (DbUpdateException ex)
            {
                SqlException Ex = ex.GetBaseException() as SqlException;
                throw Ex;
            }
        }
        // vai trò admin
        public void xoaTruyen_admin(int maTruyen)
        {
            try
            {
                if (this.VaiTro != vtTaiKhoan.admin) return;
                webtruyenptEntities db = new webtruyenptEntities();
                Truyen truyen = db.Truyens.Find(maTruyen);
                db.Truyens.Remove(truyen);
                db.SaveChanges();
                foreach (TruyenTacGia truyenTacGia in truyen.TruyenTacGias)
                {
                    ThongBao thongBao = new ThongBao();
                    thongBao.MaTK = truyenTacGia.MaTK;
                    thongBao.MaTruyen = truyen.MaTruyen;
                    thongBao.ThongBao1 = $"Truyện {truyen.TenTruyen} đã bị quản trị viên xóa";
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
        // vai trò tác giả
        public void anTruyen(int maTruyen)
        {
            try
            {
                webtruyenptEntities db = new webtruyenptEntities();
                Truyen truyen = db.Truyens.Find(maTruyen);
                bool hopLe = truyen.TruyenTacGias.ToList().Exists(x => x.MaTK == this.MaTK);
                if (hopLe)
                {
                    truyen.TamAn = true;
                    db.SaveChanges();
                }
            }
            catch (DbUpdateException ex)
            {
                SqlException Ex = ex.GetBaseException() as SqlException;
                throw Ex;
            }
        }
        // vai trò admin
        public void khoaTruyen(int maTruyen)
        {
            try
            {
                if (this.VaiTro != vtTaiKhoan.admin) return;
                webtruyenptEntities db = new webtruyenptEntities();
                Truyen truyen = db.Truyens.Find(maTruyen);
                truyen.Khoa = truyen.Khoa??false?false:true;
                db.SaveChanges();
                foreach (TruyenTacGia truyenTacGia in truyen.TruyenTacGias)
                {
                    ThongBao thongBao = new ThongBao();
                    thongBao.MaTK = truyenTacGia.MaTK;
                    thongBao.MaTruyen = truyen.MaTruyen;
                    thongBao.ThongBao1 = $"Truyện {truyen.TenTruyen} đã bị quản trị viên khóa";
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

        public bool isThichTruyen(int maTruyen)
        {
            webtruyenptEntities db = new webtruyenptEntities();
            LuotThichTruyen luotThich = db.LuotThichTruyens.FirstOrDefault(x => x.MaTK == this.MaTK && x.MaTruyen == maTruyen);
            if (luotThich != null)
                return true;
            else
                return false;
        }
        public bool isThichChuong(int maTruyen, int soChuong)
        {
            webtruyenptEntities db = new webtruyenptEntities();
            LuotThichChuong luotThich = db.LuotThichChuongs.FirstOrDefault(x => x.MaTK == this.MaTK && x.MaTruyen == maTruyen && x.SoChuong == soChuong);
            if (luotThich != null)
                return true;
            else
                return false;
        }
        public List<vvTruyen> vvTruyens()
        {
            webtruyenptEntities db = new webtruyenptEntities();
            List<vvTruyen> vvTruyens = (from tr in db.vvTruyens
                                        join tg in db.TruyenTacGias
                                        on tr.MaTruyen equals tg.MaTruyen
                                        where tg.MaTK == this.MaTK
                                        select tr).ToList();
            return vvTruyens;
        }
        public List<Truyen> Truyens()
        {
            webtruyenptEntities db = new webtruyenptEntities();
            List<Truyen> Truyens = (from tr in db.Truyens
                                        join tg in db.TruyenTacGias
                                        on tr.MaTruyen equals tg.MaTruyen
                                        where tg.MaTK == this.MaTK
                                        select tr).ToList();
            return Truyens;
        }
        public List<TheodoTG> luotTheoDoi()
        {
            webtruyenptEntities db = new webtruyenptEntities();
            return db.TheodoTGs.Where(x => x.MaTG == this.MaTK).ToList();
        }
        public bool isTheoDoi(int maTG)
        {
            webtruyenptEntities db = new webtruyenptEntities();
            TheodoTG theodoTG = db.TheodoTGs.FirstOrDefault(x => x.MaTG == maTG && x.MaTK == MaTK);
            return theodoTG != null;
        }
        public List<ThongBao> thongBaos()
        {
            webtruyenptEntities db = new webtruyenptEntities();
            return db.ThongBaos.Where(x => x.MaTK == this.MaTK && !(x.DaXem??false)).OrderByDescending(x=>x.MaThongBao).ToList();
        }
        public List<ThongBao> allThongBao()
        {
            webtruyenptEntities db = new webtruyenptEntities();
            return db.ThongBaos.Where(x => x.MaTK == this.MaTK).OrderByDescending(x => x.MaThongBao).ToList();
        }

        public bool isTruongNhom(int maNhom)
        {
            webtruyenptEntities db = new webtruyenptEntities();
            int maTK = MaTK;
            ThanhVienNhom thanhVien = db.ThanhVienNhoms.FirstOrDefault(x => x.MaNhom == maNhom && x.MaTK == maTK);
            return thanhVien.Vaitro == vtNhom.nhomTruong;
        }
        public bool isTruyenCuaToi(int maTruyen)
        {
            webtruyenptEntities db = new webtruyenptEntities();
            if (db.TruyenTacGias.FirstOrDefault(x => x.MaTruyen == maTruyen && x.MaTK == MaTK) != null)
                return true;
            int? maNhom = db.TruyenTacGias.FirstOrDefault(x => x.MaTruyen == maTruyen).DangNhom;
            if (maNhom != null && db.ThanhVienNhoms.FirstOrDefault(x => x.MaTK == MaTK && x.MaNhom == maNhom) != null)
                return true;
            return false;
        }
        public bool isTrongNhom(int maNhom)
        {
            webtruyenptEntities db = new webtruyenptEntities();
            int maTK = MaTK;
            ThanhVienNhom thanhVien = db.ThanhVienNhoms.FirstOrDefault(x => x.MaNhom == maNhom && x.MaTK == maTK);
            return thanhVien != null;
        }
    }
}
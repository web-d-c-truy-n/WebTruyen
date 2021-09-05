using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebTruyen.Helper;

namespace WebTruyen.Models
{
    public partial class Admin
    {
        public void DangKyAdmin()
        {
            try
            {
                webtruyenptEntities db = new webtruyenptEntities();
                TaiKhoan taiKhoan = new TaiKhoan();
                taiKhoan.Mail = this.Username;
                taiKhoan.MatKhau = Commons.MD5(this.Password);
                taiKhoan.VaiTro = vtTaiKhoan.admin;
                taiKhoan.NgayTao = DateTime.Now;
                db.TaiKhoans.Add(taiKhoan);
            }
            catch (DbUpdateException ex)
            {
                SqlException Ex = ex.GetBaseException() as SqlException;
                throw Ex;
            }            
        }           
    }
}
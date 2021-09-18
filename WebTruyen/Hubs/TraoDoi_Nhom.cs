using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebTruyen.Helper;
using WebTruyen.Models;

namespace WebTruyen.Hubs
{
    public class TraoDoi_Nhom : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }

        public Task JoinRoom(string maNhom)
        {
            return Groups.Add(Context.ConnectionId, maNhom);
        }

        public Task LeaveRoom(string roomName)
        {
            return Groups.Remove(Context.ConnectionId, roomName);
        }

        public void Message(int maNhom, string noiDung)
        {
            string groupName = maNhom+"";
            TraoDoiNhom traoDoiNhom = new TraoDoiNhom();
            traoDoiNhom.MaNhom = maNhom;
            traoDoiNhom.MaTV = Auth.MaTk();
            traoDoiNhom.NoiDung = noiDung;
            HanhDongCuaTK hanhDongCuaTK = new HanhDongCuaTK();
            //hanhDongCuaTK.traoDoiNhom(traoDoiNhom);
            Clients.Group(groupName).message(new { traoDoiNhom.MaNhom, traoDoiNhom.MaTV, traoDoiNhom.MaTraoDoi, traoDoiNhom.NoiDung, traoDoiNhom.PhanHoi, NgayViet = traoDoiNhom.NgayViet.ToString("dd/MM/yyyy"), traoDoiNhom.ButDanh, traoDoiNhom.Avatar });
        }
    }
}
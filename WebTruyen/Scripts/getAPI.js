var API = {
    // đăng nhập
    login: async function (tk, mk) {
        let result = null
        await $.ajax({
            type: "POST",
            url: '/Login/Login',
            data: JSON.stringify({ tk: tk, mk: mk }),
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                result = data
            },
            error: function () {
                alert("Lỗi hệ thống")
            }
        })
        return result
    },
    // đăng ký
    register: async function (HovaTen, Mail, MatKhau, SDT, Captcha) {
        let result = false
        await $.ajax({
            type: "POST",
            url: '/Login/Register',
            data: JSON.stringify({ HovaTen: HovaTen, Mail: Mail, MatKhau: MatKhau, SDT: SDT, Captcha: Captcha }),
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                result = data
            },
            error: function () {
                alert("Lỗi hệ thống")
            }
        })
        return result
    },
    // đăng xuất
    logout: async function () {
        let result = false
        await $.ajax({
            type: "POST",
            url: '/Login/Logout',
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                result = data
            },
            error: function () {
                alert("Lỗi hệ thống")
            }
        })
        return result
    },
    // lấy thông tin đăng nhập hiện tại
    TTUserHienTai: async function () {
        let result = false
        await $.ajax({
            type: "POST",
            url: '/Login/TTUserHienTai',
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                result = data
            },
            error: function () {
                alert("Lỗi hệ thống")
            }
        })
        return result
    },
    // đăng nhập admin
    loginAdmin: async function (tk, mk) {
        let result = false
        await $.ajax({
            type: "POST",
            url: '/Login/LoginAdmin',
            data: JSON.stringify({ tk: tk, mk: mk }),
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                result = data
            },
            error: function () {
                alert("Lỗi hệ thống")
            }
        })
        return result
    },
    // đăng xuất admin
    logoutAdmin: async function () {
        let result = false
        await $.ajax({
            type: "POST",
            url: '/AdminWeb/Logout',
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                result = data
            },
            error: function () {
                alert("Lỗi hệ thống")
            }
        })
        return result
    },
    // danh sách tài khoản
    dsTaiKhoan: async function (page, pagesize, timKiem) {
        let result = null
        await $.ajax({
            type: "GET",
            url: '/AdminWeb/dsTaiKhoan?page=' + page + "&pagesize=" + pagesize + "&timKiem=" + timKiem,
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                result = data
            },
            error: function () {
                alert("Lỗi hệ thống")
            }
        })
        return result
    },
    // danh sách tác phẩm
    dsTacPham: async function (page, pagesize) {
        let result = null
        await $.ajax({
            type: "POST",
            url: '/AdminWeb/dsTaiKhoan',
            data: JSON.stringify({ page: page, pagesize: pagesize }),
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                result = data
            },
            error: function () {
                alert("Lỗi hệ thống")
            }
        })
        return result
    },
    // đăng ký tác giả
    dkTacGia: async function (butDanh, vaiTro) {
        let result = null
        await $.ajax({
            type: "POST",
            url: '/Home/dkTacGia',
            data: JSON.stringify({ butDanh: butDanh, vaiTro: vaiTro }),
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                result = data
            },
            error: function () {
                alert("Lỗi hệ thống")
            }
        })
        return result
    },
    // cập nhật tình trang tài khoản
    capNhatTinhTrangTK: async function (id, tinhTrang) {
        let result = null
        await $.ajax({
            type: "POST",
            url: '/AdminWeb/setTinhTrang',
            data: JSON.stringify({ id: id, tinhTrang: tinhTrang }),
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                result = data
            },
            error: function () {
                alert("Lỗi hệ thống")
            }
        })
        return result
    },
    layTTTaiKhoan: async function (id) {
        let result
        await $.get("/AdminWeb/layTTTaiKhoan/" + id, function (data) {
            result = data
        })
        return result
    },
    xoaTaiKhoan: async function (id) {
        let result = null
        await $.ajax({
            type: "POST",
            url: '/AdminWeb/xoaTaiKhoan',
            data: JSON.stringify({ id: id }),
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                result = data
            },
            error: function () {
                alert("Lỗi hệ thống")
            }
        })
        return result
    },
    RegisterAdmin: async function (username, Password) {
        let result = null
        await $.ajax({
            type: "POST",
            url: '/AdminWeb/RegisterAdmin',
            data: JSON.stringify({ Username: username, Password: Password }),
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                result = data
            },
            error: function () {
                alert("Lỗi hệ thống")
            }
        })
        return result
    },
    RegisterTacGia: async function (butDanh, vaiTro) {
        let result = null
        await $.ajax({
            type: "POST",
            url: '/Login/RegisterTacGia',
            data: JSON.stringify({ butDanh: butDanh, vaiTro: vaiTro }),
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                result = data
            },
            error: function () {
                alert("Lỗi hệ thống")
            }
        })
        return result
    },
    XetDuyetTG: async function (id) {
        let result = null
        await $.ajax({
            type: "POST",
            url: '/AdminWeb/XetDuyetTG',
            data: JSON.stringify({ id: id }),
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                result = data
            },
            error: function () {
                alert("Lỗi hệ thống")
            }
        })
        return result
    },
    LayThongTinTG: async function (id) {
        let result
        await $.get("/AdminWeb/LayThongTinTG/" + id, function (data) {
            result = data
        })
        return result
    },
    DangTruyen: async function (MaTruyen, tenTruyen, maLoai, tacGiaGoc, tamAn, anhBia, loaiTruyen, moTa, vaiTro, dongTG, dangNhom = null) {
        let result = null
        await $.ajax({
            type: "POST",
            url: '/TacGia/DangTruyen',
            data: JSON.stringify({ MaTruyen: MaTruyen, TenTruyen: tenTruyen, MaLoai: maLoai, TacGiaGoc: tacGiaGoc, TamAn: tamAn, AnhBia: anhBia, LoaiTruyen: loaiTruyen, MoTa: moTa, vaiTro: vaiTro, dongTG: dongTG, dangNhom: dangNhom }),
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                result = data
            },
            error: function () {
                alert("Lỗi hệ thống")
            }
        })
        return result
    },
    XuatCacTruyenIndex: async function (page, pagesize) {
        let result = null
        await $.get("/Home/XuatCacTruyenIndex?page=" + page + "&pagesize=" + pagesize, function (data) {
            result = data
        })
        return result
    },
    XuatCacTruyenTheLoai: async function (page, pagesize, maLoai, loaiTruyen) {
        let result = null
        await $.get("/Home/XuatCacTruyenTheLoai?page=" + page + "&pagesize=" + pagesize + "&maLoai=" + maLoai + "&loaiTruyen=" + loaiTruyen, function (data) {
            result = data
        })
        return result
    },
    CapNhatTKAdmin: async function (MaTK, HovaTen, Mail, MatKhau, SDT) {
        let result = false
        await $.ajax({
            type: "POST",
            url: '/AdminWeb/CapNhatTKAdmin',
            data: JSON.stringify({ MaTK: MaTK, HovaTen: HovaTen, Mail: Mail, MatKhau: MatKhau, SDT: SDT }),
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                result = data
            },
            error: function () {
                alert("Lỗi hệ thống")
            }
        })
        return result
    },
    DSTacGia: async function (page, pagesize, timKiem) {
        let result
        await $.get("/AdminWeb/DSTacGia?page=" + page + "&pagesize=" + pagesize + "&timKiem=" + timKiem, function (data) {
            result = data
        })
        return result
    },
    XoaTacGia: async function (MaTG) {
        let result = false
        await $.ajax({
            type: "POST",
            url: '/AdminWeb/XoaTacGia',
            data: JSON.stringify({ MaTG: MaTG }),
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                result = data
            },
            error: function () {
                alert("Lỗi hệ thống")
            }
        })
        return result
    },
    getCaptcha: async function () {
        let result
        await $.get("/Home/getCaptcha", function (data) {
            result = data
        })
        return result
    },
    timkiemTruyen: async function (timkiem, page, pagesize) {
        let result
        await $.get("/Home/timkiemTruyen?timKiem=" + timkiem + "&page=" + page + "&pagesize=" + pagesize, function (data) {
            result = data
        })
        return result
    },
    layBinhLuan: async function (maTruyen, soChuong) {
        let result
        await $.get("/Truyen/layBinhLuan/" + maTruyen + "?&soChuong=" + soChuong, function (data) {
            result = data
        })
        return result
    },
    vietBinhLuan: async function (maTruyen, soChuong, noiDung, phanHoi) {
        let result = false
        await $.ajax({
            type: "POST",
            url: '/Truyen/vietBinhLuan',
            data: JSON.stringify({ maTruyen: maTruyen, soChuong: soChuong, noiDung: noiDung, phanHoi: phanHoi }),
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                result = data
            },
            error: function () {
                alert("Lỗi hệ thống")
            }
        })
        return result
    },
    danhGia: async function (maTruyen, danhGia) {
        let result = false
        await $.ajax({
            type: "POST",
            url: '/Truyen/danhGia',
            data: JSON.stringify({ maTruyen: maTruyen, danhGia: danhGia }),
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                result = data
            },
            error: function () {
                alert("Lỗi hệ thống")
            }
        })
        return result
    },
    thichTruyen: async function (maTruyen, isThich) {
        let result = false
        await $.ajax({
            type: "POST",
            url: '/Truyen/thichTruyen',
            data: JSON.stringify({ maTruyen: maTruyen, isThich: isThich }),
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                result = data
            },
            error: function () {
                alert("Lỗi hệ thống")
            }
        })
        return result
    },
    CapNhatTKUser: async function (HovaTen, Mail, SDT) {
        let result = false
        await $.ajax({
            type: "POST",
            url: '/Home/CapNhatTaiKhoanUser',
            data: JSON.stringify({ HovaTen: HovaTen, Mail: Mail, SDT: SDT }),
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                result = data
            },
            error: function () {
                alert("Lỗi hệ thống")
            }
        })
        return result
    },
    doiMatKhau: async function (mkHT, mkMoi, xnMK) {
        let result = false
        await $.ajax({
            type: "POST",
            url: '/Home/doiMatKhau',
            data: JSON.stringify({ mkHT: mkHT, mkMoi: mkMoi, xnMK: xnMK }),
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                result = data
            },
            error: function () {
                alert("Lỗi hệ thống")
            }
        })
        return result
    },
    layTruyenTG: async function (maTK) {
        let result
        await $.get("/Home/layTruyenTG/" + maTK, function (data) {
            result = data
        })
        return result
    },
    laySoChuongTruyen: async function (maTruyen) {
        let result
        await $.get("/TacGia/laySoChuongTruyen/" + maTruyen, function (data) {
            result = data
        })
        return result
    },
    layNoiDungChuong: async function (maTruyen, soChuong) {
        let result
        await $.get("/Home/layNoiDungChuong?maTr=" + maTruyen + "&soChuong=" + soChuong, function (data) {
            result = data
        })
        return result
    },
    createOrUpdateChuong: async function (MaTruyen, SoChuong, TenChuong, NoiDung, Dang) {
        let result = false
        await $.ajax({
            type: "POST",
            url: '/TacGia/createOrUpdateChuong',
            data: JSON.stringify({ MaTruyen: MaTruyen, SoChuong: SoChuong, TenChuong: TenChuong, NoiDung: NoiDung, Dang: Dang }),
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                result = data
            },
            error: function () {
                alert("Lỗi hệ thống")
            }
        })
        return result
    },
    thichChuong: async function (maTruyen, soChuong, isThich) {
        let result = false
        await $.ajax({
            type: "POST",
            url: '/Truyen/thichChuong',
            data: JSON.stringify({ maTruyen: maTruyen, soChuong: soChuong, isThich: isThich }),
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                result = data
            },
            error: function () {
                alert("Lỗi hệ thống")
            }
        })
        return result
    },
    layThongKe: async function (soNgay) {
        let result
        await $.get("/TacGia/layThongKe?soNgay=" + soNgay, function (data) {
            result = data
        })
        return result
    },
    theoDoi: async function (maTG, isTheoDoi) {
        let result = false
        await $.ajax({
            type: "POST",
            url: '/Home/theoDoi',
            data: JSON.stringify({ maTG: maTG, isTheoDoi: isTheoDoi }),
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                result = data
            },
            error: function () {
                alert("Lỗi hệ thống")
            }
        })
        return result
    },
    getThongBao: async function () {
        let result
        await $.get("/Home/getThongBao", function (data) {
            result = data
        })
        return result
    },
    demThongBao: async function () {
        let result
        await $.get("/Home/demThongBao", function (data) {
            result = data
        })
        return result
    },
    xoaTruyenTG: async function (maTruyen) {
        let result = false
        await $.ajax({
            type: "POST",
            url: '/TacGia/xoaTruyen',
            data: JSON.stringify({ maTruyen: maTruyen }),
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                result = data
            },
            error: function () {
                alert("Lỗi hệ thống")
            }
        })
        return result
    },
    xoaChuongTG: async function (maTruyen, soChuong) {
        let result = false
        await $.ajax({
            type: "POST",
            url: '/TacGia/xoaChuong',
            data: JSON.stringify({ maTruyen: maTruyen, soChuong: soChuong }),
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                result = data
            },
            error: function () {
                alert("Lỗi hệ thống")
            }
        })
        return result
    },
    suaButDanh: async function (butDanh) {
        let result = false
        await $.ajax({
            type: "POST",
            url: '/TacGia/suaButDanh',
            data: JSON.stringify({ butDanh: butDanh }),
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                result = data
            },
            error: function () {
                alert("Lỗi hệ thống")
            }
        })
        return result
    },
    layTruyenTGAdmin: async function (maTG) {
        let result
        await $.get("/AdminWeb/layTruyenTG?maTG=" + maTG, function (data) {
            result = data
        })
        return result
    },
    dsTruyen: async function (page, pagesize, timKiem) {
        let result
        await $.get("/AdminWeb/dsTruyen?page=" + page + "&pagesize=" + pagesize + "&timKiem=" + timKiem, function (data) {
            result = data
        })
        return result
    },
    chiTietTruyen: async function (maTruyen) {
        let result
        await $.get("/AdminWeb/chiTietTruyen?maTruyen=" + maTruyen, function (data) {
            result = data
        })
        return result
    },
    thaoTac: async function (maTruyen, thaoTac) {
        let result = false
        await $.ajax({
            type: "POST",
            url: '/AdminWeb/thaoTac',
            data: JSON.stringify({ maTruyen: maTruyen, thaoTac: thaoTac }),
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                result = data
            },
            error: function () {
                alert("Lỗi hệ thống")
            }
        })
        return result
    },
    KhoaTacGia: async function (maTG) {
        let result = false
        await $.ajax({
            type: "POST",
            url: '/AdminWeb/KhoaTacGia',
            data: JSON.stringify({ maTG: maTG }),
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                result = data
            },
            error: function () {
                alert("Lỗi hệ thống")
            }
        })
        return result
    },
    dsAdmin: async function (page, pagesize, timKiem) {
        let result = null
        await $.ajax({
            type: "GET",
            url: '/AdminWeb/dsAdmin?page=' + page + "&pagesize=" + pagesize + "&timKiem=" + timKiem,
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                result = data
            },
            error: function () {
                alert("Lỗi hệ thống")
            }
        })
        return result
    },
    taoNhom: async function (tenNhom) {
        let result = false
        await $.ajax({
            type: "POST",
            url: '/TacGia/taoNhom',
            data: JSON.stringify({ tenNhom: tenNhom }),
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                result = data
            },
            error: function () {
                alert("Lỗi hệ thống")
            }
        })
        return result
    },
    thamGiaNhom: async function (maNhom) {
        let result = false
        await $.ajax({
            type: "POST",
            url: '/TacGia/thamGiaNhom',
            data: JSON.stringify({ maNhom: maNhom }),
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                result = data
            },
            error: function () {
                alert("Lỗi hệ thống")
            }
        })
        return result
    },
    pheDuyetThanhVien: async function (maTV, maNhom) {
        let result = false
        await $.ajax({
            type: "POST",
            url: '/NhomTacGia/pheDuyetThanhVien',
            data: JSON.stringify({ maTV: maTV ,maNhom: maNhom }),
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                result = data
            },
            error: function () {
                alert("Lỗi hệ thống")
            }
        })
        return result
    },
    xoaThanhVien: async function (maTV, maNhom) {
        let result = false
        await $.ajax({
            type: "POST",
            url: '/NhomTacGia/xoaThanhVien',
            data: JSON.stringify({ maTV: maTV, maNhom: maNhom }),
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                result = data
            },
            error: function () {
                alert("Lỗi hệ thống")
            }
        })
        return result
    },
    roiNhom: async function (maNhom) {
        let result = false
        await $.ajax({
            type: "POST",
            url: '/NhomTacGia/roiNhom',
            data: JSON.stringify({maNhom: maNhom }),
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                result = data
            },
            error: function () {
                alert("Lỗi hệ thống")
            }
        })
        return result
    },
    timKiemTV: async function (timKiem, maNhom) {
        let result
        await $.get("/NhomTacGia/timKiem?timKiem=" + timKiem + "&maNhom=" + maNhom, function (data) {
            result = data
        })
        return result
    },
    thangChuc: async function (maTV, maNhom) {
        let result = false
        await $.ajax({
            type: "POST",
            url: '/NhomTacGia/thangChuc',
            data: JSON.stringify({ maTV: maTV, maNhom: maNhom }),
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                result = data
            },
            error: function () {
                alert("Lỗi hệ thống")
            }
        })
        return result
    },
    layTruyenNhom: async function (maNhom) {
        let result = false
        await $.ajax({
            type: "POST",
            url: '/NhomTacGia/layTruyenNhom',
            data: JSON.stringify({ maNhom: maNhom }),
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                result = data
            },
            error: function () {
                alert("Lỗi hệ thống")
            }
        })
        return result
    },
    suaTTNhom: async function (maNhom,tenNhom,khauHieu) {
        let result = false
        await $.ajax({
            type: "POST",
            url: '/NhomTacGia/suaTTNhom',
            data: JSON.stringify({ maNhom: maNhom, tenNhom: tenNhom, khauHieu: khauHieu }),
            dataType: "json",
            contentType: 'application/json; charset=utf-8', 
            success: function (data) {
                result = data
            },
            error: function () {
                alert("Lỗi hệ thống")
            }
        })
        return result
    },
    noiDungTraoDoi: async function (id) {
        let result
        await $.get("/NhomTacGia/noiDungTraoDoi/" + id, function (data) {
            result = data
        })
        return result
    },
}

const ttTaiKhoan = {
    binhThuong: 0,
    biKhoa30p: 1,
    biKhoa1h: 2,
    biKhoanVV: 3,
}

const ttTruyen = {
    dangTH: 1,
    hoanThanh: 2,
}

const vtTacGia = {
    tacGia: 1,
    dichGia: 2,
}

const vtAdmin = {
    admin: 1
}

function tinhTrangTK(so) {
    let str
    switch (so) {
        case 1:
            str = "Khóa 30 phút";
            break;
        case 2:
            str = "Khóa 60 phút";
            break;
        case 3:
            str = "Khóa vĩnh viễn";
            break;
        case 0:
            str = "Hoạt động";
            break;
    }
    return str;
}
function vaitroTg(so) {
    let vt
    switch (so) {
        case 1:
            vt = "Tác giả";
            break;
        case 2:
            vt = "Dịch giả";
            break;
    }
    return vt;
}
// chuyển tiếng việt có dấu thành không dấu
const locdau = (obj) => {
    var str;
    if (eval(obj))
        str = eval(obj).value;
    else
        str = obj;
    str = str.toLowerCase();
    str = str.replace(/à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ/g, "a");
    str = str.replace(/è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ/g, "e");
    str = str.replace(/ì|í|ị|ỉ|ĩ/g, "i");
    str = str.replace(/ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ/g, "o");
    str = str.replace(/ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ/g, "u");
    str = str.replace(/ỳ|ý|ỵ|ỷ|ỹ/g, "y");
    str = str.replace(/đ/g, "d");
    //str= str.replace(/!|@|%|\^|\*|\(|\)|\+|\=|\<|\>|\?|\/|,|\.|\:|\;|\'| |\"|\&|\#|\[|\]|~|$|_/g,"-");  
    /* tìm và thay thế các kí tự đặc biệt trong chuỗi sang kí tự - */
    //str= str.replace(/-+-/g,"-"); //thay thế 2- thành 1-  
    str = str.replace(/^\-+|\-+$/g, "");
    //cắt bỏ ký tự - ở đầu và cuối chuỗi 
    eval(obj).value = str.toUpperCase();
}

var toast = {
    success: function (msg, sec = 2000) {
        let html = '<div class="alert alert-success" id="success" style="position: fixed; top: 0; right: 0; z-index:999999;display:none">' + msg + '</div >';
        let element = $(html).prependTo("body");
        $(element).fadeToggle(sec * (1 / 4), function () {
            $(element).fadeToggle(sec * (3 / 4), function () {
                $(element).remove()
            })
        })
    },
    warning: function (msg, sec = 2000) {
        let html = '<div class="alert alert-warning" id="success" style="position: fixed; top: 0; right: 0; z-index:999999;display:none">' + msg + '</div >';
        let element = $(html).prependTo("body");
        $(element).fadeToggle(sec * (1 / 4), function () {
            $(element).fadeToggle(sec * (3 / 4), function () {
                $(element).remove()
            })
        })
    },
    error: function (msg, sec = 2000) {
        let html = '<div class="alert alert-danger" id="success" style="position: fixed; top: 0; right: 0; z-index:999999;display:none">' + msg + '</div >';
        let element = $(html).prependTo("body");
        $(element).fadeToggle(sec * (1 / 4), function () {
            $(element).fadeToggle(sec * (3 / 4), function () {
                $(element).remove()
            })
        })
    },
}
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
    register: async function (HovaTen, Mail, MatKhau, SDT ) {
        let result = false
        await $.ajax({
            type: "POST",
            url: '/Login/Register',
            data: JSON.stringify({ HovaTen: HovaTen, Mail: Mail, MatKhau: MatKhau, SDT:SDT }),
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
    dsTaiKhoan: async function (page, pagesize) {
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
        await $.get("/AdminWeb/layTTTaiKhoan/"+id, function (data) {
            result = data
        })
        return result
    },
    xoaTaiKhoan: async function (id) {
        let result = null
        await $.ajax({
            type: "POST",
            url: '/AdminWeb/xoaTaiKhoan',
            data: JSON.stringify({ id: id}),
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
    DangTruyen: async function (tenTruyen, maLoai, tacGiaGoc, tamAn, anhBia, loaiTruyen, moTa, vaiTro, dongTG) {
        let result = null
        await $.ajax({
            type: "POST",
            url: '/TacGia/DangTruyen',
            data: JSON.stringify({ TenTruyen: tenTruyen, MaLoai: maLoai, TacGiaGoc: tacGiaGoc, TamAn: tamAn, AnhBia: anhBia, LoaiTruyen: loaiTruyen, MoTa: moTa, vaiTro: vaiTro, dongTG: dongTG }),
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
        debugger
        let result = null
        await $.get("/Home/XuatCacTruyenIndex?page=" + page + "&pagesize=" + pagesize, function (data) {
            result = data
        })
        return result
    }

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
function locdau(obj) {
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
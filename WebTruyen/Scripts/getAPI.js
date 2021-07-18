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
                alert("Đang nhập không thành công: Lỗi hệ thống")
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
                alert("Đang nhập không thành công: Lỗi hệ thống")
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
                alert("Đang nhập không thành công: Lỗi hệ thống")
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
                alert("Đang nhập không thành công: Lỗi hệ thống")
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
                alert("Đang nhập không thành công: Lỗi hệ thống")
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
                alert("Đang nhập không thành công: Lỗi hệ thống")
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
                alert("Đang nhập không thành công: Lỗi hệ thống")
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
                alert("Đang nhập không thành công: Lỗi hệ thống")
            }
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
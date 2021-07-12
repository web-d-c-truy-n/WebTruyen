var API = {
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
    }
}
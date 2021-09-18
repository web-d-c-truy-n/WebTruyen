const locdau2 = (obj) => {    
    var str;
    str = obj;
    str = str.toLowerCase();
    str = str.replace(/à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ/g, "a");
    str = str.replace(/è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ/g, "e");
    str = str.replace(/ì|í|ị|ỉ|ĩ/g, "i");
    str = str.replace(/ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ/g, "o");
    str = str.replace(/ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ/g, "u");
    str = str.replace(/ỳ|ý|ỵ|ỷ|ỹ/g, "y");
    str = str.replace(/đ/g, "d");
    str = str.replace(/!|@|%|\^|\*|\(|\)|\+|\=|\<|\>|\?|\/|,|\.|\:|\;|\'| |\"|\&|\#|\[|\]|~|$|_/g, "-");
    /* tìm và thay thế các kí tự đặc biệt trong chuỗi sang kí tự - */
    str = str.replace(/-+-/g, "-"); //thay thế 2- thành 1-  
    str = str.replace(/^\-+|\-+$/g, "");
    //cắt bỏ ký tự - ở đầu và cuối chuỗi 
    return str
}
class ThanhVien extends React.Component {
    mouseenter = () => {
        showMenu = true
    }
    mouseleave = () => {
        showMenu = false
    }
    dropdown = (e) => {
        debugger
        $(e).next().toggle()
    }
    Error = (e) => {
        debugger
        e.onerror = null; e.src = "/Asset/Web/wp-content/themes/madara/images/no-avatar.png";
    }
    XoaThanhVien = async (maTV) => {
        if (confirm("Bạn có muốn xóa thành viên không?")) {
            let rs = await API.xoaThanhVien(maTV, maNhom)
            if (rs) {
                readerTV()
            }
        }
    }
    ThangChuc = async (maTV, vaiTro) => {
        if (confirm(vaiTro == 1?"Bạn có muốn cách chức nhóm trưởng thành viên này không?":"Bạn có muốn thăng chức thành viên này không?")) {
            let rs = await API.thangChuc(maTV, maNhom)
            if (rs) {
                readerTV()
            }
        }
    }
    render() {        
        let isNhomTruong = (maTV, vaiTro) => (
            <div class="action dropdown" onMouseEnter={this.mouseenter} onMouseLeave={this.mouseleave}>
                <a href="javascript:void(0)" class="remove-manga-history" onClick={(e) => this.dropdown(e.target)}>...</a>
                <div class="dropdown-menu" style={{ "display": "none" }}>
                    <a class="dropdown-item" href="javascript:void(0)" onClick={() => this.ThangChuc(maTV, vaiTro)}>{vaiTro == 1 ? "Giáng chức làm thành viên" : "Thăng làm nhóm trưởng"}</a>
                    <a class="dropdown-item" href="javascript:void(0)" onClick={() => this.XoaThanhVien(maTV)}>Xóa khỏi nhóm</a>
                </div>
            </div>
        )
        let data = this.props.data
        let html =[]
        data.forEach((item, index) => {
            html.push(<div class="col-md-4">
                <div class="history-content">
                    <div class="item-thumb">
                        <a href="#" title="#">
                            <img width="75" height="106" src={item.Avatar == null ? "/Asset/Web/wp-content/themes/madara/images/no-avatar.png" : item.Avatar} onError={(e) => this.Error(e.target)} class="img-responsive" alt="#" />
                        </a>
                    </div>
                    <div class="item-infor">
                        <div class="chapter">
                            <span class="chap">
                                <h3>
                                    <a href={"/Home/TacGia/" + locdau2(item.ButDanh + "-" + item.MaTK)}>{item.ButDanh}</a>
                                </h3>
                            </span>
                        </div>
                        <div class="settings-title">
                            <h3>
                                <a href="javascript:void(0)">{item.Vaitro==1?"Nhóm trưởng":"Thành viên"}</a>
                            </h3>
                        </div>
                        <div class="post-on font-meta">
                            {item.Ngayvaonhom}
                        </div>
                    </div>
                    {truongNhom == 1 ? isNhomTruong(item.MaTK, item.Vaitro) : ""}
                </div>
            </div >)
        })
        return (
            <div class="row">
                {html}
            </div>
            )
    }
}
const readerTV = async () => {
    let timKiem = $("#timKiemTV").val()
    let data = await API.timKiemTV(timKiem, maNhom)
    ReactDOM.render(<ThanhVien data={data} />, document.getElementById('thanhVien'))
}
$(document).ready(function () {    
    readerTV();
    $("#timKiemTV").keyup(function () {
        readerTV()
    })
})
const locdau2 = (obj) => {
    debugger
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
class Commons extends React.Component {
    render() {
        return (<section class="content">
            <div class="container-fluid">
                {this.props.children}
            </div>
        </section>)
    }
}
class Pagination extends React.Component {
    pageClick = (page, f) => {        
        f(page)
    }
    render() {
        let pagesize = this.props.pagesize
        let page = this.props.page
        let html
        if (page == 1) {
            if (pagesize == 1) {
                html = (<ul class="pagination justify-content-end">
                    <li class="page-item active"><a class="page-link" href="##">{page}</a></li>
                </ul>)
            } else if (pagesize == 2) {
                html = (<ul class="pagination justify-content-end">
                    <li class="page-item active"><a class="page-link" href="##">{page}</a></li>
                    <li class="page-item" onClick={() => this.pageClick(page+1, this.props.fpageClick)}><a class="page-link" href="##">{page + 1}</a></li>
                </ul>)
            } else if (pagesize == 3) {
                html = (<ul class="pagination justify-content-end">
                    <li class="page-item active" ><a class="page-link" href="##">{page}</a></li>
                    <li class="page-item" onClick={() => this.pageClick(page +1, this.props.fpageClick)}><a class="page-link" href="##">{page + 1}</a></li>
                    <li class="page-item" onClick={() => this.pageClick(page +2, this.props.fpageClick)}><a class="page-link" href="##">{page + 2}</a></li>
                </ul>)
            } else if (pagesize > 3) {
                html = (<ul class="pagination justify-content-end">
                    <li class="page-item active"><a class="page-link" href="##">{page}</a></li>
                    <li class="page-item" onClick={() => this.pageClick(page + 1, this.props.fpageClick)}><a class="page-link" href="##">{page + 1}</a></li>
                    <li class="page-item" onClick={() => this.pageClick(page + 2, this.props.fpageClick)}><a class="page-link" href="##">{page + 2}</a></li>
                    <li class="page-item" onClick={() => this.pageClick(page + 1, this.props.fpageClick)}><a class="page-link" href="##">Next</a></li>
                </ul>)
            }
        } else if (page == pagesize) {
            if (pagesize == 2) {
                html = (<ul class="pagination justify-content-end">
                    <li class="page-item" onClick={() => this.pageClick(page - 1, this.props.fpageClick)}><a class="page-link" href="##">{page - 1}</a></li>
                    <li class="page-item active"><a class="page-link" href="##">{page}</a></li>
                </ul>)
            } else if (pagesize == 3) {
                html = (<ul class="pagination justify-content-end">
                    <li class="page-item" onClick={() => this.pageClick(page - 2, this.props.fpageClick)}><a class="page-link" href="##">{page - 2}</a></li>
                    <li class="page-item" onClick={() => this.pageClick(page - 1, this.props.fpageClick)}><a class="page-link" href="##">{page - 1}</a></li>
                    <li class="page-item active"><a class="page-link" href="##">{page}</a></li>
                </ul>)
            } else if (pagesize > 3) {
                html = (<ul class="pagination justify-content-end">
                    <li class="page-item" onClick={() => this.pageClick(page -1, this.props.fpageClick)}><a class="page-link" href="##">Previous</a></li>
                    <li class="page-item" onClick={() => this.pageClick(page -2, this.props.fpageClick)}><a class="page-link" href="##">{page - 2}</a></li>
                    <li class="page-item" onClick={() => this.pageClick(page - 1, this.props.fpageClick)}><a class="page-link" href="##">{page - 1}</a></li>
                    <li class="page-item active"><a class="page-link" href="##">{page}</a></li>
                </ul>)
            }
        } else {
            if (page == 2) {
                if (pagesize == 3) {
                    html = (<ul class="pagination justify-content-end">
                        <li class="page-item" onClick={() => this.pageClick(page -1, this.props.fpageClick)}><a class="page-link" href="##">{page - 1}</a></li>
                        <li class="page-item active"><a class="page-link" href="##">{page}</a></li>
                        <li class="page-item" onClick={() => this.pageClick(page + 1, this.props.fpageClick)}><a class="page-link" href="##">{page + 1}</a></li>
                    </ul>)
                } else {
                    html = (<ul class="pagination justify-content-end">
                        <li class="page-item" onClick={() => this.pageClick(page - 1, this.props.fpageClick)}><a class="page-link" href="##">{page - 1}</a></li>
                        <li class="page-item active"><a class="page-link" href="##">{page}</a></li>
                        <li class="page-item" onClick={() => this.pageClick(page + 1, this.props.fpageClick)}><a class="page-link" href="##">{page + 1}</a></li>
                        <li class="page-item" onClick={() => this.pageClick(page + 1, this.props.fpageClick)}><a class="page-link" href="##">Next</a></li>
                    </ul>)
                }
                
            }else if (pagesize > 3) {
                html = (<ul class="pagination justify-content-end">
                    <li class="page-item" onClick={() => this.pageClick(page - 1, this.props.fpageClick)}><a class="page-link" href="##">Previous</a></li>
                    <li class="page-item" onClick={() => this.pageClick(page - 1, this.props.fpageClick)}><a class="page-link" href="##">{page - 1}</a></li>
                    <li class="page-item active"><a class="page-link" href="##">{page}</a></li>
                    <li class="page-item" onClick={() => this.pageClick(page + 1, this.props.fpageClick)}><a class="page-link" href="##">{page + 1}</a></li>
                    <li class="page-item" onClick={() => this.pageClick(page + 1, this.props.fpageClick)}><a class="page-link" href="##">Next</a></li>
                </ul>)
            }
            
        }
        return html
    }
}

// index
class Index extends React.Component {
    render() {
        return (<Commons>
            <div class="row">
                <div class="col-lg-3 col-6">
                <div class="small-box bg-info">
                        <div class="inner">
                            <h3>{SoNguoiDK}</h3>
                            <p>Số người đăng ký</p>
                        </div>
                        <div class="icon">
                            <i class="ion ion-bag"></i>
                        </div>                       
                    </div>
                </div>
            <div class="col-lg-3 col-6">
                <div class="small-box bg-success">
                        <div class="inner">
                            <h3>{SoLuotXem}</h3>

                            <p>Số lượt xem</p>
                        </div>
                        <div class="icon">
                            <i class="ion ion-stats-bars"></i>
                        </div>
                        
                    </div>
                </div>
            <div class="col-lg-3 col-6">
                <div class="small-box bg-warning">
                        <div class="inner">
                            <h3>{SoLuotThich}</h3>

                            <p>Số lượt thích</p>
                        </div>
                        <div class="icon">
                            <i class="ion ion-person-add"></i>
                        </div>                        
                    </div>
                </div>
            <div class="col-lg-3 col-6">
                <div class="small-box bg-danger">
                        <div class="inner">
                            <h3>{SoLuotTheoDoi}</h3>

                            <p>Số lượt theo dõi</p>
                        </div>
                        <div class="icon">
                            <i class="ion ion-pie-graph"></i>
                        </div>                        
                    </div>
                </div>
        </div>
        </Commons>)
    }
}
// quản lý tài khoản
class QLTaiKhoan extends React.Component {
    constructor(props) {
        super(props);
    }
    SuaTTTK = async () => {
        debugger
        let MaTK = parseInt($("#MaTK").val())
        let hoTen =  $("input.tenTK").val();
        let Mail = $("input.emailTK").val();
        let sdt = $("input.sdtTK").val();
        let mk = $("#CapLaiMK").is(':checked') ? "1111" : null
        let rs = await API.CapNhatTKAdmin(MaTK, hoTen, Mail, mk, sdt)
        if (rs) {            
            toast.success("Cập nhật thành công",4000)            
        }
    }
    Edit = async (id, TinhTrang, page) => {        
        let rs = await API.capNhatTinhTrangTK(id, TinhTrang)
        this.dsTaiKhoan(page)
    }
    Delete = async (id, page) => {
        let cf = confirm("Bạn có muốn xóa tác giả này chứ!")
        if (!cf) return
        let rs = await API.xoaTaiKhoan(id)
        if (rs) {
            this.dsTaiKhoan(page)
            toast.success("Xóa tài khoản thành công")
        }
    }
    Details = async (id) => {
        let userid = id
        let thongtin = await API.layTTTaiKhoan(userid)        
        $(".tenTK").text(thongtin.HovaTen);
        $(".emailTK").text(thongtin.Mail);
        $(".sdtTK").text(thongtin.SDT);
        $(".tinhtrang2").text(tinhTrangTK(thongtin.TinhTrang));
        $(".tenTK").val(thongtin.HovaTen);
        $(".emailTK").val(thongtin.Mail);
        $(".sdtTK").val(thongtin.SDT);
        $("#MaTK").val(thongtin.MaTK)
        $("#avatar").attr("src",thongtin.Avatar)
    }
    dsTaiKhoan = async (page) => {
        let data = await API.dsTaiKhoan(page, 10, $("#search").val())
        let html = []
        let dstk = this.dsTaiKhoan
        let state = this.setState                
        data.forEach((x) => {
            let html2 = <tr>
                <td>{x.MaTK}</td>
                <td>{x.HovaTen}</td>
                <td>{x.Mail}</td>
                <td>{x.SDT}</td>
                <td>{x.NgayTao}</td>
                <td>{tinhTrangTK(x.TinhTrang)}</td>
                <td>
                    <div class="dropdown">
                        <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown">
                            <a href="##">Edit</a>
                    </button>
                        <div class="dropdown-menu">
                            <a class="dropdown-item" href="##" onClick={() => this.Edit(x.MaTK, 1, page)}>Khóa 30 phút</a>
                            <a class="dropdown-item" href="##" onClick={() => this.Edit(x.MaTK, 2, page)}>Khóa 60 phút</a>
                            <a class="dropdown-item" href="##" onClick={() => this.Edit(x.MaTK, 3, page)}>Khóa vĩnh viễn</a>
                            <a class="dropdown-item" href="##" onClick={() => this.Edit(x.MaTK, 0, page)}>Hoạtđộng</a>
                        </div>
                    </div>
                    <div>
                        <button type="button" class="btn btn-default thongtin" data-toggle="modal" data-target="#myModal" onClick={() => this.Details(x.MaTK)}>
                            <a href="##">Details</a>
                        </button>


                    </div>
                    <div>
                        <button type="button" class="btn btn-default xoaTK" onClick={() => this.Delete(x.MaTK, page)}>
                            <a href="##">Delete</a>
                        </button>
                    </div>
                </td>
            </tr>
            html.push(html2)
        })
        ReactDOM.render(<QLTaiKhoan load={false} page={page} pagesize={Math.ceil(CountTK / 10)}>{html}</QLTaiKhoan>, document.getElementById('body'))
    }
    load = async () => {
        this.dsTaiKhoan(1)
    }
    render() {

        return (<Commons>
            {this.props.load ? this.load():""}
            <table class="table table-hover">
                <thead>
                    <tr>
                        <th>Mã Tài Khoản</th>
                        <th>Họ và Tên</th>
                        <th>Mail</th>
                        <th>Số điện thoại</th>
                        <th>Ngày tạo</th>
                        <th>Tình trạng</th>
                        <th></th>
                    </tr>        
                </thead>
                <tbody>
                    {this.props.children}
                </tbody>
                <tfoot>
                    <Pagination page={this.props.page} pagesize={this.props.pagesize} fpageClick={this.dsTaiKhoan} />
                </tfoot>
            </table>
            <div class="modal fade" id="myModal">
                <div class="modal-dialog modal-xl">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">Thông tin tài khoản</h4>
                            <button type="button" class="close" data-dismiss="modal" onClick={() => this.dsTaiKhoan(this.props.page)}>&times;</button>
                        </div>
                        <div class="modal-body">
                            <input type="hidden" id="MaTK" />
                            <section class="content">
                                <div class="container-fluid">
                                    <div class="row">
                                        <div class="col-md-3">
                                            <div class="card card-primary card-outline">
                                                <div class="card-body box-profile">
                                                    <div class="text-center">
                                                        <img class="profile-user-img img-fluid img-circle" id="avatar" src="../../dist/img/user4-128x128.jpg" alt="User profile picture" />
                                                    </div>

                                                    <h3 class="profile-username text-center tenTK">Nina Mcintire</h3>                                                    

                                                    <ul class="list-group list-group-unbordered mb-3">
                                                        <li class="list-group-item">
                                                            <b>Số điện thoại</b> <a class="float-right sdtTK">1,322</a>
                                                        </li>
                                                        <li class="list-group-item">
                                                            <b>Email</b> <a class="float-right emailTK">543</a>
                                                        </li>
                                                        <li class="list-group-item">
                                                            <b>Tình trạng</b> <a class="float-right tinhtrang2">13,287</a>
                                                        </li>
                                                    </ul>                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-9">
                                            <div class="card">
                                                <div class="card-header p-2">
                                                    <ul class="nav nav-pills">                                                        
                                                        <li class="nav-item active"><a class="nav-link" href="#settings" data-toggle="tab">Settings</a></li>
                                                    </ul>
                                                </div>
                                                <div class="card-body">
                                                    <div class="tab-content">
                                                        <div class="tab-pane active" id="settings">
                                                            <div class="form-horizontal">
                                                                <div class="form-group row">
                                                                    <label for="inputName" class="col-sm-2 col-form-label">Tên tài khoản</label>
                                                                    <div class="col-sm-10">
                                                                        <input type="text" class="form-control tenTK" id="inputName" placeholder="Name"/>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group row">
                                                                    <label for="inputEmail" class="col-sm-2 col-form-label">Email</label>
                                                                    <div class="col-sm-10">
                                                                        <input type="email" class="form-control emailTK" id="inputEmail" placeholder="Email"/>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group row">
                                                                    <label for="inputName2" class="col-sm-2 col-form-label">Số Điện Thoại</label>
                                                                    <div class="col-sm-10">
                                                                        <input type="text" class="form-control sdtTK" id="inputName2" placeholder="Name"/>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group row checkbox">
                                                                    <label for="inputName2" class="col-sm-2 col-form-label"></label>
                                                                    <div class="col-sm-10">
                                                                        <label for="inputExperience" class="col-sm-12 col-form-label" style={{ width: "100%" }}><input type="checkbox" value="" id="CapLaiMK" /> Cấp lại pass</label>
                                                                    </div>                                                                    
                                                                </div>
                                                                <div class="form-group row checkbox">
                                                                    <label for="inputName2" class="col-sm-2 col-form-label"></label>
                                                                    <div class="col-sm-10">
                                                                        <button class="btn btn-danger" onClick={this.SuaTTTK}>Sửa</button>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </section>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-dismiss="modal" onClick={() => this.dsTaiKhoan(this.props.page)}>Close</button>
                        </div>
                    </div>
                </div>
            </div>
        </Commons>)
    }
}

class QLTacGia extends React.Component {
    constructor(props) {
        super(props);
    }
    SuaTTTK = async () => {
        debugger
        let MaTK = parseInt($("#MaTK").val())
        let hoTen = $("input.tenTK").val();
        let Mail = $("input.emailTK").val();
        let sdt = $("input.sdtTK").val();
        let mk = $("#CapLaiMK").is(':checked') ? "1111" : null
        let rs = await API.CapNhatTKAdmin(MaTK, hoTen, Mail, mk, sdt)
        if (rs) {
            toast.success("Cập nhật thành công", 4000)
        }
    }
    Duyet = async (id, page) => {
        let rs = await API.XetDuyetTG(id)
        if (rs) {
            this.dsTacGia(page)
        }
    }
    Delete = async (id, page) => {
        debugger
        let cf = confirm("Bạn có muốn xóa chứ?")
        if (!cf) return
        let rs = await API.XoaTacGia(parseInt(id))
        if (rs) {
            this.dsTacGia(page)
            toast.success("Xóa thành công!")
        } else {
            toast.error("Xóa thất bại!")
        }
    }
    Details = async (id) => {
        let userid = id
        let thongtin = await API.layTTTaiKhoan(userid)
        $(".tenTK").text(thongtin.ButDanh);
        $(".emailTK").text(thongtin.Mail);
        $(".sdtTK").text(thongtin.SDT);
        $(".tinhtrang2").text(tinhTrangTK(thongtin.TinhTrang));
        $(".tenTK").val(thongtin.HovaTen);
        $(".emailTK").val(thongtin.Mail);
        $(".sdtTK").val(thongtin.SDT);
        $("#MaTK").val(thongtin.MaTK)
        $("#avatar").attr("src", thongtin.Avatar)
        let table = (body) =>(
            <table class="table table-hover">
            <thead>
                <tr>
                    <th>Mã truyện</th>
                    <th>Tên truyện</th>
                    <th>Ảnh bìa</th>
                    <th>Ngày tạo</th>
                    <th>Ngày đăng</th>
                </tr>
            </thead>
                <tbody>
                    {body}
            </tbody>
            </table>)
        let tr = await API.layTruyenTGAdmin(id)
        let truyen = tr.map((x) => {
            return (
                <tr>
                    <td>{x.MaTruyen}</td>
                    <td><a href={"/Truyen/TomTat/"+ locdau2(x.TenTruyen + "-" + x.MaTruyen)}>{x.TenTruyen}</a></td>
                    <td><img src={x.AnhBia} height="70px"/></td>
                    <td>{x.NgayTao}</td>
                    <td>{x.NgayDang}</td>
                </tr>
                )
        })


        ReactDOM.render(table(truyen), document.getElementById('tacPham'))
    }
    Khoa = async (id,page) => {
        let rs = await API.KhoaTacGia(parseInt(id))
        if (rs) {
            this.dsTacGia(page)
            toast.success("Khóa tác giả thành công!")
        } else {
            toast.error("Khóa tác giả thất bại!")
        }
    }
    dsTacGia = async (page) => {
        debugger
        let data = await API.DSTacGia(page, 10, $("#search").val())
        let html = []
        data.forEach((x) => {
            let html2 = <tr>
                <td>{x.MaTG}</td>
                <td>{x.ButDanh}</td>
                <td>{x.TenTK}</td>
                <td>{x.NgayDK}</td>
                <td>{vaitroTg(x.VaiTro)}</td>
                <td>{x.Khoa ? "Bị khóa" : "Hoạt động"}</td>
                <td>{x.DaDuyet ? <input type="checkbox" checked disabled /> : <input type="checkbox" disabled />}</td>                
                <td>
                    <div class="dropdown">
                        <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown">
                            <a href="##">Tùy chỉnh</a>
                        </button>
                        <div class="dropdown-menu">
                            {x.DaDuyet ? "" : < a class="dropdown-item" href="##" onClick={() => this.Duyet(x.MaTG, page)}>Duyệt</a>}
                            <a class="dropdown-item" href="##" onClick={() => this.Khoa(x.MaTG, page)}>{x.Khoa ? "Gỡ khóa" : "Khóa"}</a>
                        </div>
                    </div>
                    <div>
                        <button type="button" class="btn btn-default thongtin" data-toggle="modal" data-target="#myModal" onClick={() => this.Details(x.MaTG)}>
                            <a href="##">Details</a>
                        </button>
                    </div>
                    <div>
                        <button type="button" class="btn btn-default xoaTK" onClick={() => this.Delete(x.MaTG, page)}>
                            <a href="##">Delete</a>
                        </button>
                    </div>
                </td>
            </tr>
            html.push(html2)
        })
        ReactDOM.render(<QLTacGia load={false} page={page} pagesize={Math.ceil(CountTG / 10)}>{html}</QLTacGia>, document.getElementById('body'))
    }
    load = async () => {
        this.dsTacGia(1)
    }
    render() {
        return (<Commons>
            {this.props.load ? this.load() : ""}
            <table class="table table-hover">
                <thead>
                    <tr>
                        <th>Mã Tác Giả</th>
                        <th>Bút Danh</th>
                        <th>Tên Tài Khoản</th>
                        <th>Ngày Đăng ký</th>
                        <th>Vai trò</th>
                        <th>Tình trạng</th>
                        <th>Xét duyệt</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    {this.props.children}
                </tbody>
                <tfoot>
                    <Pagination page={this.props.page} pagesize={this.props.pagesize} fpageClick={this.dsTaiKhoan} />
                </tfoot>
            </table>
            <div class="modal fade" id="myModal">
                <div class="modal-dialog modal-xl">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">Thông tin tác giả</h4>
                            <button type="button" class="close" data-dismiss="modal" onClick={() => this.dsTaiKhoan(this.props.page)}>&times;</button>
                        </div>
                        <div class="modal-body">
                            <input type="hidden" id="MaTK" />
                            <section class="content">
                                <div class="container-fluid">
                                    <div class="row">
                                        <div class="col-md-3">
                                            <div class="card card-primary card-outline">
                                                <div class="card-body box-profile">
                                                    <div class="text-center">
                                                        <img class="profile-user-img img-fluid img-circle" id="avatar" src="../../dist/img/user4-128x128.jpg" alt="User profile picture" />
                                                    </div>

                                                    <h3 class="profile-username text-center tenTK">Nina Mcintire</h3>

                                                    <ul class="list-group list-group-unbordered mb-3">
                                                        <li class="list-group-item">
                                                            <b>Số điện thoại</b> <a class="float-right sdtTK">1,322</a>
                                                        </li>
                                                        <li class="list-group-item">
                                                            <b>Email</b> <a class="float-right emailTK">543</a>
                                                        </li>
                                                        <li class="list-group-item">
                                                            <b>Tình trạng</b> <a class="float-right tinhtrang2">13,287</a>
                                                        </li>
                                                    </ul>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-9">
                                            <div class="card">
                                                <div class="card-header p-2">
                                                    <ul class="nav nav-pills">
                                                        <li class="nav-item"><a class="nav-link active" href="#tacPham" data-toggle="tab">Tác phẩm</a></li>
                                                        <li class="nav-item"><a class="nav-link" href="#settings" data-toggle="tab">Settings</a></li>
                                                    </ul>
                                                </div>
                                                <div class="card-body">
                                                    <div class="tab-content">
                                                        <div class="tab-pane active" id="tacPham">
                                                            
                                                        </div>
                                                        <div class="tab-pane" id="settings">
                                                            <div class="form-horizontal">
                                                                <div class="form-group row">
                                                                    <label for="inputName" class="col-sm-2 col-form-label">Tên tài khoản</label>
                                                                    <div class="col-sm-10">
                                                                        <input type="text" class="form-control tenTK" id="inputName" placeholder="Name" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group row">
                                                                    <label for="inputEmail" class="col-sm-2 col-form-label">Email</label>
                                                                    <div class="col-sm-10">
                                                                        <input type="email" class="form-control emailTK" id="inputEmail" placeholder="Email" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group row">
                                                                    <label for="inputName2" class="col-sm-2 col-form-label">Số Điện Thoại</label>
                                                                    <div class="col-sm-10">
                                                                        <input type="text" class="form-control sdtTK" id="inputName2" placeholder="Name" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group row checkbox">
                                                                    <label for="inputName2" class="col-sm-2 col-form-label"></label>
                                                                    <div class="col-sm-10">
                                                                        <label for="inputExperience" class="col-sm-12 col-form-label" style={{ width: "100%" }}><input type="checkbox" value="" id="CapLaiMK" /> Cấp lại pass</label>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group row checkbox">
                                                                    <label for="inputName2" class="col-sm-2 col-form-label"></label>
                                                                    <div class="col-sm-10">
                                                                        <button class="btn btn-danger" onClick={this.SuaTTTK}>Sửa</button>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </section>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-dismiss="modal" onClick={() => this.dsTaiKhoan(this.props.page)}>Close</button>
                        </div>
                    </div>
                </div>
            </div>
        </Commons>)
    }
}

class QLTruyen extends React.Component {
    constructor(props) {
        super(props);
    }
    Duyet = async (id, page) => {
        let duyetTruyen = 1
        let rs = await API.thaoTac(id, duyetTruyen)
        if (rs) {
            this.dsTruyen(page)
        }
    }
    Delete = async (id, page) => {
        debugger
        let cf = confirm("Bạn có muốn xóa chứ?")
        if (!cf) return
        let xoaTruyen = 3
        let rs = await API.thaoTac(parseInt(id), xoaTruyen)
        if (rs) {
            this.dsTruyen(page)
            toast.success("Xóa thành công!")
        } else {
            toast.error("Xóa thất bại!")
        }
    }
    Khoa = async (id, page) => {
        let khoaTruyen = 2
        let rs = await API.thaoTac(parseInt(id), khoaTruyen)
        if (rs) {
            this.dsTruyen(page)
            toast.success("Khóa truyện thành công!")
        } else {
            toast.error("Khóa truyện thất bại!")
        }
    }
    Details = async (maTruyen) => {
        debugger
        let thongtin = await API.chiTietTruyen(maTruyen)
        let x = thongtin
        let truyen = (
            <section class="content">
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-md-3">
                            <div class="card card-primary card-outline">
                                <div class="card-body box-profile">
                                    <div class="text-center">
                                        <img class="profile-user-img img-fluid" id="avatar" src={x.AnhBia} alt="User profile picture" />
                                    </div>
                                    <h3 class="profile-username text-center tenTK">{x.TenTruyen}</h3>
                                    <p><strong>Tác giả</strong></p>
                                    <ul class="list-group list-group-unbordered mb-3">
                                        {x.TacGia.map((x) => {
                                            return (
                                                <li class="list-group-item">
                                                    <b></b> <a class="float-right" href={"/Home/TacGia/"+locdau2(x.ButDanh + "-" + x.MaTG)}>{x.ButDanh}</a>
                                                </li>
                                                )
                                        })}                                                                                
                                    </ul>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-9">
                            <div class="card">
                                <div class="card-header p-2">
                                    <ul class="nav nav-pills">
                                        <li class="nav-item"><a class="nav-link active" href="#chiTiet" data-toggle="tab">Chi tiết</a></li>
                                    </ul>
                                </div>
                                <div class="card-body">
                                    <div class="tab-content">
                                        <div class="tab-pane active" id="settings">
                                            <div class="form-horizontal">
                                                <div class="form-group row">
                                                    <label for="inputName" class="col-sm-2 col-form-label">Thể loại</label>
                                                    <div class="col-sm-10">
                                                        <p class="float-right">{x.TheLoai}</p>
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <label for="inputName" class="col-sm-2 col-form-label">Loại truyện</label>
                                                    <div class="col-sm-10">
                                                        <p class="float-right">{x.LoaiTruyen}</p>
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <label for="inputName" class="col-sm-2 col-form-label">Tiến độ</label>
                                                    <div class="col-sm-10">
                                                        <p class="float-right">{x.TienDo}</p>
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <label for="inputName" class="col-sm-2 col-form-label">Tình trạng</label>
                                                    <div class="col-sm-10">
                                                        <p class="float-right">{x.TinhTrang}</p>
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <label for="inputEmail" class="col-sm-2 col-form-label">Mô Tả</label>
                                                    <div class="col-sm-10">
                                                        <p class="float-right"><a href={"/Truyen/TomTat/" + locdau2(x.TenTruyen + "-" + x.MaTruyen)}>xem mô tả</a></p>
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <label for="inputName2" class="col-sm-2 col-form-label">Lượt xem</label>
                                                    <div class="col-sm-10">
                                                        <p class="float-right">{x.LuotXem}</p>
                                                    </div>
                                                </div>
                                                <div class="form-group row checkbox">
                                                    <label for="inputName2" class="col-sm-2 col-form-label">Lượt thích</label>
                                                    <div class="col-sm-10">
                                                        <p class="float-right">{x.LuotThich}</p>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        )
        ReactDOM.render(truyen, document.getElementById('moadal-body'))
    }
    dsTruyen = async (page) => {
        debugger        
        let data = await API.dsTruyen(page, 10, $("#search").val())
        let html = []
        data.forEach((x) => {
            let html2 = <tr>
                <td>{x.MaTruyen}</td>
                <td>{x.TenTruyen}</td>
                <td><img src={x.AnhBia} height="50px" /></td>
                <td>{x.NgayTao}</td>
                <td>{x.NgayDang}</td>
                <td>{x.DaDuyet ? <input type="checkbox" checked disabled /> : <input type="checkbox" disabled />}</td>
                <td>
                    <div class="dropdown">
                        <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown">
                            <a href="##">Tùy chỉnh</a>
                        </button>
                        <div class="dropdown-menu">
                            {x.DaDuyet ? "" : < a class="dropdown-item" href="##" onClick={() => this.Duyet(x.MaTruyen, page)}>Duyệt</a>}
                            <a class="dropdown-item" href="##" onClick={() => this.Khoa(x.MaTruyen, page)}>{x.Khoa?"Gỡ khóa":"Khóa"}</a>
                        </div>
                    </div>
                    <div>
                        <button type="button" class="btn btn-default thongtin" data-toggle="modal" data-target="#myModal" onClick={() => this.Details(x.MaTruyen)}>
                            <a href="##">Details</a>
                        </button>
                    </div>
                    <div>
                        <button type="button" class="btn btn-default xoaTK" onClick={() => this.Delete(x.MaTruyen, page)}>
                            <a href="##">Delete</a>
                        </button>
                    </div>
                </td>
            </tr>
            html.push(html2)
        })
        ReactDOM.render(<QLTruyen load={false} page={page} pagesize={Math.ceil(CountTr / 10)}>{html}</QLTruyen>, document.getElementById('body'))
    }
    load = async () => {
        this.dsTruyen(1)
    }
    render() {
        return (<Commons>
            {this.props.load ? this.load() : ""}
            <table class="table table-hover">
                <thead>
                    <tr>
                        <th>Mã Truyện</th>
                        <th>Tên truyện</th>
                        <th>Ảnh bìa</th>
                        <th>Ngày Tạo</th>
                        <th>Ngày đăng</th>
                        <th>Xét duyệt</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    {this.props.children}
                </tbody>
                <tfoot>
                    <Pagination page={this.props.page} pagesize={this.props.pagesize} fpageClick={this.dsTruyen} />
                </tfoot>
            </table>
            <div class="modal fade" id="myModal">
                <div class="modal-dialog modal-xl">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">Thông tin chi tiết truyện</h4>
                            <button type="button" class="close" data-dismiss="modal" onClick={() => this.dsTaiKhoan(this.props.page)}>&times;</button>
                        </div>
                        <div class="modal-body" id="moadal-body">

                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-dismiss="modal" onClick={() => this.dsTaiKhoan(this.props.page)}>Close</button>
                        </div>
                    </div>
                </div>
            </div>
        </Commons>)
    }
}

// quản lý admin
class QLAdmin extends React.Component {
    constructor(props) {
        super(props);
    }
    SuaTTTK = async () => {
        debugger
        let MaTK = parseInt($("#MaTK").val())
        let hoTen = $("input.tenTK").val();
        let Mail = $("input.emailTK").val();
        let sdt = $("input.sdtTK").val();
        let mk = $("#CapLaiMK").is(':checked') ? "1111" : null
        let rs = await API.CapNhatTKAdmin(MaTK, hoTen, Mail, mk, sdt)
        if (rs) {
            toast.success("Cập nhật thành công", 4000)
        }
    }
    Edit = async (id, TinhTrang, page) => {
        let rs = await API.capNhatTinhTrangTK(id, TinhTrang)
        this.dsTaiKhoan(page)
    }
    Delete = async (id, page) => {
        let cf = confirm("Bạn có muốn xóa tác giả này chứ!")
        if (!cf) return
        let rs = await API.xoaTaiKhoan(id)
        if (rs) {
            this.dsTaiKhoan(page)
            toast.success("Xóa tài khoản thành công")
        }
    }
    Details = async (id) => {
        let userid = id
        let thongtin = await API.layTTTaiKhoan(userid)
        $(".tenTK").text(thongtin.HovaTen);
        $(".emailTK").text(thongtin.Mail);
        $(".sdtTK").text(thongtin.SDT);
        $(".tinhtrang2").text(tinhTrangTK(thongtin.TinhTrang));
        $(".tenTK").val(thongtin.HovaTen);
        $(".emailTK").val(thongtin.Mail);
        $(".sdtTK").val(thongtin.SDT);
        $("#MaTK").val(thongtin.MaTK)
        $("#avatar").attr("src", thongtin.Avatar)
    }
    dsTaiKhoan = async (page) => {
        let data = await API.dsAdmin(page, 10, $("#search").val())
        let html = []
        data.forEach((x) => {
            let html2 = <tr>
                <td>{x.MaTK}</td>
                <td>{x.HovaTen}</td>
                <td>{x.Mail}</td>
                <td>{x.SDT}</td>
                <td>{x.NgayTao}</td>
                <td>{tinhTrangTK(x.TinhTrang)}</td>
                <td>
                    <div class="dropdown">
                        <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown">
                            <a href="##">Edit</a>
                        </button>
                        <div class="dropdown-menu">
                            <a class="dropdown-item" href="##" onClick={() => this.Edit(x.MaTK, 1, page)}>Khóa 30 phút</a>
                            <a class="dropdown-item" href="##" onClick={() => this.Edit(x.MaTK, 2, page)}>Khóa 60 phút</a>
                            <a class="dropdown-item" href="##" onClick={() => this.Edit(x.MaTK, 3, page)}>Khóa vĩnh viễn</a>
                            <a class="dropdown-item" href="##" onClick={() => this.Edit(x.MaTK, 0, page)}>Hoạtđộng</a>
                        </div>
                    </div>
                    <div>
                        <button type="button" class="btn btn-default thongtin" data-toggle="modal" data-target="#myModal" onClick={() => this.Details(x.MaTK)}>
                            <a href="##">Details</a>
                        </button>


                    </div>
                    <div>
                        <button type="button" class="btn btn-default xoaTK" onClick={() => this.Delete(x.MaTK, page)}>
                            <a href="##">Delete</a>
                        </button>
                    </div>
                </td>
            </tr>
            html.push(html2)
        })
        ReactDOM.render(<QLAdmin load={false} page={page} pagesize={Math.ceil(CountAd / 10)}>{html}</QLAdmin>, document.getElementById('body'))
    }
    load = async () => {
        this.dsTaiKhoan(1)
    }
    render() {

        return (<Commons>
            {this.props.load ? this.load() : ""}
            <table class="table table-hover">
                <thead>
                    <tr>
                        <th>Mã Tài Khoản</th>
                        <th>Họ và Tên</th>
                        <th>Mail</th>
                        <th>Số điện thoại</th>
                        <th>Ngày tạo</th>
                        <th>Tình trạng</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    {this.props.children}
                </tbody>
                <tfoot>
                    <Pagination page={this.props.page} pagesize={this.props.pagesize} fpageClick={this.dsTaiKhoan} />
                </tfoot>
            </table>
            <div class="modal fade" id="myModal">
                <div class="modal-dialog modal-xl">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">Thông tin tài khoản</h4>
                            <button type="button" class="close" data-dismiss="modal" onClick={() => this.dsTaiKhoan(this.props.page)}>&times;</button>
                        </div>
                        <div class="modal-body">
                            <input type="hidden" id="MaTK" />
                            <section class="content">
                                <div class="container-fluid">
                                    <div class="row">
                                        <div class="col-md-3">
                                            <div class="card card-primary card-outline">
                                                <div class="card-body box-profile">
                                                    <div class="text-center">
                                                        <img class="profile-user-img img-fluid img-circle" id="avatar" src="../../dist/img/user4-128x128.jpg" alt="User profile picture" />
                                                    </div>

                                                    <h3 class="profile-username text-center tenTK">Nina Mcintire</h3>

                                                    <ul class="list-group list-group-unbordered mb-3">
                                                        <li class="list-group-item">
                                                            <b>Số điện thoại</b> <a class="float-right sdtTK">1,322</a>
                                                        </li>
                                                        <li class="list-group-item">
                                                            <b>Email</b> <a class="float-right emailTK">543</a>
                                                        </li>
                                                        <li class="list-group-item">
                                                            <b>Tình trạng</b> <a class="float-right tinhtrang2">13,287</a>
                                                        </li>
                                                    </ul>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-9">
                                            <div class="card">
                                                <div class="card-header p-2">
                                                    <ul class="nav nav-pills">
                                                        <li class="nav-item active"><a class="nav-link" href="#settings" data-toggle="tab">Settings</a></li>
                                                    </ul>
                                                </div>
                                                <div class="card-body">
                                                    <div class="tab-content">
                                                        <div class="tab-pane active" id="settings">
                                                            <div class="form-horizontal">
                                                                <div class="form-group row">
                                                                    <label for="inputName" class="col-sm-2 col-form-label">Tên tài khoản</label>
                                                                    <div class="col-sm-10">
                                                                        <input type="text" class="form-control tenTK" id="inputName" placeholder="Name" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group row">
                                                                    <label for="inputEmail" class="col-sm-2 col-form-label">Email</label>
                                                                    <div class="col-sm-10">
                                                                        <input type="email" class="form-control emailTK" id="inputEmail" placeholder="Email" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group row">
                                                                    <label for="inputName2" class="col-sm-2 col-form-label">Số Điện Thoại</label>
                                                                    <div class="col-sm-10">
                                                                        <input type="text" class="form-control sdtTK" id="inputName2" placeholder="Name" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-group row checkbox">
                                                                    <label for="inputName2" class="col-sm-2 col-form-label"></label>
                                                                    <div class="col-sm-10">
                                                                        <label for="inputExperience" class="col-sm-12 col-form-label" style={{ width: "100%" }}><input type="checkbox" value="" id="CapLaiMK" /> Cấp lại pass</label>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group row checkbox">
                                                                    <label for="inputName2" class="col-sm-2 col-form-label"></label>
                                                                    <div class="col-sm-10">
                                                                        <button class="btn btn-danger" onClick={this.SuaTTTK}>Sửa</button>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </section>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-dismiss="modal" onClick={() => this.dsTaiKhoan(this.props.page)}>Close</button>
                        </div>
                    </div>
                </div>
            </div>
        </Commons>)
    }
}


$(document).ready(function () {
    let index =0, qlTaiKhoan= 1, qlTacGia = 2, qlTruyen = 3, qlAdmin = 4
    let hienTai = 0
    ReactDOM.render(<Index />, document.getElementById('body'))
    $("#QLTaiKhoan").click(function () {
        $("#search").val("")
        hienTai = qlTaiKhoan
        ReactDOM.render(<QLTaiKhoan load={true} />, document.getElementById('body'))
    })
    $("#dashboard").click(function () {
        $("#search").val("")
        hienTai = index
        ReactDOM.render(<Index />, document.getElementById('body'))
    })
    $("#TacGia").click(function () {
        $("#search").val("")
        hienTai = qlTacGia
        ReactDOM.render(<QLTacGia load={true} />, document.getElementById('body'))
    })
    $("#QLTruyen").click(function () {
        $("#search").val("")
        hienTai = qlTruyen
        ReactDOM.render(<QLTruyen load={true} />, document.getElementById('body'))
    })
    $("#QLAdmin").click(function () {
        $("#search").val("")
        hienTai = qlAdmin
        ReactDOM.render(<QLAdmin load={true} />, document.getElementById('body'))
    })
    $("#search").keyup(function () {
        switch (hienTai) {
            case qlTaiKhoan:
                ReactDOM.render(<QLTaiKhoan load={true} />, document.getElementById('body'))
                break;
            case qlTacGia:
                ReactDOM.render(<QLTacGia load={true} />, document.getElementById('body'))
                break;
            case qlTruyen:
                ReactDOM.render(<QLTruyen load={true} />, document.getElementById('body'))
                break;
            case qlAdmin:
                ReactDOM.render(<QLAdmin load={true} />, document.getElementById('body'))
                break;
        }
    })
})
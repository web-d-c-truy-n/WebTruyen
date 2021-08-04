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
                            <h3>150</h3>
                            <p>New Orders</p>
                        </div>
                        <div class="icon">
                            <i class="ion ion-bag"></i>
                        </div>
                        <a href="##" class="small-box-footer">More info <i class="fas fa-arrow-circle-right"></i></a>
                    </div>
                </div>
            <div class="col-lg-3 col-6">
                <div class="small-box bg-success">
                        <div class="inner">
                            <h3>53<sup style={{"font-size": "20px"}}>%</sup></h3>

                            <p>Bounce Rate</p>
                        </div>
                        <div class="icon">
                            <i class="ion ion-stats-bars"></i>
                        </div>
                        <a href="##" class="small-box-footer">More info <i class="fas fa-arrow-circle-right"></i></a>
                    </div>
                </div>
            <div class="col-lg-3 col-6">
                <div class="small-box bg-warning">
                        <div class="inner">
                            <h3>44</h3>

                            <p>User Registrations</p>
                        </div>
                        <div class="icon">
                            <i class="ion ion-person-add"></i>
                        </div>
                        <a href="##" class="small-box-footer">More info <i class="fas fa-arrow-circle-right"></i></a>
                    </div>
                </div>
            <div class="col-lg-3 col-6">
                <div class="small-box bg-danger">
                        <div class="inner">
                            <h3>65</h3>

                            <p>Unique Visitors</p>
                        </div>
                        <div class="icon">
                            <i class="ion ion-pie-graph"></i>
                        </div>
                        <a href="##" class="small-box-footer">More info <i class="fas fa-arrow-circle-right"></i></a>
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
        let rs = API.capNhatTinhTrangTK(id, TinhTrang)
        if (rs) {
            this.dsTaiKhoan(page)
        }
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
    }
    dsTaiKhoan = async (page) => {
        let data = await API.dsTaiKhoan(page, 10)
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
                                                        <img class="profile-user-img img-fluid img-circle" src="../../dist/img/user4-128x128.jpg" alt="User profile picture"/>
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
                                                        <li class="nav-item"><a class="nav-link active" href="#timeline" data-toggle="tab">Timeline</a></li>
                                                        <li class="nav-item"><a class="nav-link" href="#settings" data-toggle="tab">Settings</a></li>
                                                    </ul>
                                                </div>
                                                <div class="card-body">
                                                    <div class="tab-content">
                                                        <div class="tab-pane active" id="timeline">
                                                            <div class="timeline timeline-inverse">
                                                                <div class="time-label">
                                                                    <span class="bg-danger">
                                                                        10 Feb. 2014
                                                                    </span>
                                                                </div>
                                                                <div>
                                                                    <i class="fas fa-envelope bg-primary"></i>
                                                                    <div class="timeline-item">
                                                                        <span class="time"><i class="far fa-clock"></i> 12:05</span>
                                                                        <h3 class="timeline-header"><a href="##">Support Team</a> sent you an email</h3>
                                                                        <div class="timeline-body">
                                                                            Etsy doostang zoodles disqus groupon greplin oooj voxy zoodles,
                                                                            weebly ning heekya handango imeem plugg dopplr jibjab, movity
                                                                            jajah plickers sifteo edmodo ifttt zimbra. Babblely odeo kaboodle
                                                                            quora plaxo ideeli hulu weebly balihoo...
                                                                        </div>
                                                                        <div class="timeline-footer">
                                                                            <a href="##" class="btn btn-primary btn-sm">Read more</a>
                                                                            <a href="##" class="btn btn-danger btn-sm">Delete</a>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div>
                                                                    <i class="fas fa-user bg-info"></i>
                                                                    <div class="timeline-item">
                                                                        <span class="time"><i class="far fa-clock"></i> 5 mins ago</span>

                                                                        <h3 class="timeline-header border-0">
                                                                            <a href="##">Sarah Young</a> accepted your friend request
                                                                        </h3>
                                                                    </div>
                                                                </div>
                                                                <div>
                                                                    <i class="fas fa-comments bg-warning"></i>
                                                                    <div class="timeline-item">
                                                                        <span class="time"><i class="far fa-clock"></i> 27 mins ago</span>
                                                                        <h3 class="timeline-header"><a href="##">Jay White</a> commented on your post</h3>
                                                                        <div class="timeline-body">
                                                                            Take me to your leader!
                                                                            Switzerland is small and neutral!
                                                                            We are more like Germany, ambitious and misunderstood!
                                                                        </div>
                                                                        <div class="timeline-footer">
                                                                            <a href="##" class="btn btn-warning btn-flat btn-sm">View comment</a>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="time-label">
                                                                    <span class="bg-success">
                                                                        3 Jan. 2014
                                                                    </span>
                                                                </div>
                                                                <div>
                                                                    <i class="fas fa-camera bg-purple"></i>

                                                                    <div class="timeline-item">
                                                                        <span class="time"><i class="far fa-clock"></i> 2 days ago</span>

                                                                        <h3 class="timeline-header"><a href="##">Mina Lee</a> uploaded new photos</h3>

                                                                        <div class="timeline-body">
                                                                            <img src="http://placehold.it/150x100" alt="..."/>
                                                                            <img src="http://placehold.it/150x100" alt="..."/>
                                                                            <img src="http://placehold.it/150x100" alt="..."/>
                                                                            <img src="http://placehold.it/150x100" alt="..."/>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div>
                                                                    <i class="far fa-clock bg-gray"></i>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="tab-pane" id="settings">
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
        $(".tenTK").text(thongtin.HovaTen);
        $(".emailTK").text(thongtin.Mail);
        $(".sdtTK").text(thongtin.SDT);
        $(".tinhtrang2").text(tinhTrangTK(thongtin.TinhTrang));
        $(".tenTK").val(thongtin.HovaTen);
        $(".emailTK").val(thongtin.Mail);
        $(".sdtTK").val(thongtin.SDT);
        $("#MaTK").val(thongtin.MaTK)
    }
    dsTacGia = async (page) => {
        let data = await API.DSTacGia(page, 10)
        let html = []
        data.forEach((x) => {
            let html2 = <tr>
                <td>{x.MaTG}</td>
                <td>{x.ButDanh}</td>
                <td>{x.TenTK}</td>
                <td>{x.NgayDK}</td>
                <td>{vaitroTg(x.VaiTro)}</td>
                <td>{x.DaDuyet ? <input type="checkbox" checked disabled /> : <input type="checkbox" disabled />}</td>
                <td>
                    <div class="dropdown">
                        <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown">
                            <a href="##">Tùy chỉnh</a>
                        </button>
                        <div class="dropdown-menu">
                            {x.DaDuyet?"":< a class="dropdown-item" href="##" onClick={() => this.Duyet(x.MaTG, page)}>Duyệt</a>}
                            <a class="dropdown-item" href="##" onClick={() => this.Edit(x.MaTG, true, page)}>Khóa</a>
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
        </Commons>)
    }
}

$(document).ready(function () {
    ReactDOM.render(<Index />, document.getElementById('body'))
    $("#QLTaiKhoan").click(function () {
        ReactDOM.render(<QLTaiKhoan load={true} />, document.getElementById('body'))
    })
    $("#dashboard").click(function () {
        ReactDOM.render(<Index />, document.getElementById('body'))
    })
    $("#TacGia").click(function () {
        ReactDOM.render(<QLTacGia load={true} />, document.getElementById('body'))
    })
})
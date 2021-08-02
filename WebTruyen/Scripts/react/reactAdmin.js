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
                    <li class="page-item active"><a class="page-link" href="#">{page}</a></li>
                </ul>)
            } else if (pagesize == 2) {
                html = (<ul class="pagination justify-content-end">
                    <li class="page-item active"><a class="page-link" href="#">{page}</a></li>
                    <li class="page-item" onClick={() => this.pageClick(page+1, this.props.fpageClick)}><a class="page-link" href="#">{page + 1}</a></li>
                </ul>)
            } else if (pagesize == 3) {
                html = (<ul class="pagination justify-content-end">
                    <li class="page-item active" ><a class="page-link" href="#">{page}</a></li>
                    <li class="page-item" onClick={() => this.pageClick(page +1, this.props.fpageClick)}><a class="page-link" href="#">{page + 1}</a></li>
                    <li class="page-item" onClick={() => this.pageClick(page +2, this.props.fpageClick)}><a class="page-link" href="#">{page + 2}</a></li>
                </ul>)
            } else if (pagesize > 3) {
                html = (<ul class="pagination justify-content-end">
                    <li class="page-item active"><a class="page-link" href="#">{page}</a></li>
                    <li class="page-item" onClick={() => this.pageClick(page + 1, this.props.fpageClick)}><a class="page-link" href="#">{page + 1}</a></li>
                    <li class="page-item" onClick={() => this.pageClick(page + 2, this.props.fpageClick)}><a class="page-link" href="#">{page + 2}</a></li>
                    <li class="page-item" onClick={() => this.pageClick(page + 1, this.props.fpageClick)}><a class="page-link" href="#">Next</a></li>
                </ul>)
            }
        } else if (page == pagesize) {
            if (pagesize == 2) {
                html = (<ul class="pagination justify-content-end">
                    <li class="page-item" onClick={() => this.pageClick(page - 1, this.props.fpageClick)}><a class="page-link" href="#">{page - 1}</a></li>
                    <li class="page-item active"><a class="page-link" href="#">{page}</a></li>
                </ul>)
            } else if (pagesize == 3) {
                html = (<ul class="pagination justify-content-end">
                    <li class="page-item" onClick={() => this.pageClick(page - 2, this.props.fpageClick)}><a class="page-link" href="#">{page - 2}</a></li>
                    <li class="page-item" onClick={() => this.pageClick(page - 1, this.props.fpageClick)}><a class="page-link" href="#">{page - 1}</a></li>
                    <li class="page-item active"><a class="page-link" href="#">{page}</a></li>
                </ul>)
            } else if (pagesize > 3) {
                html = (<ul class="pagination justify-content-end">
                    <li class="page-item" onClick={() => this.pageClick(page -1, this.props.fpageClick)}><a class="page-link" href="#">Previous</a></li>
                    <li class="page-item" onClick={() => this.pageClick(page -2, this.props.fpageClick)}><a class="page-link" href="#">{page - 2}</a></li>
                    <li class="page-item" onClick={() => this.pageClick(page - 1, this.props.fpageClick)}><a class="page-link" href="#">{page - 1}</a></li>
                    <li class="page-item active"><a class="page-link" href="#">{page}</a></li>
                </ul>)
            }
        } else {
            if (page == 2) {
                if (pagesize == 3) {
                    html = (<ul class="pagination justify-content-end">
                        <li class="page-item" onClick={() => this.pageClick(page -1, this.props.fpageClick)}><a class="page-link" href="#">{page - 1}</a></li>
                        <li class="page-item active"><a class="page-link" href="#">{page}</a></li>
                        <li class="page-item" onClick={() => this.pageClick(page + 1, this.props.fpageClick)}><a class="page-link" href="#">{page + 1}</a></li>
                    </ul>)
                } else {
                    html = (<ul class="pagination justify-content-end">
                        <li class="page-item" onClick={() => this.pageClick(page - 1, this.props.fpageClick)}><a class="page-link" href="#">{page - 1}</a></li>
                        <li class="page-item active"><a class="page-link" href="#">{page}</a></li>
                        <li class="page-item" onClick={() => this.pageClick(page + 1, this.props.fpageClick)}><a class="page-link" href="#">{page + 1}</a></li>
                        <li class="page-item" onClick={() => this.pageClick(page + 1, this.props.fpageClick)}><a class="page-link" href="#">Next</a></li>
                    </ul>)
                }
                
            }else if (pagesize > 3) {
                html = (<ul class="pagination justify-content-end">
                    <li class="page-item" onClick={() => this.pageClick(page - 1, this.props.fpageClick)}><a class="page-link" href="#">Previous</a></li>
                    <li class="page-item" onClick={() => this.pageClick(page - 1, this.props.fpageClick)}><a class="page-link" href="#">{page - 1}</a></li>
                    <li class="page-item active"><a class="page-link" href="#">{page}</a></li>
                    <li class="page-item" onClick={() => this.pageClick(page + 1, this.props.fpageClick)}><a class="page-link" href="#">{page + 1}</a></li>
                    <li class="page-item" onClick={() => this.pageClick(page + 1, this.props.fpageClick)}><a class="page-link" href="#">Next</a></li>
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
                        <a href="#" class="small-box-footer">More info <i class="fas fa-arrow-circle-right"></i></a>
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
                        <a href="#" class="small-box-footer">More info <i class="fas fa-arrow-circle-right"></i></a>
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
                        <a href="#" class="small-box-footer">More info <i class="fas fa-arrow-circle-right"></i></a>
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
                        <a href="#" class="small-box-footer">More info <i class="fas fa-arrow-circle-right"></i></a>
                    </div>
                </div>
        </div>
        </Commons>)
    }
}
// quản lý tài khoản
class QLTaiKhoan extends React.Component {
    dsTaiKhoan = async (page) => {
        let data = await API.dsTaiKhoan(page, 10)
        let html = []
        data.forEach(function (x) {
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
                            Edit
                    </button>
                        <div class="dropdown-menu">
                            <a class="dropdown-item" href="#" iduser={x.MaTK} tinhtrang="1">Khóa 30 phút</a>
                            <a class="dropdown-item" href="#" iduser={x.MaTK} tinhtrang="2">Khóa 60 phút</a>
                            <a class="dropdown-item" href="#" iduser={x.MaTK} tinhtrang="3">Khóa vĩnh viễn</a>
                            <a class="dropdown-item" href="#" iduser={x.MaTK} tinhtrang="0">Hoạtđộng</a>
                        </div>
                    </div>
                    <div>
                        <button type="button" class="btn btn-default thongtin" data-toggle="modal" data-target="#myModal" iduser="@item.MaTK">
                            <a href="#">Details</a>
                        </button>


                    </div>
                    <div>
                        <button type="button" class="btn btn-default xoaTK" iduser="@item.MaTK">
                            <a href="#">Delete</a>
                        </button>
                    </div>
                </td>
            </tr>
            html.push(html2)
        })
        ReactDOM.render(<QLTaiKhoan load={false} page={page} pagesize={parseInt(CountTK / 10)}>{html}</QLTaiKhoan>, document.getElementById('body'))
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
                        <th>wwww</th>
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
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                        </div>
                        <div class="modal-body">
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

                                                    <p class="text-muted text-center ">Software Engineer</p>

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

                                                    <a href="#" class="btn btn-primary btn-block"><b>Follow</b></a>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-9">
                                            <div class="card">
                                                <div class="card-header p-2">
                                                    <ul class="nav nav-pills">
                                                        <li class="nav-item"><a class="nav-link" href="#timeline" data-toggle="tab">Timeline</a></li>
                                                        <li class="nav-item"><a class="nav-link" href="#settings" data-toggle="tab">Settings</a></li>
                                                    </ul>
                                                </div>
                                                <div class="card-body">
                                                    <div class="tab-content">
                                                        <div class="tab-pane" id="timeline">
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
                                                                        <h3 class="timeline-header"><a href="#">Support Team</a> sent you an email</h3>
                                                                        <div class="timeline-body">
                                                                            Etsy doostang zoodles disqus groupon greplin oooj voxy zoodles,
                                                                            weebly ning heekya handango imeem plugg dopplr jibjab, movity
                                                                            jajah plickers sifteo edmodo ifttt zimbra. Babblely odeo kaboodle
                                                                            quora plaxo ideeli hulu weebly balihoo...
                                                                        </div>
                                                                        <div class="timeline-footer">
                                                                            <a href="#" class="btn btn-primary btn-sm">Read more</a>
                                                                            <a href="#" class="btn btn-danger btn-sm">Delete</a>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div>
                                                                    <i class="fas fa-user bg-info"></i>
                                                                    <div class="timeline-item">
                                                                        <span class="time"><i class="far fa-clock"></i> 5 mins ago</span>

                                                                        <h3 class="timeline-header border-0">
                                                                            <a href="#">Sarah Young</a> accepted your friend request
                                                                        </h3>
                                                                    </div>
                                                                </div>
                                                                <div>
                                                                    <i class="fas fa-comments bg-warning"></i>
                                                                    <div class="timeline-item">
                                                                        <span class="time"><i class="far fa-clock"></i> 27 mins ago</span>
                                                                        <h3 class="timeline-header"><a href="#">Jay White</a> commented on your post</h3>
                                                                        <div class="timeline-body">
                                                                            Take me to your leader!
                                                                            Switzerland is small and neutral!
                                                                            We are more like Germany, ambitious and misunderstood!
                                                                        </div>
                                                                        <div class="timeline-footer">
                                                                            <a href="#" class="btn btn-warning btn-flat btn-sm">View comment</a>
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

                                                                        <h3 class="timeline-header"><a href="#">Mina Lee</a> uploaded new photos</h3>

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
                                                            <form class="form-horizontal">
                                                                <div class="form-group row">
                                                                    <label for="inputName" class="col-sm-2 col-form-label">Name</label>
                                                                    <div class="col-sm-10">
                                                                        <input type="email" class="form-control" id="inputName" placeholder="Name"/>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group row">
                                                                    <label for="inputEmail" class="col-sm-2 col-form-label">Email</label>
                                                                    <div class="col-sm-10">
                                                                        <input type="email" class="form-control" id="inputEmail" placeholder="Email"/>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group row">
                                                                    <label for="inputName2" class="col-sm-2 col-form-label">Name</label>
                                                                    <div class="col-sm-10">
                                                                        <input type="text" class="form-control" id="inputName2" placeholder="Name"/>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group row">
                                                                    <label for="inputExperience" class="col-sm-2 col-form-label">Experience</label>
                                                                    <div class="col-sm-10">
                                                                        <textarea class="form-control" id="inputExperience" placeholder="Experience"></textarea>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group row">
                                                                    <label for="inputSkills" class="col-sm-2 col-form-label">Skills</label>
                                                                    <div class="col-sm-10">
                                                                        <input type="text" class="form-control" id="inputSkills" placeholder="Skills"/>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group row">
                                                                    <div class="offset-sm-2 col-sm-10">
                                                                        <div class="checkbox">
                                                                            <label>
                                                                                <input type="checkbox"/> I agree to the <a href="#">terms and conditions</a>
                                                                            </label>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group row">
                                                                    <div class="offset-sm-2 col-sm-10">
                                                                        <button type="submit" class="btn btn-danger">Submit</button>
                                                                    </div>
                                                                </div>
                                                            </form>
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
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                        </div>
                    </div>
                </div>
            </div>
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
})
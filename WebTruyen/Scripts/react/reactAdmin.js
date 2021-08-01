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
})
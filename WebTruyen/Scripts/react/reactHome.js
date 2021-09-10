class PhanTu extends React.Component {
    locdau = (obj) => {
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
    render() {
        return (<div class="col-12 col-md-6 badge-pos-1">
            <div class="page-item-detail">
                <div class="item-thumb hover-details c-image-hover">
                    <a href={this.props.url} title={this.props.tenTruyen}>
                        <img width="110" height="150" src={this.props.anhBia} />
                    </a>
                </div>
                <div class="item-summary">
                    <div class="post-title font-title">
                        <h3 class="h5">
                            <span class="manga-title-badges new">NEW</span><a href="">{this.props.tenTruyen}</a>
                        </h3>
                    </div>
                    <div class="list-chapter">
                        <div class="chapter-item ">
                            <span class="chapter font-meta">
                                <a href="/" class="btn-link"> {this.props.tenChuong1} </a>
                            </span>
                        </div>
                        <div class="chapter-item ">
                            <span class="chapter font-meta">
                                <a href="./manga/manga-text-chapter/chapter-2/" class="btn-link"> {this.props.tenChuong2} </a>
                            </span>
                        </div>
                    </div>
                </div>
            </div>
        </div>)
    }
}

var page = 1
let truyenXemNhieu
class PhanTuTruyen extends React.Component {
    locdau = (obj) => {
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
        str= str.replace(/!|@|%|\^|\*|\(|\)|\+|\=|\<|\>|\?|\/|,|\.|\:|\;|\'| |\"|\&|\#|\[|\]|~|$|_/g,"-");  
        /* tìm và thay thế các kí tự đặc biệt trong chuỗi sang kí tự - */
        str= str.replace(/-+-/g,"-"); //thay thế 2- thành 1-  
        str = str.replace(/^\-+|\-+$/g, "");
        //cắt bỏ ký tự - ở đầu và cuối chuỗi 
        return str
    }
    load = async () => {
        let truyen = []
        truyenXemNhieu.forEach((item, index) => {
            truyen.push(<div class="col-12 col-md-6 badge-pos-1">
                <div class="page-item-detail">
                    <div class="item-thumb hover-details c-image-hover">
                        <a href={"/truyen/TomTat/" + this.locdau(item.TenTruyen) + "-" + item.MaTruyen} title={item.TenTruyen}>
                            <img width="110" height="150" src={item.AnhBia} />
                        </a>
                    </div>
                    <div class="item-summary">
                        <div class="post-title font-title">
                            <h3 class="h5">
                                <span class="manga-title-badges new">NEW</span><a href={"/truyen/TomTat/" + this.locdau(item.TenTruyen) + "-" + item.MaTruyen}>{item.TenTruyen}</a>
                            </h3>
                        </div>
                        <div class="list-chapter">
                            <div class="chapter-item ">
                                <span class="chapter font-meta">
                                    <a href={"Truyen/Truyen/" + this.locdau(item.TenTruyen + "-" + item.MaTruyen) + "?Chuong=" + item.SoChuong1} class="btn-link"> {item.TenChuong1} </a>
                                </span>
                            </div>
                            <div class="chapter-item ">
                                <span class="chapter font-meta">
                                    <a href={"Truyen/Truyen/" + this.locdau(item.TenTruyen + "-" + item.MaTruyen) + "?Chuong=" + item.SoChuong2} class="btn-link"> {item.TenChuong2} </a>
                                </span>
                            </div>
                            <div class="chapter-item ">
                                <span class="chapter font-meta">
                                    <a href={"Truyen/Truyen/" + this.locdau(item.TenTruyen + "-" + item.MaTruyen) + "?Chuong=" + item.SoChuong3} class="btn-link"> {item.TenChuong3} </a>
                                </span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>)
        })
        let truyen2 = [];
        for (let i = 0; i < truyen.length; i += 2) {
            truyen2.push(<div class="page-listing-item row">
                {truyen[i]}
                {truyen[i+1]}
            </div>)
        }
        ReactDOM.render(<PhanTuTruyen load={false}>{truyen2}</PhanTuTruyen>, document.getElementById('dsTryenMoi'))
    }
    render() {
        return (<div id="loop-content" class="page-content-listing item-default">
                {this.props.load ? this.load() : ""}
                {this.props.children}            
            </div>
            )
    }
}
$("#dsTryenMoi").ajaxOn()
$(document).ready(async function () {
    if (theLoai != -1 || loaiTruyen != -1) {
        truyenXemNhieu = await API.XuatCacTruyenTheLoai(page, 20, theLoai, loaiTruyen)
    }
    else {
        truyenXemNhieu = await API.XuatCacTruyenIndex(page, 20)
    }
    ReactDOM.render(<PhanTuTruyen load={true} />, document.getElementById('dsTryenMoi'))
    $("#dsTryenMoi").ajaxOff()
})
const reader = () => {
    ReactDOM.render(<PhanTuTruyen load={true} />, document.getElementById('dsTryenMoi'))
}
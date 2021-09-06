class PhanTu extends React.Component {

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
                                <a href="./manga/manga-text-chapter/chapter-3/" class="btn-link"> {this.props.tenChuong1} </a>
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
    load = async () => {
        let truyen = []
        truyenXemNhieu.forEach((item, index) => {
            truyen.push(<div class="col-12 col-md-6 badge-pos-1">
                <div class="page-item-detail">
                    <div class="item-thumb hover-details c-image-hover">
                        <a href={this.props.url} title={item.TenTruyen}>
                            <img width="110" height="150" src={item.AnhBia} />
                        </a>
                    </div>
                    <div class="item-summary">
                        <div class="post-title font-title">
                            <h3 class="h5">
                                <span class="manga-title-badges new">NEW</span><a href="">{item.TenTruyen}</a>
                            </h3>
                        </div>
                        <div class="list-chapter">
                            <div class="chapter-item ">
                                <span class="chapter font-meta">
                                    <a href="./manga/manga-text-chapter/chapter-3/" class="btn-link"> {item.TenChuong1} </a>
                                </span>
                            </div>
                            <div class="chapter-item ">
                                <span class="chapter font-meta">
                                    <a href="./manga/manga-text-chapter/chapter-3/" class="btn-link"> {item.TenChuong2} </a>
                                </span>
                            </div>
                            <div class="chapter-item ">
                                <span class="chapter font-meta">
                                    <a href="./manga/manga-text-chapter/chapter-3/" class="btn-link"> {item.TenChuong3} </a>
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
    if (theLoai != -1) {
        truyenXemNhieu = await API.XuatCacTruyenTheLoai(page, 20, theLoai)
    } else {
        truyenXemNhieu = await API.XuatCacTruyenIndex(page, 20)
    }
    ReactDOM.render(<PhanTuTruyen load={true} />, document.getElementById('dsTryenMoi'))
    $("#dsTryenMoi").ajaxOff()
})
$("#navigation-ajax").click(async function () {
    let showTruyen
    page++
    if (theLoai != -1) {
        showTruyen = await API.XuatCacTruyenTheLoai(page, 20, theLoai)
    } else {
        showTruyen = await API.XuatCacTruyenIndex(page, 20)
    }
    showTruyen.forEach((item, index) => {
        truyenXemNhieu.push(item)
    })
    ReactDOM.render(<PhanTuTruyen load={true} />, document.getElementById('dsTryenMoi'))
    $(this).removeClass(".show-loading")
})
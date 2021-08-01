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
                            <span class="manga-title-badges new">NEW</span>							                            <a href="./manga/manga-text-chapter/">{this.props.tenTruyen}</a>
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


class PhanTuTruyen extends React.Component {

    render() {        
        return (<div class="page-listing-item">
            <div class="row row-eq-height">
                <PhanTu anhBia={this.props.AnhBia}
                    tenTruyen={this.props.TenTruyen}
                    url={"/Home/ttTruyen/" + this.props.MaTruyen}
                    tenChuong1={this.props.Chuong1}
                    tenChuong2={this.props.Chuong2} />
                {
                    this.props.AnhBia2==""?"": (<PhanTu anhBia={this.props.AnhBia2}
                    tenTruyen={this.props.TenTruyen2}
                    url={"/Home/ttTruyen/" + this.props.MaTruyen2}
                    tenChuong1={this.props.Chuong12}
                    tenChuong2={this.props.Chuong22} />)
                }               
            </div>
        </div>)
    }
}


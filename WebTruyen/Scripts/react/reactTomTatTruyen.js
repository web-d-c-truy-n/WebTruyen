var BinhLuan = [];
class BinhLuans extends React.Component {
    Avatar = (image) => {
        debugger
        image.onerror = "";
        image.src = "https://secure.gravatar.com/avatar/b650eff44bd823b9df5d4fbd0d0b8422?s=195&d=mm&r=g";
        return true;
    }
    reply = (maBinhLuan, HovaTen) => {
        document.getElementById("comment_parent").value = maBinhLuan
        $("#reply-title").text("Trả lời cho " + HovaTen)
        $("#cancel-comment-reply-link").show()
    }
    load = () => {
        debugger
        let BinhLuanCha = BinhLuan.filter((x) => {
            return x.PhanHoi == null
        });
        let html = [];
        let binhLuanCon = (maBinhLuan) => {
            return BinhLuan.filter(x => x.PhanHoi == maBinhLuan)
        }
        BinhLuanCha.forEach((item, index) => {
            debugger
            let ngayBinhLuan = item.NgayBinhLuan
            let BinhLuanCon = []
            let cacBLCon = binhLuanCon(item.MaBinhLuan)
            cacBLCon.forEach((item, index) => {
                debugger
                let ngayBinhLuan = item.NgayBinhLuan
                BinhLuanCon.push(<li class="comment byuser comment-author-san4es_tv even thread-even depth-1" id="comment-717">
                    <article id="div-comment-717" class="comment-body">
                        <div class="block block-left">
                            <footer class="comment-meta">
                                <div class="comment-avatar">
                                    <img alt="" src={item.Avatar == null ? "https://secure.gravatar.com/avatar/b650eff44bd823b9df5d4fbd0d0b8422?s=195&d=mm&r=g" : item.Avatar} onError={(e) => { e.target.onerror = null; e.target.src = "https://secure.gravatar.com/avatar/b650eff44bd823b9df5d4fbd0d0b8422?s=195&d=mm&r=g" }} class="avatar avatar-60 photo" height="60" width="60" loading="lazy" />
                                </div>
                            </footer>
                        </div>
                        <div class="block block-right">
                            <div class="comment-author">
                                <h6 class="heading fn">{item.HovaTen}</h6>
                            </div>
                            <div class="comment-content">
                                <p>{item.NoiDung}</p>
                            </div>
                            <div class="comment-metadata">
                                <a href="~/Asset/Web/manga/massa-consectetur-mattis/#comment-717">
                                    {ngayBinhLuan}
                                </a>
                            </div>
                        </div>
                    </article>
                </li>)
            })

            html.push(<li class="comment byuser comment-author-san4es_tv even thread-even depth-1" id="comment-717">
                <article id="div-comment-717" class="comment-body">
                    <div class="block block-left">
                        <footer class="comment-meta">
                            <div class="comment-avatar">
                                <img alt="" src={item.Avatar == null ? "https://secure.gravatar.com/avatar/b650eff44bd823b9df5d4fbd0d0b8422?s=195&d=mm&r=g" : item.Avatar} onError={(e) => { e.target.onerror = null; e.target.src = "https://secure.gravatar.com/avatar/b650eff44bd823b9df5d4fbd0d0b8422?s=195&d=mm&r=g" }} class="avatar avatar-60 photo" height="60" width="60" loading="lazy" />
                            </div>
                        </footer>
                    </div>
                    <div class="block block-right">
                        <div class="comment-author">
                            <h6 class="heading fn">{item.HovaTen}</h6>
                        </div>
                        <div class="comment-content">
                            <p>{item.NoiDung}</p>
                        </div>
                        <div class="comment-metadata">
                            <a href="~/Asset/Web/manga/massa-consectetur-mattis/#comment-717">
                                {ngayBinhLuan}
                            </a>
                        </div>
                    </div>

                    <div class="reply">
                        <a rel="nofollow" onClick={() => this.reply(item.MaBinhLuan, item.HovaTen)} class="comment-reply-link" href="##" data-commentid="717" data-postid="449" data-belowelement="div-comment-717" data-respondelement="respond" data-replyto="Reply to Lahm">Reply</a>
                    </div>
                    {BinhLuanCon.length > 0 ?
                        <ol class="comment-list comment-reply" id="comments">
                            {BinhLuanCon}
                        </ol> : ""
                    }
                </article>
            </li>)
        })
        ReactDOM.render(<BinhLuans load={false}>{html}</BinhLuans>, document.getElementById('comments'))
    }
    render() {
        return (<ol class="comment-list">
            {this.props.load ? this.load() : ""}
            {this.props.children}
        </ol>)
    }
}

class PhanHoi extends React.Component {
    render() {
        return (<ol class="comment-list">
            {this.props.load ? this.load() : ""}
            {this.props.children}
        </ol>)
    }
}
const render = () => {
    ReactDOM.render(<BinhLuans load={true} />, document.getElementById('comments'))
}
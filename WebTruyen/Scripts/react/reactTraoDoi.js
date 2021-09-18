var dataChat = []
var chat
class TraoDoi extends React.Component {
    chat = () => {        
        let noiDung = $("#message").val()
        $.connection.hub.start().done(function () {
            chat.server.message(maTV, maNhom, noiDung)
        })
        $("#message").val("")
    }
    enterChat = (e) => {        
        if (e.keyCode == 13) {
            this.chat()
        }
    }
    componentDidMount() {
        this.componentDidUpdate()
    }

    componentDidUpdate() {
        debugger
        let top = $("#phanChat")
        $("#phanChat").scrollTop(10000000000)
    }
    render() {        
        let data = this.props.data
        let toiChat = (x) => (
            <div class="direct-chat-msg right">
                <div class="direct-chat-infos clearfix">
                    <span class="direct-chat-name float-left">{x.ButDanh}</span>
                    <span class="direct-chat-timestamp float-right">{x.NgayViet}</span>
                </div>
                <img class="direct-chat-img" style={{height:"30px"}} src={x.Avatar == null ? "/Asset/Web/wp-content/themes/madara/images/no-avatar.png" : x.Avatar} alt="message user image" />
                <div class="direct-chat-text">
                    {x.NoiDung}
                </div>
            </div>
        )
        let hoChat = (x) => (
            <div class="direct-chat-msg">
                <div class="direct-chat-infos clearfix">
                    <span class="direct-chat-name float-left">{x.ButDanh}</span>
                    <span class="direct-chat-timestamp float-right">{x.NgayViet}</span>
                </div>
                <img class="direct-chat-img" style={{ height: "30px" }} src={x.Avatar == null ? "/Asset/Web/wp-content/themes/madara/images/no-avatar.png" : x.Avatar} alt="message user image" />
                <div class="direct-chat-text">
                    {x.NoiDung}
                </div>
            </div>
        )
        let html = []
        data.forEach((x) => {
            if (x.MaTV == maTV)
                html.push(toiChat(x))
            else
                html.push(hoChat(x))
        })
        return (<div class="row">
            <div class="card direct-chat direct-chat-primary" style={{ width: "100%"}}>
                <div class="card-header ui-sortable-handle" style={{ cursor: "move" }}>
                    <h3>Trao đổi nhóm</h3>
                </div>
                <div class="card-body" style={{ display: "block", "overflow-y": "scroll", height: "500px" }} id="phanChat">
                    <div class="direct-chat-messages">
                        {html}
                    </div>
                </div>
                <div class="card-footer" style={{ display: "block" }}>
                    <div class="input-group">
                        <input type="text" name="message" placeholder="Type Message ..." class="form-control" id="message" onKeyUp={(e) => this.enterChat(e)} />
                        <span class="input-group-append">
                            <button type="button" class="btn btn-primary" onClick={this.chat}>Send</button>
                            </span>
                            </div>
                    </div>
                </div>
            </div>)
    }
}
const readerTraoDoi =  (data) => {
    ReactDOM.render(<TraoDoi data={data} />, document.getElementById('traoDoi'))
}
$(document).ready(async function () {
    debugger
    let data = await API.noiDungTraoDoi(maNhom)
    dataChat = [...data]
    readerTraoDoi(dataChat);
    chat = $.connection.traoDoi_Nhom;
    chat.client.message = function (data) {
        debugger
        dataChat.push(data)
        readerTraoDoi(dataChat)
    }
    $.connection.hub.start().done(function () {
        chat.server.joinRoom(maNhom)
    })
})
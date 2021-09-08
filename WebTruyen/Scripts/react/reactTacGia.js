
class Image extends React.Component {
    clickAnh = (Url, id) => {
        if (anhBia) {
            $("#anhBia").attr("src", Url)
            $("#anhBia").attr("idAnh", id)
            $("#dongAnhBia").click()
        } else {
            debugger
            let Url = $(this).attr("src")
            $('#editor').trumbowyg('html', '<img src = "' + Url + '" />');
            $("#dongAnhBia").click()
        }
    }
    load = () => {
        debugger
        let anh = []
        anhTG.forEach((x, index) => {
            anh.push(<img src={x.url} width="96" height="72" onClick={() => this.clickAnh(x.url, x.MaAnh)} />)
        })
        ReactDOM.render(<Image load={false}>{anh}</Image>, document.getElementById('allAnh'))
        }
    render() {
        return <div>
            {this.props.load ? this.load() : ""}
            {this.props.children}
            </div>
    }
}
class Truyen extends React.Component {
    render = async () => {
        let Truyen = await API.layTruyenTG(-1)
        let truyen = []
        Truyen.forEach((item, index) => {
            truyen.push(<option value={item.MaTruyen}>{item.TenTruyen}</option>)
        })
        return { truyen }
    }
}
const reload = () => {
    ReactDOM.render(<Image load={true} />, document.getElementById('allAnh'))
}
const reload_Truyen = () =>{
    ReactDOM.render(<Truyen />, document.getElementById('c_tenTruyen'))
}


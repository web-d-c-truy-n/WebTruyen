
class Image extends React.Component {
    clickAnh = (Url, id) => {
        debugger
        if (anhBia) {
            $("#anhBia").attr("src", Url)
            $("#anhBia").attr("idAnh", id)
            $("#dongAnh").click()
        } else {
            let html = $('#editor_e').trumbowyg('html')
            $('#editor_e').trumbowyg('html', html + '<img src = "' + Url + '" maAnh ="' + id + '" />');
            $("#dongAnh").click()
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
const reload = () => {
    ReactDOM.render(<Image load={true} />, document.getElementById('allAnh'))
}
reload()


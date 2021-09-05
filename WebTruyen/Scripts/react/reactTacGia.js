
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
const reload = () => {
    ReactDOM.render(<Image load={true} />, document.getElementById('allAnh'))
}
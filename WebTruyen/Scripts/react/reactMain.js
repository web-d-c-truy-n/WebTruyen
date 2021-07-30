
class Car extends React.Component {
    render() {
        return <h2>I am a {this.props.brand}!</h2>
    }
}



alert(ReactDOMServer.renderToString(<Car brand="Ford" />, document.getElementById('root')));
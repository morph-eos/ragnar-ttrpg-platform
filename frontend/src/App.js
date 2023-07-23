import { Routes, Route } from 'react-router-dom';
import Main from './Main';
import Router from './Router';
function App() {

    return (
        <div className="App">
            <Routes>
                <Route path="/" element={<Main/>} />
                <Route path=":query" element={<Router/>} />
            </Routes>
        </div>
    );
}

export default App;

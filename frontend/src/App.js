import { Routes, Route } from 'react-router-dom';
import Main from './Main';
import UnderConstruction from './UnderConstruction';
function App() {

    return (
        <div className="App">
            <Routes>
                <Route path="/" element={<UnderConstruction/>} />
                <Route path=":query" element={<Main/>} />
            </Routes>
        </div>
    );
}

export default App;
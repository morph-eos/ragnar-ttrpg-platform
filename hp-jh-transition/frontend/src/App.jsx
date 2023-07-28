import { Routes, Route } from 'react-router-dom';
import Main from './Main';
import Rpg from './routes/Rpg';

export default function App() {
  return (
    <div className="App">
      <div id="navbar">
        <img src="/logo.png" alt="Logo"/>
        {/* Aggiungi altri elementi della navbar, come pulsanti o menu, a destra del logo */}
      </div>
      <Routes>
        <Route path="/" element={<Main />} />
        <Route path="/rpg" element={<Rpg />} />
        <Route path="/rpg/:button" element={<Rpg />} />
        <Route path=":default" element={<Main />} />
      </Routes>
    </div>
  );
};
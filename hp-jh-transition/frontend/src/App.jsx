import { Routes, Route, Link } from 'react-router-dom';
import Main from './Main';
import NotFoundPage from './NotFoundPage';
import Rpg from './routes/Rpg';

export default function App() {
  return (
    <div className="App">
      <div id="navbar">
        <Link to="/">
          <img src="/logo.png" alt="Logo" />
        </Link>
        {/* Aggiungi altri elementi della navbar, come pulsanti o menu, a destra del logo */}
      </div>
      <Routes>
        <Route path="/" element={<Main />} />
        <Route path="/rpg" element={<Rpg />} />
        <Route path="/rpg/:button/*" element={<Rpg />} />
        <Route path="*" element={<NotFoundPage />} />
      </Routes>
    </div>
  );
};
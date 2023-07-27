import { Routes, Route } from 'react-router-dom';
import Main from './Main';
import Router from './Router';

export default function App() {
  return (
    <div className="App">
      <div
        style={{
          backgroundColor: 'orange',
          height: '60px',
          display: 'flex',
          alignItems: 'center',
          padding: '0 20px',
          borderRadius: '40px', // Imposta il raggio di curvatura degli angoli
        }}
      >
        <img src="/logo.png" alt="Logo" style={{ height: '60px', marginRight: '20px', marginLeft: '-19px' }} />
        {/* Aggiungi altri elementi della navbar, come pulsanti o menu, a destra del logo */}
      </div>
      <Routes>
        <Route path="/" element={<Main />} />
        <Route path=":query" element={<Router />} />
      </Routes>
    </div>
  );
};
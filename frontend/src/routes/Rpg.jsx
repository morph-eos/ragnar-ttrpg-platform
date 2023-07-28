import { Routes, Route, Link, useParams } from 'react-router-dom';
import Sheets from './rpg/Sheets';
import Classes from './rpg/Classes';
import Items from './rpg/Items';
import Races from './rpg/Races';
import World from './rpg/World';

export default function Rpg() {
  const { button } = useParams();
  
  return (
      <>
        {/* Navbar */}
        <nav className='p-4'>
          <ul className='flex flex-wrap space-x-4 justify-center'>
            <li className='flex-shrink-0'>
              <Link
                className={`btn-bullet btn-bullet-${button === 'sheets' ? 'sunset' : 'orange'}`}
                to="/rpg/sheets"
              >Schede</Link>
            </li>
            <li className='flex-shrink-0'>
              <Link
                className={`btn-bullet btn-bullet-${button === 'classes' ? 'sunset' : 'orange'}`}
                to="/rpg/classes"
              >Classi</Link>
            </li>
            <li className='flex-shrink-0'>
              <Link
                className={`btn-bullet btn-bullet-${button === 'items' ? 'sunset' : 'orange'}`}
                to="/rpg/items"
              >Oggetti</Link>
            </li>
            <li className='flex-shrink-0'>
              <Link
                className={`btn-bullet btn-bullet-${button === 'races' ? 'sunset' : 'orange'}`}
                to="/rpg/races"
              >Razze</Link>
            </li>
            <li className='flex-shrink-0'>
              <Link
                className={`btn-bullet btn-bullet-${button === 'world' ? 'sunset' : 'orange'}`}
                to="/rpg/world"
              >Mondo</Link>
            </li>
          </ul>
        </nav>

        {/* Route components */}
        <Routes>
          <Route path="/sheets" element={<Sheets />} />
          <Route path="/classes" element={<Classes />} />
          <Route path="/items" element={<Items/>}/>
          <Route path="/races" element={<Races />} />
          <Route path="/world" element={<World />} />
        </Routes>
      </>
  );
}
import { Link, useParams } from 'react-router-dom';
import { useState, useEffect } from 'react';
import Sheets from './rpg/Sheets';
import Classes from './rpg/Classes';
import Items from './rpg/Items';
import Races from './rpg/Races';
import World from './rpg/World';

export default function Rpg() {
  const { button } = useParams();
  
  const [component, setComponent] = useState();

  useEffect(() => {
    switch (button) {
      case 'sheets':
        setComponent(<Sheets />);
        break;
      case 'classes':
        setComponent(<Classes />);
        break;
      case 'items':
        setComponent(<Items />);
        break;
      case 'races':
        setComponent(<Races />);
        break;
      case 'world':
        setComponent(<World />);
        break;
      default:
        setComponent(<></>);
        break;
    }
  }, [button]);
  
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

        {component}
      </>
  );
}
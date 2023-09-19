import { Link, useParams } from 'react-router-dom';
import { useState, useEffect } from 'react';
import Sheets from './rpg/Sheets';
import Classes from './rpg/Classes';
import Showcase from './rpg/Showcase';
import Private from './rpg/Private';

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
      case 'races':
        setComponent(<Showcase type="races"/>);
        break;
      case 'regions':
        setComponent(<Showcase type="regions" />);
        break;
      case 'private':
        setComponent(<Private />);
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
                className={`btn-bullet${button === 'sheets' ? '-active' : ''} btn-bullet-orange`}
                to="/rpg/sheets"
              >Schede</Link>
            </li>
            <li className='flex-shrink-0'>
              <Link
                className={`btn-bullet${button === 'classes' ? '-active' : ''} btn-bullet-orange`}
                to="/rpg/classes"
              >Classi</Link>
            </li>
            <li className='flex-shrink-0'>
              <Link
                className={`btn-bullet${button === 'races' ? '-active' : ''} btn-bullet-orange`}
                to="/rpg/races"
              >Razze</Link>
            </li>
            <li className='flex-shrink-0'>
              <Link
                className={`btn-bullet${button === 'regions' ? '-active' : ''} btn-bullet-orange`}
                to="/rpg/regions"
              >Regioni</Link>
            </li>
            <li className='flex-shrink-0'>
              <Link
                className={`btn-bullet${button === 'private' ? '-active' : ''} btn-bullet-orange`}
                to="/rpg/private"
              >Accesso/Registrazione</Link>
            </li>
          </ul>
        </nav>

        {component}
      </>
  );
}
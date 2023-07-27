import { useParams } from 'react-router-dom';
import Main from './Main';
import Rpg from './routes/Rpg';

export default function Router() {
  const { query } = useParams();
  
  switch (query) {
    case 'rpg':
      return (
        <Rpg />
      );
    default:
      return (
        <Main />
      );
  }
};
import { useState, useEffect } from 'react';
import axios from 'axios';

export default function Items() {
  const [tableData, setTableData] = useState([]);
  
  useEffect(() => {
    // Funzione per eseguire la richiesta POST al server
    const fetchData = async () => {
      try {
        const response = await axios.get(window.location.origin + '/api/items');
        setTableData(response.data); // Imposta i dati della tabella ottenuti dalla risposta del server
      } catch (error) {
        console.error('Errore nella richiesta:', error);
      }
    };

    fetchData(); // Chiama la funzione per effettuare la richiesta quando il componente viene montato
  }, []);

  return (
    <div>
      <table>
        <thead>
          <tr>
            <th>Intestazione colonna 1</th>
            <th>Intestazione colonna 2</th>
            {/* Aggiungi altre intestazioni delle colonne se necessario */}
          </tr>
        </thead>
        <tbody>
          {/* Mappa i dati della tabella e mostra ciascuna riga */}
          {tableData.map((row, index) => (
            <tr key={index}>
              <td className="bg-orange">{row.dato1}</td>
              <td className="bg-sunset">{row.dato2}</td>
              {/* Aggiungi altre celle della riga se necessario */}
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
  
};
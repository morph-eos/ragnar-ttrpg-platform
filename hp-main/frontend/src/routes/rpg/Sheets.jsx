import React, { useState, useEffect } from 'react';
import axios from 'axios';

export default function Sheets() {
  const [options, setOptions] = useState([]); // Array delle opzioni ottenute dalla richiesta GET
  const [selectedOption, setSelectedOption] = useState(''); // Opzione selezionata nel dropdown

  useEffect(() => {
    // Effettua la richiesta GET al server per ottenere l'array di stringhe
    axios.get(window.origin + '/api/rpg/charaNames')
      .then(response => {
        setOptions(response.data); // Imposta l'array di stringhe nelle opzioni
        setSelectedOption(response.data[0]); // Imposta la prima opzione come opzione preselezionata
      })
      .catch(error => {
        console.error('Errore nella richiesta GET:', error);
      })
  }, []);

  const handleSelectChange = (e) => {
    // Aggiorna l'opzione selezionata nel dropdown
    setSelectedOption(e.target.value);
  };

  return (
    <div className="p-4">
      <select onChange={handleSelectChange} className="w-full px-4 py-2 border rounded-full">
        {options.map((option, index) => (
          <option key={index} value={option}>
            {option}
          </option>
        ))}
      </select>
    </div>
  );
};
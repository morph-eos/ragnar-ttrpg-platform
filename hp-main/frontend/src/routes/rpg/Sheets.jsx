import React, { useState, useEffect } from 'react';
import { findAbility } from './functions';
import axios from 'axios';

export default function Sheets() {
  const [options, setOptions] = useState([]);
  const [selectedOptionId, setSelectedOptionId] = useState();
  const [selectedCharacter, setSelectedCharacter] = useState();

  useEffect(() => {
    axios.get(window.origin + '/api/rpg/charaNames')
      .then(response => {
        setOptions(response.data);
        setSelectedOptionId(response.data[0].id); // Imposta solo l'ID come valore selezionato
      })
      .catch(error => {
        console.error('Errore nella richiesta GET:', error);
      })
  }, []);

  useEffect(() => {
    // Utilizza selectedOptionId per ottenere il personaggio corretto
    axios.post(window.origin + '/api/rpg/sheetPrint', { id: selectedOptionId })
      .then(response => {setSelectedCharacter(response.data);})
      .catch(error => {
        console.error('Errore nella richiesta POST:', error);
      })
  }, [selectedOptionId]);

  const handleSelectChange = (e) => {
    setSelectedOptionId(e.target.value); // Aggiorna solo l'ID selezionato
  };

  return (
    <div className="p-4">
      <select onChange={handleSelectChange} value={selectedOptionId} className="w-full px-4 py-2 border rounded-full">
        {options.map((option) => (
          <option key={option.id} value={option.id}>
            {option.name + ' (' + option.id + ')'}
          </option>
        ))}
      </select>
      {selectedCharacter && (
        <div>
          {
            selectedCharacter.description.references && (
              <div className="rounded-xl flex flex-wrap">
                {selectedCharacter.description.references.map((image, index) => (
                  <div
                    key={'reference' + index}
                    className="max-h-[31.8vw] max-w-[31.8vw] flex items-center justify-center mt-2 mb-2 mr-2"
                  >
                    <img
                      src={`${window.origin}/api/rpg/charaImg/${selectedCharacter._id}_${image}`}
                      alt={`Reference ${index + 1}`}
                      className="h-full w-full object-contain"
                    />
                  </div>
                ))}
              </div>
            )
          }
          <p>{selectedCharacter.name}</p>
          <p>
            {"Razza: " + selectedCharacter.race.name + ", Classe: " + selectedCharacter.class.name}
            {selectedCharacter.style && ", Stile di combattimento: " + selectedCharacter.style}
            {selectedCharacter.region && ", Regione di nascita: " + selectedCharacter.region.name}
          </p>
          <p>
            {selectedCharacter.description.gender && "Genere: " + selectedCharacter.description.gender + ", "}
            {"Anni: " + selectedCharacter.description.age + ", Altezza: " + selectedCharacter.description.height + "m, Peso: " + selectedCharacter.description.weight + "Kg"}
          </p>
          <p>{"Occhi: " + selectedCharacter.description.eyes + ", Carnagione: " + selectedCharacter.description.skin + ", Capelli: " + selectedCharacter.description.hairs}</p>
          <div>
            <p>Costituzione: {selectedCharacter.statistics.constitution}</p>
            <p>Forza: {selectedCharacter.statistics.strength}</p>
            <p>Destrezza: {selectedCharacter.statistics.dexterity}</p>
            <p>Intelligenza: {selectedCharacter.statistics.intelligence}</p>
            <p>Saggezza: {selectedCharacter.statistics.wisdom}</p>
            <p>Carisma: {selectedCharacter.statistics.charisma}</p>
          </div>
          {selectedCharacter.abilities.items[0] && (
            <div>
              <p>Lista abilità:</p>
              <div>
                {selectedCharacter.abilities.items.map((ability, index) => {
                  return (
                    <div key={"Ability "+index}>
                      <p>{ability.name}</p>
                      <p>{"Numero di utilizzi: " + selectedCharacter.abilities.uses[index]}</p>
                      <p>Descrizione: {ability.description}</p>
                    </div>
                  );
                })}
              </div>
            </div>
          )}
          {selectedCharacter.spells.items[0] && (
            <div>
              <p>Lista incantensimi:</p>
              <div>
                {selectedCharacter.spells.items.map((spell, index) => {
                  return (
                    <div key={"Spell " + index}>
                      <p>{spell.name}</p>
                      <p>{"Numero di utilizzi: " + selectedCharacter.spells.uses[index]}</p>
                      <p>Descrizione: {spell.description}</p>
                    </div>
                  );
                })}
              </div>
            </div>
          )}
        </div>
      )}
    </div>
  );
};
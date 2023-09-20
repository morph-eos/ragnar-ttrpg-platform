import React, { useState, useEffect } from "react";
import { findAbility } from "./functions";
import axios from "axios";

export default function Sheets() {
  const [options, setOptions] = useState([]);
  const [selectedOptionId, setSelectedOptionId] = useState();
  const [selectedCharacter, setSelectedCharacter] = useState();

  useEffect(() => {
    axios
      .get(window.origin + "/api/rpg/list?type=characters")
      .then((response) => {
        setOptions(response.data);
        setSelectedOptionId(response.data[0].id); // Imposta solo l'ID come valore selezionato
      })
      .catch((error) => {
        console.error("Errore nella richiesta GET:", error);
      });
  }, []);

  useEffect(() => {
    // Utilizza selectedOptionId per ottenere il personaggio corretto
    axios
      .post(window.origin + "/api/rpg/print", { id: selectedOptionId, type: 'characters' })
      .then((response) => {
        setSelectedCharacter(response.data);
      })
      .catch((error) => {
        console.error("Errore nella richiesta POST:", error);
      });
  }, [selectedOptionId]);

  const handleSelectChange = (e) => {
    setSelectedOptionId(e.target.value); // Aggiorna solo l'ID selezionato
  };

  return (
    <div className="p-4">
      <select
        onChange={handleSelectChange}
        value={selectedOptionId}
        className="w-full px-4 py-2 border rounded-full"
      >
        {options.map((option) => (
          <option key={option.id} value={option.id}>
            {option.name + " (" + option.id + ")"}
          </option>
        ))}
      </select>
      {selectedCharacter && (
        <div className="bg-white rounded-lg shadow-lg p-4">
          {selectedCharacter.description.references && (
            <div className="rounded-xl overflow-x-auto whitespace-nowrap flex flex-row items-center">
              {selectedCharacter.description.references.map((image, index) => (
                <div
                  key={"reference_" + index}
                  className="inline-block max-w-[31.4vw] max-h-[31.4vw] flex-shrink-0 justify-center mt-2 mb-2 ml-1 mr-1"
                >
                  <img
                    src={`${window.origin}/api/rpg/references/characters_${selectedOptionId}_${image}`}
                    alt={`Reference ${index + 1}`}
                    className="max-w-full max-h-full"
                  />
                </div>
              ))}
            </div>
          )}
          <h1 className="text-3xl font-semibold mb-3">
            {selectedCharacter.name}
          </h1>
          <p className="text-gray-600">
            <span className="font-bold text-orange-500">Razza:</span>{" "}
            {selectedCharacter.race.name},
            <span className="font-bold text-orange-500"> Classe:</span>{" "}
            {selectedCharacter.class.name}
            {selectedCharacter.style && (
              <>
                ,{" "}
                <span className="font-bold text-orange-500">
                  {" "}
                  Stile di combattimento:
                </span>{" "}
                {selectedCharacter.style}
              </>
            )}
            {selectedCharacter.from && (
              <>
                ,{" "}
                <span className="font-bold text-orange-500">
                  {" "}
                  Stato di provenienza:
                </span>{" "}
                {selectedCharacter.region.name}
              </>
            )}
          </p>
          <p className="text-gray-600">
            {selectedCharacter.description.gender && (
              <>
                <span className="font-bold text-orange-500">Genere:</span>{" "}
                {selectedCharacter.description.gender},
              </>
            )}
            <span className="font-bold text-orange-500"> Anni:</span>{" "}
            {selectedCharacter.description.age},
            <span className="font-bold text-orange-500"> Altezza:</span>{" "}
            {selectedCharacter.description.height}m,
            <span className="font-bold text-orange-500"> Peso:</span>{" "}
            {selectedCharacter.description.weight}Kg
          </p>
          <p className="text-gray-600">
            <span className="font-bold text-orange-500">Occhi:</span>{" "}
            {selectedCharacter.description.eyes},
            <span className="font-bold text-orange-500"> Carnagione:</span>{" "}
            {selectedCharacter.description.skin},
            <span className="font-bold text-orange-500"> Capelli:</span>{" "}
            {selectedCharacter.description.hairs}
          </p>
          <div className="mt-4">
            <h2 className="text-xl font-semibold mb-2">Statistiche</h2>
            <div className="grid grid-cols-2 gap-4">
              <div>
                <p>
                  <span className="font-bold text-orange-500">
                    Costituzione:
                  </span>{" "}
                  {selectedCharacter.statistics.constitution +
                    selectedCharacter.race.statistics.constitution +
                    selectedCharacter.class.statistics.constitution}
                </p>
                <p>
                  <span className="font-bold text-orange-500">Forza:</span>{" "}
                  {selectedCharacter.statistics.strength +
                    selectedCharacter.race.statistics.strength +
                    selectedCharacter.class.statistics.strength}
                </p>
                <p>
                  <span className="font-bold text-orange-500">Destrezza:</span>{" "}
                  {selectedCharacter.statistics.dexterity +
                    selectedCharacter.race.statistics.dexterity +
                    selectedCharacter.class.statistics.dexterity}
                </p>
              </div>
              <div>
                <p>
                  <span className="font-bold text-orange-500">
                    Intelligenza:
                  </span>{" "}
                  {selectedCharacter.statistics.intelligence +
                    selectedCharacter.race.statistics.intelligence +
                    selectedCharacter.class.statistics.intelligence}
                </p>
                <p>
                  <span className="font-bold text-orange-500">Saggezza:</span>{" "}
                  {selectedCharacter.statistics.wisdom +
                    selectedCharacter.race.statistics.wisdom +
                    selectedCharacter.class.statistics.wisdom}
                </p>
                <p>
                  <span className="font-bold text-orange-500">Carisma:</span>{" "}
                  {selectedCharacter.statistics.charisma +
                    selectedCharacter.race.statistics.charisma +
                    selectedCharacter.class.statistics.charisma}
                </p>
              </div>
            </div>
          </div>
          {selectedCharacter.abilities.items[0] && (
            <div className="mt-4">
              <h2 className="text-xl font-semibold">Lista abilità</h2>
              <div>
                {selectedCharacter.abilities.items.map((ability, index) => (
                  <div key={`Ability ${index}`} className="mt-2">
                    <p className="font-bold text-orange-500">{ability.name}</p>
                    <p>
                      <span className="font-bold">Numero di utilizzi:</span>{" "}
                      {selectedCharacter.abilities.uses[index]}
                    </p>
                    <p className="text-gray-600">
                      <span className="font-bold">Descrizione:</span>{" "}
                      {ability.description}
                    </p>
                  </div>
                ))}
              </div>
            </div>
          )}
          {selectedCharacter.spells.items[0] && (
            <div className="mt-4">
              <h2 className="text-xl font-semibold">Lista incantesimi</h2>
              <div>
                {selectedCharacter.spells.items.map((spell, index) => (
                  <div key={`Spell ${index}`} className="mt-2">
                    <p className="font-bold text-orange-500">{spell.name}</p>
                    <p>
                      <span className="font-bold">Numero di utilizzi:</span>{" "}
                      {selectedCharacter.spells.uses[index]}
                    </p>
                    <p className="text-gray-600">
                      <span className="font-bold">Descrizione:</span>{" "}
                      {spell.description}
                    </p>
                  </div>
                ))}
              </div>
            </div>
          )}
        </div>
      )}
    </div>
  );
}
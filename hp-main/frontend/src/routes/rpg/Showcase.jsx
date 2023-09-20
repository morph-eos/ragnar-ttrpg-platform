import React, { useState, useEffect } from "react";
import axios from "axios";

export default function Showcase({ type }) {
  const [options, setOptions] = useState([]);
  const [selectedOptionId, setSelectedOptionId] = useState();
  const [selectedOption, setSelectedOption] = useState();

  useEffect(() => {
    axios
      .get(window.origin + "/api/rpg/list?type=" + type)
      .then((response) => {
        setOptions(response.data);
        setSelectedOptionId(response.data[0].id); // Imposta solo l'ID come valore selezionato
      })
      .catch((error) => {
        console.error("Errore nella richiesta GET:", error);
      });
  }, [type]);

  useEffect(() => {
    axios
      .post(window.origin + "/api/rpg/print", {
        id: selectedOptionId,
        type: type,
      })
      .then((response) => {
        setSelectedOption(response.data);
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
      <div className="flex">
        <div className="w-1/3">
          {selectedOption && (
            <div className="bg-white rounded-lg shadow-lg p-4 max-h-[78vh] overflow-auto">
              {selectedOption.references && (
                <div className="rounded-xl overflow-y-auto">
                  {selectedOption.references.map((image, index) => (
                    <div key={"reference_" + index} className="mb-4">
                      <img
                        src={`${window.origin}/api/rpg/references/${type}_${selectedOptionId}_${image}`}
                        alt={`Reference ${index + 1}`}
                        className="max-w-full"
                      />
                    </div>
                  ))}
                </div>
              )}
            </div>
          )}
        </div>
        <div className="w-2/3 pl-4 max-h-[80vh] overflow-auto">
          {selectedOption && (
            <div className="bg-white rounded-lg shadow-lg p-4">
              <h1 className="text-3xl font-semibold mb-4">
                {selectedOption.name}
              </h1>
              <p className="text-gray-600">{selectedOption.description}</p>
              {type === "states" && (
                <div className="mt-4">
                  {selectedOption.races && selectedOption.races.lenght > 0 && (
                    <>
                      <h2 className="text-xl font-semibold mb-2">
                        Origine delle seguenti razze:
                      </h2>
                      <p>
                        {selectedOption.races.map((race, index) => (
                          <span key={race._id}>
                            {race.name}
                            {index < selectedOption.races.length - 1 && ", "}
                          </span>
                        ))}
                      </p>
                    </>
                  )}
                  {selectedOption.languages && (
                    <>
                      <h2 className="text-xl font-semibold mb-2 mt-4">
                        Lingue parlate:
                      </h2>
                      <p>{selectedOption.languages}</p>
                    </>
                  )}
                </div>
              )}
              {type === "races" && selectedOption.statistics && (
                <>
                  <div className="mt-4">
                    <h2 className="text-xl font-semibold mb-2">
                      Statistiche di partenza (da rifare)
                    </h2>
                    <div className="grid grid-cols-2 gap-4">
                      <div>
                        <p>
                          <span className="font-bold text-orange-500">
                            Costituzione:
                          </span>{" "}
                          {selectedOption.statistics.constitution}
                        </p>
                        <p>
                          <span className="font-bold text-orange-500">
                            Forza:
                          </span>{" "}
                          {selectedOption.statistics.strength}
                        </p>
                        <p>
                          <span className="font-bold text-orange-500">
                            Destrezza:
                          </span>{" "}
                          {selectedOption.statistics.dexterity}
                        </p>
                      </div>
                      <div>
                        <p>
                          <span className="font-bold text-orange-500">
                            Intelligenza:
                          </span>{" "}
                          {selectedOption.statistics.intelligence}
                        </p>
                        <p>
                          <span className="font-bold text-orange-500">
                            Saggezza:
                          </span>{" "}
                          {selectedOption.statistics.wisdom}
                        </p>
                        <p>
                          <span className="font-bold text-orange-500">
                            Carisma:
                          </span>{" "}
                          {selectedOption.statistics.charisma}
                        </p>
                      </div>
                    </div>
                  </div>
                  {selectedOption.abilities.items[0] && (
                    <div className="mt-4">
                      <h2 className="text-xl font-semibold">
                        Lista abilità di razza
                      </h2>
                      <div>
                        {selectedOption.abilities.items.map(
                          (ability, index) => (
                            <div key={`Ability ${index}`} className="mt-2">
                              <p className="font-bold text-orange-500">
                                {ability.name}
                              </p>
                              <p>
                                <span className="font-bold">
                                  Ottenibile al livello:
                                </span>{" "}
                                {selectedOption.abilities.lvlsToGet[index]}
                              </p>
                              <p className="text-gray-600">
                                <span className="font-bold">Descrizione:</span>{" "}
                                {ability.description}
                              </p>
                            </div>
                          ),
                        )}
                      </div>
                    </div>
                  )}
                </>
              )}
            </div>
          )}
        </div>
      </div>
    </div>
  );
}
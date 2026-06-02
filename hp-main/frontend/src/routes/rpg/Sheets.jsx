/**
 * RAGNAR TTRPG PLATFORM - LEGACY CHARACTER SHEETS COMPONENT
 * =========================================================
 * 
 * File: Sheets.jsx
 * Purpose: Character sheet display and management interface
 * 
 * COMPONENT OVERVIEW:
 * This component provides the user interface for viewing and managing
 * character sheets in the legacy HeatPeak Studio implementation. It
 * demonstrates the MongoDB-based approach to character data management
 * with Axios HTTP client for API communication.
 * 
 * LEGACY ARCHITECTURE PATTERNS:
 * - Direct HTTP requests with Axios (no request interceptors or caching)
 * - Component-level state management with useState hooks
 * - Manual error handling in HTTP requests
 * - Dynamic API endpoint construction with window.origin
 * - Simple dropdown selection pattern for character switching
 * 
 * DATA FLOW:
 * 1. Component mounts and fetches character list from /api/rpg/list
 * 2. Auto-selects first character and fetches detailed data via /api/rpg/print
 * 3. User can switch characters through dropdown selection
 * 4. Character data updates trigger re-rendering of character sheet display
 * 
 * API INTEGRATION:
 * - GET /api/rpg/list?type=characters: Fetches list of available characters
 * - POST /api/rpg/print: Retrieves detailed character data by ID
 * 
 * MODERN EVOLUTION COMPARISON:
 * Current Angular implementation (jh-main) features:
 * - HTTP interceptors for authentication and error handling
 * - Reactive forms with real-time validation
 * - NgRx state management for centralized character data
 * - TypeScript interfaces for type safety
 * - Angular Material components for consistent UI
 * - Azure AD B2C integration for user authentication
 * - PostgreSQL with Entity Framework for relational data modeling
 * 
 * Team: HeatPeak Studio (Legacy Implementation)
 * Database: MongoDB with Mongoose ODM
 * HTTP Client: Axios for REST API communication
 */

import React, { useState, useEffect } from "react";
import { findAbility } from "./functions";
import axios from "axios";

/**
 * CHARACTER SHEETS COMPONENT
 * Provides interface for viewing and selecting character sheets
 * 
 * STATE MANAGEMENT:
 * - options: Array of available characters from MongoDB
 * - selectedOptionId: Currently selected character ID
 * - selectedCharacter: Detailed character data for display
 * 
 * COMPONENT LIFECYCLE:
 * 1. Mount: Fetch character list and auto-select first character
 * 2. Selection: Update character details when dropdown selection changes
 * 3. Display: Render character sheet with detailed information
 */
export default function Sheets() {
  // Component state for character management
  const [options, setOptions] = useState([]); // Available characters list
  const [selectedOptionId, setSelectedOptionId] = useState(); // Selected character ID
  const [selectedCharacter, setSelectedCharacter] = useState(); // Full character data

  /**
   * INITIAL DATA LOADING
   * Fetches the list of available characters on component mount
   * Auto-selects the first character for immediate display
   */
  useEffect(() => {
    axios
      .get(window.origin + "/api/rpg/list?type=characters")
      .then((response) => {
        setOptions(response.data);
        setSelectedOptionId(response.data[0].id); // Auto-select first character
      })
      .catch((error) => {
        console.error("Errore nella richiesta GET:", error);
      });
  }, []);

  /**
   * CHARACTER DETAILS LOADING
   * Fetches detailed character data when selection changes
   * Uses POST request with character ID to retrieve full character sheet
   */
  useEffect(() => {
    // Prevent API call if no character is selected
    if (!selectedOptionId) return;
    
    axios
      .post(window.origin + "/api/rpg/print", { id: selectedOptionId, type: 'characters' })
      .then((response) => {
        setSelectedCharacter(response.data);
      })
      .catch((error) => {
        console.error("Errore nella richiesta POST:", error);
      });
  }, [selectedOptionId]);

  /**
   * CHARACTER SELECTION HANDLER
   * Updates selected character ID when user changes dropdown selection
   */
  const handleSelectChange = (e) => {
    setSelectedOptionId(e.target.value);
  };

  return (
    <div className="p-4">
      {/* Character Selection Dropdown */}
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
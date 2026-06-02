/**
 * RAGNAR TTRPG PLATFORM - LEGACY RPG HUB COMPONENT
 * ================================================
 * 
 * File: Rpg.jsx
 * Purpose: Main navigation hub for RPG functionality with dynamic component loading
 * 
 * COMPONENT ARCHITECTURE:
 * This component serves as the central hub for all RPG-related functionality
 * in the legacy HeatPeak Studio implementation. It uses React Router's useParams
 * hook to dynamically load different RPG components based on URL parameters.
 * 
 * LEGACY ROUTING PATTERN:
 * - Uses switch-case pattern for component selection
 * - Component state management with useState and useEffect
 * - Direct component imports and conditional rendering
 * - URL-based navigation with React Router Link components
 * 
 * AVAILABLE RPG SECTIONS:
 * - sheets: Character sheet management and viewing
 * - classes: Character class definitions and abilities
 * - races: Available character races and racial bonuses
 * - states: Game states and conditions management
 * - private: User authentication and registration
 * 
 * UI/UX PATTERN:
 * - Horizontal navigation bar with bullet-style buttons
 * - Active state highlighting with conditional CSS classes
 * - Responsive design with Tailwind CSS flexbox utilities
 * - Orange theme color scheme (btn-bullet-orange)
 * 
 * EVOLUTION TO MODERN IMPLEMENTATION:
 * The current Angular version (jh-main) features:
 * - Angular Router with lazy loading and route guards
 * - Material Design navigation with side drawer
 * - TypeScript interfaces for type safety
 * - Reactive forms with validation
 * - Azure AD B2C integration for authentication
 * 
 * Team: HeatPeak Studio (Legacy Implementation)
 */

import { Link, useParams } from 'react-router-dom';
import { useState, useEffect } from 'react';
import Sheets from './rpg/Sheets';
import Classes from './rpg/Classes';
import Showcase from './rpg/Showcase';
import Private from './rpg/Private';

/**
 * RPG HUB COMPONENT
 * Central navigation and component loading for all RPG functionality
 * 
 * DYNAMIC COMPONENT LOADING:
 * Uses URL parameters to determine which RPG component to display.
 * This pattern allows for clean URLs and direct linking to specific sections.
 * 
 * COMPONENT MAPPING:
 * - sheets: Character sheet management (MongoDB-based character data)
 * - classes: Character class definitions with abilities and progression
 * - races: Character races with racial bonuses and lore
 * - states: Game conditions and status effects
 * - private: User authentication and character ownership
 * 
 * STATE MANAGEMENT:
 * Uses local component state for simplicity. Modern implementation
 * uses NgRx for centralized state management with better scalability.
 */
export default function Rpg() {
  const { button } = useParams(); // Extract current section from URL
  
  const [component, setComponent] = useState(); // Currently displayed component

  /**
   * COMPONENT SELECTION LOGIC
   * Updates displayed component based on URL parameter changes
   * Uses switch-case pattern for component mapping
   */
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
      case 'states':
        setComponent(<Showcase type="states" />);
        break;
      case 'private':
        setComponent(<Private />);
        break;
      default:
        setComponent(<></>); // Empty component for default/invalid routes
        break;
    }
  }, [button]);
  
  return (
      <>
        {/* RPG Navigation Bar - Horizontal button layout */}
        <nav className='p-4'>
          <ul className='flex flex-wrap space-x-4 justify-center'>
            {/* Character Sheets Section */}
            <li className='flex-shrink-0'>
              <Link
                className={`btn-bullet${button === 'sheets' ? '-active' : ''} btn-bullet-orange`}
                to="/rpg/sheets"
              >Schede</Link>
            </li>
            
            {/* Character Classes Section */}
            <li className='flex-shrink-0'>
              <Link
                className={`btn-bullet${button === 'classes' ? '-active' : ''} btn-bullet-orange`}
                to="/rpg/classes"
              >Classi</Link>
            </li>
            
            {/* Character Races Section */}
            <li className='flex-shrink-0'>
              <Link
                className={`btn-bullet${button === 'races' ? '-active' : ''} btn-bullet-orange`}
                to="/rpg/races"
              >Razze</Link>
            </li>
            
            {/* Game States Section */}
            <li className='flex-shrink-0'>
              <Link
                className={`btn-bullet${button === 'states' ? '-active' : ''} btn-bullet-orange`}
                to="/rpg/states"
              >Stati</Link>
            </li>
            
            {/* Authentication/Registration Section */}
            <li className='flex-shrink-0'>
              <Link
                className={`btn-bullet${button === 'private' ? '-active' : ''} btn-bullet-orange`}
                to="/rpg/private"
              >Accesso/Registrazione</Link>
            </li>
          </ul>
        </nav>

        {/* Dynamic Component Rendering */}
        {/* Renders the selected component based on current URL parameter */}
        {component}
      </>
  );
}
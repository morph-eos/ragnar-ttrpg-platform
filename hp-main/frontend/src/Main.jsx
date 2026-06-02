/**
 * RAGNAR TTRPG PLATFORM - LEGACY MAIN LANDING PAGE
 * ================================================
 * 
 * File: Main.jsx
 * Purpose: Landing page component showing construction status
 * 
 * COMPONENT OVERVIEW:
 * This is the main landing page for the HeatPeak Studio legacy implementation
 * of the Ragnar TTRPG Platform. It displays a "under construction" message
 * with animated GIF and social media reference.
 * 
 * LEGACY DESIGN APPROACH:
 * - Inline styling instead of CSS modules or styled-components
 * - Direct reference to public assets (/construction-under-kipp.gif)
 * - Simple flexbox layout for centering content
 * - Black background with white text for dark theme
 * 
 * BUSINESS CONTEXT:
 * During the HeatPeak Studio phase, the platform was in early development
 * with limited public features available. This page served as a placeholder
 * while the RPG functionality was being developed behind the /rpg routes.
 * 
 * MODERN EVOLUTION:
 * The current implementation (jh-main branch) features:
 * - Full Angular dashboard with character management
 * - Complete CRUD operations for characters, classes, and races
 * - Azure cloud integration for file storage
 * - Advanced authentication and authorization
 * - Modern Material Design UI components
 * 
 * Team: HeatPeak Studio
 * Instagram: @heatpeakstudio (legacy social media presence)
 */

/**
 * MAIN LANDING PAGE COMPONENT
 * Displays construction notice and social media reference
 * 
 * STYLING APPROACH:
 * Uses inline styles for simplicity in this legacy implementation.
 * Modern version uses Angular Material and structured SCSS files.
 * 
 * LAYOUT STRUCTURE:
 * - Full viewport height (90vh) with flexbox centering
 * - Animated construction GIF as main visual element
 * - Social media call-to-action for user engagement
 */
export default function Main() {
  return (
    <div
      style={{
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'center',
        justifyContent: 'center',
        height: '90vh',
        backgroundColor: 'black',
      }}
    >
      {/* Construction Animation - Engaging visual feedback for users */}
      <img
        src="/construction-under-kipp.gif"
        alt="Under Construction"
        style={{ width: 'auto', height: 'auto' }}
      />
      
      {/* Status Message and Social Media CTA */}
      <h1 style={{ color: 'white' }}>
        Website under construction~ Check @heatpeakstudio on Instagram to get more informations!
      </h1>
    </div>
  );
};
/*
 * API Router - Central API Routing Configuration
 * 
 * This router acts as the central hub for all API endpoints in the legacy HeatPeak Studio
 * TTRPG platform. It organizes routes by feature domain and provides a clean separation
 * between different API functionalities. This modular approach allows for better
 * organization and maintainability of the RESTful API endpoints.
 * 
 * Route Organization:
 * - /api/rpg/* - All TTRPG game mechanics and character management
 * - Additional domain routes can be added here as needed
 * 
 * Legacy Note: This represents the original API design before the transition
 * to the modern .NET Core architecture with more sophisticated routing.
 */

const express = require('express');
const router = express.Router();

const rpgRouter = require('./routes/rpg.js');

// Mount the RPG-specific routes under /api/rpg
router.use('/rpg', rpgRouter);

// API Root endpoint - provides basic API information
router.get('/', (req, res) => {
  res.send('HeatPeak Studio TTRPG API - Legacy Backend System');
});

module.exports = router;
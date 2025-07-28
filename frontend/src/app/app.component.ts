/**
 * RAGNAR TTRPG PLATFORM - ANGULAR TRANSITION APPLICATION COMPONENT
 * ================================================================
 * 
 * File: app.component.ts
 * Purpose: Root Angular component for transition phase implementation
 * 
 * TRANSITION PHASE CONTEXT:
 * This component represents the frontend implementation during the transition
 * from React (hp-main) to Angular, before the final evolution to the modern
 * Angular implementation with NgRx and Azure integration (jh-main).
 * 
 * ARCHITECTURAL EVOLUTION:
 * - Legacy (hp-main): React with component state and React Router
 * - Transition (hp-jh-transition): Angular 17 with basic structure
 * - Modern (jh-main): Angular 18 with NgRx, Material Design, Azure AD B2C
 * 
 * ANGULAR FEATURES INTRODUCED:
 * - TypeScript for type safety (vs JavaScript in React version)
 * - Component-based architecture with decorators
 * - Dependency injection system
 * - Built-in router and forms modules
 * - RxJS for reactive programming patterns
 * 
 * COMPONENT STRUCTURE:
 * This is a minimal root component that serves as the entry point for the
 * Angular application. In the transition phase, it primarily serves as a
 * container for other components and routing configuration.
 * 
 * INTEGRATION WITH SPRING BOOT:
 * The Angular frontend integrates with the Spring Boot backend through:
 * - HTTP client for API communication
 * - Build process that creates static files served by Spring Boot
 * - SPA routing handled by Spring Boot's WebRoutingConfig
 * 
 * Team: HeatPeak Studio (Transition Phase)
 * Target: Modern Angular implementation with enterprise features
 */
import { Component } from '@angular/core';

/**
 * ROOT ANGULAR COMPONENT
 * 
 * The @Component decorator defines this as an Angular component with:
 * - selector: HTML tag name for using this component (<app-root>)
 * - templateUrl: Path to the HTML template file
 * - styleUrl: Path to the component-specific CSS file (Angular 17+ syntax)
 * 
 * COMPONENT PROPERTIES:
 * - title: Application title displayed in the component template
 * - Uses component scoped CSS for styling isolation
 * - Serves as the root container for all other application components
 * 
 * TRANSITION NOTES:
 * This minimal component structure will evolve in the modern implementation to include:
 * - Navigation bar with authentication status
 * - Route guards for protected areas
 * - Global state management integration
 * - Material Design theming
 */
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  /**
   * APPLICATION TITLE
   * Bound to the template for display purposes
   * Follows the HeatPeak Studio naming convention during transition phase
   */
  title = 'com.heatpeakstudio.frontend';
}

/*
 * Angular App Module - Main Application Configuration
 * 
 * This is the root module of the Angular application that bootstraps and configures
 * the entire TTRPG platform frontend. It handles component declarations, service
 * providers, routing configuration, and third-party library integrations.
 * 
 * Key Responsibilities:
 * - Component registration and declarations
 * - HTTP client configuration with interceptors
 * - NgRx state management setup
 * - Routing module integration
 * - Custom directives and pipes registration
 * 
 * Architecture Pattern: Module-based organization with lazy loading support
 * State Management: NgRx for complex state handling
 * HTTP Handling: Angular HTTP client with custom interceptors
 */

import { provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { StoreModule } from '@ngrx/store';
import { NavbarComponent } from './components/general/navbar/navbar.component';
import { HeroComponent } from './components/general/hero/hero.component';
import { HomeComponent } from './components/general/home/home.component';
import { WhatsupComponent } from './components/general/home/whatsup/whatsup.component';
import { ProjectsComponent } from './components/general/home/projects/projects.component';
import { FooterComponent } from './components/general/footer/footer.component';
import { FileFallbackDirective } from './directives/file-fallback.directive';


@NgModule({
  declarations: [
    //Comopnents
    AppComponent,
    NavbarComponent,
    HeroComponent,
    HomeComponent,
    WhatsupComponent,
    ProjectsComponent,
    FooterComponent,
    //Directives
    FileFallbackDirective
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    StoreModule.forRoot({}, {})
  ],
  providers: [provideHttpClient(withInterceptorsFromDi())],
  bootstrap: [AppComponent]
})
export class AppModule { }

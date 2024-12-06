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

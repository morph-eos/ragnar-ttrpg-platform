import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { StoreModule } from '@ngrx/store';
import { NavbarComponent } from './general/navbar/navbar.component';
import { HeroComponent } from './general/hero/hero.component';
import { HomeComponent } from './general/home/home.component';
import { WhatsupComponent } from './general/home/whatsup/whatsup.component';
import { ProjectsComponent } from './general/home/projects/projects.component';
import { FooterComponent } from './general/footer/footer.component';


@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    HeroComponent,
    HomeComponent,
    WhatsupComponent,
    ProjectsComponent,
    FooterComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule,
    StoreModule.forRoot({}, {})
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

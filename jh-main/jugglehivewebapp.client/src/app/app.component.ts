import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { DomainLogic } from './app.domain';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  constructor(private http: HttpClient) {}
  title = 'jugglehivewebapp.client';

  ngOnInit() {
    DomainLogic.applyDomainSpecificStyles();
  }
}
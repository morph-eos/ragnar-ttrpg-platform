import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AzureStorageService {
  private apiBaseUrl = 'https://localhost:7187/api/Azure'; 

  constructor(private http: HttpClient) {}

  getTempFileURI(filePath: string): Observable<string> {
    return this.http.get(`${this.apiBaseUrl}/TempFileURI?fileName=${filePath}`, { responseType: 'text' });
  }
}

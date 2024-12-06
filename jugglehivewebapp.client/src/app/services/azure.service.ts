import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BackendService } from './backend.service';

@Injectable({
  providedIn: 'root'
})
export class AzureService extends BackendService {

  private apiBaseUrl = this.getBackendUrl() + 'api/Azure'; 

  getTempFileURI(filePath: string): Observable<string> {
    return this.http.get(`${this.apiBaseUrl}/TempFileURI?fileName=${filePath}`, { responseType: 'text' });
  }
}

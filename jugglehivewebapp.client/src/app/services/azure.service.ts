/*
 * Azure Service - Cloud Storage Integration
 * 
 * This service handles all Azure cloud storage operations for the Angular frontend.
 * It provides methods to interact with Azure Blob Storage through the backend API,
 * enabling file uploads, downloads, and temporary URL generation for secure access.
 * 
 * Key Features:
 * - Temporary file URI generation for secure access
 * - Azure Blob Storage integration through backend proxy
 * - Extends BackendService for consistent HTTP handling
 * 
 * Usage: Inject this service into components that need cloud storage functionality
 * Security: All Azure operations are proxied through the backend for security
 */

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

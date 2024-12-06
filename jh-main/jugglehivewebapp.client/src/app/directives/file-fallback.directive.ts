import { Directive, ElementRef, HostListener } from '@angular/core';
import { AzureStorageService } from '../services/azure-storage.service';

@Directive({
    selector: 'img, video, iframe, a' // Applied to all <img>, <video>, <iframe>, <a> tags
})
export class FileFallbackDirective {
    constructor(
        private el: ElementRef,
        private azureStorageService: AzureStorageService
    ) {}

    @HostListener('error') onError() {
        // Get the current HTML element
        const element = this.el.nativeElement;

        // Get the value of the src or href attribute depending on the element
        let filePath: string | null = null;

        if (element.hasAttribute('src')) {
            filePath = element.getAttribute('src');
        } else if (element.hasAttribute('href')) {
            filePath = element.getAttribute('href');
        }

        // If there is no valid path, stop
        if (!filePath) {
            console.error('No path found for the element');
            return;
        }

        // Make a request to the backend to get the new URL
        this.azureStorageService.getTempFileURI(filePath).subscribe(
            (newUrl: string) => {
                if (element.tagName === 'IMG' || element.tagName === 'VIDEO' || element.tagName === 'IFRAME') {
                    // Update the element's source with the new URL
                    element.src = newUrl;
                    if (element.tagName === 'VIDEO') {
                        element.load(); // Reload the video
                    }
                } else if (element.tagName === 'A') {
                    // Update the href attribute for the download link
                    element.href = newUrl;
                }
            },
            (error) => {
                console.error('Error retrieving the file from the backend:', error);
            }
        );
    }
}

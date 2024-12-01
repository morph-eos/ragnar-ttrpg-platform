import { enableDebugTools } from "@angular/platform-browser";

export class DomainLogic {

    static readonly subdomains = ['localhost', 'jugglehive'].concat(['ragnar', 'projectsketch']);  // List of valid subdomains
    
    /**
     * Function to apply domain/subdomain specific styles
     */
    static applyDomainSpecificStyles() {
        // Remove the previous stylesheet (if any)
        this.removePreviousStyles();

        const subdomain = this.getCurrentSubdomain();
        
        // Load the appropriate stylesheet
        if (subdomain == 'jugglehive' || subdomain == 'localhost') {
            this.loadStylesheet('style.main.css');
        } else {
            this.loadStylesheet('style.' + subdomain + '.css');
        }
    }

    /**
     * Function to get the current subdomain
     */
    static getCurrentSubdomain(): string {
        let subdomain = window.location.hostname.split('.')[0].toLowerCase();

        for (let i = 1; !this.subdomains.includes(subdomain) && i < window.location.hostname.split('.').length; i++) {
            subdomain = window.location.hostname.split('.')[i].toLowerCase();
        }

        if (this.subdomains.includes(subdomain)) return subdomain;
        else throw new Error('Subdomain not found');
    }

    /**
     * Function to remove the previous stylesheet (if any)
     */
    static removePreviousStyles() {
        const previousStyle = document.getElementById('dynamic-stylesheet');
        if (previousStyle) {
            previousStyle.remove();
        }
    }

    /**
     * Function to load a specific stylesheet
     */
    static loadStylesheet(href: string) {
        const link = document.createElement('link');
        link.id = 'dynamic-stylesheet';
        link.rel = 'stylesheet';
        link.type = 'text/css';
        link.href = href;
        document.head.appendChild(link);
    }
}
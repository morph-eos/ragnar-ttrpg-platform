let backend;

if (window.location.origin.includes('localhost')) {
    backend = 'http://localhost:4000';
} else {
    backend = 'https://heatpeakstudio.com';
}

module.exports = Object.freeze({
    BACKEND: backend
});
<div align="center">
  <img src="https://raw.githubusercontent.com/morph-eos/ragnar-ttrpg-platform/main/icons/ragnar.svg" alt="Ragnar TTRPG" width="100" height="100" />
  <img src="https://raw.githubusercontent.com/morph-eos/ragnar-ttrpg-platform/main/icons/jugglehive.svg" alt="Juggle Hive" width="100" height="100" />
</div>

# Ragnar TTRPG Platform — Cloud Infrastructure

[![License: CC BY-NC-ND 4.0](https://img.shields.io/badge/License-CC%20BY--NC--ND%204.0-lightgrey.svg)](https://creativecommons.org/licenses/by-nc-nd/4.0/)

## Overview

Cloud infrastructure for the Ragnar TTRPG Platform, implemented by **Stefano Sciacovelli**. Provides containerized cloud storage via Nextcloud with Nginx reverse proxy, SSL automation, and external database integration.

## Architecture

| Component | Technology |
|-----------|-----------|
| Cloud Storage | Nextcloud |
| Reverse Proxy | Nginx |
| SSL | Let's Encrypt (Certbot) |
| Container | Docker Compose |
| Database | External MySQL/MariaDB |

Services:

- **Nginx**: SSL termination, HTTP→HTTPS redirect, reverse proxy to Nextcloud
- **Certbot**: 4096-bit RSA certificate generation and auto-renewal
- **Nextcloud**: File storage, user management, WebDAV/CalDAV/CardDAV

## Project Structure

```
├── docker-compose.yml       # Production: Nginx + Certbot + Nextcloud
├── web/
│   └── nginx.conf           # Production Nginx (SSL + reverse proxy)
├── kickstart/
│   ├── docker-compose.yml   # Initial SSL certificate generation
│   └── web/
│       └── nginx.conf       # HTTP-only Nginx for ACME challenges
├── .env.example             # Environment variables template
├── .github/workflows/
│   └── deploy.yml           # Automated deployment trigger
├── LICENSE.md
└── README.md
```

## Getting Started

### Prerequisites

- Docker Engine 20.10+, Docker Compose 2.0+
- Domain with DNS pointing to server
- External MySQL/MariaDB database
- Open ports: 80, 443

### Deployment

```bash
git checkout jh-cloud

# Configure environment
cp .env.example .env && nano .env

# Create data directories
mkdir -p ../data/{nextcloud,certbot}

# Initial SSL certificate (first time only)
docker-compose -f kickstart/docker-compose.yml up certbot
docker-compose -f kickstart/docker-compose.yml down

# Start services
docker-compose up -d
```

### Required Environment Variables

```bash
DOMAIN=your-domain.com
CERTBOT_EMAIL=admin@your-domain.com
MYSQL_HOST=your-database-host
MYSQL_DATABASE=nextcloud
MYSQL_USER=nextcloud_user
MYSQL_PASSWORD=secure_password
NEXTCLOUD_ADMIN_USER=admin
NEXTCLOUD_ADMIN_PASSWORD=secure_admin_password
```

Data persisted in `../data/nextcloud` (app data) and `../data/certbot` (certificates).

## License

[CC BY-NC-ND 4.0](https://creativecommons.org/licenses/by-nc-nd/4.0/) — For commercial inquiries, contact the development team.

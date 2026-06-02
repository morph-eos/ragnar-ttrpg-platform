<div align="center">
  <img src="https://raw.githubusercontent.com/morph-eos/ragnar-ttrpg-platform/main/icons/ragnar.svg" alt="Ragnar TTRPG" width="100" height="100" />
  <img src="https://raw.githubusercontent.com/morph-eos/ragnar-ttrpg-platform/main/icons/jugglehive.svg" alt="Juggle Hive" width="100" height="100" />
</div>

# Ragnar TTRPG Platform — DevOps Infrastructure

[![License: CC BY-NC-ND 4.0](https://img.shields.io/badge/License-CC%20BY--NC--ND%204.0-lightgrey.svg)](https://creativecommons.org/licenses/by-nc-nd/4.0/)

## Overview

CI/CD pipeline and infrastructure management for the Ragnar TTRPG Platform, implemented by **Stefano Sciacovelli**. Features GitHub Actions workflows for automated deployment, Azure VM lifecycle management, and Docker-based containerization with SSL automation.

## Architecture

| Component | Technology |
|-----------|-----------|
| CI/CD | GitHub Actions |
| Container | Docker + Docker Compose |
| Cloud | Azure VM, Azure Storage |
| Web Server | Nginx + Let's Encrypt (Certbot) |
| Provisioning | Bash scripts (Ubuntu 20.04-22.04) |

## Project Structure

```text
├── .github/workflows/
│   ├── deploy.yml       # Deployment orchestration (ACTIVE)
│   ├── startvm.yml      # Azure VM startup (DISABLED)
│   └── stopvm.yml       # VM shutdown + backup (DISABLED)
├── docker/
│   ├── docker-compose.yml       # Production: Nginx + Certbot + App
│   ├── web/nginx.conf           # Production Nginx (SSL + reverse proxy)
│   └── kickstart/
│       ├── docker-compose.yml   # Initial SSL certificate generation
│       └── web/nginx.conf       # HTTP-only Nginx for ACME challenges
├── scripts/
│   └── terraform.sh             # Server provisioning (Docker, Azure CLI, PostgreSQL)
├── LICENSE.md
└── README.md
```

## Workflows

### deploy.yml (Active)

Triggered via repository dispatch (`jugglehive-deploy`). Deploys code from any repository to an Azure VM:

1. Checks out source code from target repository
2. Transfers files to server via SSH
3. Injects environment variables and secrets
4. Handles SSL certificate initialization (kickstart on first deploy)
5. Starts services with Docker Compose

### startvm.yml / stopvm.yml (Disabled)

VM lifecycle management with Azure CLI. The stop workflow includes automated Nextcloud backup (database dump + file compression) with 7-day retention and Azure Storage offsite transfer.

## Getting Started

### Server Provisioning

```bash
# On a fresh Ubuntu 20.04-22.04 server
export AZURE_STORAGE_ACCOUNT_NAME="your-account"
export AZURE_STORAGE_ACCOUNT_KEY="your-key"
chmod +x scripts/terraform.sh && sudo ./scripts/terraform.sh
```

Installs: Docker + Compose, Azure CLI, PostgreSQL 16 client, Azure File Storage mount.

### Triggering Deployment

```json
{
  "event_type": "jugglehive-deploy",
  "client_payload": {
    "service": "target-repository-name",
    "server": "target-server-hostname"
  }
}
```

### Required GitHub Secrets

- **Server**: `SERVER_USERNAME`, `SERVER_KEY`
- **Azure**: `AZURE_CREDENTIALS`, `AZURE_RESOURCE_GROUP_NAME`, `AZURE_STORAGE_ACCOUNT_NAME`, `AZURE_STORAGE_ACCOUNT_KEY`
- **App**: `DOMAIN`, `CERTBOT_EMAIL`, database credentials, Nextcloud credentials
- **GitHub**: `GITHUB_TOKEN`, `CONTENTS_PAT`

## License

[CC BY-NC-ND 4.0](https://creativecommons.org/licenses/by-nc-nd/4.0/) — For commercial inquiries, contact the development team.

---

<sub>Part of the **[Ragnar TTRPG Platform](../README.md)** monorepo — see the root README for the full evolution across all phases.</sub>

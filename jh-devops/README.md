<div align="center">
  <img src="https://raw.githubusercontent.com/morph-eos/ragnar-ttrpg-platform/60918ec9b8f650089ba7a31dda8c19b47719a516/icons/ragnar.svg" alt="Ragnar TTRPG" width="100" height="100" />
  <img src="https://raw.githubusercontent.com/morph-eos/ragnar-ttrpg-platform/60918ec9b8f650089ba7a31dda8c19b47719a516/icons/jugglehive.svg" alt="Juggle Hive" width="100" height="100" />
</div>

# Ragnar TTRPG Platform - DevOps Infrastructure

## Table of Contents

- [Branch Overview: jh-devops](#branch-overview-jh-devops)
- [DevOps Architecture Overview](#devops-architecture-overview)
- [Project Structure](#project-structure)
- [Workflow Architecture](#workflow-architecture)
  - [Workflow Status Overview](#workflow-status-overview)
  - [1. Deployment Workflow (`deploy.yml`)](#1-deployment-workflow-deployyml)
  - [2. VM Start Workflow (`startvm.yml`)](#2-vm-start-workflow-startvmyml)
  - [3. VM Stop & Backup Workflow (`stopvm.yml`)](#3-vm-stop--backup-workflow-stopvmyml)
- [Docker Infrastructure](#docker-infrastructure)
  - [Docker Configuration Architecture](#docker-configuration-architecture)
- [Infrastructure Setup Scripts](#infrastructure-setup-scripts)
  - [Server Provisioning Script (`scripts/terraform.sh`)](#server-provisioning-script-scriptsterraformsh)
- [Configuration Details](#configuration-details)
  - [Repository Dispatch Integration](#repository-dispatch-integration)
  - [Azure Integration](#azure-integration)
  - [Security Configuration](#security-configuration)
- [Advanced Features](#advanced-features)
  - [Multi-Repository Orchestration](#multi-repository-orchestration)
  - [Intelligent Deployment Logic](#intelligent-deployment-logic)
  - [Backup and Recovery](#backup-and-recovery)
- [Usage Instructions](#usage-instructions)
- [Monitoring and Security](#monitoring-and-security)
- [License](#license)

## Branch Overview: jh-devops

This branch contains the **DevOps infrastructure** and CI/CD pipeline configuration for the Ragnar TTRPG Platform, originally developed to support the deployment and operations of an innovative digital tabletop role-playing game solution. The infrastructure was designed to handle the scalable deployment requirements of what was intended to be a commercial platform serving hybrid online/offline gaming experiences.

**Project Evolution**: This DevOps infrastructure was built to support the original vision of creating a market-competitive TTRPG platform. When the project scope proved challenging to complete within available resources, the comprehensive automation and deployment systems were preserved as a demonstration of enterprise-level DevOps practices and cloud infrastructure management.

**DevOps Implementation**: This infrastructure was designed and implemented solely by **Stefano Sciacovelli** ([GitHub Profile](https://github.com/M04ph3u2)) as part of the platform's deployment automation requirements, showcasing advanced CI/CD pipeline orchestration and Azure cloud management capabilities.

## DevOps Architecture Overview

The DevOps infrastructure follows a **distributed microservices orchestration pattern** with the following components:

- **GitHub Actions Workflows**: Automated deployment, VM management, and backup orchestration
- **Multi-Repository Integration**: Cross-repository deployment triggers via repository dispatch
- **Azure Cloud Integration**: VM lifecycle management and resource orchestration
- **Automated Backup System**: Database and file system backup with retention policies
- **Environment Management**: Secure secrets management and environment configuration

## Project Structure

``` sh
jh-devops/
├── .github/
│   └── workflows/
│       ├── deploy.yml          # Main deployment orchestration workflow
│       ├── startvm.yml         # Azure VM startup automation
│       └── stopvm.yml          # VM shutdown and backup workflow
├── docker/                     # Docker configuration templates and SSL setup
│   ├── docker-compose.yml      # Production Docker Compose configuration
│   ├── kickstart/              # Initial SSL certificate generation setup
│   │   ├── docker-compose.yml  # Kickstart Docker Compose for certificate generation
│   │   └── web/
│   │       └── nginx.conf      # Nginx configuration for certificate kickstart
│   └── web/
│       └── nginx.conf          # Production Nginx configuration with SSL
├── scripts/                    # Deployment and maintenance scripts
│   └── terraform.sh            # Infrastructure setup and server provisioning script
└── README.md                   # This documentation file
```

## Workflow Architecture

### Workflow Status Overview

- **deploy.yml** - **ACTIVE**: Ready for deployment operations
- **startvm.yml** - **DISABLED**: VM startup automation disabled  
- **stopvm.yml** - **DISABLED**: Scheduled backup and shutdown disabled

### 1. Deployment Workflow (`deploy.yml`)

**Trigger**: Repository dispatch event `jugglehive-deploy` - **Active**
**Purpose**: Multi-repository deployment orchestration

#### Workflow Steps

1. **Code Acquisition**:
   - Checks out source code from target repository
   - Preserves original codebase structure
   - Merges with deployment configuration

2. **Environment Preparation**:
   - Connects to target Azure VM via SSH
   - Cleans existing deployment artifacts
   - Prepares directory structure

3. **File Transfer & Organization**:
   - Transfers complete repository to server
   - Reorganizes files for deployment structure
   - Handles cloud and docker configurations

4. **Environment Configuration**:
   - Injects secrets as environment variables
   - Configures domain-specific settings
   - Updates nginx configurations dynamically

5. **Service Deployment**:
   - Stops existing services gracefully
   - Handles SSL certificate initialization
   - Starts new services with updated configuration

#### Supported Environment Variables

- Database configuration (MySQL/PostgreSQL)
- Azure Storage integration
- SSL certificate management
- Domain and email configuration
- Nextcloud administration settings

### 2. VM Start Workflow (`startvm.yml`)

**Trigger**: Repository dispatch event `jugglehive-disabled` - **Currently disabled**
**Purpose**: Automated Azure VM startup

#### Features

- **Azure CLI Integration**: Uses Azure CLI 2.30.0 for VM operations
- **Multi-VM Support**: Starts both `jugglehive-cloud` and `jugglehive-webapp` VMs
- **Credential Management**: Secure Azure credential handling
- **Scheduled Execution**: Supports cron-based scheduling (currently commented)

### 3. VM Stop & Backup Workflow (`stopvm.yml`)

**Trigger**: Scheduled execution (21:30 UTC daily) - **Currently disabled**
**Purpose**: Automated backup and VM shutdown

#### Backup Operations

1. **Nextcloud Backup**:
   - Places Nextcloud in maintenance mode
   - Creates compressed backup of data directory
   - Performs MySQL database dump
   - Schedules backup transfer to Azure Storage

2. **Retention Management**:
   - Automatically removes backups older than 7-8 days
   - Maintains rolling backup window
   - Optimizes storage usage

3. **Service Management**:
   - Graceful service shutdown
   - Resource cleanup
   - Scheduled backup transfer via cron

#### Backup Strategy Features

- **Database Consistency**: Ensures data integrity during backup
- **File System Snapshots**: Complete Nextcloud data preservation
- **Automated Retention**: Self-managing backup lifecycle
- **Azure Storage Integration**: Offsite backup storage

## Docker Infrastructure

### Docker Configuration Architecture

The `docker/` directory contains a comprehensive containerization setup with SSL certificate management:

#### Production Configuration (`docker/docker-compose.yml`)

**Services Overview:**

- **Nginx Container**: SSL termination, reverse proxy, and HTTP redirection
- **Certbot Container**: Automated Let's Encrypt certificate generation and renewal
- **Application Container**: Main web application with database and storage integration

**Key Features:**

- **SSL Security**: 4096-bit RSA certificates with automatic renewal
- **High Availability**: Always-restart policy for production resilience
- **Environment Integration**: PostgreSQL and Azure Storage configuration
- **Domain Flexibility**: Dynamic domain configuration via environment variables

#### Kickstart Configuration (`docker/kickstart/`)

**Purpose**: Initial SSL certificate generation for new deployments

**Components:**

- **Minimal Nginx**: HTTP-only configuration for ACME challenges
- **Certificate Generation**: One-time SSL certificate creation
- **Domain Validation**: Let's Encrypt HTTP-01 challenge support

**Usage Flow:**

1. Deploy kickstart configuration
2. Generate initial SSL certificates
3. Switch to production configuration
4. Enable automatic certificate renewal

#### Nginx Configuration Details

**Production Nginx (`docker/web/nginx.conf`):**

- **HTTP Block**: Handles ACME challenges and forces HTTPS redirect
- **HTTPS Block**: SSL termination and application proxy
- **Security Headers**: Server token hiding and security optimization
- **Certificate Integration**: Dynamic certificate path resolution

**Kickstart Nginx (`docker/kickstart/web/nginx.conf`):**

- **HTTP-Only**: Minimal configuration for certificate generation
- **ACME Support**: Dedicated challenge handling endpoint
- **Domain Validation**: Proves ownership for certificate issuance

## Infrastructure Setup Scripts

### Server Provisioning Script (`scripts/terraform.sh`)

**Purpose**: Installs every needed dependency for the Ragnar TTRPG Platform on a fresh Ubuntu 20.04-22.04 LTS installation.

#### Components Installed

**System Environment:**

- **Environment File**: Creates `/etc/environment` for persistent variables
- **Utility Tools**: zip and unzip for backup operations and file handling

**Docker Infrastructure:**

- **Docker Engine**: Latest Docker CE with CLI and Compose plugin
- **Repository Setup**: Official Docker repository with GPG verification
- **Clean Installation**: Removes conflicting packages before installation

**Azure Integration:**

- **Azure CLI**: Microsoft's official Azure CLI for cloud resource management
- **File Storage**: CIFS utilities for Azure File Storage mounting
- **Persistent Mounting**: Automatic mounting via `/etc/fstab` configuration

**Database Clients:**

- **MySQL Client**: Core MySQL client tools for database operations
- **PostgreSQL**: Full PostgreSQL 16 installation with client tools

#### Usage Instructions

**Prerequisites:**

- Fresh Ubuntu 20.04-22.04 LTS server
- Root or sudo access
- Internet connectivity
- Azure Storage account credentials (environment variables)

**Required Environment Variables:**

```bash
export AZURE_STORAGE_ACCOUNT_NAME="your-storage-account"
export AZURE_STORAGE_ACCOUNT_KEY="your-storage-key"
```

**Execution:**

```bash
# Make script executable
chmod +x scripts/terraform.sh

# Run the installation script
sudo ./scripts/terraform.sh
```

**Post-Installation:**

- Docker and Docker Compose ready for deployment
- Azure File Storage mounted at `/root/azurestorage`
- Database clients ready for backup operations
- System ready for containerized application deployment

## Configuration Details

### Repository Dispatch Integration

The deployment system uses GitHub's repository dispatch API to trigger deployments across multiple repositories:

```json
{
  "event_type": "jugglehive-deploy",
  "client_payload": {
    "service": "target-repository-name",
    "server": "target-server-hostname"
  }
}
```

### Azure Integration

#### VM Management

- **Resource Group**: Configurable via secrets
- **VM Names**: `jugglehive-cloud`, `jugglehive-webapp`
- **Operations**: Start, stop, deallocate
- **Authentication**: Service Principal via JSON credentials

#### Azure Storage

- **Backup Storage**: Integrated with Azure File Share
- **Account Management**: Configurable storage account and keys
- **Retention Policies**: Automated cleanup of old backups

### Security Configuration

#### Secrets Management

The system requires the following GitHub repository secrets:

##### Server Access

- `SERVER_USERNAME`: SSH username for deployment server
- `SERVER_KEY`: SSH private key for server authentication

##### Azure Credentials

- `AZURE_CREDENTIALS`: Service principal JSON for Azure CLI
- `AZURE_RESOURCE_GROUP_NAME`: Azure resource group name
- `AZURE_STORAGE_ACCOUNT_NAME`: Storage account name
- `AZURE_STORAGE_ACCOUNT_KEY`: Storage account access key

##### Application Configuration

- `DOMAIN`: Primary domain name
- `CERTBOT_EMAIL`: Let's Encrypt registration email
- `MYSQL_HOST`, `MYSQL_DATABASE`, `MYSQL_USER`, `MYSQL_PASSWORD`: Database configuration
- `POSTGRES_HOST`, `POSTGRES_DATABASE`, `POSTGRES_USER`, `POSTGRES_PASSWORD`: PostgreSQL configuration
- `NEXTCLOUD_ADMIN_USER`, `NEXTCLOUD_ADMIN_PASSWORD`: Nextcloud admin credentials

##### GitHub Integration

- `GITHUB_TOKEN`: GitHub personal access token for container registry
- `CONTENTS_PAT`: Personal access token with repository contents permissions

## Advanced Features

### Multi-Repository Orchestration

The DevOps system can deploy code from any repository in the organization:

1. **Dynamic Code Acquisition**: Fetches code from specified repository
2. **Configuration Overlay**: Applies deployment-specific configuration
3. **Service Integration**: Handles multiple service types (web apps, cloud services)

### Intelligent Deployment Logic

#### SSL Certificate Management

- **First-Time Setup**: Automatically runs kickstart process for initial certificates
- **Renewal Handling**: Manages ongoing certificate renewal
- **Domain Configuration**: Dynamic domain substitution in configurations

#### Container Management

- **Graceful Shutdown**: Properly stops existing containers
- **Resource Cleanup**: Removes unused containers, networks, and images
- **Registry Authentication**: Handles GitHub Container Registry authentication

### Backup and Recovery

#### Backup Features

- **Application-Aware**: Nextcloud maintenance mode during backup
- **Database Consistency**: Proper mysqldump with transaction consistency
- **Compression**: Efficient ZIP compression for file backups
- **Scheduling**: Cron-based backup transfer scheduling

#### Recovery Preparation

- **Structured Naming**: Date-based backup naming convention
- **Offsite Storage**: Azure Storage integration for disaster recovery
- **Retention Policies**: Automated cleanup prevents storage overflow

## Usage Instructions

### Triggering Deployments

Deployments are triggered via GitHub repository dispatch with the `jugglehive-deploy` event type. The system supports multiple services and server targets through payload configuration.

### Manual VM Management

VMs can be started and stopped using repository dispatch events for cost optimization and maintenance scheduling. Monitor deployments through GitHub Actions interface.

## Monitoring and Security

### Deployment Monitoring

Key metrics include deployment duration, success rates, and resource utilization. Logs are accessible through GitHub Actions interface and SSH server access.

### Security Features

- **Access Control**: Principle of least privilege with secure key management
- **Operational Security**: Audit logging, secret rotation, and encrypted backups
- **Compliance**: Automated retention policies and complete audit trails

### Integration Ecosystem

Integrates with GitHub Container Registry, Azure Cloud Services, Docker Compose, Let's Encrypt, and database management systems.

## License

This project is licensed under the Attribution-NonCommercial-NoDerivatives 4.0 International License. See the [LICENSE.md](LICENSE.md) file for details.

---

*This branch represents the DevOps infrastructure component of the Ragnar TTRPG Platform, implemented by Stefano Sciacovelli as part of the development team, demonstrating enterprise-level CI/CD practices, multi-cloud integration, and automated operations management.*

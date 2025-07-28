#!/bin/bash

# ===============================================================================
# RAGNAR TTRPG PLATFORM - INFRASTRUCTURE SETUP SCRIPT (terraform.sh)
# ===============================================================================
# 
# This script installs every needed dependency for the Ragnar TTRPG Platform.
# It's meant to be run on a fresh Ubuntu 20.04-22.04 LTS installation.
# 
# Purpose: Automates the installation of Docker, Azure CLI, database clients,
#          and Azure File Storage mounting for the TTRPG platform infrastructure.
# 
# Author: Stefano Sciacovelli (https://github.com/M04ph3u2)
# DevOps Infrastructure Implementation
# ===============================================================================

# ===============================================================================
# SYSTEM ENVIRONMENT SETUP
# ===============================================================================
# Create environment file for storing persistent environment variables
# This file is sourced during login and maintains configuration across reboots
sudo touch /etc/environment

# ===============================================================================
# UTILITY INSTALLATION
# ===============================================================================
# Install zip and unzip utilities for backup compression and file handling
# These are required for backup operations and archive management
sudo apt install zip -y
sudo apt install unzip -y

# ===============================================================================
# DOCKER INSTALLATION
# ===============================================================================
# Remove any existing Docker packages to prevent conflicts during installation
# This ensures a clean installation from the official Docker repository
for pkg in docker.io docker-doc docker-compose docker-compose-v2 podman-docker containerd runc; do sudo apt-get remove $pkg; done

# Update package index and install Docker prerequisites
sudo apt-get update
sudo apt-get install ca-certificates curl

# Set up Docker's official GPG key for package verification
sudo install -m 0755 -d /etc/apt/keyrings
sudo curl -fsSL https://download.docker.com/linux/ubuntu/gpg -o /etc/apt/keyrings/docker.asc
sudo chmod a+r /etc/apt/keyrings/docker.asc

# Add Docker's official repository to APT sources
# This ensures we get the latest Docker version with security updates
echo \
  "deb [arch=$(dpkg --print-architecture) signed-by=/etc/apt/keyrings/docker.asc] https://download.docker.com/linux/ubuntu \
  $(. /etc/os-release && echo "$VERSION_CODENAME") stable" | \
  sudo tee /etc/apt/sources.list.d/docker.list > /dev/null

# Update package index with Docker repository and install Docker Engine
sudo apt-get update
sudo apt-get install docker-ce docker-ce-cli containerd.io docker-buildx-plugin docker-compose-plugin

# ===============================================================================
# AZURE CLI INSTALLATION
# ===============================================================================
# Install Azure CLI using Microsoft's official installation script
# This provides full Azure cloud resource management capabilities
curl -sL https://aka.ms/InstallAzureCLIDeb | sudo bash

# ===============================================================================
# DATABASE CLIENT INSTALLATION
# ===============================================================================
# Install MySQL client for database backup and management operations
# Required for connecting to external MySQL databases and performing backups
sudo apt install -y mysql-client-core-8.0

# Install PostgreSQL client and tools for database operations
# This includes psql command-line tool and pg_dump for database backups
sudo apt install curl ca-certificates
sudo install -d /usr/share/postgresql-common/pgdg
sudo curl -o /usr/share/postgresql-common/pgdg/apt.postgresql.org.asc --fail https://www.postgresql.org/media/keys/ACCC4CF8.asc
sudo sh -c 'echo "deb [signed-by=/usr/share/postgresql-common/pgdg/apt.postgresql.org.asc] https://apt.postgresql.org/pub/repos/apt $(lsb_release -cs)-pgdg main" > /etc/apt/sources.list.d/pgdg.list'
sudo apt update
sudo apt -y install postgresql-16

# ===============================================================================
# AZURE FILE STORAGE MOUNTING
# ===============================================================================
# Install CIFS utilities for mounting Azure File Storage
# This enables persistent file storage and backup capabilities
sudo apt install cifs-util

# Create mount point for Azure File Storage
# Directory will be used for backup storage and shared file access
mkdir /root/azurestorage > /dev/null 2>&1

# Configure persistent mounting of Azure File Storage in /etc/fstab
# This ensures the storage is automatically mounted on system boot
# Uses environment variables for Azure Storage account credentials
sudo bash -c 'echo "//$AZURE_STORAGE_ACCOUNT_NAME.file.core.windows.net/general /root/azurestorage cifs nofail,username=$AZURE_STORAGE_ACCOUNT_NAME,password=$AZURE_STORAGE_ACCOUNT_KEY,dir_mode=0755,file_mode=0755,serverino,nosharesock,actimeo=30" >> /etc/fstab'

# Mount Azure File Storage immediately
# This connects to the Azure Storage account using the provided credentials
sudo mount -t cifs //$AZURE_STORAGE_ACCOUNT_NAME.file.core.windows.net/general /root/azurestorage -o username=$AZURE_STORAGE_ACCOUNT_NAME,password="$AZURE_STORAGE_ACCOUNT_KEY",dir_mode=0755,file_mode=0755,serverino,nosharesock,actimeo=30
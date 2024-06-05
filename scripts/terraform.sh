#Installs every needed dependency
#This script is meant to be run on a fresh Ubuntu 20.04-22.04 LTS installation

#Create environment file
sudo touch /etc/environment

#Install zip and unzip
sudo apt install zip -y
sudo apt install unzip -y

#Install Docker
for pkg in docker.io docker-doc docker-compose docker-compose-v2 podman-docker containerd runc; do sudo apt-get remove $pkg; done
sudo apt-get update
sudo apt-get install ca-certificates curl
sudo install -m 0755 -d /etc/apt/keyrings
sudo curl -fsSL https://download.docker.com/linux/ubuntu/gpg -o /etc/apt/keyrings/docker.asc
sudo chmod a+r /etc/apt/keyrings/docker.asc
echo \
  "deb [arch=$(dpkg --print-architecture) signed-by=/etc/apt/keyrings/docker.asc] https://download.docker.com/linux/ubuntu \
  $(. /etc/os-release && echo "$VERSION_CODENAME") stable" | \
  sudo tee /etc/apt/sources.list.d/docker.list > /dev/null
sudo apt-get update
sudo apt-get install docker-ce docker-ce-cli containerd.io docker-buildx-plugin docker-compose-plugin

#Install AZ CLI
curl -sL https://aka.ms/InstallAzureCLIDeb | sudo bash

#Install mysql-client
sudo apt install -y mysql-client-core-8.0

#Install postgresql
sudo apt install curl ca-certificates
sudo install -d /usr/share/postgresql-common/pgdg
sudo curl -o /usr/share/postgresql-common/pgdg/apt.postgresql.org.asc --fail https://www.postgresql.org/media/keys/ACCC4CF8.asc
sudo sh -c 'echo "deb [signed-by=/usr/share/postgresql-common/pgdg/apt.postgresql.org.asc] https://apt.postgresql.org/pub/repos/apt $(lsb_release -cs)-pgdg main" > /etc/apt/sources.list.d/pgdg.list'
sudo apt update
sudo apt -y install postgresql-16

#Mount Azure File Storage
sudo apt install cifs-util
mkdir /root/azurestorage > /dev/null 2>&1
sudo bash -c 'echo "//$AZURE_STORAGE_ACCOUNT_NAME.file.core.windows.net/general /root/azurestorage cifs nofail,username=$AZURE_STORAGE_ACCOUNT_NAME,password=$AZURE_STORAGE_ACCOUNT_KEY,dir_mode=0755,file_mode=0755,serverino,nosharesock,actimeo=30" >> /etc/fstab'
sudo mount -t cifs //$AZURE_STORAGE_ACCOUNT_NAME.file.core.windows.net/general /root/azurestorage -o username=$AZURE_STORAGE_ACCOUNT_NAME,password="$AZURE_STORAGE_ACCOUNT_KEY",dir_mode=0755,file_mode=0755,serverino,nosharesock,actimeo=30
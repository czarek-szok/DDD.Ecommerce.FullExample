# This is the example how we build the container, which is used to run the Azure Devops
# pipeline, in which we can restore, build and test dotnet core application,
# run SonarQube scans and do docker build and docker push
# Base file for, which contains requried .net core SDK version
# Recommend to point to immutable SEMVER SDK version, not generic aka 2.1 or 3.1 or 5.0
# This image uses sdk:3.1.404 and puts openjdk on top of it
# (openjdk is required for sonarqube to run)
FROM docker-images.artifactory.danskenet.net/db/dotnet/core/sdk:5.0.200

# Version of the Sonar binaries
ENV SONAR_SCANNER_MSBUILD_VERSION 5.0.4.24009

# Specifying where node.js will find the certs. Required for Azure DevOps extensions
ENV NODE_EXTRA_CA_CERTS=/etc/ssl/certs/ca-certificates.crt

RUN apt-get update && apt-get dist-upgrade -y
RUN apt-get install -y unzip

# Install Java runtime, to be able to run SonarQube scans inside of the container
RUN mkdir /usr/share/man/man1/
RUN apt-get install -y openjdk-11-jre

# Install docker to be able to build the docker images form this container
RUN apt-get install docker.io -y

# Adding node.js, as it is requirement for Azure DevOps containers
# Official requirements: https://docs.microsoft.com/en-us/azure/devops/pipelines/process/container-phases?view=azure-devops
# To be able to run some of the Azure DevOps extensions
RUN apt-get install nodejs -y

# Install Sonar Scanner

RUN apt-get install -y unzip \
    && wget http://artifactory.danskenet.net/artifactory/db-docker-devexp/sonar-scanner/sonar-scanner-msbuild-$SONAR_SCANNER_MSBUILD_VERSION-net5.0.zip \
    && unzip sonar-scanner-msbuild-$SONAR_SCANNER_MSBUILD_VERSION-net5.0.zip -d /sonar-scanner \
    && rm sonar-scanner-msbuild-$SONAR_SCANNER_MSBUILD_VERSION-net5.0.zip \
    && chmod +x -R /sonar-scanner

# Cleanup
RUN apt-get -q autoremove \
    && apt-get -q clean -y \
    && rm -rf /var/lib/apt/lists/* /var/cache/apt/*.bin
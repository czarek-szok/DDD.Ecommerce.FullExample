####################
# GLOBAL ARGUMENTS #
####################

ARG StartupProjectName=DDD.Ecommerce.Api

#################
# RUNTIME IMAGE #
#################

FROM docker-images.artifactory.danskenet.net/db/dotnet/core/aspnet:5.0.0 AS runtime

ARG StartupProjectName
ARG PublishPath

ENV DOTNET_ASSEMBLY_NAME=${StartupProjectName} \
    ASPNETCORE_URLS=http://*:8080

WORKDIR /app

COPY ${PublishPath} .

RUN adduser --disabled-password chuser
RUN chown chuser:chuser /app /app/*
USER chuser

EXPOSE 8080

ENTRYPOINT exec dotnet ${DOTNET_ASSEMBLY_NAME}.dll
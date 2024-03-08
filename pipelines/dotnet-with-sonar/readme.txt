The Dockerfile contains definition of docker image that will be used to create container for running the CI pipeline.
It contains .NET 5 and sonarquebe.
If there is a need to create new image with newer version here are steps to build and push the image to artifactory:
1. docker build -t db-docker-wjcc-all.artifactory.danskenet.net/build-images/dotnet-with-sonar:5.0.200 .
2. docker login db-docker-wjcc-all.artifactory.danskenet.net
docker push db-docker-wjcc-all.artifactory.danskenet.net/build-images/dotnet-with-sonar:5.0.200
3. docker push db-docker-wjcc-all.artifactory.danskenet.net/build-images/dotnet-with-sonar:5.0.200
# How to launch

docker-compose up -d

## Auth settings

Client ID=test_online_shop
Client Secret=EYBfEbKXBvBtiDoIBLlqSfRYD8PJm98K

## Launch Sonar

docker run --rm -p 9000:9000 -v sonarqube_extensions:/opt/sonarqube/extensions sonarqube


## Build docker

docker build ./ -f ./Cart.Api/Dockerfile

## Run docker-compose

docker-compose up -d --build

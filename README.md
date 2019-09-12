# MovieRecommendationAPI
A simple ML Model created using ML.net and hosted as dot net core web API
Supported Hosting Infrastructure
1. Stand alone web app
2. Containerized(docker) web app
3. AKS

Request Url: https://{HostUrl}/api/recommendation/execute

Request Payload:
{
	"movieSelection": "6:10"
}

Building a docker image

From root folder -> change directory to MovieRecomendationApp [cd MovieRecomendationApp/]

docker build --tag {reposirotyname}/{imagename}:v1.0.0 .

Run the docker image

docker run -p 8080:80 -it {reposirotyname}/{imagename}:v1.0.0

test localy browse http://localhost:8080/api/recommendation/

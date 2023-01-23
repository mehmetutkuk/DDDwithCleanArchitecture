# Euronext.CompanyWebcast

The solution is developed with Domain Driven Design and Clean Architectures prensibles. I used external common library such as ErrorOr, MediatR, Moq etc. purpose of the covering some requirements of the project has. 

To run this application executing the `docker-compose up -d` command will be enough.
You can find executable endpoints in under the Request folder.

HTTP POST
`curl -X 'POST' \
  'http://localhost:8081/api/Forecasts?weathermanId=erear' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "forecastDateTime": "2023-01-27T18:16:00.615Z",
  "celsius": 59.1
}'`


HTTP GET

`http://localhost:8081/api/Forecasts`

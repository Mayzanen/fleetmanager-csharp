# fleetmanager-csharp
Fleet Manager C#

Varmuuskopio tietokannasta löytyy seed_data kansiosta FleetManager.zip:stä.

Startup.cs rivillä 27 on määritelty kannan connection info.

Swagger löytyy polusta: /swagger, Visual Studiosta ajaessa esim. http://localhost:56062/swagger/

Testauksen Postman kutsut:
GET http://localhost:56062/api/car
Palauttaa tietokannan kaikki autot

POST http://localhost:56062/api/car
Body: Esim.
{
	"Make": "Testi auto",
	"Model": "Siisti malli",
	"Registration": "ABC-42",
	"Year": 2018,
	"InspectionDate": "2018-03-12 00:00:00",
	"EngineSize": 42,
	"EnginePower": 166
}
Palauttaa luodun auton id:n kera.

GET http://localhost:56062/api/car/{id}
Palauttaa auton annetulla id:llä

PUT http://localhost:56062/api/car/{id}
Body: Esim.
{
	"Make": "Testi auto",
	"Model": "Siisti malli",
	"Registration": "ABC-42",
	"Year": 2018,
	"InspectionDate": "2018-03-15 00:00:00",
	"EngineSize": 142,
	"EnginePower": 200,
	"Id": 10005
}
Palauttaa päivitetyn auton.

DELETE http://localhost:56062/api/car/{id}
Palauttaa 200 OK Id löytyessä.

POST http://localhost:56062/api/car/filteredCars
Body: Esim.
{
	"MinYear": 2000,
	"MaxYear": 2010,
	"Model": "model2",
	"Make": "make1"
}
Palauttaa filteröidyt autot. Toimii myös osittaisilla filtteriarvoilla esim.
Body:
{
	"Model": "model2",
	"Make": "make1"
}
Tai
{
	"MinYear": 2000,
	"MaxYear": 2010
}

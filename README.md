# MyAirport
# Author
* Manuela CALVO & Sophie PAGES


# MyAirportAPI url :
* Swagger : https://localhost:44377/index.html
* Bagages : https://localhost:44377/api/Bagages  ou +/ID
* Vols : https://localhost:44377/api/Vols
* Vols + bagage : https://localhost:44377/api/Vols/ID?displayBagages=true

# MyAirportGraphQL :
* GraphIQL : https://localhost:44351/graphiql
 Exemple de commandes : 
	```
	{bagages{bagageId,codeIata}}
	```
	```
	{vols{volId,lig, des}}
	```
	
* Sans GraphIQL : 
* Bagages: https://localhost:44351/graphql?Query={bagages{bagageId}}
* Vols: https://localhost:44351/graphql?Query={vols{volId}}

# MyAirportRazort :
* Bagages: https://localhost:44377/Bagages
* Vols: https://localhost:44377/Vols

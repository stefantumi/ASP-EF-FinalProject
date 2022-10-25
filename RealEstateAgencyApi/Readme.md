# Real Estate Agency API

# ATH 

## Passa að nota branch simplify
## Passa að nota réttan connection streng í [AgencyContext.cs]

# docker

ef þú notar docker þá notaði ég þessa skipun til að búa til container fyrir mssql
`sudo docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=StefanTumi.7" \
-p 1433:1433 --name Agencies --hostname Agencies \
-d mcr.microsoft.com/mssql/server:2019-latest`


Api for handling database requests for Real Estates

## Unsuccessful goals
Data Transfer Objects - unable to implement due to lack of personal time available on frontend.
Which basically makes the client an Admin tool for the service.

Identity Managment - Initial intentions were to provide user authentication and authorization with ASP 



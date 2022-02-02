##Copiar ficheros de la base de datos
$source = "DB"
$destino = "src"


Copy-Item -Path $source -Filter "*.sql" -Recurse -Destination $destino -Container -force

##Borrar la imagen vieja
docker rm $(docker stop $(docker ps -a -q --filter ancestor='server-sql' --format="{{.ID}}"))


##NETWORK 2 Containers
docker network create BackEndAPI

##construir la imagen
docker build -t server-sql src.

##iniciar el contenedor ##Terminos y Password
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Passw0rd" -d -p 1433:1433 --net APINET -v C:\Users\a842225\source\repos\GitJoshua\WebBackEndRepo\DB\data:/var/opt/mssql/data -v C:\Users\a842225\source\repos\GitJoshua\WebBackEndRepo\DB\log:/var/opt/mssql/log -v C:\Users\a842225\source\repos\GitJoshua\WebBackEndRepo\DB\secrets:/var/opt/mssql/secrets server-sql 



##Borrar la imagen vieja
docker rm $(docker stop $(docker ps -a -q --filter ancestor='mcr.microsoft.com/mssql/server:2019-latest' --format="{{.ID}}"))

##Dockerizar API
docker build -t mcr.microsoft.com/mssql/server:2019-latest -f DockerfileCode .

##Iniciar contenedor API
docker run -d -p 5000:5000 -p 5001:5001 -p 8000:80 --net BackEndAPI mcr.microsoft.com/mssql/server:2019-latest



#DOCKER COMPOSE
##docker-compose up -d
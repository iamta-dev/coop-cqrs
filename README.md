# coop-cqrs
coop rvp test

# start container docker
```
$ docker-compose build
$ docker-compose up -d

## start pizza-proxy
$ cd PizzaProxy
$ dotnet build
$ dotnet run
```

# loging , cmd container docker
```
$ docker logs --follow <container name>
$ docker exec -it <container name> /bin/bash
```

# test api
## cmd
```
$ curl http://localhost:8000/api/Pizza
```

## postman
import : [coop-cqrs.postman_collection.json](./coop-cqrs.postman_collection.json)

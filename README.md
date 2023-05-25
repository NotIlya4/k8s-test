# K8S Test
This is a `Kubernetes` test project where i deploy `ASP.NET` service that communicate with sql server and seq. Service speaks with sql server and seq via `ClusterIP`. Service, sql server and seq exposed via `LoadBalancer`. This time instead of entity framework i used `Dapper`.

## Deploy
To deploy an app do following steps:
1. Run `cd k8s`
2. Run `kubectl apply --recursive -f .`

App deployed and now you can navigate:
- `http://localhost:5000/swagger/index.html` Service swagger docs.
- `http://localhost:1433` Sql server database.
- `http://localhost:5341` Seq logging.


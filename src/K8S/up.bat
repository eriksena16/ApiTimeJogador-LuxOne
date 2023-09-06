@echo off
@echo kubectl apply -f .\redis-deployment.yaml
kubectl apply -f .\webapi-deployment.yaml
kubectl apply -f .\webapi-service.yaml
@echo kubectl apply -f .\webapi-loadbalancer.yaml
@echo off
kubectl delete service webapi-lb
kubectl delete service webapi
kubectl delete deployment webapi
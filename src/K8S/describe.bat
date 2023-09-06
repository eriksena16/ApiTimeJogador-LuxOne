@echo off
kubectl get pods -o wide
kubectl get deployment -o wide
kubectl get services -o wide
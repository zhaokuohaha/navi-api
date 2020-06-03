#!/bin/bash

mode=$1

buildapi(){
    echo "buildapi"
    docker build -t ./api/Dckerfile navi_api  ./api
    docker run -d  -p 5002:5002 --rm  --name navi_api  navi_api
}

buildweb(){
    echo "buildweb"
    docker build -t -f ./web/Dckerfile navi ./web
    docker run -d -it -p 5003:5003 --rm --name navi navi
}

#  api
if [ $mode = "api" ]
then
    buildapi
elif [ $mode = "web" ]
then
    buildweb
elif [ $mode = "all" ]
then
    buildapi && buildweb
else
    echo "输入错误"
fi

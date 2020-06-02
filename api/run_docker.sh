#!/bin/bash

mode = $0

#  api
if [mode == 'api']
then
    buildapi
elif [mode == 'web']
then
    buildweb
elif [mode == '' || mode == 'all']
    buildapi && buildweb
else
    echo '输入错误'
fi

buildapi(){
    docker build -t navi_api .
    docker run -d  -p 5002:5002 --rm  --name navi_api  navi_api
}

buildweb(){
    docker build -t navi .
    docker run -d -it -p 5003:5003 --rm --name navi navi
}

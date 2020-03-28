#  api
docker build -t navi_api .

docker run -d  -p 5002:5002  --name navi_api  navi_api


# web

docker build -t navi .

docker run -d -it -p 5003:5003 --rm --name navi navi
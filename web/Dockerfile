# FROM node:lts-alpine

# # install simple http server for serving static content
# RUN npm install -g http-server

# # make the 'app' folder the current working directory
# WORKDIR /app

# # copy both 'package.json' and 'package-lock.json' (if available)
# COPY package*.json /app/

# # install project dependencies
# RUN npm install

# # copy project files and folders to the current working directory (i.e. 'app' folder)
# COPY . .

# # build app for production with minification
# RUN npm run build

# EXPOSE 5003
# CMD [ "http-server", "dist", "-p", "5003" ]

# 手动部署

FROM node:lts-alpine

RUN npm install -g http-server

WORKDIR /app

COPY dist ./dist

EXPOSE 5003
CMD [ "http-server", "dist", "-p", "5003" ]
FROM node:10-alpine

WORKDIR /home/node/app

COPY packeges*.json ./

RUN mkdir ./backend

COPY ./backend/package*.json ./backend/

USER node

RUN npm run install-server

COPY --chown=node:node . .

EXPOSE 8080

CMD [ "npm", "run", "start-server" ]
FROM node:10-alpine

WORKDIR /home/node/app

USER node

COPY ./ ./

RUN npm run install-server

COPY --chown=node:node . .

EXPOSE 8080

CMD [ "npm", "run", "start-server" ]
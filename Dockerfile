FROM node:16-alpine

RUN mkdir /app && chown node:node /app
WORKDIR /app

USER node
COPY --chown=node:node . .

RUN npm run install-server

EXPOSE 4000

CMD [ "npm", "run", "start-server" ]
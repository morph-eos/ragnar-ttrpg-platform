FROM node:16-alpine

RUN mkdir /app && chown node:node /app
WORKDIR /app

USER node
COPY --chown=node:node ./backend ./backend
COPY --chown=node:node ./frontend/dist ./frontend/dist
COPY --chown=node:node ./frontend/public ./frontend/public
COPY --chown=node:node ./package*.json ./


RUN npm run install-server

EXPOSE 4000

CMD [ "npm", "run", "start-server" ]

const { env } = require('process');

const target = env.ASPNETCORE_HTTPS_PORT ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}` :
  env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'http://localhost:60448';

const PROXY_CONFIG = [
  {
    context: [
      "/weatherforecast" // Change the context to match your API endpoint path, e.g., "/api/weatherforecast"
    ],
    target: target,
    secure: false,
    headers: {
      Connection: 'Keep-Alive'
    }
  }
];

module.exports = PROXY_CONFIG;

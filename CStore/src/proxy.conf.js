const PROXY_CONFIG = [
  {
    context: [
      "/api",
    ],
    target: "https://localhost:7030",
    secure: false
  }
]

module.exports = PROXY_CONFIG;

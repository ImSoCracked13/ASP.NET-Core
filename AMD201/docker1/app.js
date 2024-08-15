const http = require('http')
const server = http.createServer((req, res) => {
   res.write("<h1>Practice with Docker</h1>")
   res.end()
})
server.listen(3000, () => {
   console.log('Server is running at http://localhost:3000')
})
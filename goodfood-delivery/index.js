const express = require('express')
const port = 80
const app = express()

app.get('/api/deliveries', (req,res) => {
    res.send("Liste des livraisons en cours")
})

app.listen(port, () => {
    console.log("Serveur à l'écoute au port " + port)       
})


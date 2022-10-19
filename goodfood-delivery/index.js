const express = require('express');
const port = 5000; // use .env
const app = express();
const cors = require("cors");
const bodyParser = require("body-parser");
const livraison = require("./route/livraison");

app.use(cors());
app.use(bodyParser.urlencoded({ extended: true }));
app.use(express.json());

app.use("/api/livraison", livraison);

app.listen(port, () => {
    console.log("Serveur à l'écoute au port " + port);      
});

module.exports = app;
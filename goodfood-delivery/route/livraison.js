const express = require("express");
const router = express.Router();

const Datastore = require('nedb') 


// Type 3: Persistent datastore with automatic loading
// You can issue commands right away
const db = new Datastore({ filename: 'stockage/livraison', autoload: true });

db.loadDatabase();

router.get('/all', async (req,res) => {
    db.find({}, (err, docs) => {
        res.status(200).json(docs)
    });
})

router.get('/:id', async (req,res) => {
    try{
        db.findOne({"commande_id": 1}, (err, newDoc) => {
            res.status(200).json(newDoc);
        });
    }catch(e){
        res.status(500).json({"erreur": "y'a une couille dans le paté"});
    }
})

// input
// {
//     "commande_id":"",
//     "restaurant_id":"",
//     "adresse_id":"",
//     "client_id":""
// }
router.post('/init', async (req, res) => {
    try{
        // verif sur les input
        let cmd = {
            "commande_id": 1,
            "livreur": {
                "livreur_id": null,
                "position": {
                    "x": null,
                    "y": null
                }
            },
            "restaurant_id": "",
            "adresse_id": "",
            "date_livraison": {
                "debut": "", // Date now()
                "fin": null
            },
            "statut": "", // en faire un par default
            "client_id": ""
        };


        db.insert(cmd, (err, newDoc) => {
            res.status(200).json(newDoc);
        });
    }catch(e){
        res.status(500).json({"erreur": "y'a une couille dans le paté"});
    }
});

router.put('/:id/update', async (req, res) => {
    try{
        // Replace a document by another
        db.update({ planet: 'Jupiter' }, { planet: 'Pluton'}, {}, function (err, numReplaced) {
            // numReplaced = 1
            // The doc #3 has been replaced by { _id: 'id3', planet: 'Pluton' }
            // Note that the _id is kept unchanged, and the document has been replaced
            // (the 'system' and inhabited fields are not here anymore)
        });
    }catch(e){
        res.status(500).json({"erreur": "y'a une couille dans le paté"});
    }
});

router.delete('/:id/delete', async (req, res) => {
    try{
    // Remove one document from the collection
    // options set to {} since the default for multi is false
    db.remove({ _id: 'id2' }, {}, function (err, numRemoved) {
        // numRemoved = 1
    });
    }catch(e){
        res.status(500).json({"erreur": "y'a une couille dans le paté"});
    }
});

// route livreur - position

router.put('/:id/livreur/update/position', async (req, res) => {
    try{
        // Replace a document by another
        db.update({ planet: 'Jupiter' }, { planet: 'Pluton'}, {}, function (err, numReplaced) {
            // numReplaced = 1
            // The doc #3 has been replaced by { _id: 'id3', planet: 'Pluton' }
            // Note that the _id is kept unchanged, and the document has been replaced
            // (the 'system' and inhabited fields are not here anymore)
        });
    }catch(e){
        res.status(500).json({"erreur": "y'a une couille dans le paté"});
    }
});

// route statut

router.put('/:id/update/statut', async (req, res) => {
    try{
    // Replace a document by another
    db.update({ planet: 'Jupiter' }, { planet: 'Pluton'}, {}, function (err, numReplaced) {
        // numReplaced = 1
        // The doc #3 has been replaced by { _id: 'id3', planet: 'Pluton' }
        // Note that the _id is kept unchanged, and the document has been replaced
        // (the 'system' and inhabited fields are not here anymore)
    });
    }catch(e){
        res.status(500).json({"erreur": "y'a une couille dans le paté"});
    }
});


module.exports=router;
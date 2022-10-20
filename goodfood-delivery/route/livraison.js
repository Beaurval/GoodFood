const express = require("express");
const router = express.Router();

const { body, param, validationResult } = require('express-validator');

const Datastore = require('nedb') 


// Type 3: Persistent datastore with automatic loading
// You can issue commands right away
const db = new Datastore({ filename: 'stockage/livraison', autoload: true });

db.loadDatabase();

// pour le dev
router.get('/all', 
async (req,res) => {
    db.find({}, (err, docs) => {
        res.status(200).json(docs)
    });
})

router.get('/:id', 
param('id'), 
async (req,res) => {
    try{
        const errors = validationResult(req);
        if (!errors.isEmpty()) {
          return res.status(400).json({ errors: errors.array() });
        }

        db.findOne({"_id": req.params.id}, (err, newDoc) => {
            if(newDoc == null){
                res.status(404).json(newDoc);
            }else {
                res.status(200).json(newDoc);
            }
        });
    }catch(e){
        res.status(500).json({"erreur": "y'a une couille dans le paté"});
    }
}),

router.get('/byCommande_id/:id', 
param('id'), 
async (req,res) => {
    try{
        const errors = validationResult(req);
        if (!errors.isEmpty()) {
          return res.status(400).json({ errors: errors.array() });
        }

        db.findOne({"commande_id": parseInt(req.params.id)}, (err, newDoc) => {
            if(newDoc == null){
                res.status(404).json(newDoc);
            }else {
                res.status(200).json(newDoc);
            }
        });
    }catch(e){
        res.status(500).json({"erreur": "y'a une couille dans le paté"});
    }
})



router.post('/init', 
body('commande_id').exists(),
body('restaurant_id').exists(),
body('adresse_id').exists(),
body('client_id').exists(),
async (req, res) => {
    try{
        const errors = validationResult(req);
        if (!errors.isEmpty()) {
          return res.status(400).json({ errors: errors.array() });
        }

        let cmd = {
            "commande_id": req.body.commande_id,
            "livreur": {
                "livreur_id": "",
                "position": {
                    "x": null,
                    "y": null
                }
            },
            "restaurant_id": req.body.restaurant_id,
            "adresse_id": req.body.adresse_id,
            "date_livraison": {
                "debut": (new Date(Date.now())).toISOString(), // Date now()
                "fin": null
            },
            "statut": "started", // en faire un par default
            "client_id": req.body.client_id
        };


        db.insert(cmd, (err, newDoc) => {
            res.status(200).json({_id: newDoc._id});
        });
    }catch(e){
        res.status(500).json({"erreur": "y'a une couille dans le paté"});
    }
});

router.put('/:id', 
param('id').exists(), 
async (req, res) => {
    try{
        const errors = validationResult(req);
        if (!errors.isEmpty()) {
          return res.status(400).json({ errors: errors.array() });
        }
        db.update({ _id: req.params.id }, {}, {}, function (err, numReplaced) {
            res.status(200).json(numReplaced);
        });
    }catch(e){
        res.status(500).json({"erreur": "y'a une couille dans le paté"});
    }
});

router.delete('/:id/delete', 
param('id').exists(), 
async (req, res) => {
    try{
        const errors = validationResult(req);
        if (!errors.isEmpty()) {
          return res.status(400).json({ errors: errors.array() });
        }
    db.remove({ _id: req.params.id }, {}, function (err, numRemoved) {
        res.status(200).json(numRemoved);
    });
    }catch(e){
        res.status(500).json({"erreur": "y'a une couille dans le paté"});
    }
});

// route livreur - position

router.put('/:id/livreur/update/position', 
param('id').exists(),
body('x').exists(),
body('y').exists(),
async (req, res) => {
    try{
        const errors = validationResult(req);
        if (!errors.isEmpty()) {
          return res.status(400).json({ errors: errors.array() });
        }
        
        db.update({ _id: id}, { livreur: {position: {x: req.body.x, y: req.body.y}}}, {}, function (err, numReplaced) {
            res.status(200).json(numReplaced);
        });
    }catch(e){
        res.status(500).json({"erreur": "y'a une couille dans le paté"});
    }
});

// route statut

const statutPossible = [
    "init",
    "started",
    "delivery in progress",
    "canceled",
    "done"
]

router.put('/:id/update/statut', 
param('id').exists(),
body('statut').exists(),
async (req, res) => {
    try{
        const errors = validationResult(req);
        if (!errors.isEmpty()) {
          return res.status(400).json({ errors: errors.array() });
        }
        
        let update = {};
        if(statutPossible.indexOf(req.body.statut) == 4){
            update = { 
                statut: req.body.statut,
                date_livraison: {
                    fin:  (new Date(Date.now())).toISOString()
                }
            };
        }else if(statutPossible.indexOf(req.body.statut) != -1){
            update = {statut: req.body.statut};
        }else {
            res.status(400).json({error: 'invalid t must be => "' + statutPossible.join(', ') + '"'});
        }

        db.update({ _id: id}, update, {}, function (err, numReplaced) {
            res.status(200).json(numReplaced);
    });
    }catch(e){
        res.status(500).json({"erreur": "y'a une couille dans le paté"});
    }
});


module.exports=router;
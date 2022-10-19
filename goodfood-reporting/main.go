package main

import (
	"encoding/json"
	"io/ioutil"
	"log"
	"net/http"

	"github.com/gin-gonic/gin"
)

const providerUrl = `http://20.124.42.95/api/provider`
const userUrl = `http://20.124.42.95/api/users`
const orderUrl = `http://20.124.42.95/api/orders`

type Provider struct {
	ID int `json: "id"`
}

type User struct {
	ID int `json: "id"`
}

type Order struct {
	ID int `json: "id"`
}

func RequestTotalUser() int {
	response, err := http.Get(userUrl)
	if err != nil {
		log.Fatal(err)
	}
	bytes, errRead := ioutil.ReadAll(response.Body)
	defer func() {
		e := response.Body.Close()
		if e != nil {
			log.Fatal(e)
		}
	}()
	if errRead != nil {
		log.Fatal(errRead)
	}
	var users []User
	errUnmarshal := json.Unmarshal(bytes, &users)
	if errUnmarshal != nil {
		log.Fatal(errUnmarshal)
	}
	return len(users)
}

func RequestTotalProvider() int {
	response, err := http.Get(providerUrl)
	if err != nil {
		log.Fatal(err)
	}
	bytes, errRead := ioutil.ReadAll(response.Body)
	defer func() {
		e := response.Body.Close()
		if e != nil {
			log.Fatal(e)
		}
	}()
	if errRead != nil {
		log.Fatal(errRead)
	}
	var provider []Provider
	errUnmarshal := json.Unmarshal(bytes, &provider)
	if errUnmarshal != nil {
		log.Fatal(errUnmarshal)
	}
	return len(provider)
}

func RequestTotalCA() int {
	response, err := http.Get(orderUrl)
	if err != nil {
		log.Fatal(err)
	}
	bytes, errRead := ioutil.ReadAll(response.Body)
	defer func() {
		e := response.Body.Close()
		if e != nil {
			log.Fatal(e)
		}
	}()
	if errRead != nil {
		log.Fatal(errRead)
	}
	var orders []Order
	errUnmarshal := json.Unmarshal(bytes, &orders)
	if errUnmarshal != nil {
		log.Fatal(errUnmarshal)
	}
	return len(orders)
}

func returnTotalUser(c *gin.Context) {

	c.IndentedJSON(http.StatusOK, RequestTotalUser())
}

func returnTotalProvider(c *gin.Context) {

	c.IndentedJSON(http.StatusOK, RequestTotalProvider())
}

func returnTotalCA(c *gin.Context) {

	c.IndentedJSON(http.StatusOK, RequestTotalCA())
}

func main() {

	//log.Printf("%v", RequestCA())
	router := gin.Default()
	router.GET("/TotalUser", returnTotalUser)
	router.GET("/TotalProvider", returnTotalProvider)
	router.GET("/TotalCA", returnTotalCA)
	router.Run("localhost:8080")
}

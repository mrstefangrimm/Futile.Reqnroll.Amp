# Docker

Tests the results of various calculator implementations in a docker containers. A Web UIs and a Web API are tested. Both tests and systems under test are docker containers. This is possible because Futile.Reqnroll.Amp does not require Windows.

Requires:
 - Docker


## Step-by-step

### 1 Build and Run SUT containers

Manual build and create the test containers.

```bash
# Create a network for both SUTs and Tests
docker network create calcnet

cd ../../tests/WebCalculator/
docker build . -t webcalculator:latest
docker run -d --name webcalculator --network calcnet -p 80:80 webcalculator:latest

cd ../WebCalculatorApi/
docker build . -t webcalculatorapi:latest
docker run -d --name webcalculatorapi --network calcnet -p 8080:8080 webcalculatorapi:latest
```

### Test the SUT

#### Web UI:
URL in browser: http://localhost:80

#### Web API:
```bash
curl -X POST http://localhost:8080/api/calculation -H "Content-Type: application/json" -d '{ "firstNumber": 1, "secondNumber": 2, "mathOperation": "Add" }'
```

### 2 Build, Run the WebCalculator Test container and Execute the Tests

Build and run the test container.

```bash
cd ../../examples/Docker/PlayWright.Specs/
docker build . -t webcalculator.specs:latest
docker run -it --name webcalculator.specs --network calcnet --rm webcalculator.specs:latest
```

Execute the tests in the test container. `xunit.v3` creates an executable.

```bash
./bin/Debug/net10.0/WebCalculator.Specs
```

### 3 Build, Run the WebAPI Test container and Execute the Tests

Build and run the test container.

```bash
cd ../HttpClient.Specs/
docker build . -t webcalculatorapi.specs:latest
docker run -it --name webcalculatorapi.specs --network calcnet --rm webcalculatorapi.specs:latest
```

Execute the tests in the test container. `xunit.v3` creates an executable.

```bash
./bin/Debug/net10.0/WebCalculatorApi.Specs
```



### 4 Clean-up

```bash
docker rm -f webcalculatorapi
docker rm -f webcalculator
docker rmi -f webcalculatorapi.specs
docker rmi -f webcalculator.specs
docker rmi -f webcalculatorapi
docker rmi -f webcalculator
docker network rm calcnet
```


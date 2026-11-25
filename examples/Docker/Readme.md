# Docker

Demonstrates how to tests various calculator implementations in a docker container. A calculator with Web UI and a calculator with a Web API are tested. Test and system under test (SUT) are docker containers. This is possible because Futile.Reqnroll.Amp does not require Windows.

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
docker run -d --name webcalculator --network calcnet -p 8081:8080 webcalculator:latest

cd ../WebCalculatorApi/
docker build . -t webcalculatorapi:latest
docker run -d --name webcalculatorapi --network calcnet -p 8080:8080 webcalculatorapi:latest
```

### 2 Test the SUT

#### Web UI:
URL in browser: [http://localhost:8081](http://localhost:8081)

#### Web API:
```bash
curl -X POST http://localhost:8080/api/calculation -H "Content-Type: application/json" -d '{ "firstNumber": 1, "secondNumber": 2, "mathOperation": "Add" }'
```

### 3 Build, Run the WebCalculator Test container and Execute the Tests

Build and run the test container.

```bash
cd ../../examples/Docker/PlayWright.Specs/
docker build . -t webcalculator.specs:latest
docker run -it --rm --name webcalculator.specs --network calcnet -v.://src/WebCalculator.Specs/bin/Debug/net10.0/report --rm webcalculator.specs:latest
```

Execute the tests in the test container. `xunit.v3` creates an executable.

```bash
./net10.0/WebCalculator.Specs
```

Exit and terminate the docker container.

```bash
exit
```

The test report is available as html in the current Windows directory. You may want to delete the file *reqnroll_report.html* after reviewing it.



### 4 Build, Run the WebAPI Test container and Execute the Tests

Build and run the test container.

```bash
cd ../HttpClient.Specs/
docker build . -t webcalculatorapi.specs:latest
docker run -it --rm --name webcalculatorapi.specs --network calcnet -v.://src/WebCalculatorApi.Specs/bin/Debug/net10.0/report --rm webcalculatorapi.specs:latest
```

Execute the tests in the test container. `xunit.v3` creates an executable.

```bash
./net10.0/WebCalculatorApi.Specs
```

Exit and terminate the docker container.

```bash
exit
```

The test report is available as html in the current Windows directory. You may want to delete the file *reqnroll_report.html* after reviewing it.

### 5 Clean up

```bash
docker rm -f webcalculatorapi
docker rm -f webcalculator
docker rmi -f webcalculatorapi.specs
docker rmi -f webcalculator.specs
docker rmi -f webcalculatorapi
docker rmi -f webcalculator
docker network rm calcnet
docker system prune -f
```


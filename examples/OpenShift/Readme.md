# OpenShift Source-to-Image (s2i)

Demonstrates how to tests various calculator implementations in OpenShift. A calculator with Web UI and a calculator with a Web API are tested. Test and system under test (SUT) are built in OpenShift; using s2i. The calculators are Deployments. The tests are Jobs.

Requires:

- OpenShift. No Docker or Image Registry is required; all is handled by OpenShift



## Step-by-step

### 1 Setup the Build Configs

```bash
# Create a new namespace
oc new-project futile-tests

oc apply -f ./imagestream-s2i-webcalculator.yaml
oc apply -f ./imagestream-s2i-webcalculatorapi.yaml
oc apply -f ./imagestream-s2i-webcalculator.spec.yaml
oc apply -f ./imagestream-s2i-webcalculatorapi.spec.yaml

oc apply -f ./buildconfig-s2i-webcalculator.yaml
oc apply -f ./buildconfig-s2i-webcalculatorapi.yaml
oc apply -f ./buildconfig-s2i-webcalculator.spec.yaml
oc apply -f ./buildconfig-s2i-webcalculatorapi.spec.yaml
```

### 2 Start the Builds

```bash
oc start-build s2i-webcalculator
oc start-build s2i-webcalculatorapi
oc start-build s2i-webcalculator-spec
oc start-build s2i-webcalculatorapi-spec
```

### 3 Deploy the SUT

```bash
oc apply -f ./deployment-s2i-webcalculator.yaml
oc apply -f ./deployment-s2i-webcalculatorapi.yaml
```

### 4 Test the SUT

#### Web UI:

 Check the route in OpenShift. For OpenShift Local, it is .apps-crc.testing

URL in browser:  http://route-s2i-webcalculator.apps-crc.testing/

#### Web API:
```bash
# Check the route in OpenShift. For OpenShift Local, it is .apps-crc.testing
curl -X POST http://route-s2i-webcalculatorapi.apps-crc.testing/api/calculation -H "Content-Type: application/json" -d '{ "firstNumber": 1, "secondNumber": 2, "mathOperation": "Add" }'
```

### 5 Create and Run the Test Jobs

```bash
oc apply -f job-s2i-webcalculator.spec.yaml
oc logs -f job/webcalculator-specs

oc apply -f job-s2i-webcalculatorapi.spec.yaml
oc logs -f job/webcalculatorapi-specs
```

### 6 Clean up

```bash
oc delete project futile-tests
```






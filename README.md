<table border="0">
  <tr>
    <td><img src="res/rnramp-logo.png" width="80"></td>
    <td><h1>Reqnroll.Amp</h1></td>
  </tr>
</table>

Reqnroll.Amp is a class library that boosts (amplifies) your test‑writing. [Reqnroll](https://reqnroll.net/) is BDD testing environment for C#. Reqnroll.Amp is a tiny class library on top of Reqnroll.



## Features:

- Support for Windows application E2E testing
- Support for Web application E2E testing
- Support for Web API  E2E testing
- Test profiles which can be selected at runtime
- Support of multiple applications under test



## Getting Started

The e2e tests under /tests/ are best suited to get started. The source code contains tests for all of the features listed above.

| Test Project | Feature | Description |
| -- | -- | -- |
| WebCalculator.Specs | PlayWrightMinimal | Tests the online calculator https://futile-calculator.netlify.app/ |
| WebCalculator.Specs | PlayWrightProfile | Tests the online calculator with different profiles (e.g. testing in slow motion) |
| WebCalculator.Specs | PlayWrightProfile | Tests the online calculator with a command line argument that is defined in the test (i.e. as a variable) |
| WpfCalculator.Specs | FlaUiMinimal | Tests the WpfCalculator.exe |
| WpfCalculator.Specs | FlaUiWithProfile | Tests the WpfCalculator.exe with different profiles |
| WpfCalculator.Specs | FlaUiWithProfileAndArgument | Tests the WpfCalculator.exe with a command line argument that is defined in the test (i.e. as a variable) |
| Wpf2Calculator.Specs | FlaUI | Tests two WpfCalculator.exe at the same time |
| WindowsCalculator.Specs | FlaUI | Tests the Windows calculator. |
| WebCalculatorApi.Specs | HttpClientTestHost | Tests the calculator Web Api by starting a ASP.NET TestHost |



## Examples

The examples are bigger than tests. The examples do not try to solve "real world problems". Instead, they demonstrate some aspects of e2e testing.



## How it works

While Reqnroll does the hard stuff and lets you use BDD for unit tests, integration tests, e2e test with any framework that is on the market (PlayWright, Selenium, ... you name it), various DI frameworks, Testing frameworks (MSTest, NUnit, xUnit), Reqnroll.Amp comes with some hard-wired decisions.



Reqnroll.Amp uses:

- Reqnroll
- Chrome browser and PlayWright for Web UI testing
- FlaUI for Windows application testing
- xunit.v3
- Autofac



Two features are unique:

1. It is possible to define profiles in `reqnroll.ampsettings.json` which can be selected at runtime
2. It is possible to start applications as part of a e2e test. Muliple Web UIs, APIs and Windows applications can be part of one test scenario



## Repository structure

- src: source code of the Reqnroll.Amp library
- tests: test the features and aspects of Reqnroll.Amp. Best entry point to learn
- examples: examples use Futile.Reqnroll.Amp nuget package from nuget.org. Examples are more complex than tests



If you want to work offline (air gapped), you may like the "Build-AmpArtifiacts" resp. "Build-AmpArtifiacts-windows" scripts. These scripts get all the package dependencies and compress the nuget packages into an archive (zip on Windows, tar.gz on Linux)

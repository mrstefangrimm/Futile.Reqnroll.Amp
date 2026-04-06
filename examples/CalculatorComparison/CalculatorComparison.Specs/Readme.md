# Calculator Comparison

Compares the results of various calculator implementations. Multiple Windows Applications and Web UIs are tested in one test scenario. This is possible with the generic drivers in Futile.Reqnroll.Amp.

Requires:
 - Visual Studio
 - .NET SDK
 - Windows
 - Chrome browser
 - Internet



## Run in Visual Studio

Open *Reqnroll.Amp.Examples.slnx* in Visual Studio and build the solution. The solution includes the project *CalculatorComparison.Specs* with the features:

- FourCalculators.feature
  Example of a test with four calculators tested in one scenario.
- FutileWebCalculator.feature
  Example of a test for https://futile-calculator.netlify.app/.
- StoreApp.feature
  Example of a test for the Windows Calculator.
- WebCalculator.feature
  Example of a test for https://webcalculator.netlify.app/.
- WpfCalculator.feature
  Example of a test for a Windows application written with WPF.

In the Visual Studio Test Explorer, you should see the test group *CalculatorComparison.Specs* with subgroups for all the mentioned features and one test for each feature.

For each test, you get a nicely formatted *Test Detail Summary*. In the output folder (e.g. `CalculatorComparison.Specs\bin\Debug\net10.0-windows\`), a subfolder *reports* contains the file *reqnroll_report.html* and, if an error occurred, a screenshot of your Windows desktop.



Ignore the projects *WebCalculator.Specs* and *WebCalculatorApi.Specs* in the solution *Reqnroll.Amp.Examples.slnx*. They are configured for Docker.



## Run on the command line

Open a command line and execute:

```sh
 dotnet publish .\CalculatorComparison.Specs\ -c Release -o published
```

This creates the subfolder *published*. In the Windows file explorer, navigate into the folder and double-click *CalculatorComparison.Specs.exe*. A subfolder *reports* contains the file *reqnroll_report.html* and, if an error occurred, a screenshot of your Windows desktop.

To execute the tests, just execute:

```shell
.\published\CalculatorComparison.Specs.exe
```


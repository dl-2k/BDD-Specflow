# Automation Test BDD using SpecFlow for Project DemoQA

## Overview
An automation test project for https://demoqa.com web, built on .NET 8 (C# is the main programming language), NUnit 3.

## Solution Structure

There are 3 projects in this solution:

1. **DemoQA.Core**: Contains essential components for working with APIs and reading configuration files.
2. **DemoQA.Service**: Provides functionalities for API interactions.
3. **DemoQA.Test**:  Tests and Features are written here , dependent on Core and Services

## Dependency Packages

| Package         | Description                               |       Link                                     |
|-----------------|-------------------------------------------|------------------------------------------|
| ExtentReports   |  Generates HTML reports for test cases                 | [https://extentreports.com/]
| FluentAssert   |    Enhances code readability               | [https://fluentassertions.com/]
| RestSharp   |   Streamlines the process of making HTTP requests and interacting with RESTful APIs in .NET applications                | [https://restsharp.dev/]
| Specflow.Nunit   |   Connects Specflow with NUnit to facilitate BDD testing                | [https://docs.specflow.org/projects/specflow/en/latest/Integrations/NUnit.html]




## Development Tools

The project is set up using Visual Studio 2022, which is recommended as the main IDE. Alternatively, you can use Visual Studio Code, but you'll need to install the .NET 5 SDK and relevant C# extensions for effective project management and execution.


## Configuration Files

- The `appsetting.json` file is the main config file of this project, it allows you to configure the application URL.

## Running Tests
Before running the test, you must log into the  [API Swagger of DemoQA] (https://demoqa.com/swagger/#/) or (https://demoqa.com/login) to create new user and get the username, password, userId. Then, paste it into the file of folder `TestData/Account.json`

**NOTE**:  Ensure that your userName, password, and userId remain confidential and are not revealed in public repositories.

## How to Run Tests

1. **Visual Studio 2022**:
   - Use Test Explorer to select tests to run.
2. **Visual Code**:
   - Install the .NET Core Test Explorer extension and then select tests to run.
3. **Command Lines**:
   - Restore all dependency packages: `dotnet restore`
   - Build project: `dotnet build`
   - Run tests: `dotnet test`
   - Run specific tests based on category: `dotnet test --filter  Category=FillRegistartionForm` 
         (Replace `FillRegistartionForm` with the desired test category.)   
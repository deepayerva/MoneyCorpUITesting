Disclaimer
Selenium is a browser automation tool. This particular repository only covers Selenium setup for C# based programming language.
You can do that by following guidlines listed here.

Prerequisites
To run these particular examples, I used Visual Studio 2022 with Nunit test framework to download Webdriver and Selenium required package itself using C# NuGet:

Installation
This particular code was built with Visual Studio with c# which will be used to build and launch the application.

Project Structure:
I created three folders mainly
PageObjects: In which page class files are present, Page class used as a placeholder for Objects and methods used on that page of the application
Tests: Contains the test files, I normally use one test file for every page in the application
Utilities:Contains helper classes 
There is another important file appsettings.json this file contains test parametes (configuration or environmnet).

Testing
If everything is done correctly, project build successfully, going to Test Explorer and find the tests written for the project and you can run each test or run the suite.




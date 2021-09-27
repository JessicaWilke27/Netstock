# Netstock
Release Notes

  Odoo integration assessment is a .NET Core 3.1 solution, developed and tested on Visual Studio 2019.
Source Code
  All source code can be found on GitHub https://github.com/JessicaWilke27/Netstock 
  
  To run with visual studio
  
  1.	Download source code from repository
  2.	Open “Netstock.sln” in Visual Studio
  3.	Set “NetstockConsole” as StartUp project
  4.	Rebuild solution
  5.	Run NetstockConsole
 
  *Note: The project will run all processing every minute. To change configuration, time interval can be set in App.config file. Different schedules (minutes, hourly and daily)  are present. Scheduler to be used can also be defined in the config file.
  
  After every run all generated CSV files will be saved in the location defined in the config. Defaults to Netstock\Console\bin\Debug\Output 

To Run without Visual Studio

1.	Download source code from repository
2.	Location NetstockConsole.exe – \Location of code\Netstock\Publish\ProgramFiles\NetstockConsole.exe
3.	Run NetstockConsole.exe

*Note: The project will run all processing every minute. To change configuration, time interval can be set in App.config file. Different schedules (minutes, hourly and daily) are present. Scheduler to be used can also be defined in the config file.

After every run all generated CSV files will be saved in the location defined in the config. Defaults to – \Location of code\Netstock\Publish\Output 


Overview

  Following aspects have been addressed during the design and implementation phase:
  -	Platform decision: .NET Core 3.1 is used because of its cross-platform capabilities. Thus, solution can be run on multiple platforms such as Windows, Linux etc
  -	Application Type: Console Application  
    o	According to specification of the assignment, it can be deduced that the processing can be considered as an unattended execution with no user interaction. 
    
    o	A console application can easily be defined and registered as a Windows service or Linux daemon. 
    
    o	General, potentially scalable and extensible application design is considered.  
    
  -	During application design, strong considerations are given to OO fundamentals, SOLID design principles as well as SLAP
  -	All configuration settings are extracted to the config file to allow for easy configuration changes without the need for recompilation of project.
 
  -	Solution is divided into two main aspects:
  
    o	Console Application
    
    Entry point into application
    
    Services such as logging, scheduling and running of arbitrary services were developed.
    
    Scheduling: Since application is running unattended with no user interaction, a scheduler is used to trigger periodic execution of services
    
    Logging: Logging is used for diagnostics and monitoring
    
    o	Odoo Service
    
    Designed and developed as independent and decouple service in the form of a class library (DLL)
    
    Service is kicked off and runs under the shell of the console.
    
    Scheduled execution is controlled by the host application (Console)
    
    
External Libraries

  External libraries were leveraged to facilitate development. Since requirements are to deal with downloading and transforming multiple models with the potential to expand to larger ERM systems, a structured approach is chosen when it comes to the serialization and deserialization process. CSV mappers are employed to standardize and abstract the data transformation operations.
  
  Various options were considered for consuming of XML-RPC services and for transformation of XML data to CSV. Some viable options considered were:
  
  -	Libraries for consuming XML-RPC services
  -	XSLT
  -	From XML DOM to CSV
 
  Considering that this is an assignment with time constraints the choice is made based on time availability, usability and performance without negatively impacting architectural and design principles.
  
  Kveer.XmlRPC library is used to consume XML-RPC services. Responses are serialized into structs.
  
  CsvHelper library is leveraged for writing CSV files and mapping structs to CSV fields.
  
  Microsoft.Extensions.DependencyInjection library is used for IOC and dependency injection
  
Production Ready

  Structure of application is production quality. Further factors that need to be considered are:
  -	Proper production scope must be defined.
  -	Factors for final design will be:
  
    o	Volume of data

    o	Frequency of runs

    o	CSV file lifecycle

    o	Hosting environment of application

    o	Real services to be consumed 

    o	Proper field/model mapping must be established

    o	Data encoding decisions

    o	Logging needs to be strengthened

    o	Error handling

    o	Potential monitoring

    o	Is there more than one service to be run

    o	Scheduling intervals/scheduling times

    o	Overlapping schedulers

    o	Unit testing


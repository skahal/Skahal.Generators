Skahal.Generators
================================

Skahal.Infrastructure T4 templates generators

--------

Features
===
 - Generators for
 	- Domain
 		- Services
 			- `Skahal.Infrastructure.Framework.Domain.ServiceBase`
 		- Repository interface
 			- `Skahal.Infrastructure.Framework.Repositories.IRepository`
 		- Specifications
 			- `KissSpecifications`
 		- Unit Tests
 			- `NUnit`
 	- Repositories
 		- Memory
 			- `Skahal.Infrastructure.Framework.Repositories.MemoryRepository`
 		- MongoDB
 			- `Skahal.Infrastructure.Repositories.MongoDBRepositoryBase`
 	- WebApi
 		- Controllers
 			- `ASP .NET Web Api (ApiController)`
 				- GET /resource
 				- GET /resource/id
 				- POST /resource
 				- PUT /resource/id
 				- DELETE /resource/id
 			
Using
===	
* Download the whole source code inside your root solution source code folder.
* Config the YourConfig.tt file to reference your domain and infrastructure assemblies and namespaces.
* Change the msbuilds/Skahal.Generators.targets to copy the file to your folders.
* For each .tt that you want to use, hit "Run custom tool" or hit "Transform all templates" on Skahal.Generators project.
* Rebuild Skahal.Generators to run the tasks inside Skahal.Generators.targets.

--------

Roadmap
-------- 
 - Configure Travis-CI
 - Create a NuGet package
 		
 
--------

How to improve it?
======

Create a fork of [Skahal.Generators](https://github.com/skahal/Skahal.Generators/fork). 

Did you change it? [Submit a pull request](https://github.com/skahal/Skahal.Generators/pull/new/master).


License
======

Licensed under the The MIT License (MIT).
In others words, you can use this library for developement any kind of software: open source, commercial, proprietary and alien.


Change Log
======
 - 0.5.0 First version.

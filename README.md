
System requirements: 
- .Net core 3.1, iisexpress or higher
- Visual Studio 2019, Internet conection

Getting Started:

-Clone or Download solution from Dev branch and open solution file ..Funda\Funda.sln with Visual Studio

-Run site with IIS Express

About:

This solution uses Funda partner API to count top 10 real estate agents that have most objects listed for sale.
You can find full task description at 'Fullstack assignment 2021.docx' file in this repo.

Implementation is pretty simple and straightforward.

Domain project contains projections of funda entities that obtained at the responce. And Counter class that  accumulates  the
retrieved data and  returns final results.  All the data stored in a memory and flushed after each request, just for simplicity, 
as it's not a production ready solution. Using of some caching system would help to increase  the speed of folowing requests 
and decrease number of interactions after retrieving initial data.

Infrastructure project provides a  web client for comunication with funda API. MakelaarService will get first request to obtain 
a first bunch of objects to proceed and number of records that left. After that will make all other requests asyncronously in parallel, 
that helps find a results in an acceptable period of time.

Application contains Dtos and handlers for queries used in Web projects conrollers. In a bigger solutions with much more actions this kind  
of segregation helps to keep logic separated from implementation.

Web part is a simple React web application that shows final results.

As a provided funda endpoint  serves for another purposes in a real world, this implementation, that makes a bunch of requiest 
for object retrieving, looks a little bit unnatural and  probably can be replaced by one simple query at a funda server side, 
thus have a one quite big flaw - it can create(and creates) unwanted high load on vendor API that causes rejections for some requests. 
That's why there is a counter of successfully processed requests provided.

As a solution, in fact, consist of one request to service that retrieve a result using thirdparty API and Counter class, 
the Test project served rather as a reminder to have tests. And thats why it have only one, quite general, test for Counter class. 
In real-life application it should have at least tests for MakelaarService but as a developer I feel lazy to mock API client responces 
just to check that two blocks of code are called in a right order. Can we have some indulgence for test assignments? 

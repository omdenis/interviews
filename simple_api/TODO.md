
DOD: Definition of Done
- requirements > checklist
- manual testing
- unit testing
- integration tests

+ requirements

+ US1. Implement API endpoint: Calculate least angle between watch hands.
+ Return least angle as output
+ test: calculate (core logic)
+ integration test
+ end point scenarios
+ case 1: url + time
+ case 2: wrong data - validation The value '11/2213dsgfdsfg' is not valid for DateTime.

+ US2. Inventory management
+   1. Create APIs to
+      1. Create inventory items
+         1. With SKU, description and quantity
+         2. Adding inventory with unknown SKU, it should create new.
+         3. Adding inventory with known SKU, it should add the quantity to existing
+      2. Remove a defined quantity for a specific SKU
+      3. List of all inventory

DEBT:
- Split assemblies (domain, db)
- The original design forces me to use domain entity as DTO object. It's better to separate. For example by using AutoMapper :-)
- Domain logic should be extracted (now it's ready for it, because it's separate folder)
- There is no interfaces for Repository: violation DIP principle and now domain knows about datalayer
- UseCases does not have interfaces because I don't like it :-) But it's fully covered by integration tests, so no value to isolate them by iterfaces and I try to avoid extra layer of complexity by introducing such abstractions.
- TODO: string should by typed, ex: SkuType
- No error handling / data validations

LOG
+ 5m the current design
+ 10m ERROR: target framework issues
+ 20m US1...
+ 10m clean up
+ DOD

+  5m US2: analysis
+ 60m  integration tests, environment, endpoints
+ 40m 
	+ UC1: create item (SKU, desc, quantity)
	+ UC5: list of items
	+ create integration tests
+ 10m UC2: create unkown SKU -> the new one
+ 10m UC3: create known SKU -> add quantity
+  5m UC4: SKU - remove quantity 
+ DOD

+ send the result

+ User Stories
    + As a freelancer I want to be able to register how I spend time on my projects, so that I can provide my customers with an overview of my work.
    + As a freelancer I want to be able to get an overview of my time registrations per project, so that I can create correct invoices for my customers.
    + As a freelancer I want to be able to sort my projects by their deadline, so that I can prioritise my work.

- Questions

- Use Cases
    - list of projects
        - view
            +  .NET Core v3.1 and Node  
            + EF in memory
            + build script
            - TODO: run script
            + cli
                + fetch faked projects from server
                + show project
            + srv
                + add faked data
                + test controller
            + remove search
        - start
            + ui kit
            - fake data
            - srv validation
            - datetime
        - stop
        - completed
        - min: 30m
        - open porject's overview
            - rounter
        - add the new one
        - add deadline
        - delete 
        - sorting by deadlines        
    - project's overview 
        - view
        - periods
        - total time
        - return back to list of the projects
        - completed
        - disable start/finish for completed
    - refactoring
        - TODO: queryProvider (App.tsx)
        - Project Get(int prjectId) - add exception handlers

- DEBT
    - no jest tests (UI)
    - no e2e scenarios (playwright)
    - UI testing: 30 mins rule was disabled - Controller_StopProject_ShortInterval
    - UiButton color: not rendered
    - no error handling for react-query/axios    
    - 

- DoD
    - Works, obviously
    - Contains readable, bug free code
    - Is appropriately covered by tests, in the frontend and backend (where required)
    - Follows sensible structured design patterns and thought proceses
    - Validates user input and contains test coverage for these use cases, at least in the backend
    - The front-end is typed using typescript

-   Out of scope (checklist)
    - many many unit tests
    - client tests
    - e2e scenatios
    - ordering
    - editing
    - error handling
    - no styling
    - auth
    - db
    - handle responses

- Finalize
    - remove dependences
    - Send the solution (git link)
    - inform about (not having a laptop) + guideline for deployment
    - Prepare to a talk

Log:
+ 30m - req.analysis
+  5m - ERR notsup Unsupported platform for fsevents@2.3.3
+ 30m - environment 
+ 15m - ERR: .Net Core 3.1 dependencies
+ 10m - ERR: no unit tests
+ 60m - API: add project
90m

+ 10m - API: 2 new projects
+ 15m - CLI: folder structure
+  5m - ERR: ERROR in useBaseQuery.js 27:2-28
+ 45m - ERR: Uncaught TypeError: dispatcher.useSyncExternalStore is not a function + other issues
165m

+ 60m - Start/stop: init structure
+ 60m -           : server intervals
+ 60m -           : update state
345m

+ 25m - Srv: fix unit tetss /clean up db
+ 30m - Cli: modal dialog
+ 30m - Cli: validation
+ 20m - Cli: UiBUtton - could not change the color as a parameter (tailwind)
+ 10m - Uncaught Error: No QueryClient set, use QueryClientProvider to set one
+ 10m - Cli: add router - project list <> project
+ 60m - Cli: project information

- project list
- env: 



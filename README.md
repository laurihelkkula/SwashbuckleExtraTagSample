# About this project
This project is an example of creating extra tags to Swagger documentation with Swashbuckle in a ASP.Net Framework 4.6 project. The project was created with Visual Studio 2019 ASP.Net WebApi template, then irrelevant stuff was removed, Swashbuckle added and finally the important bits were implemented.

# Important bits
- See App_Start/SwaggerConfig.cs for wiring up the filters.
- See the ExtraTags folder for the implementation.
- See ValuesController.cs for how to use the attributes.

# See the important bits in action
Run the app, for example with Visual Studio. Go to https://localhost:44390/swagger and notice that the actions marked with the `My awesome tag` can be found under the `My awesome tag` section, and that section has a description. Corresponding values can be found in the Swagger JSON (https://localhost:44390/swagger/docs/v1).

# Credit
The implementation was adapted from https://github.com/domaindrivendev/Swashbuckle.AspNetCore/blob/master/src/Swashbuckle.AspNetCore.Annotations/AnnotationsDocumentFilter.cs

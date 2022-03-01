# Lesson 04 exercises
## ASP.NET Core routing and model binding
We are going to build a contact book

## Exercise 04-1
Setup the project and add template files.

- Create a new ASP.NET Core Web app (Razor Pages) with `dotnet new`[^1].
- Add a new folder in `Pages` called `Contact` and add a page called `Index` and a page called `Details`
- Add a link to `Contacts` to the navigation bar (check out `/Pages/Shared/_Layout.cshtml`)

## Exercise 04-2
Next up, we are going to add a form, binding model, and a handler

- Add the following form fields to `Index.cshtml`:
  - `Name`
  - `Email`
  - `Phone`
- Add a complex binding model[^3] as a child class and use that for model binding
- Setup a page handler for `POST` requests on the `Index` page[^6]
  - When the form is posted, it should be added to a list (just create a service[^9] and inject it in `Program.cs`[^8])

## Exercise 04-3
Set up server-side validation[^2][^7] for the fields that fulfills the following requirements:
- Field `Email` must contain a valid e-mail address
- Field `Name` must contain a string with length between two (2) and 50 characters
- Field `Phone` must contains a valid phone number

## Exercise 04-4
For each entry in the contacts list, add a link to `Details` (see the example code[^5]).

## Exercise 04-5 – Optional
Check out https://getbootstrap.com/docs/5.1/forms/input-group/ and style your form with Bootstrap[^4]


[^1]: https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-new-sdk-templates#web-options
[^2]: https://docs.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-6.0#built-in-attributes
[^3]: https://docs.microsoft.com/en-us/aspnet/core/mvc/models/model-binding?view=aspnetcore-6.0#complex-types
[^4]: https://getbootstrap.com/
[^5]: https://github.com/bvda/sw4bed-01/blob/f85ff5f935fe47be02caa9a5f940bdb9fa7a8dc2/examples/lesson-04-routing-and-model-binding/routing-and-model-binding/BlockchainExplorer/Pages/Transactions/Index.cshtml#L24
[^6]: https://github.com/bvda/sw4bed-01/blob/8f3fea24c936ecd817186fb31727b301b2be3596/examples/lesson-04-routing-and-model-binding/routing-and-model-binding/BlockchainExplorer/Pages/Transactions/Index.cshtml.cs#L38-L44
[^7]: https://github.com/bvda/sw4bed-01/blob/8f3fea24c936ecd817186fb31727b301b2be3596/examples/lesson-04-routing-and-model-binding/routing-and-model-binding/BlockchainExplorer/Pages/Transactions/Index.cshtml.cs#L53-L61
[^8]: https://github.com/bvda/sw4bed-01/blob/8f3fea24c936ecd817186fb31727b301b2be3596/examples/lesson-04-routing-and-model-binding/routing-and-model-binding/BlockchainExplorer/Services/TransactionService.cs#L10
[^9]: https://github.com/bvda/sw4bed-01/blob/8f3fea24c936ecd817186fb31727b301b2be3596/examples/lesson-04-routing-and-model-binding/routing-and-model-binding/BlockchainExplorer/Program.cs#L6

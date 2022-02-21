# Lesson 04 exercises
## ASP.NET Core routing and model binding
We are going to build a contact book

## Exercise 04-1
Setup the project and add template files.

- Create a new ASP.NET Core Web app (Razor Pages) with `dotnet new`[^1].
- Add a new folder in `Pages` called `Contact` and add a page called `Index` and a page called `Details`.
- Add a link to `Contacts` to the navigation bar (check out `/Pages/Shared/_Layout.cshtml`)

## Exercise 04-2
Next up, we are going to add a form, binding model, and a handler

- Add the following form fields to `Index.cshtml`:
  - `Name`
  - `Email`
  - `Phone`
- Add a complex binding model[^3] as a child class and use that for model binding
- Setup a page handler for `POST` requests on the `Index` page.

## Exercise 04-3
Setup server-side validation[^2] for the fields that fulfills the following requirements:
- Field `Email` must contain a valid e-mail address.
- Field `Name` must contain a string with length between two (2) and 50 characters.
- Field `Phone` must contains a valid phone number

## Exercise 04-4 – Optional
Check out https://getbootstrap.com/docs/5.1/forms/input-group/ and style your form with Bootstrap[^4]


[^1]: https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-new-sdk-templates#web-options
[^2]: https://docs.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-6.0#built-in-attributes
[^3]: https://docs.microsoft.com/en-us/aspnet/core/mvc/models/model-binding?view=aspnetcore-6.0#complex-types
[^4]: https://getbootstrap.com/
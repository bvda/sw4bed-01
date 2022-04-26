# Lesson 12 exercises
## Extending MTG Collection Central

## Exercise 12-1
### Get up and running
Open the .NET project located in `examples/lesson-12-persisting-data-with-mongo-db/mtg-collection`

1. Start the database by running `docker compose up` in the project root
2. The Docker stack contains a MongoDB[^5] running on port 27018 and Mongo Express[^6] instance running @ http://localhost:5050/. The user and password can be found in `examples/lesson-12-persisting-data-with-mongo-db/mtg-collection/docker-compose.yaml`
3. Start the application. The database should be seeded automatically when navigating opening http://localhost:5000 in a browser

## Exercise 12-2
### Filter by artist
We want to be able to explore the awesome art of the game, so we need to be able to filter based on artist

1. Add a new field to the model in `examples/lesson-12-persisting-data-with-mongo-db/mtg-collection/Pages/Index.cshtml` 
2. Update the filter in `examples/lesson-12-persisting-data-with-mongo-db/mtg-collection/Services/CardService.cs` to include artist name

## Exercise 12-3
### Add pagination to `Index`
Right now, everything is fine since we are only loading 783 cards. But there are more than 22.630 unique cards printed (in more than 49.900 variants). This would be a lot of data to handle for the browser, and does not exactly account for at great user experience, so we need to add pagination[^3]. You can find some information and inspiration[^4]

## Exercise 12-4
### Add card search to `Decks/Details`

## Exercise 12-5
### Add more cards
If you are having too good of a day, check out the set(s) Apocalyse and/or Innistrad on Scryfall[^1] (you can find more information about the model[^2] on their site)

[^1]: https://scryfall.com/docs/api/
[^2]: https://scryfall.com/docs/api/cards
[^3]: https://www.mongodb.com/docs/manual/reference/method/cursor.skip/
[^4]: https://mongodb.github.io/mongo-csharp-driver/2.15/reference/driver/crud/reading/
[^5]: https://hub.docker.com/_/mongo
[^6]: https://hub.docker.com/_/mongo-express
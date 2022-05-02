# MongoDB
#work #work/swbed #work/swbed/hand-in

## Introduction
We are creating a Web API for Hearthstone[^1] cards. The data provided comes the official API[^2] and our job is to merge data from various endpoints into a single endpoint, so we can limit the number of requests for client applications.

We will be using a MongoDB to store the data and use official MongoDB C# Driver[^3] for data access.

Before you can begin the requirements, you'll need to set up and seed the database with data from `cards.json` and `metadata.json` (see Lesson 12 example code for inspiration).

I have written some Postman test suite, so you can test your API as you implement it. Check the Postman documentation[^4] out on how to import collections.

## Requirements
### Functional requirements
- `F1` An endpoint @ `GET /cards` that returns all available card
	- `F1.1` Should have a query parameter `page` that is used for pagination
	- `F1.2` Each page should consist of at most 100 entries
	- `F1.3` Should have a query parameter `setid` that is used for filtering cards based on sets
	- `F1.4` Should have a query parameter `artist` that filters on artist name (exact)
	- `F1.5` Should have a query parameter `classid` that filters on class
- `F2` An endpoint @ `GET /sets` that returns all available sets
- `F3` An endpoint @ `GET /rarities` that returns all available rarities
- `F4` An endpoint @ `GET /classes` that returns all available classes
- `F5` An endpoint @ `GET /types` that returns all available card types

### Technical requirements
1. All configuration values should be located in `appsettings.json`
2. Each controller must use a logging provider and log each request to the console
3. All data most be persisted in a MongoDB
4. Data returned from the endpoints should map any ids to string values according to the metadata, eg. `{..., "ClassId": 14, ..., "SetId": 1127, ...}` is returned as `{..., "Class": "Demon Hunter", "Set": "The Boomsday Project"}`
5. All communication must be secure (TLS/HTTPS)
6. The MongoDB instance shall run in Docker Compose (see Lesson 12 example code for inspiration)
7. The API shall be hosted locally on port 5000

## Data model
The provided data is modelled according to the classes defined in this section. This should serve a helping hand for you when you are seeding your database with the data defined in `cards.json` and `metadata.json`.

_Hint: You will have to create response classes for some of the endpoints to fulfill the requirements_

### Card
```csharp
public class Card {
	public int Id { get; set; }
	public int ClassId { get; set; }
	public int TypeId { get; set; }
	public int SetId { get; set; }
	public int? SpellSchoolId { get; set; }
	public int RarityId { get; set; }
	public int? Health { get; set; }
	public int? Attack { get; set; }
	public int ManaCost { get; set; }
	public String Artist { get; set; }
	public String Text { get; set; }
	public String FlavorText { get; set; }
}
```

### Set
```csharp
public class Set {
	public int Id { get; set; }
	public String Name { get; set; }
	public String Type { get; set; }
	public int CardCount { get; set; }
}
```

### CardType 
```csharp
public class CardType {
	public int Id { get; set; }
	public String Name { get; set; }
}
```

### Class
```csharp
public class Class {
	public int Id { get; set; }
	public String Name { get; set; }
}
```

### Rarity
```csharp
public class Rarity {
	public int Id { get; set; }
	public String Name { get; set; }
}
```

[^1]: https://playhearthstone.com/en-gb
[^2]: https://develop.battle.net/documentation/hearthstone/game-data-apis
[^3]: https://www.nuget.org/packages/mongodb.driver
[^4]: https://learning.postman.com/docs/getting-started/importing-and-exporting-data/
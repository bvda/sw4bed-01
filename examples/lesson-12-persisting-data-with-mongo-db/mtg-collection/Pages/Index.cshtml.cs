using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using mtg_collection.Services;
using mtg_collection.Data;

namespace mtg_collection.Pages;

public class IndexModel : PageModel
{

    [BindProperty]
    public InputSearchModel SearchModel { get; set; }
    private readonly ILogger<IndexModel> _logger;
    private readonly CardService _service;

    public IList<Card> Cards { get; set; } = new List<Card>();

    public IndexModel(ILogger<IndexModel> logger, CardService service)
    {
        _logger = logger;
        _service = service;
        SearchModel = new InputSearchModel();
    }

    public async Task<IActionResult> OnGetAsync(string name, string type)
    {
        Cards = await _service.Search(name, type);
        // var client = new MongoClient("mongodb://root:example@localhost:27017");
        // var database = client.GetDatabase("mtg");
        // var collection = database.GetCollection<Card>("cards");
        // // IMongoCollection<BsonDocument> collection = ; // initialize to the collection to write to.
        // using(var file = new StreamReader("lea-p2.json")) {
        //     var cards = JsonSerializer.Deserialize<List<Card>>(file.ReadToEnd(), new JsonSerializerOptions {
        //         PropertyNameCaseInsensitive = true
        //     });
        //     collection.InsertMany(cards);
        // }
        SearchModel = new InputSearchModel {
            Name = name,
            Type = type,
        };
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(string name, string type) {
        await _service.Search(SearchModel.Name);
        return RedirectToPage("Index", new { Name = SearchModel.Name, Type = SearchModel.Type });
    }

    public class InputSearchModel {
        public string? Name { get; set; }
        public string? Type { get; set; }
    }
}

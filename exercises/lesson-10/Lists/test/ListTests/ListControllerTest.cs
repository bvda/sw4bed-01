using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

using Lists.Models;

namespace ListTests.ListController;

public class ListControllerTests
{
  private readonly HttpClient _client;

  public ListControllerTests() {
    var applicationFactory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => {});
    _client = applicationFactory.CreateClient();
  }

  [Fact]
  public async Task GetListReturnsSuccess() {
    var response = await _client.GetAsync("/list");
    response.EnsureSuccessStatusCode();
    Assert.Equal(JsonContent.Create(await response.Content.ReadAsStringAsync()).Value, "[]");
  }

  [Fact]
  public async Task GetItemAtIndexReturnsSuccess() {

    await _client.PostAsJsonAsync("/list", new { Item = "Test" });

    var response = await _client.GetAsync("/list?index=0");
    response.EnsureSuccessStatusCode();
    Assert.Equal(HttpStatusCode.OK, response.StatusCode);
  }

  [Fact]
  public async Task GetItemIndexOutOfBoundsReturnsBadRequest() {
    var response = await _client.GetAsync("/list?index=0");
     Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
  }

  [Fact]
  public async Task PostItemSuccess() {
    var body = JsonContent.Create(new { Item = "Test" });
    var response = await _client.PostAsync("/list", body);
    response.EnsureSuccessStatusCode();
    Assert.Contains(await body.ReadAsStringAsync(), await response.Content.ReadAsStringAsync());
  }

  [Fact]
  public async Task PostItemWithWrongFormatReturnsBadRequest() {
    var body = JsonContent.Create(new [] { new { Item = "Test" }});
    var response = await _client.PostAsync("/list", body);
    Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
  }
}
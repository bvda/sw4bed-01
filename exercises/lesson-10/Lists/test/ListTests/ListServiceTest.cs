using Xunit;
using System.Linq;
using System.Collections.Generic;
using Lists.Models;
using Lists.Services;

namespace ListTests.ListService;

public class ListServiceTest 
{
  [Fact]
  public void ItemInserted() 
  { 
    var service = new ListService<string>();

    string input = "Test";
    int countBeforeInsert = 0;
    int countAfterInsert = 1;

    Assert.Equal(countBeforeInsert, service.Items.Count);

    var list = service.AddItemToList(new ListItem<string> {
      Item = input
    });

    Assert.Equal(countAfterInsert, service.Items.Count);

  }

  [Fact]
  public void ItemInsertedAtTail() 
  { 
    var service = new ListService<int>();

    var input = new ListItem<int> {
      Item = 1337
    };
    var output = 1337;
    var list = service.AddItemToList(input);
    
    Assert.Equal(list.Last().Item, output);
  }

  [Theory]
  [InlineData(0, new [] {1, 2, 3}, new [] { 2, 3 })]
  [InlineData(1, new [] {1, 2, 3}, new [] { 1, 3 })]
  [InlineData(2, new [] {1, 2, 3}, new [] { 1, 2 })]
  public void ItemRemovedAtIndex(int index, int[] before, int[] after) 
  { 
    var service = new ListService<int>();
    service.Items.AddRange(before.Select(x => new ListItem<int> { Item = x}).ToList());
    var output = service.RemoveItem(index);
    var expected = after.Select(x => new ListItem<int> { Item = x}).ToList();

    foreach(var item in output.Select((item, i) => new { item, i})) {
      Assert.Equal(expected[item.i].Item, output[item.i].Item);
    } 
  }
}
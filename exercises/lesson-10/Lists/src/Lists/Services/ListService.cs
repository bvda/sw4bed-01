using Lists.Models;

namespace Lists.Services;

public class ListService<T> {

  public List<ListItem<T>> Items = new List<ListItem<T>>();

  public List<ListItem<T>> AddItemToList(ListItem<T> item) {
    // Implement
    return new List<ListItem<T>>(Items);
  }

  public List<ListItem<T>> GetItems() {
    // Implement
    return Items;
  }

  public List<ListItem<T>> RemoveItem(int index) {
    // Implement
    return new List<ListItem<T>>(Items);
  }
}
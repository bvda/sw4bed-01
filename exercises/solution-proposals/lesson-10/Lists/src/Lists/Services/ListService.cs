using Lists.Models;

namespace Lists.Services;

public class ListService<T> {

  public List<ListItem<T>> Items = new List<ListItem<T>>();

  public List<ListItem<T>> AddItemToList(ListItem<T> item) {
    Items.Add(item);
    return Items;
  }

  public List<ListItem<T>> GetItems() {
    return Items;
  }

  public List<ListItem<T>> RemoveItem(int index) {
    Items.RemoveAt(index);
    return Items;
  }
}
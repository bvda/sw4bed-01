using Microsoft.EntityFrameworkCore;

using Lesson07_ContactsAPI.Model;

namespace Lesson07_ContactsAPI.Data;

public class ContactContext : DbContext {
  public DbSet<Contact> Contacts => Set<Contact>();

  public ContactContext(DbContextOptions<ContactContext> options) : base(options) { }
}

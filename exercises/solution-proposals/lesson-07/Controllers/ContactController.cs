using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lesson07_ContactsAPI.Data;
using Lesson07_ContactsAPI.Model;

namespace Lesson07_ContactsAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ContactController : ControllerBase
{

  private readonly ContactContext _context;
  public ContactController(ContactContext context)
  {
    _context = context;
  }

  [HttpGet]
  public async Task<ActionResult<IEnumerable<Contact>>> Get() {
    return await _context.Contacts.ToListAsync();
  }

  [HttpGet("configuration")]
  public ActionResult GetConfiguration() {
    return Ok();
  }

  [HttpPost]
  public async Task<ActionResult<int>> Post([FromBody] Contact contact) {
    await _context.Contacts.AddAsync(contact);
    return await _context.SaveChangesAsync();
  }
}
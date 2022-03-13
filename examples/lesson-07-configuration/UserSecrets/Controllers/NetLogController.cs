using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserSecrets.Data;
using UserSecrets.Model;

namespace UserSecrets.Controllers;

[ApiController]
[Route("[controller]")]
public class NetLogController : ControllerBase {

  private readonly NetLogContext _context;
  public NetLogController(NetLogContext context) {
    _context = context;
  }

  [HttpPost(Name = "PostNetLog")]
  public async Task<ActionResult<NetLog>> PostNetLog() 
  {
    var log = new NetLog {
      ID = new Guid(),
      Source = "234.215.249.151",
      Destination = "186.22.155.214",
      UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US) AppleWebKit/534.19 (KHTML, like Gecko) Chrome/11.0.661.0 Safari/534.19",
      Port = 60304,
      Date = DateTime.Now
    };
    await _context.NetLogs.AddAsync(log);
    await _context.SaveChangesAsync();
    return log;
  }


  [HttpGet(Name = "GetNetLogs")]
  public async Task<ActionResult<IList<NetLog>>> GetNetLogs()
  {
    return await _context.NetLogs.ToListAsync();
  }
}
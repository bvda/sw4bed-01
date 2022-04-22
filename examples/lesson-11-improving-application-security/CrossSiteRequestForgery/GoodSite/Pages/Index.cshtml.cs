using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace GoodSite.Pages;

public class IndexModel : PageModel
{
  private readonly ILogger<IndexModel> _logger;

  public IndexModel(ILogger<IndexModel> logger)
  {
    _logger = logger;
  }

  public void OnGet()
  {
  }
  
  public IActionResult OnPost()
  {
    _logger.LogInformation("OnPost");
    return RedirectToPage("Index");
  }

  public async Task<IActionResult> OnPostSignIn()
  {
    _logger.LogInformation("OnPostSignIn");
    var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, "user.Email"),
            new Claim("FullName", "user.FullName"),
            new Claim(ClaimTypes.Role, "Administrator"),
        };

    var claimsIdentity = new ClaimsIdentity(
        claims, CookieAuthenticationDefaults.AuthenticationScheme);

    var authProperties = new AuthenticationProperties
    {
      //AllowRefresh = <bool>,
      // Refreshing the authentication session should be allowed.

      //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
      // The time at which the authentication ticket expires. A 
      // value set here overrides the ExpireTimeSpan option of 
      // CookieAuthenticationOptions set with AddCookie.
      
      //IsPersistent = true,
      // Whether the authentication session is persisted across 
      // multiple requests. When used with cookies, controls
      // whether the cookie's lifetime is absolute (matching the
      // lifetime of the authentication ticket) or session-based.

      //IssuedUtc = <DateTimeOffset>,
      // The time at which the authentication ticket was issued.

      //RedirectUri = <string>
      // The full path or absolute URI to be used as an http 
      // redirect response value.
    };

    await HttpContext.SignInAsync(
        CookieAuthenticationDefaults.AuthenticationScheme,
        new ClaimsPrincipal(claimsIdentity),
        authProperties
    );
    return RedirectToPage("Index");
  }
}

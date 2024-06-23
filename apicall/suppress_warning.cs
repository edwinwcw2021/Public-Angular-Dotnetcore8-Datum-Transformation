using Microsoft.AspNetCore.Mvc;

namespace apicall
{
  public class suppress_warning
  {
    #pragma warning disable 1998
    public async Task<IActionResult> Test()
    {
      throw new NotImplementedException();
    }
    #pragma warning restore 1998
  }
}

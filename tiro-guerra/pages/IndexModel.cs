using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

public class IndexModel : PageModel
{
    public void OnGet()
    {
    }
 
    public void OnPostSubmit()
    {
        ViewData["Message"] = "Deu erro cara";
    }
}


using Microsoft.AspNetCore.Mvc.RazorPages;

public class IndexModel : PageModel
{
    public void OnGet()
    {
    }
 
    public void OnPostSubmit(string name)
    {
        ViewData["Message"] = string.Format("Hello {0}.\\nCurrent Date and Time: {1}", name, DateTime.Now.ToString());
    }
}
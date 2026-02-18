using Microsoft.AspNetCore.Mvc;
using Project498.WebApi.Services;

namespace Project498.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class StringsController(IStringService stringService) : ControllerBase
{
    [HttpGet("reverse/{input}")]
    public IActionResult Reverse(string input)
    {
        return Ok(stringService.Reverse(input));
    }

    public static string ReverseWords(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return input; 
        // Split on spaces, remove empty entries
        string[] words = input.Split(' ',
            StringSplitOptions.RemoveEmptyEntries);
        
        // Reverse the array
        Array.Reverse(words);
        
        // Join back into a single string
        return string.Join(" ", words);
    }
}
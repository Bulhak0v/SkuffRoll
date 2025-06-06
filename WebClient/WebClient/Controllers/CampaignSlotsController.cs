using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebClient.Models;

namespace WebClient.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CampaignSlotsController : Controller
    {
        private readonly SkuffrollDbContext _context;

        public CampaignSlotsController(SkuffrollDbContext context)
        {
            _context = context;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateSlot([FromBody] JsonElement input)
        {
            string temp = input.GetRawText();

            Console.WriteLine(temp);

            return Ok();
        }
    }
}

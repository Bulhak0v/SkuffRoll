using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using WebClient.Models;
using WebClient.Models.CampaignData;

namespace WebClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignController : Controller
    {
        private readonly SkuffrollDbContext _context;

        public CampaignController(SkuffrollDbContext context)
        {
            _context = context;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCampaign([FromBody] JsonElement input)
        {
            Campaign newCampaign = new Campaign();
            CampaignDataWithLogin campaignDataWithLogin = input.Deserialize<CampaignDataWithLogin>();

            newCampaign.name = campaignDataWithLogin.name;
            newCampaign.description = "-";
            
            _context.Campaigns.Add(newCampaign);
            await _context.SaveChangesAsync();

            int userId = _context.Users.FirstOrDefault(u => u.login == campaignDataWithLogin.login).id;
            UserCampaign newUserCampaign = new UserCampaign();
            newUserCampaign.user_id = userId;
            newUserCampaign.campaign_id = newCampaign.id;

            _context.UserCampaigns.Add(newUserCampaign);
            await _context.SaveChangesAsync();

            return Ok(newCampaign.id);
        }

        [HttpDelete("delete/{name}")]
        public async Task<IActionResult> DeleteCampaign(string name)
        {
            Campaign campaign = await _context.Campaigns.FirstOrDefaultAsync(c => c.name == name);
            if (campaign == null)
            {
                return NotFound("Campaign not found");
            }

            _context.Campaigns.Remove(campaign);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}

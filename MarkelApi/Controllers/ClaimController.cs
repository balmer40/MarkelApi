using System.ComponentModel.Design;
using MarkelApi.Models;
using MarkelApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MarkelApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClaimController : ControllerBase
    {
        private readonly IClaimRepository claimRepository;

        public ClaimController(IClaimRepository claimRepository)
        {
            this.claimRepository = claimRepository;
        }

        [HttpGet]
        [Route("{ucr}")]
        public async Task<IActionResult> GetClaim(string ucr)
        {
            var claim = await this.claimRepository.GetClaim(ucr);

            return Ok(claim);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateClaim(Claim claim)
        {
            await this.claimRepository.UpdateClaim(claim);

            return Ok();
        }
    }
}


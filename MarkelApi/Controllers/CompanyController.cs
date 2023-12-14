using MarkelApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MarkelApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository companyRepository;
        private readonly IClaimRepository claimRepository;

        public CompanyController(ICompanyRepository companyRepository, IClaimRepository claimRepository)
        {
            this.companyRepository = companyRepository;
            this.claimRepository = claimRepository;
        }

        [Route("{companyId}")]
        public async Task<IActionResult> GetCompany(int companyId)
        {
            var company = await this.companyRepository.GetCompany(companyId);

            return Ok(company);
        }

        [Route("{companyId}/claims")]
        public async Task<IActionResult> GetClaims(int companyId)
        {
            var company = await this.claimRepository.GetClaims(companyId);

            return Ok(company);
        }
    }
}


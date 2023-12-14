using System;
using AutoFixture;
using FluentAssertions;
using MarkelApi.Controllers;
using MarkelApi.Models;
using MarkelApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace MarkelApi.UnitTests.Controllers
{
	public class CompanyControllerTests
	{
		private Fixture fixture;
		private int companyId; 
		private Company company;
        private List<Claim> claims;

        private Mock<ICompanyRepository> mockCompanyRepository;
        private Mock<IClaimRepository> mockClaimRepository;

		private CompanyController companyController;

		public CompanyControllerTests()
		{
			this.fixture = new Fixture();
			this.companyId = fixture.Create<int>();
			this.company = this.fixture.Create<Company>();
			this.claims = this.fixture.Create<List<Claim>>();

			this.mockCompanyRepository = new Mock<ICompanyRepository>();
			this.mockClaimRepository = new Mock<IClaimRepository>();

			this.mockCompanyRepository.Setup(cr => cr.GetCompany(this.companyId)).ReturnsAsync(this.company);
            this.mockClaimRepository.Setup(cr => cr.GetClaims(this.companyId)).ReturnsAsync(this.claims);

            this.companyController = new CompanyController(this.mockCompanyRepository.Object, this.mockClaimRepository.Object);
		}

		[Fact]
		public async Task GetCompanyReturnsExpectedCompany()
		{
			var okObjectResult = await this.companyController.GetCompany(this.companyId) as OkObjectResult;

            okObjectResult?.Value.Should().Be(this.company);
		}

        [Fact]
        public async Task GetClaimsReturnsExpectedClaims()
        {
			var okObjectResult = await this.companyController.GetClaims(this.companyId) as OkObjectResult;

            okObjectResult?.Value.Should().Be(this.claims);
        }
    }
}


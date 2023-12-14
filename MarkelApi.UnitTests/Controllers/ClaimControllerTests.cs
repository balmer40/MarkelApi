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
	public class ClaimControllerTests
	{
        private Fixture fixture;
        private string ucr;
        private Claim claim;

        private Mock<IClaimRepository> mockClaimRepository;

        private ClaimController claimController;

        public ClaimControllerTests()
        {
            this.fixture = new Fixture();
            this.ucr = fixture.Create<string>();
            this.claim = this.fixture.Create<Claim>();

            this.mockClaimRepository = new Mock<IClaimRepository>();

            this.mockClaimRepository.Setup(cr => cr.GetClaim(this.ucr)).ReturnsAsync(this.claim);

            this.claimController = new ClaimController(this.mockClaimRepository.Object);
        }

        [Fact]
        public async Task GetClaimReturnsExpectedClaim()
        {
            var okObjectResult = await this.claimController.GetClaim(this.ucr) as OkObjectResult;

            okObjectResult?.Value.Should().Be(this.claim);
        }

        [Fact]
        public async Task UpdateClaimUpdatesClaim()
        {
            await this.claimController.UpdateClaim(this.claim);

            this.mockClaimRepository.Verify(cr => cr.UpdateClaim(this.claim));
        }
    }
}


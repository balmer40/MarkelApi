using System;
using MarkelApi.Models;

namespace MarkelApi.Repositories
{
	public class StubClaimRepository : IClaimRepository
	{
        public Task<List<Claim>> GetClaims(int companyId)
        {
            return Task.FromResult(new List<Claim> { CreateClaim() });
        }

        public Task<Claim> GetClaim(string ucr)
        {
            return Task.FromResult(CreateClaim(ucr));
        }

        public Task UpdateClaim(Claim claim)
        {
            return Task.CompletedTask;
        }

        private Claim CreateClaim(string ucr = null)
        {
            return new Claim
            {
                Ucr = ucr ??  "stubUcr",
                Name = "stubName",
                ClaimDate = DateTime.Today,
                LossDate = DateTime.Today,
                AssuredName = "stubAssuredName",
                IncuredLoss = 2.2,
                Closed = false
            };
        }
    }
}


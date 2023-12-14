using System;
using MarkelApi.Models;

namespace MarkelApi.Repositories
{
	public interface IClaimRepository
	{
        Task<List<Claim>> GetClaims(int companyId);
        Task<Claim> GetClaim(string ucr);
        Task UpdateClaim(Claim claim);
    }
}


using System;
using MarkelApi.Models;

namespace MarkelApi.Repositories
{
	public class StubCompanyRepository : ICompanyRepository
	{
        public Task<Company> GetCompany(int companyId)
        {
            var company = new Company
            {
                Id = 1,
                Name = "stubName",
                Address1 = "stubAddressName1",
                Address2 = "stubAddressName2",
                Address3 = "stubAddressName3",
                Postcode = "stubPostcode",
                Country = "stubCountry",
                Active = false,
                InsuranceDateEnd = DateTime.Today
            };

            return Task.FromResult(company);
        }
    }
}


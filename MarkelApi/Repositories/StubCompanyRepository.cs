using System;
using MarkelApi.Models;

namespace MarkelApi.Repositories
{
    public class StubCompanyRepository : ICompanyRepository
    {
        public Task<Company> GetCompany(int companyId)
        {
            var company = CreateCompany(companyId);

            return Task.FromResult(company);
        }

        private Company CreateCompany(int companyId)
        {
            return new Company
            {
                Id = companyId,
                Name = "stubName",
                Address1 = "stubAddressName1",
                Address2 = "stubAddressName2",
                Address3 = "stubAddressName3",
                Postcode = "stubPostcode",
                Country = "stubCountry",
                Active = false,
                InsuranceDateEnd = DateTime.Today
            };
        }
    }
}


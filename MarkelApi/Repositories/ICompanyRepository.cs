using System;
using MarkelApi.Models;

namespace MarkelApi.Repositories
{
	public interface ICompanyRepository
	{
        Task<Company> GetCompany(int companyId);
    }
}


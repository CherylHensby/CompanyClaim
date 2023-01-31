using CompanyClaimsAPI.Models;
using Microsoft.Rest;

namespace CompanyClaimsAPI.Services.Interfaces
{
    public interface ICompanyService
    {
        /// <summary>
        /// Gets the Company of the company Id passed
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        Task<HttpOperationResponse<Company>> GetCompanyAsync(int Id);

    }
}
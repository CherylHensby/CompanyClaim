using CompanyClaimsAPI.Models;
using Microsoft.Rest;

namespace CompanyClaimsAPI.Services.Interfaces
{
    public interface ICompanyService
    {
        Task<HttpOperationResponse<Company>> GetCompanyAsync(int companyId);

    }
}
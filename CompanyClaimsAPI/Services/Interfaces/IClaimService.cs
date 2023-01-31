using CompanyClaimsAPI.Models;
using Microsoft.Rest;

namespace CompanyClaimsAPI.Services.Interfaces
{
    public interface IClaimService
    {
        Task<HttpOperationResponse<List<Claim>>> GetCompanyClaimsAsync(int companyId);
        Task<HttpOperationResponse<Claim>> GetClaimByUcr(string ucr);
        Task<HttpOperationResponse<Claim>> UpdateClaim(string ucr, Claim claim);
    }
}
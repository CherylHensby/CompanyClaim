using CompanyClaimsAPI.Models;
using Microsoft.Rest;

namespace CompanyClaimsAPI.Services.Interfaces
{
    public interface IClaimService
    {
        /// <summary>
        /// •	We need an endpoint that will give me a list of claims for one company
        /// Gets list of claims for the Company, passing the companyId
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        Task<HttpOperationResponse<List<Claim>>> GetCompanyClaimsAsync(int Id);
        /// <summary>
        /// Gets back a Claim by passing the UCR of the claim
        /// </summary>
        /// <param name="ucr"></param>
        /// <returns></returns>
        Task<HttpOperationResponse<Claim>> GetClaimByUcr(string ucr);
        /// <summary>
        /// •	We need an endpoint that will give me the details of one claim. We need a property to be returned that tells us how old the claim is in days
        /// Updates the claim passing the ucr of the claim and the claim object
        /// </summary>
        /// <param name="ucr"></param>
        /// <param name="claim"></param>
        /// <returns></returns>
        Task<HttpOperationResponse<Claim>> UpdateClaim(string ucr, Claim claim);



        Task<HttpOperationResponse<Claim>> UpdateFakeClaim(string ucr, Claim claim);
    }
}
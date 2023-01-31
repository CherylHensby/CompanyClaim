using CompanyClaimsAPI.Models;

namespace CompanyClaimsAPI.Data.Interfaces
{
    public interface IDataLayer
    {
        /// <summary>
        /// Gets a list of claims for a company
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        Task<List<Claim>>? GetCompanyClaimsAsync(int companyId);
        /// <summary>
        /// Gets all companies
        /// </summary>
        /// <returns></returns>
        Task<List<Company>>? GetFullListOfCompaniesAsync();
        /// <summary>
        /// Gets the claim of the UCR passed
        /// </summary>
        /// <param name="ucr"></param>
        /// <returns></returns>
        Task<Claim> GetClaimByUcrAsync(string ucr);
        /// <summary>
        /// Gets the full list of claims
        /// </summary>
        /// <returns></returns>
        List<Claim> GetFullClaimsList();
        /// <summary>
        /// Updates the Claim entity
        /// </summary>
        /// <param name="ucr"></param>
        /// <param name="claimToUpdate"></param>
        /// <returns></returns>
        Claim UpdateClaim(string ucr, Claim claimToUpdate);
        /// <summary>
        /// Gets all companies
        /// </summary>
        /// <returns></returns>
        List<Company> GetAllCompanies();
        /// <summary>
        /// Gets all the claims for a Company
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        List<Claim> GetAllCompanyClaims(int companyId);
        /// <summary>
        /// Saves claim changes - but this method does not save the method is not completed
        /// </summary>
        void SaveClaimChanges();
    }
}
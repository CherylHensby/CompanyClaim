using CompanyClaimsAPI.Models;

namespace CompanyClaimsAPI.Data.Interfaces
{
    public interface IDataLayer
    {
        Task<List<Claim>>? GetCompanyClaimsAsync(int companyId);
        Task<List<Company>>? GetFullListOfCompaniesAsync();
        Task<Claim> GetClaimByUcrAsync(string ucr);
        List<Claim> GetFullClaimsList();
        Claim UpdateClaim(string ucr, Claim claimToUpdate);
        void SaveChanges();
    }
}
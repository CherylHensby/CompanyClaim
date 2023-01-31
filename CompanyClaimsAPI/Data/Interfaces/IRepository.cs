using CompanyClaimsAPI.Models;

namespace CompanyClaimsAPI.Data.Interfaces
{
    public interface IRepository
    {
        IQueryable<Claim> GetAllClaims();
        Claim AddClaim(Claim claim);
    }
}

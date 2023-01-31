using CompanyClaimsAPI.Data.Interfaces;
using CompanyClaimsAPI.Models;

namespace CompanyClaimsAPI.Data
{
    public class FakeRepository : IRepository
    {
        private static IList<Claim> fakeClaims = new List<Claim> {
        new Claim{ UCR = "1234",  AssuredName = "Pilcoin Pipers", InsuredLoss = 10000, CompanyId = 1, claimType = new ClaimType(){ Id = 1, Name = Helpers.AttributeHelpers.GetEnumDescription(ClaimTypeEnum.HurricaneDamage) } },
        new Claim{ UCR = "5467",  AssuredName = "Steady Eddy", InsuredLoss = 10000, CompanyId = 1, claimType = new ClaimType(){ Id = 1, Name = Helpers.AttributeHelpers.GetEnumDescription(ClaimTypeEnum.HurricaneDamage) } },
        new Claim{ UCR = "2876",  AssuredName = "Roaming Rolland", InsuredLoss = 10000, CompanyId = 1, claimType = new ClaimType(){ Id = 1, Name = Helpers.AttributeHelpers.GetEnumDescription(ClaimTypeEnum.HurricaneDamage) } },
     };

        public Claim AddClaim(Claim claim)
        {
            fakeClaims.Add(claim);
            return claim;
        }

        public IQueryable<Claim> GetAllClaims()
        {
            return fakeClaims.AsQueryable();
        }
    }
}

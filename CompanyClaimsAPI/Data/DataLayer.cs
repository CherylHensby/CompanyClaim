using CompanyClaimsAPI.Data.Interfaces;
using CompanyClaimsAPI.Models;

namespace CompanyClaimsAPI.Data
{
    /// <summary>
    /// This is a mocked data of a datalayer, mimicing repository for database 
    /// </summary>
    public class DataLayer : IDataLayer
    {

        public  Task<List<Company>>? GetFullListOfCompaniesAsync()
        {
            List<Company> companyList = GetAllCompanies();
            return Task.FromResult(companyList);
        }

        public List<Claim> GetAllCompanyClaims(int companyId)
        {
            List<Claim> claims = GetFullClaimsList().Where(cl => cl.CompanyId == companyId).ToList();
            return claims;
        }

        public List<Company> GetAllCompanies()
        {
            List<Company> companies= new List<Company>();
            DateTime fistCdt = DateTime.ParseExact("11/06/2024 10:00:00", "dd/MM/yyyy HH:mm:ss", null);
            Company company1 = new Company()
            {
                Id = 1,
                Active = true,
                Address1 = "900 Oxford Road",
                Address2 = "Skipton",
                Address3 = "Norfolk",
                Country = "UK",
                InsuranceEndDate = fistCdt,
                PostCode = "NR3 987",
                Name = "Romance Plumbers",
                Claims = GetAllCompanyClaims(1),
            };
            DateTime fistCdt2 = DateTime.ParseExact("31/01/2024 10:00:00", "dd/MM/yyyy HH:mm:ss", null);
            Company company2 = new Company()
            {
                Id = 2,
                Active = true,
                Address1 = "102 Station Road",
                Address2 = "Rayleigh",
                Address3 = "Essex",
                Country = "UK",
                InsuranceEndDate = fistCdt2,
                PostCode = "DA44 987",
                Name = "Spar Electrical",
                Claims = GetAllCompanyClaims(2),
            };
            companies.Add(company1);
            companies.Add(company2);
            return companies;
        }

        public Task<List<Claim>>? GetCompanyClaimsAsync(int companyId)
        {
            List<Claim> claims = GetFullClaimsList().Where(cl=>cl.CompanyId == companyId).ToList();
            return Task.FromResult(claims);
        }

        public Task<Claim> GetClaimByUcrAsync(string ucr)
        {
            List<Claim> claimyList = GetFullClaimsList();
            if(claimyList.Where(c => c.UCR == ucr).Any())
            {
                var claim = claimyList.Where(c => c.UCR == ucr).First();
                return Task.FromResult(claim);
            }
              
            return Task.FromResult<Claim>(null);
        }

        public List<Claim> GetFullClaimsList()
        {
            List<Claim> claimyList = new List<Claim>();
            DateTime fistCdt = DateTime.ParseExact("11/10/2022 10:00:00", "dd/MM/yyyy HH:mm:ss", null);
            Claim firstClaim = new Claim()
            {
                AssuredName = "Mr Gunner",
                ClaimDate = fistCdt,
                CompanyId = 1,
                InsuredLoss = 10000,
                LossDate = fistCdt,
                UCR = "394585t8",
                claimType = new ClaimType() { Id = Convert.ToInt32(ClaimTypeEnum.AccidentalDamage), Name = Helpers.AttributeHelpers.GetEnumDescription(ClaimTypeEnum.AccidentalDamage) },
                Closed = false
            };

            DateTime secondCdt = DateTime.ParseExact("31/01/2022 10:00:00", "dd/MM/yyyy HH:mm:ss", null);
            Claim secondClaim = new Claim()
            {
                AssuredName = "Mr Runner",
                ClaimDate = secondCdt,
                CompanyId = 2,
                InsuredLoss = 0,
                LossDate = secondCdt,
                UCR = "74757576",
                claimType = new ClaimType() { Id = Convert.ToInt32(ClaimTypeEnum.HurricaneDamage), Name = Helpers.AttributeHelpers.GetEnumDescription(ClaimTypeEnum.HurricaneDamage) },
                Closed = false
            };
            DateTime thirdCdt = DateTime.ParseExact("26/04/2022 10:00:00", "dd/MM/yyyy HH:mm:ss", null);
            Claim thirdClaim = new Claim()
            {
                AssuredName = "Mr Runner",
                ClaimDate = thirdCdt,
                CompanyId = 2,
                InsuredLoss = 0,
                LossDate = thirdCdt,
                UCR = "9d8e8e87e",
                claimType = new ClaimType() { Id = Convert.ToInt32(ClaimTypeEnum.FloodDamage), Name = Helpers.AttributeHelpers.GetEnumDescription(ClaimTypeEnum.FloodDamage) },
                Closed = true
            };
            claimyList.Add(firstClaim);
            claimyList.Add(secondClaim);
            claimyList.Add(thirdClaim);
            return claimyList;
        }

        public Claim UpdateClaim(string ucr, Claim claimToUpdate)
        {
            SaveClaimChanges();
            return claimToUpdate;
        }

        public void SaveClaimChanges()
        {
            //throw new NotImplementedException();
        }
    }
}

using CompanyClaimsAPI.Data.Interfaces;
using CompanyClaimsAPI.Models;
using CompanyClaimsAPI.Services.Interfaces;
using Microsoft.Rest;
using System.Net;

namespace CompanyClaimsAPI.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IDataLayer _dataLayer;
        public CompanyService(IDataLayer dataLayer) {
            _dataLayer = dataLayer;
        }

        public async Task<HttpOperationResponse<Company>> GetCompanyAsync(int companyId)
        {
            try
            {
                List<Company> companies = await _dataLayer.GetFullListOfCompaniesAsync();
                if (companies.Any())
                {
                    var company = companies.Where(c => c.Id == companyId).FirstOrDefault();
                    if (company != null && company.Id > 0)
                    {
                        return new HttpOperationResponse<Company>()
                        {
                            Body = company,
                            Response = new HttpResponseMessage(HttpStatusCode.OK)
                        };
                    }
                    else
                    {
                        return new HttpOperationResponse<Company>()
                        {
                            Body = null,
                            Response = new HttpResponseMessage(HttpStatusCode.NotFound)
                        };
                    }
                }
                else
                {
                    return new HttpOperationResponse<Company>()
                    {
                        Body = null,
                        Response = new HttpResponseMessage(HttpStatusCode.NotFound)
                    };
                }
            }
            catch (Exception)
            {

                return new HttpOperationResponse<Company>()
                {
                    Body = null,
                    Response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                };
            }

        }
    }
}

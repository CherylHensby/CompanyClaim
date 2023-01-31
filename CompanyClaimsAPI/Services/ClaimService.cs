using CompanyClaimsAPI.Data.Interfaces;
using CompanyClaimsAPI.Models;
using CompanyClaimsAPI.Services.Interfaces;
using Microsoft.Rest;
using System.Net;

namespace CompanyClaimsAPI.Services
{
    public class ClaimService : IClaimService
    {
        private readonly IDataLayer _dataLayer;
        public ClaimService(IDataLayer dataLayer) {
            _dataLayer = dataLayer;
        }

        public async Task<HttpOperationResponse<Claim>> GetClaimByUcr(string ucr)
        {
            try
            {
                var claim = await _dataLayer.GetClaimByUcrAsync(ucr);
                if (claim != null)
                {
                    return new HttpOperationResponse<Claim>()
                    {
                        Body = claim,
                        Response = new HttpResponseMessage(HttpStatusCode.OK)
                    };
                }

                else
                {
                    return new HttpOperationResponse<Claim>()
                    {
                        Body = null,
                        Response = new HttpResponseMessage(HttpStatusCode.NotFound)
                    };
                }
            }
            catch (Exception)
            {
                return new HttpOperationResponse<Claim>()
                {
                    Body = null,
                    Response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                };
            }
          
        }

        public async Task<HttpOperationResponse<List<Claim>>> GetCompanyClaimsAsync(int companyId)
        {
            try
            {
                var claims = await _dataLayer.GetCompanyClaimsAsync(companyId);
                if (claims != null && claims.Count > 0)
                {
                    return new HttpOperationResponse<List<Claim>>()
                    {
                        Body = claims,
                        Response = new HttpResponseMessage(HttpStatusCode.OK)
                    };
                }

                else
                {
                    return new HttpOperationResponse<List<Claim>>()
                    {
                        Body = null,
                        Response = new HttpResponseMessage(HttpStatusCode.NotFound)
                    };
                }
            }
            catch (Exception)
            {
                return new HttpOperationResponse<List<Claim>>()
                {
                    Body = null,
                    Response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                };
            }
          
        }

        public async Task<HttpOperationResponse<Claim>> UpdateClaim(string ucr, Claim claim)
        {
            try
            {
                var claimToUpdate = await _dataLayer.GetClaimByUcrAsync(ucr);
                if (claimToUpdate != null && claimToUpdate.UCR != null)
                {
                    var updatedClaim = _dataLayer.UpdateClaim(claimToUpdate.UCR, claim);
                    if (updatedClaim != null && updatedClaim.UCR != null)
                    {
                        return new HttpOperationResponse<Claim>()
                        {
                            Body = updatedClaim,
                            Response = new HttpResponseMessage(HttpStatusCode.OK)
                        };
                    }
                    else
                    {
                        return new HttpOperationResponse<Claim>()
                        {
                            Body = null,
                            Response = new HttpResponseMessage(HttpStatusCode.NotModified)
                        };
                    }
                }
                else
                {
                    return new HttpOperationResponse<Claim>()
                    {
                        Body = null,
                        Response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                    };
                }

            }
            catch (Exception)
            {
                return new HttpOperationResponse<Claim>()
                {
                    Body = null,
                    Response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                };
            }

        }
    }
}

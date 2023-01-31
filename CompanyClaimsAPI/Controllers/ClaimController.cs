using CompanyClaimsAPI.Data;
using CompanyClaimsAPI.Data.Interfaces;
using CompanyClaimsAPI.Models;
using CompanyClaimsAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace CompanyClaimsAPI.Controllers
{
    [Route("api/[controller]")]
    public class ClaimController : ControllerBase
    {

        [HttpGet("Get Company Claims")]
        [SwaggerOperation(Summary = "Get Company Claims")]
        [SwaggerResponse((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> CompanyClaimsAsync(int companyId)
        {

            IDataLayer _dataLayer = new DataLayer();
            ClaimService claimService = new ClaimService(_dataLayer);
            var claim = await claimService.GetCompanyClaimsAsync(companyId);
            if (claim.Response.IsSuccessStatusCode && (int)claim.Response.StatusCode == 200)//REQUEST SUCCESSFUL, CONTENT BACK
                return Ok(claim.Body);
            else if (claim.Response.StatusCode == HttpStatusCode.NotFound)
            {
                return NoContent();
            }
            else
            {

                var responseContent = await claim.Response.Content.ReadAsStringAsync();

                throw (claim.Response.StatusCode == HttpStatusCode.BadRequest)
                    ? new ValidationException(responseContent)
                    : new Exception(responseContent);
            }
        }

        [HttpGet("Get Claim By UCR")]
        [SwaggerOperation(Summary = "Get Company Claim By UCR")]
        [SwaggerResponse((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> GetClaimByUCR(string ucr)
        {

            IDataLayer _dataLayer = new DataLayer();
            ClaimService claimService = new ClaimService(_dataLayer);
            var claim = await claimService.GetClaimByUcr(ucr);
            if (claim.Response.IsSuccessStatusCode && (int)claim.Response.StatusCode == 200)//REQUEST SUCCESSFUL, CONTENT BACK
                return Ok(claim.Body);
            else if (claim.Response.StatusCode == HttpStatusCode.NotFound)
            {
                return NoContent();
            }
            else
            {

                var responseContent = await claim.Response.Content.ReadAsStringAsync();

                throw (claim.Response.StatusCode == HttpStatusCode.BadRequest)
                    ? new ValidationException(responseContent)
                    : new Exception(responseContent);
            }
        }


        [HttpPut("{UCR}")]
        public async Task<IActionResult> UpdateClaim(string ucr, [FromBody] Claim claim)
        {
            IDataLayer _dataLayer = new DataLayer();
            ClaimService claimService = new ClaimService(_dataLayer);
            var _claim = await claimService.GetClaimByUcr(ucr);
            if(_claim.Response.IsSuccessStatusCode)
            {
               _claim.Body = MapClaimModel(claim, _claim);
            }
            var updatedClaim = await claimService.UpdateClaim(ucr, _claim.Body);
            if (updatedClaim.Response.IsSuccessStatusCode && (int)updatedClaim.Response.StatusCode == 204)//UPDATE SUCCEEDED 
                return Ok(updatedClaim.Body);
            else if (updatedClaim.Response.StatusCode == HttpStatusCode.NoContent)
            {
                return NoContent();
            }
            else
            {

                var responseContent = await updatedClaim.Response.Content.ReadAsStringAsync();

                throw (updatedClaim.Response.StatusCode == HttpStatusCode.BadRequest)
                    ? new ValidationException(responseContent)
                    : new Exception(responseContent);
            }
        }

        private static Claim MapClaimModel(Claim claim, Microsoft.Rest.HttpOperationResponse<Claim> _claim)
        {
            _claim.Body.AssuredName = claim.AssuredName;
            _claim.Body.claimType = claim.claimType;
            _claim.Body.ClaimDate = claim.ClaimDate;
            _claim.Body.UCR = claim.UCR;
            return _claim.Body;
        }
    }
}

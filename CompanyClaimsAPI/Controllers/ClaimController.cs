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
        /// <summary>
        /// •	We need an endpoint that will give me a list of claims for one company
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
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

        /// <summary>
        /// •	We need an endpoint that will give me the details of one claim. We need a property to be returned that tells us how old the claim is in days
        /// </summary>
        /// <param name="ucr"></param>
        /// <returns></returns>
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


        /// <summary>
        /// •	We need an endpoint that will allow us to update a claim
        /// </summary>
        /// <param name="ucr"></param>
        /// <param name="claim"></param>
        /// <returns></returns>
        [HttpPut("{UCR}")]
        public async Task<IActionResult> UpdateClaim(string ucr, [FromBody] Claim claim)
        {
            IDataLayer _dataLayer = new DataLayer();
            ClaimService claimService = new ClaimService(_dataLayer);
            var updatedClaim = await claimService.UpdateClaim(ucr, claim);
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


        /// <summary>
        /// •	We need an endpoint that will allow us to update a claim
        /// </summary>
        /// <param name="ucr"></param>
        /// <param name="claim"></param>
        /// <returns></returns>
        [HttpPut("{UCR} Update Fake Claim Repository")]
        public async Task<IActionResult> UpdateFakeRepositoryClaim(string ucr, [FromBody] Claim claim)
        {

            IDataLayer _dataLayer = new DataLayer();
            ClaimService claimService = new ClaimService(_dataLayer);
            var updatedClaim = await claimService.UpdateFakeClaim(ucr, claim);
            if (updatedClaim.Response.IsSuccessStatusCode && (int)updatedClaim.Response.StatusCode == 200)//UPDATE SUCCEEDED 
                return Ok(updatedClaim.Body);
            else if (updatedClaim.Response.StatusCode == HttpStatusCode.OK)
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
    }
}

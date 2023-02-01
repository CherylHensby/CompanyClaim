using CompanyClaimsAPI.Data;
using CompanyClaimsAPI.Data.Interfaces;
using CompanyClaimsAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace CompanyClaimsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        //ToDO: Fix problem with not being able to inject datalayer or companyservice interfaces into constructor of controller, as added them to services in startup! No time to sort, but must!
        public CompanyController() { }

        [HttpGet("Is Company Active")]
        [SwaggerOperation(Summary = "Is Company Active")]
        [SwaggerResponse((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> IsCompanyActive(int companyId)
        {
            IDataLayer _dataLayer = new DataLayer();
            CompanyService companyService = new CompanyService(_dataLayer);
           var company = await companyService.GetCompanyAsync(companyId);
           if (company.Response.IsSuccessStatusCode && (int)company.Response.StatusCode == 200)
                return Ok(company.Body);
            else if (company.Response.StatusCode == HttpStatusCode.NotFound)
            {
                return NoContent();
            }
            else
            {
                var responseContent = await company.Response.Content.ReadAsStringAsync();

                throw (company.Response.StatusCode == HttpStatusCode.BadRequest)
                    ? new ValidationException(responseContent)
                    : new Exception(responseContent);
            }
        }

        /// <summary>
        /// •	We need an endpoint that will give me a single company. We need a property to be returned that will tell us if the company has an active insurance policy
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [HttpGet("Get Company by ID")]
        [SwaggerOperation(Summary = "Get Company by ID")]
        [SwaggerResponse((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> GetCompany(int companyId)
        {
            IDataLayer _dataLayer = new DataLayer();
            CompanyService companyService = new CompanyService(_dataLayer);
            var company = await companyService.GetCompanyAsync(companyId);
            if (company.Response.IsSuccessStatusCode && (int)company.Response.StatusCode == 200)
                return Ok(company.Body);
            else if (company.Response.StatusCode == HttpStatusCode.NotFound)
            {
                return NoContent();
            }
            else
            {
                var responseContent = await company.Response.Content.ReadAsStringAsync();
                throw (company.Response.StatusCode == HttpStatusCode.BadRequest)
                    ? new ValidationException(responseContent)
                    : new Exception(responseContent);
            }
        }
    }
}

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CompanyClaimsAPI.Models
{
    public class Company
    {
        public int Id { get; set; }
        [StringLength(200, ErrorMessage = "Description Max Length is 200")]
        public string? Name { get; set; }
        [StringLength(100, ErrorMessage = "Description Max Length is 100")]
        public string? Address1 { get; set; }
        [StringLength(100, ErrorMessage = "Description Max Length is 100")]
        public string? Address2 { get; set; }
        [StringLength(100, ErrorMessage = "Description Max Length is 100")]
        public string? Address3 { get; set; }
        [StringLength(20, ErrorMessage = "Description Max Length is 20")]
        public string? PostCode { get; set; }
        [StringLength(50, ErrorMessage = "Description Max Length is 50")]
        public string? Country { get; set; }
        public bool Active { get; set; }
        [Description("Insurance End Date")]
        public DateTime? InsuranceEndDate { get; set; }
        public List<Claim>? Claims { get; set; }
        private bool _hasActivePolicy;

        [Description("Has Active Policy?")]
        public bool HasActivePolicy
        {
            get
            {
                if (_hasActivePolicy == false)
                {
                    _hasActivePolicy = AreActivePolicies();
                }
                return _hasActivePolicy;
            }
        }

        private bool AreActivePolicies()
        {
            if(Claims != null)
            {
                if (Claims.Any() && Claims.Any(cl => cl.Closed == false))
                    return true;
                return false;
            }
            return false;
        }

    }
}

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CompanyClaimsAPI.Models
{
    public class Claim
    {
        [Description("Unique Reference Identifier")]
        [StringLength(20, ErrorMessage = "Description Max Length is 20")]
        public string? UCR { get; set; }
        //public Company Company { get; set; }
        public int CompanyId { get; set; }
        [Description("Claim Date")]
        public DateTime? ClaimDate { get; set; }
        [Description("Loss Date")]

        private int _totalDays;
        [Description("Days Since Claim Date")]
        public int TotalDaysSinceClaim
        {
            get
            {
                if (_totalDays == 0)
                {
                    _totalDays = AgeOfClaimInDays(); 
                }
                return _totalDays;
            }
        }

        private int AgeOfClaimInDays()
        {
            if(ClaimDate != null)
            {
                DateTime today = DateTime.Now;
                var diffOfDates = today.Subtract((DateTime)ClaimDate);
                return diffOfDates.Days;
            }
            else { return 0; }
     

        }
        public DateTime? LossDate { get; set; }

        [Description("Assured Name")]
        [StringLength(100, ErrorMessage = "Description Max Length is 100")]
        public string? AssuredName { get; set; }
        [Description("Insured Loss")]
        public float InsuredLoss { get; set;}
        public ClaimType? claimType { get; set; }

        [Description("Claim Closed")]
        public bool Closed { get; set; }
    }
}

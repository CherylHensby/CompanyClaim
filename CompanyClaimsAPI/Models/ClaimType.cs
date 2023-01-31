using System.ComponentModel.DataAnnotations;

namespace CompanyClaimsAPI.Models
{
    public class ClaimType
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Description Max Length is 20")]
        public string? Name { get; set; }
    }
}

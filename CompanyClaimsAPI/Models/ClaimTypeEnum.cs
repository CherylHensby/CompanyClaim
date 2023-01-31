using System.ComponentModel;

namespace CompanyClaimsAPI.Models
{
    public enum ClaimTypeEnum
    {
        [Description("Accidental Damage")]
        AccidentalDamage,
        [Description("Property Damage")]
        PropertyDamage,
        [Description("Flood Damage")]
        FloodDamage,
        [Description("Hurricane Damage")]
        HurricaneDamage

    }
}

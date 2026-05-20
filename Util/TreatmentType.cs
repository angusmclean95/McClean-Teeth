using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace McClean_Teeth.Util
{
    public enum TreatmentType
    {
        [Description("Checkup")]
        Checkup,

        [Description("Hygiene")]
        Hygiene,

        [Description("Filling")]
        Filling,

        [Description("Tooth Extraction")]
        Tooth_Extraction,

        [Description("Teeth Whitening")]
        Teeth_Whitening,

        [Description("Veneers")]
        Veneers,

        [Description("Composite Bonding")]
        Composite_Bonding,

        [Description("Emergency")]
        Emergency
    }

    public static class TreatmentTypeUtil
    {
        public static string GetDisplayName(
            TreatmentType treatment
        )
        {
            var field = treatment
                .GetType()
                .GetField(treatment.ToString());

            var attribute = (DescriptionAttribute)
                Attribute.GetCustomAttribute(
                    field,
                    typeof(DescriptionAttribute)
                );

            return attribute != null
                ? attribute.Description
                : treatment.ToString();
        }

        public static List<string> GetAllDisplayNames()
        {
            return Enum
                .GetValues(typeof(TreatmentType))
                .Cast<TreatmentType>()
                .Select(GetDisplayName)
                .ToList();
        }
    }
}
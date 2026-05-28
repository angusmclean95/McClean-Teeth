using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

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
        public static string GetDisplayName(TreatmentType treatment)
        {
            FieldInfo field = treatment
                .GetType()
                .GetField(treatment.ToString());

            DescriptionAttribute attribute = (DescriptionAttribute) Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));

            return attribute != null ? attribute.Description : treatment.ToString();
        }

        public static TreatmentType FromUppercase(string uppercased)
        {
            foreach (TreatmentType treatment in Enum.GetValues(typeof(TreatmentType)))
            {
                if (treatment.ToString().ToUpper() == uppercased)
                {
                    return treatment;
                }
            }
            throw new ArgumentException($"No TreatmentType with uppercase name '{uppercased}' found.");
        }

        public static TreatmentType FromDisplayName(string displayName)
        {
            foreach (TreatmentType treatment in Enum.GetValues(typeof(TreatmentType)))
            {
                if (GetDisplayName(treatment) == displayName)
                {
                    return treatment;
                }
            }
            throw new ArgumentException($"No TreatmentType with display name '{displayName}' found.");
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
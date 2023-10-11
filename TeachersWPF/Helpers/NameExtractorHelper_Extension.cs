using System;
using System.Linq;

namespace TeachersWPF.Helpers
{
    internal static class NameExtractorHelper_Extension
    {
        public static string GetShortName(this string inputString)
        {
            if (string.IsNullOrWhiteSpace(inputString))
            {
                return string.Empty;
            }
            string[] result = inputString.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            switch (result.Length)
            {
                case 1:
                    return result[0];
                case 2:
                    return string.Format("{1} {0}.", result[0], result[1].FirstOrDefault());
                default:
                    return string.Format("{1} {0}. {2}", result[0], result[1].FirstOrDefault(), result[2]);

            }
        }
    }
}

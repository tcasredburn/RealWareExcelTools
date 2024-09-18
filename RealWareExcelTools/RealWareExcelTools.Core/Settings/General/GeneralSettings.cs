using System;

namespace RealWareExcelTools.Core.Settings.General
{
    public class GeneralSettings
    {
        /// <summary>
        /// Current Year or Custom.
        /// </summary>
        public string DefaultTaxYearType { get; set; } = "Current Year";

        /// <summary>
        /// Custom value if DefaultTaxYearType is set to Custom.
        /// </summary>
        public string DefaultTaxYearValue { get; set; }

        /// <summary>
        /// Returns the tax year based on the DefaultTaxYearType and DefaultTaxYearValue.
        /// </summary>
        /// <returns></returns>
        public string GetTaxYear()
        {
            if (DefaultTaxYearType == "Current Year")
            {
                return DateTime.Now.Year.ToString();
            }
            else
            {
                return DefaultTaxYearValue;
            }
        }
    }
}
